using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerioRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Listar()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}