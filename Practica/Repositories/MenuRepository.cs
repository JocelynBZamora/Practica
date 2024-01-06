using Microsoft.EntityFrameworkCore;
using neatBurger.Models.entities;

namespace neatBurger.Repositories
{
    public class MenuRepository : Repository<Menu>
    {
        public MenuRepository(NeatContext context) : base(context){  }
        public override IEnumerable<Menu> GetAll() => 
            Context.Menu.Include(x => x.IdClasificacionNavigation).
            OrderBy(x => x.IdClasificacionNavigation.Nombre).ThenBy(x => x.Nombre);
        public Menu? GetByName(string name) => 
            Context.Menu.Include(x => x.IdClasificacionNavigation).
            FirstOrDefault(x => x.Nombre == name);
    }
}
