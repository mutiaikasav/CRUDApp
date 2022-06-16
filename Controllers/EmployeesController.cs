using System.Threading.Tasks;
using CRUDApp.Data;
using CRUDApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDApp.Controllers
{
    public class EmployeesController:Controller
    {
        private ApplicationDBContext _context;

        public EmployeesController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru {e.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru");
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exist = await _context.Employees.Where(x => x.Id==id).FirstOrDefaultAsync();
            return View(exist);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _context.Employees.Where(x => x.Id==employee.Id).FirstOrDefault();
                    if (exist != null)
                    {
                        exist.Name = employee.Name;
                        exist.Position = employee.Position;
                        exist.Division = employee.Division;
                        exist.Address = employee.Address;
                        exist.Gender = employee.Gender;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru {e.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru");
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _context.Employees.Where(x => x.Id==id).FirstOrDefaultAsync();
            return View(exist);   
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            // if (ModelState.IsValid)
            // {
            //     try
            //     {
                    var exist = _context.Employees.Where(x => x.Id==employee.Id).FirstOrDefault();
                    if (exist != null)
                    {
                        _context.Remove(exist);
                        await _context.SaveChangesAsync();
                        
                    }
                    return RedirectToAction("Index");
            //     }
            //     catch (Exception e)
            //     {
            //         ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru a {e.Message}");
            //     }
            // }

            // ModelState.AddModelError(string.Empty, $"Gagal menambah karyawan baru b");
            // return View(employee);
        }

    }
}