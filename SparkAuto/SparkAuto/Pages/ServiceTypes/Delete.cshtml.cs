using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.ServiceTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            ServiceType = _context.ServiceType.FirstOrDefault(x => x.Id == id);
            if (ServiceType is null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_context.ServiceType.Any(x => x.Id == ServiceType.Id))
                {
                    _context.ServiceType.Remove(ServiceType);
                    _context.SaveChanges();
                    return RedirectToPage("Index");
                }
                return NotFound();
            }
            return Page();
        }
    }
}
