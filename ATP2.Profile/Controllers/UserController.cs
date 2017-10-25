﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.Profile.Models;
using Entity;

namespace ATP2.Profile.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            return View(new UserSearchModel());
        }
        [HttpPost]
        public ActionResult Search(UserSearchModel searchModel)
        {
            //Actually would search using searchmodel.searchtext then fill the model with users
            searchModel.Users = (List<User>)Session["Users"];
            return View(searchModel);
        }


        public ActionResult CreateNew()
        {
            return View();
        }


    }
}