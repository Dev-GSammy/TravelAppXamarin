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

            var assembly = typeof(MainPage);

            MainIcon.Source = ImageSource.FromResource("TravelAppXamarin.Assets.Images.plane.png", assembly);

        }
        /// <summary>
        /// This marks the temporary suspension of my work on this project. Eduardo took a quite shocking turn when he 
        /// started teaching so fast and not explaining his actions. using classes and interfaces even I don't understand.
        /// In any case, I promise to be back to refactor the code. Use the MVVM pattern, make the app better and
        /// conclude my work here once and for all. Thanks for the time spent on the TravelAppXamarin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
 