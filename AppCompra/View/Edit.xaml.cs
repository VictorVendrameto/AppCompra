using AppCompras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompra.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit : ContentPage
    {
        public Edit()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto prod_anex = BindingContext as Produto;

                Produto p = new Produto
                {
                    
                    //id = ((Produto) BindingContext).id,
                    id = prod_anex.id,
                    desc = txt_desc.Text,
                    quant = Convert.ToDouble(txt_quant.Text),
                    preco = Convert.ToDouble(txt_preco.Text),
                };
                await App.Database.update(p);

                await DisplayAlert("Sucesso!", "Produto Editado", "OK");

                await Navigation.PushAsync(new Listagem());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Eita!", ex.Message, "OK");
            }
        }
    }
}