using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();
        [HttpGet]
        [Route("create/{userId}")]
        public ActionResult<IEnumerable<Library>> Create(int userId)
        {
            try
            {
                Library library = new Library()
                {
                    UserId = userId,
                };
                context.Libraries.Add(library);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<Library>> Get(int userId)
        {
            try
            {
                var userLibrary = context.Libraries.Where(x => x.UserId == userId).FirstOrDefault();
                return Ok(userLibrary);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
