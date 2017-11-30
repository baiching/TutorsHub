﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ATP2.Profile.Models;
using ATP2.Profile.Models.HomeModels;
using BLL;
using BLL.SearchRepository;
using BLL.UserRepository;
using Entity;
using Entity.Data;
using Entity.UserModels;

namespace ATP2.Profile.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }


        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {

                IUserService<Admin> adminService =
                    new ServiceProvider().Create<Admin>();

                var admin = adminService.GetByEmail(loginModel.Email);

                if (admin != null)
                {
                    admin.LastLogin = DateTime.Now;

                    adminService.Update(admin);
                    Session["Admin"] = admin;
                    Session["UserName"] =admin.Email;
                    Session["Role"] = Role.Admin;
                    return RedirectToAction("AdminDashboard", "Account");
                }



                IUserService<Entity.UserModels.Tutor> tutoService =
                    new ServiceProvider().Create<Entity.UserModels.Tutor>();

                var tutor = tutoService.GetByEmail(loginModel.Email);

                if (tutor != null)
                {
                    tutor.LastLogin = DateTime.Now;

                    tutoService.Update(tutor);
                    Session["Tutor"] = tutor;
                    Session["UserName"] = tutor.Email;
                    Session["Role"] = Role.Tutor;
                    return RedirectToAction("Dashboard", "Tutor");
                }

                ModelState.AddModelError("Invalid", "Invalid User");
                return View("Login",loginModel);
            }

            return View(loginModel);
        }




        [HttpPost]
        public ActionResult Search(SearchModel searchModel)
        {
            searchModel.SelectedSubjects=new List<Subject>();
            foreach (var subject in searchModel.Subjects)
            {
                if (subject.IsChecked)
                {
                    searchModel.SelectedSubjects.Add(subject);
                }
            }
            
            searchModel.TutorList=new PublicSearch().SearchTutors(
                searchModel.Location,searchModel.Gender,searchModel.Class
                ,searchModel.SalaryMin,searchModel.SalaryMax,searchModel.SelectedSubjects
                );



            return View(searchModel);
        }



        [HttpGet]
        public ActionResult ViewTutor()
        {
            IUserService<Entity.UserModels.Tutor> tutoService =
                new ServiceProvider().Create<Entity.UserModels.Tutor>();


            var tutor= tutoService.GetByEmail("tkhan@iquantile.com");
            return View(tutor);
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
          
            if (ModelState.IsValid)
            {
                IUserService<Admin> adminService =
                    new ServiceProvider().Create<Admin>();

                var admin = adminService.GetByEmail(loginModel.Email);

                if (admin != null)
                {
                    admin.LastLogin = DateTime.Now;

                    adminService.Update(admin);
                    Session["Admin"] = admin;
                    Session["Role"] = Role.Admin;
                    return RedirectToAction("AdminDashboard", "Account");
                }
                IUserService<Entity.UserModels.Tutor> tutoService =
                    new ServiceProvider().Create<Entity.UserModels.Tutor>();
                var tutor = tutoService.GetByEmail(loginModel.Email);

                if (tutor != null)
                {
                    tutor.LastLogin = DateTime.Now;

                    tutoService.Update(tutor);
                    Session["Tutor"] = tutor;
                    Session["Role"] = Role.Tutor;
                    return RedirectToAction("Dashboard", "Tutor");
                }

                ModelState.AddModelError("Invalid","Invalid User");
                return View(loginModel);
            }
            
            return View(loginModel);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new RegistrationModel());
        }


   
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }


      

    }
}