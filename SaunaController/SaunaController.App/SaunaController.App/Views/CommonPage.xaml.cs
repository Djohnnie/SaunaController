using SaunaController.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaunaController.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonPage : ContentPage
    {
        public CommonPage()
        {
            InitializeComponent();
            BindingContext = new CommonViewModel();
        }
    }
}