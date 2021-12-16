using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using Entities;
using GuardaTips.Views;
using Xamarin.Forms;

namespace GuardaTips.ViewModels
{
    public class TipsViewModel :BaseViewModel 
    {
        private ObservableCollection<TipModel> tips; 
        private readonly IDomain<TipModel> _domain;
        public ICommand CrearTipCommand { get; set; }
        public ICommand VerTipCommand { get; set; }
        public ICommand BorrarTipCommand { get; set; }
        public ObservableCollection<TipModel> Tips
        {
            get { return tips; }
            set
            {
                tips = value;
                OnPropertyChanged();
            }
        }

        public TipsViewModel(IDomain<TipModel> domain)
        {
            _domain = domain;

            CrearTipCommand = new Command(async () => await 
            App.Current.MainPage.Navigation.PushAsync(new CrearEditarTipView()));

            BorrarTipCommand = new Command<TipModel>(async (x) =>
            { 
                await _domain.DeleteItemAsync(x);
                ObtenerTips();
            });

            VerTipCommand = new Command<TipModel>(async (x) =>
            {
                VerTipViewModel.Tip = x;
                await App.Current.MainPage.Navigation.PushAsync(new VerTipView());                
            });
            ObtenerTips();
        }

        public async Task ObtenerTips()
        {
            Tips = new ObservableCollection<TipModel>(await _domain.GetItemsAsync());
        }
    }
}
