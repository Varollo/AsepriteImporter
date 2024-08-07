using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Varollo.AsepriteImporter.Data;

namespace Varollo.AsepriteImporter
{
    public class AsepriteSheet
    {
        private Dictionary<string, List<AsepriteFrame>> _frameNameMap = null;

        private int? _frameCount = null;

        public AsepriteFrame this[int index] => Frames[(index %= FrameCount) < 0 ? -index : index];
        public IEnumerable<AsepriteFrame> this[string name] => FrameNameMap[name];

        [JsonProperty("frames", NullValueHandling = NullValueHandling.Ignore)]
        public AsepriteFrame[] Frames { get; internal set; }

        public MetaData? MetaData { get; internal set; }
        public int FrameCount => _frameCount ??= Frames.Length;

        private Dictionary<string, List<AsepriteFrame>> FrameNameMap => _frameNameMap ??= InitializeMap();

        public bool HasAnimation(string name)
        {
            return FrameNameMap.ContainsKey(name);
        }

        private Dictionary<string, List<AsepriteFrame>> InitializeMap()
        {
            _frameNameMap = new();

            if (MetaData?.Tags != null)
                InitializeMapByTagData(Frames, MetaData.Value.Tags);
            else
                InitializeMapByFrameName(Frames);

            return _frameNameMap;
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
                    int maxIndex = Math.Abs(tag.To.Value - tag.From.Value);
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
            if (FrameNameMap.TryGetValue(tagName, out var list))
                list.Add(frame);
            else
                FrameNameMap.Add(tagName, new() { frame });
        }

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
