using Xamarin.Forms;
using GreatQuotes.Data;
using GreatQuotes.ViewModels;
using System;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(QuoteViewModel quote)
        {
            InitializeComponent ();
        }

        async void OnDeleteQuote(object sender, EventArgs e)
        {
            var vm = DependencyService.Get<MainViewModel>();
            await vm.OnDeleteQuote(vm.SelectedQuote);
        }

        async void OnEditQuote(object sender, EventArgs e)
        {
            var vm = DependencyService.Get<MainViewModel>();
            await vm.OnEditQuote(vm.SelectedQuote);
        }
    }
}

