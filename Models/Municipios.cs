using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDATM.Models {
    public class Municipios {

        [Key]
        public int MunID { get; set; }
        public string MunNome { get; set; }

        /* criando uma coleção de objetos */
        public virtual ICollection<ATMs> ATMs { get; set; }

    }
}