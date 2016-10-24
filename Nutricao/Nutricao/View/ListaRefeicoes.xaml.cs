using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Nutricao
{
    public partial class ListaRefeicoes : ContentPage
    {
        public ObservableCollection<Refeicao> Refeicoes { get; set; }
        public RefeicaoDAO Dao { get; set; }

        public ListaRefeicoes(RefeicaoDAO Dao)
        {
            BindingContext = this;
            this.Dao = Dao;
            Refeicoes = this.Dao.ListaRefeicoes;
            InitializeComponent();
        }

        /// <summary>
        ///     Realiza uma ação ao clicar em um item da Lista de Refeições
        ///     Remove o Item da Lista de Refeições
        /// </summary>
        /// <param name="sender">Objeto que executou o evento</param>
        /// <param name="e">Argumentos do evento</param>
        public async void AcaoItem(object sender, ItemTappedEventArgs e)
        {
            Refeicao refeicao = e.Item as Refeicao;
            var resposta = await DisplayAlert("Remover Item", "Deseja remover a refeição " + refeicao.Descricao + "?", "Sim", "Não");
            if (resposta)
            {
                Dao.Remove(refeicao);
                await DisplayAlert("Remover Item", "Refeição " + refeicao.Descricao + " removida com sucesso!", "OK");
            }                
        }
    }
}
