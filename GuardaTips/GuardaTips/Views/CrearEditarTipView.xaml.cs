using GuardaTips.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuardaTips.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearEditarTipView : ContentPage
    {
        public CrearEditarTipView()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<CrearEditarTipViewModel>();
        }
    }
}