using AutoMapper;
using Online_Assessment_Project.DomainModel;
using Online_Assessment_Project.Filters;
using Online_Assessment_Project.ServiceLayer;
using Online_Assessment_Project.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Assessment_Project.Controllers
{
    public class AccountController : Controller
    {
        IUserServices userService;
        IRoleServices roleServices;
        public AccountController()
        {
            userService = new UserServices();
            roleServices = new RoleServices();
        }
        // GET: Account
        [HttpGet]
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel user)
        {
            
                if (ModelState.IsValid)
                {
                    string name = User.Identity.Name;
                    ViewBag.name = name;
                    UserViewModel validatedData = userService.ValidateUser(user);
                    //if(user.EmailID == "manoj@gmail.com" && user.Password == "123")
                    if (validatedData != null)
                    {
                        Session["CurrentUserID"] = validatedData.UserId;
                        TempData["Login_successfull_msg"] = "You are successfully logged in";
                        FormsAuthentication.SetAuthCookie(user.EmailID, true);
                        return RedirectToAction("DisplayAvailableTest", "Test");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Email or Password");
                        return View(user);
                    }
                }


                else
                    return View();

            
            }


        
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    
    public ActionResult Display()
        {
            List<User> data = userService.Display();
            return View(data);


            //var mapcategory = new MapperConfiguration(configurationExpression => { configurationExpression.CreateMap<List<User>,List<CreateViewModel>>(); });
            //IMapper mapper = mapcategory.CreateMapper();
            //var userData = mapper.Map< List < User > ,List<CreateViewModel>>(data);
            //return View(data);
            ////userService.Create(userData);
            ////return RedirectToAction("Display");
        }
        public ActionResult Create()
        {
            List<Online_Assessment_Project.DomainModel.Role> Roles = roleServices.Display();
            ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(CreateViewModel createviewmodel)
        {
            var mapcategory = new MapperConfiguration(configurationExpression => { configurationExpression.CreateMap<CreateViewModel, User>(); });
            IMapper mapper = mapcategory.CreateMapper();
            var userData = mapper.Map<CreateViewModel, User>(createviewmodel);
            List<Online_Assessment_Project.DomainModel.Role> Roles = roleServices.Display();
            ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");
            userService.Create(userData);
            return RedirectToAction("Display");
        }

        public ActionResult Delete(int Id)
        {

            userService.Delete(Id);

            return RedirectToAction("Display");
        }
        public ActionResult Edit(int Id)
        {
            List<Online_Assessment_Project.DomainModel.Role> Roles = roleServices.Display();
            ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");
            User user = userService.Edit(Id);

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CreateViewModel createviewmodel)
        {

            var mapcategory = new MapperConfiguration(configurationExpression => { configurationExpression.CreateMap<CreateViewModel, User>(); });
            IMapper mapper = mapcategory.CreateMapper();
            var userData = mapper.Map<CreateViewModel, User>(createviewmodel);
            List<Online_Assessment_Project.DomainModel.Role> Roles = roleServices.Display();
            ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");
            userService.Update(userData);
            TempData["Message"] = "updated";

            return RedirectToAction("Display");
        }
    }
}