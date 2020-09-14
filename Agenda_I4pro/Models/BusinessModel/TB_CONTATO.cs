
namespace Agenda_I4pro.Models.BusinessModel
{
    public class TB_CONTATO
    {

        public string CD_CONTO_NOME { get; set; }
        public string CD_CONTO_SOBRENOME { get; set; }

        private  TB_CONTATO(string cd_conto_nome, string cd_conto_sobrenome)
        {
            this.CD_CONTO_NOME = cd_conto_nome;
            this.CD_CONTO_SOBRENOME = CD_CONTO_SOBRENOME;
        }
        public TB_CONTATO()
        {
                
        }




    }
}