using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelAppXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //The OnAppearing method calls reloads from the database every time the page is called.
            //The using directive is an Idisposable method that closes the connection to the database automatically when it's done being called
            ///The variable posts stores the items in the database and then the postlistview receives it as it's itemsource for display.
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                postListView.ItemsSource = posts;
            }
                
        }
    }
}