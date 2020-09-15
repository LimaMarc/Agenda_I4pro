using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Agenda_I4pro.Models.ModelViewModel;
using Agenda_I4pro.Models.BusinessModel;

namespace Agenda_I4pro.Infrasctructure
{
    /// <summary>
    /// Classe responsável pela comunicação com o Banco de Dados, utilizando ADO.NET
    /// Herda os métodos (Contrato) de sua Interface:IRepositorioContatoDB
    /// </summary>
    public class ContatoRepositorioDB : IRepositorioContatoDB
    {

        //String de Conexão
        //Mudar no WebConfig
        private readonly string _connectionstring = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection conexaoDataBase;




        public void cadastrarContato(TB_CONTATO contato, List<string> listaEmail, List<string> listaTelefone)
        {
            int identificador;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_CRIAR_CONTATO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nome", contato.CD_CONTO_NOME);
                        cmd.Parameters.AddWithValue("@sobrenome", contato.CD_CONTO_SOBRENOME);

                        var returnParameter = cmd.Parameters.Add("@identificador", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;


                        cmd.ExecuteNonQuery();
                        identificador = Convert.ToInt32(returnParameter.Value);

                    }
                    foreach (var item in listaEmail)
                    {
                        using (SqlCommand cmd = new SqlCommand(DbCommand.SP_CRIAR_CONTATO_EMAIL, conexaoDataBase))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;



                            cmd.Parameters.AddWithValue("@id_conto", identificador);
                            cmd.Parameters.AddWithValue("@cd_email", item);
                            var row = cmd.ExecuteNonQuery();
                        }




                    }


                    foreach (var item in listaTelefone)
                    {
                        using (SqlCommand cmd = new SqlCommand(DbCommand.SP_CRIAR_CONTATO_TELEFONE, conexaoDataBase))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;



                            cmd.Parameters.AddWithValue("@id_conto", identificador);
                            cmd.Parameters.AddWithValue("@cd_celular", item);
                            var row = cmd.ExecuteNonQuery();
                        }




                    }



                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método para exibir o detalhe de um Contato
        public List<ContatoDetalheViewModel> Detalhe(int id)
        {
            List<ContatoDetalheViewModel> lista = new List<ContatoDetalheViewModel>();


            ContatoDetalheViewModel contatoDetalheViewModel;

            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();

                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_LISTAR_CONTATO_TELEFONE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_conto", id);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            contatoDetalheViewModel = new ContatoDetalheViewModel();
                            contatoDetalheViewModel.ID_CONTO = Convert.ToInt32(exc.GetValue(0).ToString());
                            contatoDetalheViewModel.CD_CONTO_NOME = exc.GetValue(1).ToString();
                            contatoDetalheViewModel.CD_CONTO_SOBRENOME = exc.GetValue(2).ToString();
                            contatoDetalheViewModel.CD_TEL = exc.GetValue(3).ToString();

                            lista.Add(contatoDetalheViewModel);
                        }

                        exc.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_LISTAR_CONTATO_EMAIL, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_conto", id);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            contatoDetalheViewModel = new ContatoDetalheViewModel();
                            contatoDetalheViewModel.CD_CONTO_NOME = exc.GetValue(0).ToString();
                            contatoDetalheViewModel.CD_CONTO_SOBRENOME = exc.GetValue(1).ToString();
                            contatoDetalheViewModel.CD_EMAIL = exc.GetValue(2).ToString();
                            contatoDetalheViewModel.ID_EMAIL = Convert.ToInt32(exc.GetValue(3).ToString());
                            lista.Add(contatoDetalheViewModel);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lista;

        }



        //Método para Listar todos os Contatos cadastrados
        public List<ContatoViewModel> listarContato()
        {


            List<ContatoViewModel> lista = new List<ContatoViewModel>();


            ContatoViewModel contatoEmail;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();

                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_LISTAR_CONTATO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            contatoEmail = new ContatoViewModel();
                            contatoEmail.ID = Convert.ToInt32(exc.GetValue(0).ToString());
                            contatoEmail.NomeContato = exc.GetValue(1).ToString();
                            contatoEmail.SobreNome = exc.GetValue(2).ToString();
                            lista.Add(contatoEmail);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }


        //Método para Excluir um contato
        public void excluirContato(int idConto)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_EXCLUIR_CONTATO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idConto", idConto);

                        var i = cmd.ExecuteNonQuery();


                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void editarContato(int id, TB_CONTATOVIEWMODEL tB_CONTATOVIEWMODEL, ICollection<TB_TELEFONEVIEWMODEL> tB_TELEFONEVIEWMODELs, ICollection<TB_EMAILVIEWMODEL> tB_EMAILVIEWMODELs)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_EDITAR_CONTATO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idConto", id);
                        cmd.Parameters.AddWithValue("@conto_nome", tB_CONTATOVIEWMODEL.CD_CONTO_NOME);
                        cmd.Parameters.AddWithValue("@contoSobrenome", tB_CONTATOVIEWMODEL.CD_CONTO_SOBRENOME);
                        var i = cmd.ExecuteNonQuery();


                    }
                    foreach (var item in tB_TELEFONEVIEWMODELs)
                    {
                        using (SqlCommand cmd = new SqlCommand(DbCommand.SP_EDITAR_CONTATO_TELEFONE, conexaoDataBase))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@idConto", id);
                            cmd.Parameters.AddWithValue("@idTelefone", item.ID_TEL);                            
                            cmd.Parameters.AddWithValue("@cd_telefone", item.CD_TEL);
                            var i = cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }


                    }
                    foreach (var item in tB_EMAILVIEWMODELs)
                    {
                        using (SqlCommand cmd = new SqlCommand(DbCommand.SP_EDITAR_CONTATO_EMAIL, conexaoDataBase))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@idConto", id);
                            cmd.Parameters.AddWithValue("@idEmail", item.ID_EMAIL);
                            cmd.Parameters.AddWithValue("@cd_email", item.CD_EMAIL);
                            var i = cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }



                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ContatoEditarViewModel exibirContatoViewModel(int ID_CONTO)
        {
            ContatoEditarViewModel contatoEditarViewModel = new ContatoEditarViewModel();
            List<TB_TELEFONEVIEWMODEL> listaTelefone = new List<TB_TELEFONEVIEWMODEL>();
            List<TB_EMAILVIEWMODEL> listaEmail = new List<TB_EMAILVIEWMODEL>();
            TB_CONTATOVIEWMODEL contato = new TB_CONTATOVIEWMODEL();

            TB_TELEFONEVIEWMODEL tbTelefoneViewModel;
            TB_EMAILVIEWMODEL tbEmailViewModel;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();

                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_EXIBIR_CONTATO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_conto", ID_CONTO);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {

                            contato.ID_CONTO = Convert.ToInt32(exc.GetValue(0).ToString());
                            contato.CD_CONTO_NOME = exc.GetValue(1).ToString();
                            contato.CD_CONTO_SOBRENOME = exc.GetValue(2).ToString();

                        }

                        exc.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_LISTAR_CONTATO_TELEFONE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_conto", ID_CONTO);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            tbTelefoneViewModel = new TB_TELEFONEVIEWMODEL();
                            tbTelefoneViewModel.CD_TEL = exc.GetValue(3).ToString();
                            tbTelefoneViewModel.ID_TEL = Convert.ToInt32(exc.GetValue(4).ToString());
                            listaTelefone.Add(tbTelefoneViewModel);
                        }

                        contato.TB_TELEFONEVIEWMODEL = listaTelefone;

                        exc.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand(DbCommand.SP_LISTAR_CONTATO_EMAIL, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_conto", ID_CONTO);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            tbEmailViewModel = new TB_EMAILVIEWMODEL();
                            tbEmailViewModel.CD_EMAIL = exc.GetValue(2).ToString();
                            tbEmailViewModel.ID_EMAIL = Convert.ToInt32(exc.GetValue(3).ToString());                         listaEmail.Add(tbEmailViewModel);
                        }

                        contato.TB_EMAILVIEWMODEL = listaEmail;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            contatoEditarViewModel.TB_TELEFONEVIEWMODEL = listaTelefone;
            contatoEditarViewModel.TB_EMAILVIEWMODEL = listaEmail;
            contatoEditarViewModel.TB_CONTATOVIEWMODEL = contato;

            return contatoEditarViewModel;
        }
    }
}