using System.Text;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool FoiExcluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.FoiExcluido = false;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.FoiExcluido = true;
        }

        public bool Excluido()
        {
            return this.FoiExcluido;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine($"Id: {this.Id}");
            retorno.AppendLine($"Genero: {this.Genero}");
            retorno.AppendLine($"Titulo: {this.Titulo}");
            retorno.AppendLine($"Descricao: {this.Descricao}");
            retorno.AppendLine($"Ano de inicio: {this.Ano}");
            retorno.AppendLine($"Excluído: {this.FoiExcluido}");

            return retorno.ToString();
        }
    }
}