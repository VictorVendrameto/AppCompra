using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCompras.Model;

namespace AppCompra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProd : ContentPage
    {
        public NewProd()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                   desc = txt_desc.Text,
                   quant = Convert.ToDouble(txt_quant.Text),
                   preco = Convert.ToDouble(txt_preco.Text),
                };
                await App.Database.insert(p);

                await DisplayAlert("Sucesso!", "Produto Cadastrado", "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Eita!", ex.Message, "OK");
            }
        }
    }
}