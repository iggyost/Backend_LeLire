using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesBooksController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();
        [HttpGet]
        [Route("put/{libraryId}/{bookId}")]
        public ActionResult<IEnumerable<Library>> Put(int libraryId, int bookId)
        {
            try
            {
                var checkAvail = context.LibraryBooks.Where(x => x.LibraryId == libraryId && x.BookId == bookId).FirstOrDefault();
                if (checkAvail == null)
                {
                    LibraryBook libraryBook = new LibraryBook()
                    {
                        LibraryId = libraryId,
                        BookId = bookId
                    };
                    context.LibraryBooks.Add(libraryBook);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
} 
