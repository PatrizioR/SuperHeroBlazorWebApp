using SuperHeroBlazorWebApp.Server.Models.Context;
using SuperHeroBlazorWebApp.Shared.Models;

namespace SuperHeroBlazorWebApp.Server.Controllers
{
    public class MovieController : BaseEntityController<Movie, SuperHeroBlazorContext>
    {
        public MovieController(SuperHeroBlazorContext context) : base(context)
        {
        }
    }
}
