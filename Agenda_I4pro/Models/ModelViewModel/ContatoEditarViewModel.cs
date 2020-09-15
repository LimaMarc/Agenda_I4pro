

using System.Collections.Generic;

namespace Agenda_I4pro.Models.ModelViewModel
{
    public class ContatoEditarViewModel
    {
        public TB_CONTATOVIEWMODEL TB_CONTATOVIEWMODEL { get; set; }
        public ICollection<TB_EMAILVIEWMODEL> TB_EMAILVIEWMODEL { get; set; }
        public ICollection<TB_TELEFONEVIEWMODEL> TB_TELEFONEVIEWMODEL { get; set; }
    }
}