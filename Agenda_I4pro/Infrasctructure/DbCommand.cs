


namespace Agenda_I4pro.Infrasctructure
{

    //Classe selada para não permitir a Herança. Somente a consulta das propriedades de leituras(Procedures)
    /// <summary>
    /// Classe responsável por armazenar todos os Objetos de Banco de Dados: Procedures, Views, Function, 
    /// LinkedServer e etc
    /// No nosso caso como estamos trabalhando com ADO.NET e nos comunicando com o Banco de Dado via Procedure
    /// essa classe armazena as Procedures do Banco de Dados Agenda
    /// </summary>
    public sealed class DbCommand
    {
        private DbCommand()
        {

        }

        //Conjunto de Procedures do Banco de Dados
        //O ideal é ter mapeada todas as procedures, view, function do banco de dados em um arquivo separado,
        //pois caso haja a necessidade de alterar a nomenclatura de uma procedure, nós alteramos em apenas um
        //único lugar. Evitando refatorar todo o código para alterar a chamadas de procedure.
        public static readonly string SP_CRIAR_CONTATO = "SP_CRIAR_CONTATO";
        public static readonly string SP_CRIAR_CONTATO_EMAIL = "SP_CRIAR_CONTATO_EMAIL";
        public static readonly string SP_CRIAR_CONTATO_TELEFONE = "SP_CRIAR_CONTATO_TELEFONE";
        public static readonly string SP_EXCLUIR_CONTATO = "SP_EXCLUIR_CONTATO";
        public static readonly string SP_LISTAR_CONTATO = "SP_LISTAR_CONTATO";
        public static readonly string SP_LISTAR_CONTATO_EMAIL = "SP_LISTAR_CONTATO_EMAIL";
        public static readonly string SP_LISTAR_CONTATO_TELEFONE = "SP_LISTAR_CONTATO_TELEFONE";
        public static readonly string SP_EDITAR_CONTATO = "SP_EDITAR_CONTATO";
        public static readonly string SP_EDITAR_CONTATO_EMAIL = "SP_EDITAR_CONTATO_EMAIL";
        public static readonly string SP_EDITAR_CONTATO_TELEFONE = "SP_EDITAR_CONTATO_TELEFONE";
        public static readonly string SP_EXIBIR_CONTATO = "SP_EXIBIR_CONTATO";

    }
}