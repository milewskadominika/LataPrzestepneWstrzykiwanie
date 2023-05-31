﻿using System.ComponentModel.DataAnnotations;

namespace LataPrzestepneWstrzykiwanie.Forms
{
    public class YearForm
    {
        [Display(Name = "Podaj rok urodzenia")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość z zakresu {1} i {2}.")]
        public int Year { get; set; }

        [Display(Name = "Podaj imię")]
        public string? Name { get; set; }
    }
}
