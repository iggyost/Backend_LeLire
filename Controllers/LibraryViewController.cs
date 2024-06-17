using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryViewController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();

        [HttpGet]
        [Route("get/{libraryId}")]
        public ActionResult<IEnumerable<LibraryView>> Get(int libraryId)
        {
            try
            {
                var libraryView = context.LibraryViews.Where(x => x.LibraryId == libraryId).ToList();
                return libraryView;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}