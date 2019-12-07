using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDATM.Models {
    public class UFS {

        [Key]
        public int UfID { get; set; }
        public string UfSigla { get; set; }
        public string UfNome { get; set; }

        /* criando uma coleção de objetos */
        public virtual ICollection<ATMs> ATMs { get; set; }

    }
}