using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRUDATM.Models {
    public class UFS {

        [Key]
        public int UfID { get; set; }

        [Required(ErrorMessage = "A sigla é obrigatória.")]
        public string UfSigla { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório.")]        
        [Display(Name = "Nome")]
        [Remote("ValidaNome", "UFS", ErrorMessage = "Estado já cadastrado!")]
        public string UfNome { get; set; }

        /* criando uma coleção de objetos */
        public virtual ICollection<ATMs> ATMs { get; set; }

    }
}