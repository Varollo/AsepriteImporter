namespace Varollo.AsepriteImporter.MetaData
{
    /// <summary>
    /// Describes the flow or <b>direction</b> of a <see cref="AsepriteTagData"/>.
    /// </summary>
    public enum AsepriteAnimationDirection
    {
        /// <summary>
        /// <see cref="AsepriteTagData.From"/> <c>>></c> <see cref="AsepriteTagData.To"/>.
        /// </summary>
        Forward,
        /// <summary>
        /// <see cref="AsepriteTagData.To"/> <c>>></c> <see cref="AsepriteTagData.From"/>.
        /// </summary>
        Reverse,
        /// <summary>
        /// <see cref="AsepriteTagData.From"/> <c>>></c> <see cref="AsepriteTagData.To"/> <c>>></c> <see cref="AsepriteTagData.From"/>.
        /// </summary>
        PingPong,
        /// <summary>
        /// <see cref="AsepriteTagData.To"/> <c>>></c> <see cref="AsepriteTagData.From"/> <c>>></c> <see cref="AsepriteTagData.To"/>.
        /// </summary>
        PingPongReverse
    }
}