using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nutricao
{
    public partial class CadastroRefeicao : ContentPage
    {
        /// <summary>
        ///     Altera o contexto de Binding do CadastroRefeicao.xaml para
        ///     a View Model CadastroRefeicaoViewModel
        /// </summary>
        /// <param name="dao">Instâncida de RefeicaoDAO</param>
        public CadastroRefeicao(RefeicaoDAO dao)
        {
            CadastroRefeicaoViewModel vm = new CadastroRefeicaoViewModel(dao, this);
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
