﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreatQuotes.Views
{
    public partial class QuoteListPage : ContentPage
    {
        public QuoteListPage()
        {
            BindingContext = new List<GreatQuote>(QuoteManager.Load());
            InitializeComponent();
        }

        void OnQuoteSelected(object sender, ItemTappedEventArgs e)
        {
            GreatQuote quote = (GreatQuote)e.Item;
            Navigation.PushAsync(new QuoteDetailPage(new QuoteViewModel(quote)), true);
        }
    }
}

