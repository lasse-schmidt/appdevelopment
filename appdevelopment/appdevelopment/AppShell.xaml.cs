using appdevelopment.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace appdevelopment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
        }
    }
}
