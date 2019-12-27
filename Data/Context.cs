using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDATM.Models {
    public class Context : DbContext {

        public Context()
            : base("CRUDATM_desenv") {

        }

        public DbSet<ATMs> ATMs { get; set; }
        public DbSet<Municipios> Municipios { get; set; }
        public DbSet<UFS> UFS { get; set; }
                
    }
}