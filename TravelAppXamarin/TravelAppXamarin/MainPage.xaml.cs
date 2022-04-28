using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelAppXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Submitbtn_Clicked(object sender, EventArgs e)
        {
            bool isName = string.IsNullOrEmpty(NameEntry.Text);
            bool isPassword = string.IsNullOrEmpty(Password.Text);
             if (isName || isPassword)
            {
                NameEntry.Text = "You didn't fill all fields. Try Again!!!";
                Password.Text = "You are welcome";
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            } 
        }
    }
}
