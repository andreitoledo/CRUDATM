using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDATM.Models {
    public class ATMs {

        [Key]
        public int AtmID { get; set; }
        public string AtmPC { get; set; }
        public string AtmNOME { get; set; }

        /* FK e coleção de objetos para Municipio */
        public int MunID { get; set; }        
        public virtual Municipios Municipios { get; set; }

        /* FK e coleção de objetos para UFS */
        public int UfID { get; set; }
        public virtual UFS UFS { get; set; }
        

    }
}