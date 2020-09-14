using Agenda_I4pro.Models.BusinessModel;
using Agenda_I4pro.Models.ModelViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_I4pro.Infrasctructure
{
    interface IContatoControllerService
    {
        void cadastrarContato(TB_CONTATO contato, List<string> listaEmail, List<string> listaTelefone);
        List<ContatoDetalheViewModel> Detalhe(int id);

        List<ContatoViewModel> listarContato();

        void excluirContato(int ID_CONTO);

    }
}
