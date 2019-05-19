using BoardGamesProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGamesProject.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(@"Data Source=mssql01.dcsweb.pl,51433;Initial Catalog=1028_BoardGamesDB;Persist Security Info=True;User ID=1028_testuser;Password=TestUser!@3") { }
        public DbSet<BoardGame> BoardGames { get; set; }
    }
}