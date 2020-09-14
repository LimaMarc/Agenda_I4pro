

namespace Agenda_I4pro.Models.ModelViewModel
{
    public class ContatoDetalheViewModel
    {


        //Contato
        public int ID_CONTO { get; set; }
        public string CD_CONTO_NOME { get; set; }
        public string CD_CONTO_SOBRENOME { get; set; }



        //Email
        public int ID_EMAIL { get; set; }
        public string CD_EMAIL { get; set; }


        //Telefone

        public int ID_TEL { get; set; }
        public string CD_TEL { get; set; }



        //ListarContatoTelefone
        //TipoTelefone
        public int ID_TPO_TEL { get; set; }
        public string CD_TIPO_TEL { get; set; }

    }
}