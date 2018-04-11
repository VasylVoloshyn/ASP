﻿using MyQASPTr.Models;
using System;
using System.Web.Mvc;

namespace MyQASPTr.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {            
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
    }
}