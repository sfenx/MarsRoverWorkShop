namespace MarsRoverWorkShop.LandingSurface
{
    public class Area : ILandingSurface
    {
        public Dimension Dimension { get; private set; }
        public void Define(int width, int height)
        {
            Dimension = new Dimension(width, height);
        }
    }
}
