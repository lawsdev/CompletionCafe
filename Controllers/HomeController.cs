﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CompletionCafe.Models;

namespace CompletionCafe.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public ActionResult Datetime()
    // {
    //     return (var fDt = DateTime.Now.ToString("f") ViewData["fDt"] = fDt;)
    // }

    public IActionResult Index()
    {
        return View();
    }

     public IActionResult Sort()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
