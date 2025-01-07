﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_trev.Data;

namespace azure_app_trev.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly azure_app_trev.Data.AppDbContext _context;

        public DetailsModel(azure_app_trev.Data.AppDbContext context)
        {
            _context = context;
        }

        public Data.Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FirstOrDefaultAsync(m => m.id == id);

            if (person is not null)
            {
                Person = person;

                return Page();
            }

            return NotFound();
        }
    }
}
