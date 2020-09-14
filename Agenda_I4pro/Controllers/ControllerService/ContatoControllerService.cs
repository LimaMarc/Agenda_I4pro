


using Agenda_I4pro.Infrasctructure;
using Agenda_I4pro.Models.BusinessModel;
using Agenda_I4pro.Models.ModelViewModel;
using System.Collections.Generic;

namespace Agenda_I4pro.Controllers.ControllerService
{

    public  class ContatoControllerService : IContatoControllerService
    {

        ContatoRepositorioDB dbService;


        public ContatoControllerService()
        {

            dbService = new ContatoRepositorioDB();

        }
               


        public void cadastrarContato(TB_CONTATO contato, List<string> listaEmail, List<string> listaTelefone)
        {
            dbService.cadastrarContato(contato, listaEmail, listaTelefone);
        }

        public List<ContatoDetalheViewModel> Detalhe(int id)
        {
            List<ContatoDetalheViewModel> contatoViewModel = dbService.Detalhe(id);
            return contatoViewModel;
        }

        public void excluirContato(int ID_CONTO)
        {
            dbService.excluirContato(ID_CONTO);
            
        }



        public List<ContatoViewModel> listarContato()
        {
            List<ContatoViewModel> contatoEmail = dbService.listarContato();
            return contatoEmail;
        }
    }
}