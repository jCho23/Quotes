using System;
using System.Collections.Generic;
using GreatQuotes.Views;
using GreatQuotes.ViewModels;

using Xamarin.Forms;

namespace GreatQuotes.Views
{
    public partial class QuoteListPage : ContentPage
    {
        public QuoteListPage()
        {
            BindingContext = App.MainViewModel;
            InitializeComponent ();
        }

        void OnQuoteSelected(object sender, ItemTappedEventArgs e)
        {
            QuoteViewModel quote = (QuoteViewModel)e.Item;
            Navigation.PushAsync(new QuoteDetailPage(quote), true);
        }
    }
}

