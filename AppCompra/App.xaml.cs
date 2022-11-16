using AppCompras.Helper;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCompra
{
    public partial class App : Application
    {
        static SQLiteDB database;

        public static SQLiteDB Database
        {
            get
            {
                if(database == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "arquivo.db3"
                    );


                    database = new SQLiteDB(path);
                }
                return database; 
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Listagem());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
