using Day2AppList.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Day2AppList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        private List<Cart> Cartlist { get; set; }
        private List<Cart> Cartlist1 { get; set; }
        private int _CIndex { get; set; }
        private List<int> _Ctdex { get; set; }
        public SecondPage(List<Cart> lEmp)
        {
            InitializeComponent();
            Cartlist= lEmp;
            CartsList.ItemsSource = Cartlist;
            Cartlist1 = new List<Cart>();
            _Ctdex = new List<int>();
        }

        async void Buttons_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }


        private void Buttone_Clicked(object sender, EventArgs e)

        {
            if (Cartlist[_CIndex].CartTickImg.Equals("check.png"))
            {
                _Ctdex.Add(_CIndex);
            }
                foreach (var er in _Ctdex)
            {
                try
                {
                    if (Cartlist.IndexOf(Cartlist[er]) != -1)
                    {
                        Cartlist.RemoveAt(er);
                    }
                }
                catch (Exception)
                {

                    DisplayAlert("Status","Cart is Empty Now","OK","Cancel");
                } 
                
              
            }
            _Ctdex.Clear();
            CartsList.ItemsSource = null;
            CartsList.ItemsSource = Cartlist;
        }

        private void CartsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _CIndex = Cartlist.IndexOf((Cart)e.SelectedItem);
            if (Cartlist[_CIndex].CartTickImg.Equals("uncheck.png"))
            {
              
                Cartlist[_CIndex].CartTickImg = "check.png";

            }
            else {
                Cartlist[_CIndex].CartTickImg = "uncheck.png";
            }
            CartsList.ItemsSource = null;
            CartsList.ItemsSource = Cartlist;
        }
    }
}