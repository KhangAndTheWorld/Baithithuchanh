using System.Diagnostics;
using BaiThiThucHanh2025.Data;
using Microsoft.AspNetCore.Mvc;
using BaiThiThucHanh2025.Models;


namespace BaiThiThucHanh2025.Controllers;

public class HomeController : Controller
{
    private readonly TestContext _context;

    public HomeController(TestContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    // [HttpPost("Create")]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> PostEvent(Player @player)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Player.Add(@player);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index)); 
    //     }
    //     return View("Create", @player);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}