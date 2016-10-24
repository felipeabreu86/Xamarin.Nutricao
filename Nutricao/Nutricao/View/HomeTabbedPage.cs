using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace Nutricao
{
    public class HomeTabbedPage : TabbedPage
    {
        protected SQLiteConnection con = null;
        protected RefeicaoDAO dao = null;
        protected CadastroRefeicao telaCadastroRefeicao = null;
        protected ListaRefeicoes telaListaRefeicoes = null;

        /// <summary>
        /// Carrega a tela com abas
        /// </summary>
        public HomeTabbedPage()
        {
            InicializarAtributosDaClasse();
            InserirAbasDaPagina();
        }

        /// <summary>
        /// Inicializa os atributos da classe HomeTabbedPage
        /// </summary>
        private void InicializarAtributosDaClasse()
        {
            con = DependencyService.Get<ISqlite>().GetConnecticon();
            dao = new RefeicaoDAO(con);
            telaCadastroRefeicao = new CadastroRefeicao(dao);
            telaListaRefeicoes = new ListaRefeicoes(dao);
        }

        /// <summary>
        /// Insere as paginas como abas
        /// </summary>
        private void InserirAbasDaPagina()
        {
            this.Children.Add(telaCadastroRefeicao);
            this.Children.Add(telaListaRefeicoes);
        }
    }
}