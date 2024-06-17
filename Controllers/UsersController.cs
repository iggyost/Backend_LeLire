using Backend_LeLire.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_LeLire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public static LeLireLightDbContext context = new LeLireLightDbContext();

        [HttpGet]
        [Route("get/{phone}")]
        public ActionResult<IEnumerable<User>> Get(string phone)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (user != null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("enter/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> Enter(string phone, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Неверный пароль!");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("reg/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> RegUser(string phone, string password)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
                if (checkAvail == null)
                {
                    User user = new User()
                    {
                        Phone = phone,
                        Password = password,
                        StatusId = 1
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Пользователь с таким номером уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpPut]
        [Route("name/{userId}/{result}")]
        public ActionResult<IEnumerable<User>> ChangeName(int userId, string result)
        {
            try
            {
                var selectedUser = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                selectedUser.Name = result;
                context.Entry(selectedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
