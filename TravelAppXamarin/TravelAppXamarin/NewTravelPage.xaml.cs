using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAppXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelAppXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }
        //The line below is for the event handler of the button created.
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //the object created is used to pass and create a new table titled post into the database. with the column experience
            //The id is created automatically since we already made it autoincrement
            Post post = new Post()
            {
                Experience = ExperienceEntry.Text
            };
            bool ifempty = string.IsNullOrEmpty(ExperienceEntry.Text);
            //The following lines first creates a connection to the database location already called.
            //The next line creates the table with the column name as the type. The third line inserts the rows and the we close the connection.
            if (ifempty)
            {
                DisplayAlert("Empty entry","Your entry box is empty, please write your experience","Ok");
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);
                    if (rows > 0)
                        DisplayAlert("New Row Insert", "New Insert Successful", "Ok");
                    else
                        DisplayAlert("New Row Insert", "Insert Unsuccessful", "Ok");
                    ExperienceEntry.Text = "";
                }
            }
        }
    }
}