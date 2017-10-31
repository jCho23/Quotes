using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GreatQuotes.Data;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<QuoteViewModel> Quotes { get; private set; }

		QuoteViewModel selectedQuote;
		public QuoteViewModel SelectedQuote
        {
            get
            {
                return selectedQuote;
            }

            set
            {
                SetPropertyValue(ref selectedQuote, value);    
            }
        }

        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(
                QuoteManager.Load()
                            .Select(q => new QuoteViewModel(q)));

        }

    }
}