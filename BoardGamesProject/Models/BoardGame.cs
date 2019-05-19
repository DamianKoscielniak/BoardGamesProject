using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesProject.Models
{
    public class BoardGame
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nazwa gry")]
        public string Name { get; set; }

        [Display(Name = "Data wydania")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Minimalny wiek gracza")]
        public int MinimalAge { get; set; }

        [Display(Name = "Opis gry")]
        public string Description { get; set; } 
    }
}