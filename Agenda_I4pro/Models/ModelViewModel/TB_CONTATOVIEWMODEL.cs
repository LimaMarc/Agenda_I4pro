
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda_I4pro.Models.ModelViewModel
{
    public class TB_CONTATOVIEWMODEL
    {
        

        public int ID_CONTO { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do contato é obrigatório", AllowEmptyStrings = false)]
        public string CD_CONTO_NOME { get; set; }


        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "O sobrenome do contato é obrigatório", AllowEmptyStrings = false)]
        public string CD_CONTO_SOBRENOME { get; set; }

       
        public virtual ICollection<TB_EMAILVIEWMODEL> TB_EMAILVIEWMODEL { get; set; }
        
        public virtual ICollection<TB_TELEFONEVIEWMODEL> TB_TELEFONEVIEWMODEL { get; set; }
    }
}