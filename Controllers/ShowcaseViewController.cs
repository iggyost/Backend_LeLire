using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowcaseViewController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();
        [HttpGet]
        [Route("get/popular")]
        public ActionResult<IEnumerable<ShowcaseView>> GetPopular()
        {
            try
            {
                var popularBooks = context.ShowcaseViews.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                return popularBooks;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/all")]
        public ActionResult<IEnumerable<ShowcaseView>> GetAll()
        {
            try
            {
                var allItems = context.ShowcaseViews.ToList();
                return allItems;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
