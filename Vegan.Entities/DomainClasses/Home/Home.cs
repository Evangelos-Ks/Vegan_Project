namespace Vegan.Entities.Home
{
    public abstract class Home : Product
    {
        public string Instructions { get; set; }
        public string Information { get; set; }
        public string Category { get; set; } = "Home";
    }
}
