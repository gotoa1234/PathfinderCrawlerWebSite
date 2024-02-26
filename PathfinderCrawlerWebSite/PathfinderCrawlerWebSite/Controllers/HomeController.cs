﻿using Microsoft.AspNetCore.Mvc;
using PathfinderCrawlerWebSite.Service.Implement;

namespace PathfinderCrawlerWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrawlerService _crawlerService;

        public HomeController(ILogger<HomeController> logger,
            ICrawlerService crawlerService)
        {
            _logger = logger;
            _crawlerService = crawlerService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}