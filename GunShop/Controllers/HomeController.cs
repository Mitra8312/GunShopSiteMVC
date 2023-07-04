using GunShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.Json;


namespace GunShop.Controllers
{
    public class HomeController : Controller
    {
        private GunShopContext dataBase;
        public HomeController(GunShopContext context)
        {
            dataBase = context;
        }

        public IActionResult SendMail()
        {
            Send send = new Send();
            var profile = new User();
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                var user = HttpContext.Session.GetString("AuthUser");
                profile = dataBase.Users.First(x => x.LoginUser == user);

                if (ModelState.IsValid) // 9DKkXBVWiCMrPS3Ugne0
                {
                    send.Name = profile.Nickname;
                    send.Email = profile.EmailAddressUser;
                    send.Message = "Поздравляю с приобритением валыны, придет по почте вместе с маски шоу, чтобы остальным неповадно было";
                    MailAddress from = new MailAddress("адрес пошты", "ЭкстраваGUNтный");
                    MailAddress to = new MailAddress(send.Email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Message from user";
                    m.Body = $"Message was sent. Thank's, {send.Name}, we will contact you soon!";
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                    smtp.Credentials = new NetworkCredential("адрес пошты", "9DKkXBVWiCMrPS3Ugne0");
                    smtp.EnableSsl = true;
                    smtp.Send(m);

                    MailAddress too = new MailAddress("yaUstal@mpt.ru", "ЭкстраваGUNтный");
                    MailMessage mo = new MailMessage(too, too);
                    mo.Subject = $"Message to {send.Email}";
                    mo.Body = send.Message;
                    mo.IsBodyHtml = true;

                    smtp.Credentials = new NetworkCredential("Depo", "QWERTYLang");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }

                return Redirect("~/Home/Profile");
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }

        public async Task<IActionResult> Product(int? id)
        {
            if (id != null)
            {
                Weapon weapon = await dataBase.Weapons.FirstOrDefaultAsync(w => w.IdWeapon == id);
                if (weapon != null)
                {
                    return View(weapon);
                }
            }
            return NotFound();
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            
            cart.CartLines.Add(dataBase.Weapons.Find(ID));

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/CartView");
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart")) 

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            cart.CartLines.RemoveAt(number);

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/CartView");
        }

        public IActionResult RemoveAllFromCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.CartLines.RemoveAll(item => item.IdWeapon == ID);

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/Profile");
        }

        public IActionResult CartView()
        {
            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            return View(cart);
        }

        public IActionResult Profile()
        {
            var profile = new User();
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                var user = HttpContext.Session.GetString("AuthUser");
                profile = dataBase.Users.First(x => x.LoginUser == user);
            }

            return View(profile);
        }

        public async Task<IActionResult> Catalog()
        {
            return View(await dataBase.Weapons.ToListAsync());
        }

        public IActionResult SignIn()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("RegOrAut", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {

            User user = await dataBase.Users.FirstOrDefaultAsync(u => u.LoginUser == model.LoginUser && u.PasswordUser == model.PasswordUser);
            if (user != null)
            {
                HttpContext.Session.SetString("AuthUser", model.LoginUser);
                await Authenticate(model.LoginUser);

                return RedirectToAction("RegOrAut", "Home");

            }
            ModelState.AddModelError("", "Некоректный логин или пароль");

            return RedirectToAction("RegOrAut", "Home");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("RegOrAut");
        }

        public IActionResult RegOrAut()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingUp(User user)
        {
            dataBase.Users.Add(user);
            await dataBase.SaveChangesAsync();

            User user1 = await dataBase.Users.FirstOrDefaultAsync(u => u.LoginUser == user.LoginUser && u.PasswordUser == user.PasswordUser);
            if (user != null)
            {
                HttpContext.Session.SetString("AuthUser", user.LoginUser);
                await Authenticate(user.LoginUser);

                return RedirectToAction("Profile", "Home");

            }
            ModelState.AddModelError("", "Некоректный логин или пароль");

            return RedirectToAction("RegOrAut", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}