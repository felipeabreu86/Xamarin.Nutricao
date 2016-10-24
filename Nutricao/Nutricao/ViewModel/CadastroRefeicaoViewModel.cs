using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nutricao
{
    public class CadastroRefeicaoViewModel : INotifyPropertyChanged
    {
        private string descricao;
        private double calorias;
        private RefeicaoDAO Dao;
        private ContentPage Page;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SalvaRefeicao { get; protected set; }

        /// <summary>
        /// Construtor da classe CadastroRefeicaoViewModel
        /// </summary>
        /// <param name="dao">Instância de RefeicaoDAO</param>
        /// <param name="page">Instância da View</param>
        public CadastroRefeicaoViewModel(RefeicaoDAO dao, ContentPage page)
        {
            this.Dao = dao;
            this.Page = page;
            ConfiguraComandoSalvaRefeicao();
        }

        /// <summary>
        /// Métodos Get e Set da propriedade descrição
        /// </summary>
        public string Descricao
        {
            get 
            { 
                return descricao;
            }
            set 
            {
                if (value != descricao)
                {
                    descricao = value;
                    OnPropertyChanged("Descricao");
                }
            }
        }

        /// <summary>
        /// Métodos Get e Set da propriedade calorias
        /// </summary>
        public double Calorias
        {
            get
            {
                return calorias;
            }
            set
            {
                if (value != calorias)
                {
                    calorias = value;
                    OnPropertyChanged("Calorias");
                }
            }
        }

        /// <summary>
        /// Indica para a View, através do envento PropertyChangedEventHandler, que 
        /// uma propriedade da tela foi atualizada
        /// </summary>
        /// <param name="nome">Nome da propriedade atualizada</param>
        private void OnPropertyChanged(string nome)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }

        /// <summary>
        /// Ação realizada ao clicar no botão Salvar
        /// Salva os valores Descrição e Calorias no BD
        /// Restaura valores originais na tela Cadastro Refeição
        /// </summary>
        public void ConfiguraComandoSalvaRefeicao()
        {
            SalvaRefeicao = new Command(() =>
            {
                if (IsCamposValidos(descricao, calorias))
                {
                    Refeicao refeicao = new Refeicao(descricao, calorias);
                    Dao.Salvar(refeicao);
                    string msg = "A refeição " + descricao + " de " + calorias + " calorias foi salva com sucesso!";
                    Page.DisplayAlert("Salvar Refeição", msg, "OK");
                    Clear();
                }
            });
        }

        /// <summary>
        /// Verifica se os campos da tela Cadastro Refeição são válidos
        /// </summary>
        /// <param name="descricao">Texto do campo Descrição</param>
        /// <param name="calorias">Valor do Slider Calorias</param>
        /// <returns></returns>
        public bool IsCamposValidos(string descricao, double qtdCalorias)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Page.DisplayAlert("Atenção!", "Preencha o campo Descrição.", "OK");
                return false;
            }
            else if (double.Equals(qtdCalorias, 0.0))
            {
                Page.DisplayAlert("Atenção!", "Escolha a quantidade de calorias.", "OK");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Restaura os valores iniciais das propriedades da tela
        /// </summary>
        public void Clear()
        {
            Descricao = string.Empty;
            Calorias = double.MinValue;
        }
    }
}