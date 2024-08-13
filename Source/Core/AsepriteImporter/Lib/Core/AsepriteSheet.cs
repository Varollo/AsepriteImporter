using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Varollo.AsepriteImporter.MetaData;

namespace Varollo.AsepriteImporter
{
    /// <summary>
    /// Object representing a <i>Aseprite sprite sheet</i> data.
    /// </summary>
    public class AsepriteSheet
    {
        private Dictionary<string, List<AsepriteFrame>> _frameNameMap = null;

        private int? _frameCount = null;

        /// <summary>
        /// Retrieves a <i>frame</i> in the <b>sheet</b> by it's "<paramref name="index"/>".
        /// <br/><i>Out of bounds</i> "<paramref name="index"/>" values are wrapped back to <c>0</c>.
        /// </summary>
        /// <param name="index"> Order, starting from <c>0</c>, which the <i>frame</i> appears in the <b>sheet</b>. </param>
        /// <returns><i>Frame at position "<paramref name="index"/>"</i></returns>
        public AsepriteFrame this[int index] => Frames[(index %= FrameCount) < 0 ? -index : index];

        /// <summary>
        /// Retrieves a <i>frame array</i> containing any frames with the <see cref="AsepriteFrame.Name"/> of "<paramref name="name"/>" in the <b>sheet.</b>
        /// <br/><i>Invalid</i> "<paramref name="name"/>" values result in an empty array.
        /// </summary>
        /// <param name="name"> String corresponding to one or more <i>frame</i>'s <see cref="AsepriteFrame.Name"/>. </param>
        /// <returns> All <i>frames</i> with <see cref="AsepriteFrame.Name"/> of "<paramref name="name"/>"</returns>
        public IEnumerable<AsepriteFrame> this[string name]
        {
            get
            {
                if (FrameNameMap.TryGetValue(name, out var frame))
                    return frame;
                else
                    return Array.Empty<AsepriteFrame>();
            }
        }

        /// <summary>
        /// Array containing all <b>frames</b> in the <i>sprite sheet.</i>
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L1">frames</see>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L1"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        [JsonProperty("frames", NullValueHandling = NullValueHandling.Ignore)]
        public AsepriteFrame[] Frames { get; internal set; }

        /// <summary>
        /// (optional) <b>Meta data</b> about the <i>sprite sheet.</i>
        /// <br/><br/>
        /// Represents property
        /// "<see href="https://gist.github.com/dacap/a32adb9248320326733a#file-file-json-L30">meta</see>"
        /// on frame's JSON data.
        /// </summary>
        /// <seealso href="https://gist.github.com/dacap/db18e5747a4b6e208d3c#file-file-json-L27"/>
        /// <seealso href="https://www.aseprite.org/docs/cli/#data"/>
        public AsepriteMetaData? MetaData { get; internal set; }

        /// <summary>
        /// <b>Amount</b> of <i>frames</i> in the <i>sprite sheet.</i>
        /// </summary>
        public int FrameCount => _frameCount ??= Frames.Length;

        private Dictionary<string, List<AsepriteFrame>> FrameNameMap => _frameNameMap ??= InitializeMap();

        /// <summary>
        /// Checks whether or not an <i>animation</i>, represented by a <paramref name="name"/>, is present in the <i>sprite sheet.</i>
        /// </summary>
        /// <param name="name">Key <paramref name="name"/> of the <i>animation</i>, corresponding to <see cref="MetaData.AsepriteTagData.Name"/>, or <see cref="AsepriteFrame.Name"/></param>.
        /// <returns><c>true</c> when <i>animation is present</i>, <c>false</c> when it isn't.</returns>
        public bool HasAnimation(string name)
        {
            return FrameNameMap.ContainsKey(name);
        }

        private Dictionary<string, List<AsepriteFrame>> InitializeMap()
        {
            _frameNameMap = new Dictionary<string, List<AsepriteFrame>>();

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

        private void InitializeMapByTagData(AsepriteFrame[] frames, AsepriteTagData[] tags)
        {
            if (tags == null || tags.Length == 0)
                InitializeMapByFrameName(frames);

            var frameList = new List<AsepriteFrame>(frames);

            while (frameList.Count > 0)
                foreach (var tag in tags)
                {
                    int maxIndex = Math.Abs(tag.To.Value - tag.From.Value);
                    int frameCount = maxIndex + 1;

                    int loopFrameCount = frameCount;

                    if (tag.Direction == AsepriteAnimationDirection.PingPong
                    || (tag.Direction == AsepriteAnimationDirection.PingPongReverse))
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
                FrameNameMap.Add(tagName, new List<AsepriteFrame>() { frame });
        }

        private static int ProcessFrameIndex(AsepriteAnimationDirection direction, int index, int maxIndex)
        {
            return direction switch
            {
                AsepriteAnimationDirection.Forward => index,
                AsepriteAnimationDirection.Reverse => maxIndex - index,
                AsepriteAnimationDirection.PingPong => Oscillate(maxIndex, index),
                AsepriteAnimationDirection.PingPongReverse => maxIndex - Oscillate(maxIndex, index),
                _ => index,
            };
        }

        private static int Oscillate(int max, int k) => Math.Abs((k + max) % (2 * max) - max);

    }
}
