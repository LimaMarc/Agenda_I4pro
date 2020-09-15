using Agenda_I4pro.Models.BusinessModel;
using Agenda_I4pro.Models.ModelViewModel;
using System.Collections.Generic;


namespace Agenda_I4pro.Infrasctructure
{
    interface IContatoControllerService
    {

        void cadastrarContato(TB_CONTATO contato, List<string> listaEmail, List<string> listaTelefone);
        List<ContatoDetalheViewModel> Detalhe(int id);

        List<ContatoViewModel> listarContato();
        ContatoEditarViewModel exibirContatoViewModel(int ID_CONTO);
        void editarContato(int id, TB_CONTATOVIEWMODEL tB_CONTATOVIEWMODEL, ICollection<TB_TELEFONEVIEWMODEL> tB_TELEFONEVIEWMODELs, ICollection<TB_EMAILVIEWMODEL> tB_EMAILVIEWMODELs);
        void excluirContato(int ID_CONTO);

    }
}
