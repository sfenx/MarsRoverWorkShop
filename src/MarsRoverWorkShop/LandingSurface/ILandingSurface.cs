namespace MarsRoverWorkShop.LandingSurface
{
    public interface ILandingSurface
    {
        Dimension Dimension { get; }
        void Define(int width, int height);
    }
}
