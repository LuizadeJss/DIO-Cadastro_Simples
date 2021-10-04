using System;
using System.Collections.Generic;
using Cadastro.Interface;

namespace Cadastro
{
    public class DoramaReposi : IRepo<Dorama> // tocar Dorama por dorama
    {
        private List<Dorama> listaDorama = new List<Dorama>(); // "banco de dados" na memoria

        public void Atualiza(int id, Dorama objeto)
		{
			listaDorama[id] = objeto;
		}

		public void Exclui(int id)
		{

			listaDorama[id].Excluir();
		}

		public void Insere(Dorama objeto)
		{
			listaDorama.Add(objeto);
			
		}

		public List<Dorama> Lista()
		{
			return listaDorama;
		}

		public int ProId()
		{
			return listaDorama.Count;
		}

		public Dorama ReId(int id)
		{
			return listaDorama[id];
		}
		
    }

}