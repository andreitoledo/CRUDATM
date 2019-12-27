using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CRUDATM.Models {
    public class Municipios {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MunID { get; set; }

        [Required(ErrorMessage = "O nome do município é obrigatório.")]
        [Display(Name = "Nome")]
        [Remote("ValidaNome", "Municipios", ErrorMessage = "Município já cadastrado!")]
        public string MunNome { get; set; }

        /* criando uma coleção de objetos */
        public virtual ICollection<ATMs> ATMs { get; set; }

    }
}