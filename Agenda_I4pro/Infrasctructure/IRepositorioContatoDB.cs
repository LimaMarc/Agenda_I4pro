
using Agenda_I4pro.Models.BusinessModel;
using Agenda_I4pro.Models.ModelViewModel;
using System.Collections.Generic;

namespace Agenda_I4pro.Infrasctructure
{
    /// <summary>
    /// Interface para as operações do Sistema Agenda
    /// </summary>
        interface IRepositorioContatoDB
    {

        /// <summary>
        /// Método para Cadastrar um contato no Banco de Dados
        /// </summary>
        /// <param name="contato"> Objeto/Tabela TB_CONTATO. Possui como parâmetros: Nome e Sobrenome</param>
        /// <param name="listaEmail"> Objeto/Tabela TB_EMAIL. Possui como parâmetros: descrição do email e Id do contato, satisfazendo o Relacionamento 1.N (Um Contato possui N E-mail)</param>
        /// <param name="listaTelefone">Objeto/Tabela TB_TELEFONE. Possui como parâmetros: descrição do TELEFONE e Id do contato, satisfazendo o Relacionamento 1.N (Um Contato possui N Telefone) </param>
        void cadastrarContato(TB_CONTATO contato, List<string> listaEmail,List<string> listaTelefone);
        List<ContatoDetalheViewModel> Detalhe(int id);

        List<ContatoViewModel> listarContato();

        void excluirContato(int ID_CONTO);
    }
}
