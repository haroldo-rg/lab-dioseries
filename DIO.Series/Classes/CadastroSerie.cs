using System;
using System.Linq;

namespace DIO.Series
{
    public class CadastroSerie
    {
        private SerioRepositorio Repositorio;

        public CadastroSerie()
        {
            Repositorio = new SerioRepositorio();
        }

        public void Iniciar()
        {
            while(ObterOpcaoUsuario() != "X") {}
        }

        private string ObterOpcaoUsuario()
        {
            Console.Write(@"
DIO Séries ao seu dispor!!!
1 - Listar séries
2 - Inserir nova série
3 - Atualizar série
4 - Excluir série
5 - Visualizar série
C - Limpar tela
X - Sair

Informe a opção desejada: ");

            string opcao = Console.ReadLine().ToUpper();

            switch (opcao)
            {
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
                    VisualizarSerie();
                    break;
                
                case "C":
                    LimparTela();
                    break;
                
                case "X":
                    Sair();
                    break;
                
                default:
                    TratarOpcaoInvalida();
                    break;
            }

            return opcao;

        }

        private void ListarSeries()
        {
            Console.WriteLine("Lista de séries");

            var lista = Repositorio.Listar().Where(serie => serie.Excluido() == false).ToList();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine($"#ID {serie.RetornaId()} - {serie.RetornaTitulo()}");
            }
        }

        private void InserirSerie()
        {
            Serie serie = LerDadosSerie(null);
            Repositorio.Inserir(serie);

            Console.WriteLine($"Série {serie.RetornaId()} incluída com sucesso!");
        }

        private void AtualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            if(!VerificaExistenciaSerie(entradaId))
            {
                ExibeMensagemSerieInexistente(entradaId);
                return;
            }

            Serie serie = LerDadosSerie(entradaId);
            Repositorio.Atualizar(entradaId, serie);

            Console.WriteLine($"Série {entradaId} atualizada com sucesso!");
        }

        private void ExcluirSerie()
        {
            Console.Write("Digite o Id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            if(!VerificaExistenciaSerie(entradaId))
            {
                ExibeMensagemSerieInexistente(entradaId);
                return;
            }

            Repositorio.Excluir(entradaId);

            Console.WriteLine($"Série {entradaId} excluída com sucesso!");
        }

        private void VisualizarSerie()
        {
            Console.Write("Digite o Id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            if(!VerificaExistenciaSerie(entradaId))
            {
                ExibeMensagemSerieInexistente(entradaId);
                return;
            }

            Serie serie = Repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie.ToString());
        }

        private void LimparTela()
        {
            Console.Clear();
        }

        private void Sair()
        {
            Console.WriteLine("Obrigado por utilizar os nossos serviços.\n\n");
        }
        private Serie LerDadosSerie(int? id)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{ i.ToString().PadLeft(2, '0') } - { Enum.GetName(typeof(Genero), i) }");
            }

            Console.WriteLine();

            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine().Trim();

            Console.Write("Digite o Ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine().Trim();

            return new Serie( (id == null ? Repositorio.ProximoId() : (int)id) , (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
        }

        private void TratarOpcaoInvalida()
        {
            Console.WriteLine("Selecione uma opção válida.");
        }

        private bool VerificaExistenciaSerie(int id)
        {
            var listaSeries = Repositorio.Listar();

            return listaSeries.Count > 0 && id >= 0 && id < listaSeries.Count && !listaSeries[id].Excluido();
        }

        private void ExibeMensagemSerieInexistente(int numeroConta)
        {
            Console.WriteLine($"Série #{numeroConta} inexistente.");
        }
    }
}