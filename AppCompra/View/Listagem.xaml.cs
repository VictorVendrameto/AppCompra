using AppCompras.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listagem : ContentPage
    {
        ObservableCollection<Produto> list_prod = new ObservableCollection<Produto>();
        public Listagem()
        {
            InitializeComponent();

   
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = list_prod.Sum(i => i.preco * i.quant);

            string msg = "O total da compra é: " + soma;

            DisplayAlert("Eita!", msg, "OK");
        }

        
        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new NewProd());
            }
            catch (Exception ex)
            {
                DisplayAlert("Eita!", ex.Message, "OK");
            }
            
        
        }

        protected override void OnAppearing()
        {
            if (list_prod.Count == 0)
            {

                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Produto> temp = await App.Database.getAll();

                    foreach (Produto item in temp)
                    {
                        list_prod.Add(item);
                    }

                    ref_carregando.IsRefreshing = false;
                });
            }
            list_produto.ItemsSource = list_prod;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Produto prod_select = (Produto)disparador.BindingContext;
            bool confirm = await DisplayAlert("Tem Certeza", "Remover Item?", "Sim", "Não");

            if(confirm)
            {
                await App.Database.delete(prod_select.id);

                list_prod.Remove(prod_select);
            }
        }

        private void txt_busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            string buscou = e.NewTextValue;
            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.search(buscou);

                list_prod.Clear();

                foreach (Produto item in temp)
                {
                    list_prod.Add(item);
                }

                ref_carregando.IsRefreshing = false;
            });
        }

        private void lst_prod_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new Edit
            {
                BindingContext = (Produto)e.SelectedItem
            });
        }
    }
}