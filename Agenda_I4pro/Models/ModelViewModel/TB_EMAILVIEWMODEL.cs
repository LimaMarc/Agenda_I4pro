

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda_I4pro.Models.ModelViewModel
{
    public class TB_EMAILVIEWMODEL
    {
        public int ID_EMAIL { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "O e-mail é obrigatório", AllowEmptyStrings = false)]
        public string CD_EMAIL { get; set; }
       

        public virtual TB_CONTATOVIEWMODEL TB_CONTATO { get; set; }
    }
}