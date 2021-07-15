using System.Linq;
using Finalexam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginReg.Controllers
{
    public class UserController : Controller
    {
        private MyContext _context;
        public UserController(MyContext context){
            _context=context;
        }
        [HttpGet("")]
        public IActionResult Register(){
            if(HttpContext.Session.GetInt32("UserId")==null){
                return View();
            } else {
                return RedirectToAction("Hobby");
            }
        }

        [HttpPost("create")]
        public IActionResult Create(User NewUser){
            if(ModelState.IsValid){
                if(_context.Users.Any(u=> u.Username==NewUser.Username)){
                    ModelState.AddModelError("Username","This Username is already registered");
                    return View("Register");
                } else {
                    PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                    NewUser.Password = passwordHasher.HashPassword(NewUser,NewUser.Password);
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId",NewUser.UserId);
                    return RedirectToAction("Hobby");
                }
            } else {
                return View("Register");
            }
        }
     

        [HttpGet("login")]
        public IActionResult LoginForm(){
            if(HttpContext.Session.GetInt32("UserId")==null){
            return View();
            } else {
                return RedirectToAction("Hobby");
            }
        }

        [HttpPost("check")]
        public IActionResult Login(LoginUser LoggedUser){
            if (ModelState.IsValid){
                User DbUser = _context.Users.FirstOrDefault(u => u.Username==LoggedUser.Username);
                if (DbUser == null){
                    ModelState.AddModelError("Username","Username or Password is Invalid");
                    return View("LoginForm");
                } else {
                    PasswordHasher<LoginUser> passwordHasher = new PasswordHasher<LoginUser>();
                    var result = passwordHasher.VerifyHashedPassword(LoggedUser,DbUser.Password,LoggedUser.Password);
                    if (result==0){
                        ModelState.AddModelError("Email","Email or Password is Invalid");
                        return View("LoginForm");
                    } else {
                        HttpContext.Session.SetInt32("UserId",DbUser.UserId);
                        return RedirectToAction("Hobby");
                    }
                }
            } else {
                return View("LoginForm");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm");
        }
        
    
   [HttpGet("Hobby")]
        public IActionResult Hobby(){
            if(HttpContext.Session.GetInt32("UserId")!=null){
            ViewBag.AllHobby = _context.Hobbies.Include(c => c. Users).ToList();
                return View();
            } else {
                return RedirectToAction("LoginForm");
            }
            
        }

       

[HttpGet("CreateHobby")]
    public ViewResult CreateHobby ()
    {
        return View("CreateHobby");
    }

    [HttpGet("Detail/{id}")]
    public IActionResult Detail(int id)
{
     ViewBag.AllHobby= _context.Hobbies.Include(h=>h.Users).ThenInclude(h=>h.User).FirstOrDefault(v => v.HobbyId == id);
       
            return View("Detail");
}
    [HttpPost("new/CreateHobby")]
        public IActionResult CreateHobby(Hobby newHobby)
        {
            ViewBag.AllHobby= _context.Hobbies.ToList();
             
            if(ModelState.IsValid)
            {
                _context.Add(newHobby);
                _context.SaveChanges();
                return RedirectToAction("Hobby");            
            }else{
                return View("CreateHobby");
            }
        }
        [HttpPost("Add/{id}")]
        public ActionResult Add(int id)
        {
           
        
           Relation ADD = new Relation();
            ADD.UserId = (int)HttpContext.Session.GetInt32("UserId");
           ADD.HobbyId = id;
            _context.Relationes.Add(ADD);
            _context.SaveChanges();
            return RedirectToAction("Detail");
        }
        }


 

    }

