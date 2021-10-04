using System;

namespace Cadastro
{
    class Program
    {
        static DoramaReposi repo = new();
        static void Main(string[] args)
        {
            string opcaoUsu = ObOpcaoUsua();

            while (opcaoUsu.ToUpper() != "X")
            {
                switch (opcaoUsu)
                {
                    case "1":
                      ListarDorama();
                    break;
                    
                    case "2":
                      InserirDorama();
                    break;
                    
                    case "3":
                      AtualizarDorama();
                    break;

                    case "4":
                      ExcluirDorama();
                    break;
                    
                    case "5":
                      VisuDorama();
                    break;
                    
                    case "L":
                      Console.Clear();
                    break;

                    default:
                     throw new ArgumentOutOfRangeException();
                } 
                opcaoUsu = ObOpcaoUsua();
            }
            Console.WriteLine("Volte sempre :)");
        }
        private static void ListarDorama()
        {
            Console.WriteLine("LISTAR DORAMAS");
          
            var lista = repo.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum domara cadastrado.");
                return ;
            }
            foreach (var Dorama in lista)
            {
               if(Dorama.ReExcluido() == true)
               
                Console.WriteLine("#ID {0}: - {1} (NÃO DISPONÍVEL)", Dorama.ReId(), Dorama.ReTitulo());
               
               else
                Console.WriteLine("#ID {0}: - {1}", Dorama.ReId(), Dorama.ReTitulo());
            }
        }

        private static void InserirDorama()
        {
           Console.WriteLine("INSERIR NOVA SÉRIE");
           Console.WriteLine();
           foreach(int i in Enum.GetValues(typeof(Genero)))
           {
             Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
           } 
           Console.WriteLine();  
           Console.WriteLine("Digite o gênero entre as opções acima: ");
           int entradaGene = int.Parse(Console.ReadLine());
           Console.WriteLine();

           Console.WriteLine("Digite Título do Dorama: ");
           string entradaTitu = Console.ReadLine();
           Console.WriteLine();
           
           Console.WriteLine("Digite o ano de início do Dorama: ");
           int entradaAno = int.Parse(Console.ReadLine());
           Console.WriteLine();

           Console.WriteLine("Digite a descrição do Dorama: ");
           string entradaDes = Console.ReadLine();
           Console.WriteLine();
           
           Dorama novaDorama = new(id: repo.ProId(),
                                       genero: (Genero)entradaGene,
                                       titulo: entradaTitu,
                                       ano: entradaAno,
                                       descricao: entradaDes,
                                       excluido: false);
                              
           repo.Insere(novaDorama);
           Console.WriteLine("DORAMA INSERIDO COM SUCESSO!");
        }

        private static void AtualizarDorama()
        {
            string r;
          int entradaGenero;
          string entradaTitu;
          int entradaAno;
          string entradaDes;
          var Dorama = repo.Lista();

          Console.WriteLine("Digite o Id da Dorama que deseja alterar: ");
          int indiceDorama = int.Parse(Console.ReadLine());
         
          Console.WriteLine("O gênero deste dorama é: {0}. Deseja alterar?", Dorama[indiceDorama].ReGenero()); //GENERO
          r = Console.ReadLine().ToUpper();
          if(r == "S")
          {
            foreach (int i in Enum.GetValues(typeof(Genero)))
             {
             Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
             }             
             Console.WriteLine("Digite o novo Gênero entre as opções acima: "); 
              entradaGenero = int.Parse(Console.ReadLine());
          }
          else
          {
              entradaGenero = (int)Dorama[indiceDorama].ReGenero();          
          }

           Console.WriteLine();
           Console.WriteLine("O Titulo desse Dorama é: {0}. Deseja alterar? ", Dorama[indiceDorama].ReTitulo());
             r = Console.ReadLine().ToUpper();
          if(r == "S")
          {
           Console.WriteLine("Digite novo Título do Dorama: ");// TITULO
           entradaTitu = Console.ReadLine();
          }
          else
          {
            entradaTitu = Dorama[indiceDorama].ReTitulo();
          }
           Console.WriteLine();

           Console.WriteLine("O Ano de início desse Dorama é: {0}. Deseja alterar? ", Dorama[indiceDorama].ReAno());// ANO
             r = Console.ReadLine().ToUpper();
          if(r == "S")
          {
             Console.WriteLine("Digite o novo Ano de início desse Dorama: ");
            entradaAno = int.Parse(Console.ReadLine()); 
          }
          else 
          {
            entradaAno = Dorama[indiceDorama].ReAno();
          }
           Console.WriteLine();

           Console.WriteLine("A descrição desse Dorama é: {0}. Deseja alterar? ", Dorama[indiceDorama].ReDes());// DESCRICAO
            r = Console.ReadLine().ToUpper();
             if(r == "S")
          {
             Console.WriteLine("Digite a nova Descricao desse Dorama: ");
            entradaDes = Console.ReadLine(); 
          }
          else 
          {
            entradaDes = Dorama[indiceDorama].ReDes();
          }          
            
           Console.WriteLine("O status de excluido desse Dorama é: {0}. Deseja alterar?",Dorama[indiceDorama].ReExcluido());
            r = Console.ReadLine().ToUpper(); 
           bool entradaExcluido;

          if(r == "S")
          {
           Console.WriteLine("Digite novo status: ");
             entradaExcluido = bool.Parse(Console.ReadLine());
             Console.WriteLine();
          }
          else
          {
            entradaExcluido = Dorama[indiceDorama].ReExcluido();
          }
           Dorama atualizaDorama = new(id: indiceDorama,
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitu,
                                       ano: entradaAno,
                                       descricao: entradaDes,
                                       excluido: entradaExcluido);
          

           repo.Atualiza(indiceDorama, atualizaDorama);
           Console.WriteLine("DORAMA ATUALIZADO");
        }
        private static void ExcluirDorama()
        {
          Console.WriteLine("EXCLUSÃO DE DORAMA");
          Console.WriteLine("Insira o Id do dorama que deseja excluir: ");
          int indiceDorama = int.Parse(Console.ReadLine());

          repo.Exclui(indiceDorama);
          Console.WriteLine("DORAMA EXCLUÍDO COM SUCESSO");
        }

        private static void VisuDorama()
        {
           Console.WriteLine("VISUALIZAR DORAMAS");
           Console.WriteLine("Digite o Id do dorama que deseja visualizar: ");
           int indiceDorama = int.Parse(Console.ReadLine());

           var Dorama = repo.ReId(indiceDorama);
           Console.WriteLine(Dorama);
           Console.WriteLine();
        }
        
        private static string ObOpcaoUsua()
        {
            Console.WriteLine();
            Console.WriteLine("DORAMAFLIX, AS SUAS ORDENS :)");
            Console.WriteLine("Informe a opção dejesada: ");

            Console.WriteLine("1. Listar Doramas");
            Console.WriteLine("2. Inserir nova Dorama");
            Console.WriteLine("3. Atualizar Dorama");
            Console.WriteLine("4. Excluir Dorama");
            Console.WriteLine("5. Visualizar Dorama");
            Console.WriteLine("L. Limpar a Tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string opcaoUsu = Console.ReadLine().ToUpper();
            
            Console.WriteLine();
            return opcaoUsu;
        }
    }
}
