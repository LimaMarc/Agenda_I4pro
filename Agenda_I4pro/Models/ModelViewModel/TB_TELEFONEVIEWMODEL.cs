
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda_I4pro.Models.ModelViewModel
{
    public class TB_TELEFONEVIEWMODEL
    {
        public int ID_TEL { get; set; }
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O telefone é obrigatório", AllowEmptyStrings = false)]
        public string CD_TEL { get; set; }
        

        public virtual TB_CONTATOVIEWMODEL TB_CONTATO { get; set; }
    }
}