using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesProject.Enumerates
{
    public enum VisitType
    {
        [Display(Name = "Strona WWW")]
        WebSite = 1,

        [Display(Name = "Web Service")]
        WebService = 2,
    }
}