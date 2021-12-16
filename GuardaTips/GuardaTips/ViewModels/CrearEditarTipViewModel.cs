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
    public  class CrearEditarTipViewModel:BaseViewModel
    {
        private readonly IDomain<TipModel> _domain;
        public ICommand GuardarTipCommand { get; set; }
        private TipModel tip;
        private DateTime fechaActualizacion;
        private DateTime fechaCreacion;
        private string titulo;
        private string descripcion;
        public TipModel Tip
        {
            get { return tip; }
            set 
            { 
                tip = value; 
                OnPropertyChanged();
            }
        }
                
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

        public CrearEditarTipViewModel(IDomain<TipModel> domain)
        {
            _domain = domain;
            GuardarTipCommand = new Command(async() => await GuardarParametros());
            Tip = new TipModel();
        }

        public async Task GuardarParametros()
        {
            await Task.Run(() =>
            {
                Tip.FechaActualizacion = FechaActualizacion;
                Tip.Titulo = Titulo;
                Tip.Descripcion = Descripcion;
                Tip.FechaCreacion = FechaCreacion;
            });          

            await _domain.SaveItemAsync(Tip);
            await App.Current.MainPage.Navigation.PushAsync(new TipsView());
        }
    }
}
