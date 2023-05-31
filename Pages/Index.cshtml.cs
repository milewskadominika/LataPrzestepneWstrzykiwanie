﻿using LataPrzestepneWstrzykiwanie.Data;
using LataPrzestepneWstrzykiwanie.Forms;
using LataPrzestepneWstrzykiwanie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Security.Claims;

namespace LataPrzestepneWstrzykiwanie.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public YearForm Form { set; get; }

        public List<Model> people = new();

        public string Result = "";


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext contex)
        {
            _logger = logger;
            _context = contex;
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                bool prz = czyPrzestepny();
                Result = Verbose(prz);
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    people =
                    JsonConvert.DeserializeObject<List<Model>>(Data);
                people.Add(recordCreationModel());
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(people));

                _context.History.Add(recordCreationHistory());
                _context.SaveChanges();
                return Page();
            }
        }

        public Model recordCreationModel()
        {
            Model record = new Model()
            {
                Name = Form.Name ?? "",
                Year = Form.Year,
                Przestepny = czyPrzestepny()
            };

            return record;

        }

        public History recordCreationHistory()
        {
            History record = new History(_context)
            {
                CreatedDate = DateTime.Now,
                Year = Form.Year,
                UserLogin = HttpContext.User.Identity.Name ?? "",
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "",
                IsLeap = czyPrzestepny()
            };
            return record;
        }


        public bool czyPrzestepny()
        {
            //1 gdy przestepny, 0 gdy nie
            return ((Form.Year % 4 == 0 && Form.Year % 100 != 0) || Form.Year % 400 == 0);
        }


        public String Verbose(bool p)
        {
            if (Form.Name != null)
            {
                Result += Form.Name;
                Result += " urodził się w ";
                Result += Form.Year;
                Result += " roku. To";
            }
            else
            {
                Result += Form.Year;
                Result += " to";
            }


            if (p)
            {
                Result += " był rok przestępny.";
            }
            else
            {
                Result += " nie był rok przestępny.";
            }


            return Result;
        }

    }
}