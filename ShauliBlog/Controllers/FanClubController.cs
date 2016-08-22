﻿using ShauliBlog.Models;
using ShauliBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShauliBlog.Controllers
{
    public class FanClubController : Controller
    {
        private FanDbContext _context;

        public FanClubController()
        {
            _context = new FanDbContext();
        }
        // GET: FanClub
        public ActionResult Index()
        {
            var fanList = _context.Fans.ToList();
            //Return Fan list ?
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Create()
        {
            var fanForm = new FanFormViewModel();
            fanForm.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "Male"},
                new SelectListItem { Value = "F", Text = "Female" }
            };
            return View(fanForm);
        }
    }
}