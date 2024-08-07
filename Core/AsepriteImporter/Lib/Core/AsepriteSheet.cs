using System;
using System.Collections;
using System.Collections.Generic;

namespace Varollo.AsepriteImporter
{
    public class AsepriteSheet : IEnumerable<AsepriteFrame>
    {
        private readonly Dictionary<string, List<AsepriteFrame>> _frameNameMap;
        private readonly AsepriteFrame[] _frames;

        internal AsepriteSheet(AsepriteFrame[] frames, MetaData? metaData = null)
        {
            MetaData = metaData;
            FrameCount = frames.Length;

            _frames = frames;
            _frameNameMap = new();

            if (metaData?.Tags != null)
                InitializeMapByTagData(frames, metaData.Value.Tags);
            else
                InitializeMapByFrameName(frames);
        }

        public AsepriteFrame this[int index] => _frames[(index %= FrameCount) < 0 ? -index : index];
        public IEnumerable<AsepriteFrame> this[string name] => _frameNameMap[name];

        public MetaData? MetaData { get; }
        public int FrameCount { get; }

        public bool HasAnimation(string name)
        {
            return _frameNameMap.ContainsKey(name);
        }

        private void InitializeMapByFrameName(AsepriteFrame[] frames)
        {
            int frameCount = frames.Length;
            for (int i = 0; i < frameCount; i++)
            {
                AsepriteFrame frame = frames[i];
                AsignFrameToTag(frame, frame.Name);
            }
        }

        private void InitializeMapByTagData(AsepriteFrame[] frames, TagData[] tags)
        {
            if (tags == null || tags.Length == 0)
                InitializeMapByFrameName(frames);

            List<AsepriteFrame> frameList = new(frames);

            while (frameList.Count > 0)
                foreach (var tag in tags)
                {
                    int maxIndex = Math.Abs(tag.To - tag.From);
                    int frameCount = maxIndex + 1;

                    int loopFrameCount = frameCount;
                    if (tag.Direction is AnimationDirection.PingPong or AnimationDirection.PingPongReverse)
                        loopFrameCount *= 2;

                    for (int i = 0; i < loopFrameCount; i++)
                    {
                        int frameIndex = ProcessFrameIndex(tag.Direction, i, maxIndex);
                        AsepriteFrame frame = frameList[frameIndex];
                        AsignFrameToTag(frame, frame.Name);
                    }

                    frameList.RemoveRange(0, frameCount);
                }
        }

        private void AsignFrameToTag(AsepriteFrame frame, string tagName)
        {
            if (_frameNameMap.TryGetValue(tagName, out var list))
                list.Add(frame);
            else
                _frameNameMap.Add(tagName, new() { frame });
        }

        public IEnumerator<AsepriteFrame> GetEnumerator() => ((IEnumerable<AsepriteFrame>)_frames).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _frames.GetEnumerator();

        private static int ProcessFrameIndex(AnimationDirection direction, int index, int maxIndex)
        {
            return direction switch
            {
                AnimationDirection.Forward => index,
                AnimationDirection.Reverse => maxIndex - index,
                AnimationDirection.PingPong => Oscillate(maxIndex, index),
                AnimationDirection.PingPongReverse => maxIndex - Oscillate(maxIndex, index),
                _ => index,
            };
        }

        private static int Oscillate(int max, int k) => Math.Abs((k + max) % (2 * max) - max);

    }
}
