using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;

namespace myapp.Controllers;

public class EmployeeController : Controller
{
    private readonly DBMvcContext _dbContext;

    public EmployeeController(DBMvcContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult GetEmployees()
    {
        List<Employee> list = _dbContext.Employees.ToList();
        ViewData["allemps"] = list;

        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee emp)
    {
        _dbContext.Employees.Add(emp);
        _dbContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }

    [HttpGet]
    public IActionResult Delete(Employee emp)
    {
        _dbContext.Employees.Remove(emp);
        _dbContext.SaveChanges();
        return RedirectToAction("GetEmployees");
    }

    public IActionResult Index()
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
