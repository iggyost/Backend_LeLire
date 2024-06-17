using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();
        [HttpGet]
        [Route("get/{bookId}")]
        public ActionResult<IEnumerable<Book>> Get(int bookId)
        {
            try
            {
                var selectedBook = context.Books.Where(x => x.BookId == bookId).FirstOrDefault();
                return Ok(selectedBook);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }
}
