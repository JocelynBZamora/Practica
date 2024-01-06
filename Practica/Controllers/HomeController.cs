using Microsoft.AspNetCore.Mvc;
using neatBurger.Models.ViewModels;
using neatBurger.Repositories;

namespace neatBurger.Controllers
{
    public class HomeController : Controller
    {
        private MenuRepository menuRepository;
        public HomeController(MenuRepository _menuRepository)
        {
            _menuRepository = menuRepository;
        }
        

        public IActionResult Index() => View();
       
        public IActionResult Menu() 
        {
            return View();
        }
        
        public IActionResult Promociones() 
        {
            var data = menuRepository?.GetAll().Where(x => x.PrecioPromocion is not null).ToList();
            
            if (data is null || !data.Any()) return RedirectToAction(nameof(Index));
            var promo = data.First();
            var vm = new PromocionesVm()
            {
                Descripcion = promo.Descripción,
                Id = promo.Id,
                Nombre = promo.Nombre,
                Precio = promo.Precio,
                PrecioPromo = (double)promo.PrecioPromocion !,
                SiguientePromo = data.ElementAtOrDefault(data.IndexOf(promo) - 1)?.Nombre ?? promo.Nombre,
                AnteriorPromo = data.ElementAtOrDefault(data.IndexOf(promo)+1)?.Nombre ?? promo.Nombre
            };
            return View(vm);
        }
        [Route("Promociones/{Id}")]
        public IActionResult Promociones(string Id)
        {
            Id = Id.Replace('-', ' ');

            var data = menuRepository.GetAll().Where(p => p.PrecioPromocion is not null).ToList();

            if (data is null || !data.Any()) return RedirectToAction(nameof(Index));

            var promocion = data.FirstOrDefault(p => p.Nombre.ToLower() == Id);

            if (promocion is null) return RedirectToAction(nameof(Index));

            var viewModel = new PromocionesVm()
            {
                Id = promocion.Id,
                Nombre = promocion.Nombre,
                Descripcion = promocion.Descripción,
                Precio = (double)promocion.Precio,
                PrecioPromo = (double)promocion.PrecioPromocion!,
                AnteriorPromo = data.ElementAtOrDefault(data.IndexOf(promocion) - 1)?.Nombre ?? promocion.Nombre,
                SiguientePromo = data.ElementAtOrDefault(data.IndexOf(promocion) + 1)?.Nombre ?? promocion.Nombre
            };

            return View(viewModel);
        }

    }
}
