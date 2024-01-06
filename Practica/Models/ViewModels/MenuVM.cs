namespace neatBurger.Models.ViewModels
{
    public class MenuVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Precio { get; set; }
        public string Clasificacion { get; set; } = null!;
    }
}
