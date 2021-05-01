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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
