namespace Varollo.AsepriteImporter.MG
{
    /// <summary>
    /// Counter used by a <see cref="AsepriteAnimator"/>.
    /// </summary>
    public interface IAnimationCounter
    {
        /// <summary>
        /// Gets current count.
        /// </summary>
        /// <returns>Current count of this counter.</returns>
        double GetCount();
    }
}