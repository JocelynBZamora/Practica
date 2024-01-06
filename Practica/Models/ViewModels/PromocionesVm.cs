namespace neatBurger.Models.ViewModels
{
    public class PromocionesVm
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public double Precio {  get; set; }
        public double PrecioPromo {  get; set; }
        public string AnteriorPromo { get; set; } = null!;
        public string SiguientePromo { get; set; } = null!;
    }
}
