using SQLite;
using System;
using System.Collections.ObjectModel;

namespace Nutricao
{
    public class RefeicaoDAO
    {
        private SQLiteConnection conexao;
        private ObservableCollection<Refeicao> listaRefeicoes;

        public ObservableCollection<Refeicao> ListaRefeicoes
        {
            get
            {
                if (listaRefeicoes == null)
                {
                    listaRefeicoes = GetAll();
                }
                return listaRefeicoes;
            }
            private set
            {
                listaRefeicoes = value;
            }
        }

        public RefeicaoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            conexao.CreateTable<Refeicao>();
        }

        public void Salvar(Refeicao refeicao)
        {
            conexao.Insert(refeicao);
            listaRefeicoes.Add(refeicao);
        }

        public void Remove(Refeicao refeicao)
        {
            conexao.Delete<Refeicao>(refeicao.ID);
            listaRefeicoes.Remove(refeicao);
        }

        private ObservableCollection<Refeicao> GetAll()
        {
            return new ObservableCollection<Refeicao> (conexao.Table<Refeicao>());
        }
    }
}