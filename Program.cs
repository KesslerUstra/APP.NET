using System;

namespace APP.NET
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcao();
            while(opcao.ToUpper() != "X"){
                switch(opcao){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }
                opcao = ObterOpcao();
            }
            limpar();
            Console.WriteLine("Obrigado por usar o software");
        }

        private static void ExcluirSerie(){
            limpar();
            Console.WriteLine("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());
            if(teste(indice)){
                repositorio.Exclui(indice);
                Console.WriteLine("Serie excluida com sucesso !");
                return;
            }
            espaco();
            Console.WriteLine("Série não encontrada !");
            
        }

        private static void VizualizarSerie(){
            limpar();
            Console.WriteLine("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());
            if(!teste(indice)){
                espaco();
                Console.WriteLine("Série não encontrada");
                return;
            }
            var serie = repositorio.RetornaPorId(indice);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie(){
            limpar();
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            if(!teste(indiceSerie)){
                espaco();
                Console.WriteLine("Série não encontrada !");
                return;
            }
            espaco();
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            espaco();
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota da série:");
            double entradaNota = System.Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(Id:indiceSerie,genero: (Genero)entradaGenero,nota: entradaNota,titulo:entradaTitulo,ano: entradaAno,descricao:entradaDescricao);
            repositorio.Atualiza(indiceSerie,atualizarSerie);
            limpar();
        }

        private static void ListarSeries(){
            limpar();
            Console.WriteLine("-----------------Lista de Séries-----------------");
            espaco();
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista){
                if(!serie.retornaExcluido())
                    Console.WriteLine("{0} : {1}",serie.retornaId(),serie.retornaTitulo());
            }
            espaco();
        }

        private static void InserirSerie(){
            limpar();
            Console.WriteLine("Inserindo Série");
            espaco();
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota da série:");
            double entradaNota = System.Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.proximoId(),genero: (Genero)entradaGenero,nota: entradaNota,titulo:entradaTitulo,ano: entradaAno,descricao:entradaDescricao);
            repositorio.Insere(novaSerie);
            limpar();
        }

        private static string ObterOpcao(){
            Console.WriteLine();
            Console.WriteLine("------APP Séries------");
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1 -> Listar Séries");
            Console.WriteLine("2 -> Inserir nova série");
            Console.WriteLine("3 -> Atualizar série");
            Console.WriteLine("4 -> Excluir série");
            Console.WriteLine("5 -> Vizualizar série");
            Console.WriteLine("C -> Limpar Tela");
            Console.WriteLine("X -> Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        private static void limpar(){
            Console.Clear();
        }

        private static void espaco(){
            Console.WriteLine();
        }

        private static bool teste(int indice){
            try
            {
                repositorio.RetornaPorId(indice);
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }
    }
}
