using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroBlazorWebApp.Server.Models.Context;
using SuperHeroBlazorWebApp.Shared.Models;

namespace SuperHeroBlazorWebApp.Server.Controllers
{
    public class SuperHeroController : BaseEntityController<SuperHero, SuperHeroBlazorContext>
    {
        public SuperHeroController(SuperHeroBlazorContext context) : base(context)
        {
        }
        public override IQueryable<SuperHero> GetAll()
        {
            return base.GetAll().Include(sh => sh.Movies);
        }

        public override async Task<SuperHero?> Get(int id)
        {
            return await base.GetAll()
                             .Include(sh => sh.Movies)
                             .FirstOrDefaultAsync(sh => sh.Id == id);
        }
    }
}
