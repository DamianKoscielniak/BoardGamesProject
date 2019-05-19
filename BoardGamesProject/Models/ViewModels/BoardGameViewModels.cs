using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesProject.Models.ViewModels
{
    public class SingleBoardGame
    { 
        public int ID { get; set; }

        [Display(Name = "Nazwa gry")]
        public string Name { get; set; }

        [Display(Name = "Data wydania")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Minimalny wiek gracza")]
        public int MinimalAge { get; set; }
    }

    public class BoardGameCreateViewModel
    {
        [Display(Name = "Nazwa gry")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa gry jest wymagana!")]
        public string Name { get; set; }

        [Display(Name = "Data wydania")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Data wydania jest wymagana!")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Minimalny wiek gracza")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Minimalny wiek gracza jest wymagany!")]
        [Range(1, 21, ErrorMessage = "Wiek gracza musi być z przedziału {1} - {2}!")]
        
        public int MinimalAge { get; set; }

        [Display(Name = "Opis gry")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Opis jest wymagany!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class BoardGameEditViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa gry")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa gry jest wymagana!")]
        public string Name { get; set; }

        [Display(Name = "Data wydania")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Data wydania jest wymagana!")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Minimalny wiek gracza")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Minimalny wiek gracza jest wymagany!")]
        [Range(1, 21, ErrorMessage = "Wiek gracza musi być z przedziału {1} - {2}!")]

        public int MinimalAge { get; set; }

        [Display(Name = "Opis gry")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Opis jest wymagany!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class BoardGameDetailsViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa gry")]
        public string Name { get; set; }

        [Display(Name = "Data wydania")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Minimalny wiek gracza")]
        public int MinimalAge { get; set; }

        [Display(Name = "Opis gry")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<CookieObject> LastVisits { get; set; }
    }
}