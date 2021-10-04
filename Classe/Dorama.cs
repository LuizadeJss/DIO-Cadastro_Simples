using System;

namespace Cadastro // tirando o .classe(nome da pasta, é possivel que todos os arquivos do programa acessem essa classe) 
{
    public class Dorama : ClasseBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}
        //Metodos
      public Dorama (int id, Genero genero, string titulo, string descricao, int ano, bool excluido )
       {
           this.Id = id; //dentro da "ClasseBase"
          this.Genero = genero;
          this.Titulo = titulo;
          this.Descricao = descricao;
          this.Ano = ano;
          this.Excluido = excluido;
       }
       public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;// ve se o dorama esta incluido
			
            return retorno;
		}
        public Genero ReGenero()
        {
             return this.Genero;
        }
        public string ReTitulo()
        {
            return this.Titulo;
        }
        public int ReAno()
		{
          return this.Ano;
		}
        public string ReDes()
        {
            return this.Descricao;
        }
        public int ReId()
        {
            return this.Id;
        }

        public bool ReExcluido()
        {
            return this.Excluido;
        }  
        public void Excluir()
        {
            this.Excluido = true;
        }     
         
    }
}