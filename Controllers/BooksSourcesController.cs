using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksSourcesController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();

        [HttpGet]
        [Route("get/{bookId}/{languageId}")]
        public List<byte[]> GetPages(int bookId, int languageId)
        {
            try
            {
                List<byte[]> result = new List<byte[]>();
                int i;
                for (i = 1; i <= context.BooksSources.Where(x => x.BookId == bookId && x.LanguageId == languageId).Count(); i++)
                {
                    var selectedPage = context.BooksSources.Where(x => x.BookId == bookId && x.PageNum == i && x.LanguageId == languageId).Select(x => x.Source).FirstOrDefault();
                    string path = $"Books\\{selectedPage}";
                    byte[] imageBytes = System.IO.File.ReadAllBytes(path);
                    result.Add(imageBytes);
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}