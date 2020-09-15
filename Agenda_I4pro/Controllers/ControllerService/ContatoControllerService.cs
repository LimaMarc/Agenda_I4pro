


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

        public void editarContato(int id, TB_CONTATOVIEWMODEL tB_CONTATOVIEWMODEL, ICollection<TB_TELEFONEVIEWMODEL> tB_TELEFONEVIEWMODELs, ICollection<TB_EMAILVIEWMODEL> tB_EMAILVIEWMODELs)
        {
            dbService.editarContato(id, tB_CONTATOVIEWMODEL, tB_TELEFONEVIEWMODELs, tB_EMAILVIEWMODELs);
        }

        public void excluirContato(int ID_CONTO)
        {
            dbService.excluirContato(ID_CONTO);
            
        }

        public ContatoEditarViewModel exibirContatoViewModel(int ID_CONTO)
        {
            ContatoEditarViewModel contatoEditarViewModel = dbService.exibirContatoViewModel(ID_CONTO);
            return contatoEditarViewModel;
        }

        public List<ContatoViewModel> listarContato()
        {
            List<ContatoViewModel> contatoEmail = dbService.listarContato();
            return contatoEmail;
        }
    }
}