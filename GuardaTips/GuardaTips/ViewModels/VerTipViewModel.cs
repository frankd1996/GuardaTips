using Domain;
using Entities;
using GuardaTips.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuardaTips.ViewModels
{
    public class VerTipViewModel:BaseViewModel
    {
        //private TipModel tip;
        public ICommand EditarTipCommand { get; set; }
        public IDomain<TipModel> _domain { get; set; }
        public static TipModel Tip { get; set; }    
        private DateTime fechaActualizacion;
        private DateTime fechaCreacion;
        private string titulo;
        private string descripcion;
        //public TipModel Tip
        //{
        //    get { return tip; }
        //    set
        //    {
        //        tip = value;
        //        OnPropertyChanged();
        //    }
        //}

        public DateTime FechaActualizacion
        {
            get { return fechaActualizacion; }
            set
            {
                fechaActualizacion = value;
                OnPropertyChanged();
            }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set
            {
                fechaCreacion = value;
                OnPropertyChanged();
            }
        }
        public string Titulo
        {
            get { return titulo; }
            set
            {
                titulo = value;
                OnPropertyChanged();
            }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }
        public VerTipViewModel(IDomain<TipModel> domain)
        {
            _domain = domain;
            EditarTipCommand = new Command(async () =>
            {
                Tip.FechaActualizacion = FechaActualizacion;
                Tip.FechaCreacion = FechaCreacion;
                Tip.Titulo = Titulo;
                Tip.Descripcion = Descripcion;

                await _domain.SaveItemAsync(Tip);
                await App.Current.MainPage.Navigation.PushAsync(new TipsView());
            });
            FechaActualizacion = Tip.FechaActualizacion;
            FechaCreacion = Tip.FechaCreacion;
            Titulo = Tip.Titulo;
            Descripcion = Tip.Descripcion;
        }
    }
}
