using Domain;
using Entities;
using GuardaTips.Services;
using GuardaTips.ViewModels;
using GuardaTips.Views;
using Infrastructure;
using System;
using Xamarin.Forms;

namespace GuardaTips
{
    public partial class App : Application 
    {
        private static string dbPath;
        
        public App()
        {
            InitializeComponent();
            dbPath = GetDbPath();
            ApiDbContext.dbPath = dbPath;
            Startup.Init();
            MainPage = new NavigationPage(new TipsView());            
        }

        public string GetDbPath()
        {
            return DependencyService.Get<IFileHelper>().GetLocalFilePath("tipsdb.db");
        }
       
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
