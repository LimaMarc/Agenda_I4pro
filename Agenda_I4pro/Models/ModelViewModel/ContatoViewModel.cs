
namespace Agenda_I4pro.Models.ModelViewModel
{
    public class ContatoViewModel
	{

		private int _id;
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}



		private string _nomeContato;
		public string NomeContato
		{
			get { return _nomeContato; }
			set { _nomeContato = value; }
		}




		private string _sobreNome;
		public string SobreNome
		{
			get { return _sobreNome; }
			set { _sobreNome = value; }
		}


		
		public ContatoViewModel()
		{

		}
	}
}