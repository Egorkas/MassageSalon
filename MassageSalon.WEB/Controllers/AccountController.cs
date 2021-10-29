using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.WEB.Models;
using MassageSalon.WEB.Models.LoginOrRegister;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IVisitorService _visitorService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AccountController(IVisitorService visitorService, IRoleService roleService, IMapper mapper)
        {
            _visitorService = visitorService;
            _roleService = roleService;
            _mapper = mapper;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewBag.Title = "Register";
            return View(); 
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                VisitorModel visitor = _mapper.Map<Visitor, VisitorModel>(_visitorService.Get(v => v.Login.Equals(model.Login)));
                if (visitor == null)
                {
                    // Add visitor to Db
                    visitor = new VisitorModel { Name = model.Name, Login = model.Login, Password = model.Password };
                    
                    await _visitorService.CreateAsync(_mapper.Map<VisitorModel, Visitor>(visitor));
                    visitor = _mapper.Map<Visitor, VisitorModel>
                        (_visitorService.GetWithInclude
                            (_visitorService.Get(u => u.Login == visitor.Login && u.Password == visitor.Password).Id)
                                );

                    await Authenticate(visitor); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                VisitorModel visitor = _mapper.Map<Visitor, VisitorModel>(_visitorService.Get(u => u.Login == model.Login && u.Password == model.Password));
                if (visitor != null)
                {
                    RoleModel visitorRole = _mapper.Map<Role, RoleModel>(_roleService.Get(r => r.Id == visitor.RoleId));
                    visitor.Role = visitorRole;
                    await Authenticate(visitor); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect Login or password");
            }
            return View(model);
        }
        private async Task Authenticate(VisitorModel visitor)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, visitor.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, visitor.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
