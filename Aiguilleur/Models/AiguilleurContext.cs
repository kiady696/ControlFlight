using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Aiguilleur.Models
{
    public class AiguilleurContext : DbContext
    {
        public AiguilleurContext() : base("AiguilleurDB")
        {
            //mload anle base izy 
        }
        public DbSet<Modele> modeles { get; set; }
        public DbSet<Avion> avions { get; set; }
        public DbSet<Vol> vols { get; set; }
        
        

    }
}