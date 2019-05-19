using BoardGamesProject.Enumerates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoardGamesProject.Models
{
    [NotMapped]
    public class CookieObject
    {
        public DateTime Date { get; set; }
        public VisitType VisitType { get; set; }
    }
}