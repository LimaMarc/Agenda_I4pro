using System;
using System.Collections.Generic;


namespace Agenda_I4pro.Models.BusinessModel
{
    public class TB_TELEFONE
    {

       
        public string CD_TEL { get; set; }
        public int ID_TPO_TEL { get; set; }
        public Nullable<int> ID_CONTO { get; set; }

        public virtual TB_CONTATO TB_CONTATO { get; set; }
       





        public TB_TELEFONE()
        {

        }
    }
}