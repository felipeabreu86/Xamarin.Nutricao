using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nutricao
{
    public class App : Application
    {
        /// <summary>
        ///     Carrega a página principal da aplicação
        /// </summary>
        public App()
        {
            MainPage = new HomeTabbedPage();
        }

        /// <summary>
        ///     Handle when your app starts
        /// </summary>
        protected override void OnStart()
        {
            
        }

        /// <summary>
        ///     Handle when your app sleeps
        /// </summary>
        protected override void OnSleep()
        {
            
        }

        /// <summary>
        ///     Handle when your app resumes
        /// </summary>
        protected override void OnResume()
        {
            
        }
    }
}