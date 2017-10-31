using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GreatQuotes.Data;
using Xamarin.Forms;
using XamarinUniversity.Interfaces;

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

        public async Task OnAddQuote()
        {
            var newQuote = new QuoteViewModel();
            Quotes.Add(newQuote);
            SelectedQuote = newQuote;

            if (!DependencyService.Get<INavigationService>().CanGoBack)
            {
                await DependencyService.Get<INavigationService>()
                                   .NavigateAsync(AppPages.Edit, newQuote);
            }
        }

        public async Task OnEditQuote(QuoteViewModel quote)
        {
            SelectedQuote = quote;
            await DependencyService.Get<INavigationService>()
                .NavigateAsync(AppPages.Edit, quote);
        }

        public async Task OnDeleteQuote(QuoteViewModel quote)
        {
            bool result = await DependencyService.Get<IMessageVisualizerService>()
                .ShowMessage("Are you sure?",
                    "Are you sure you want to delete this quote from " + quote.Author + "?",
                    "Yes", "No");

            if (result == true)
            {
                int pos = Quotes.IndexOf(quote);
                Quotes.Remove(quote);
                if (SelectedQuote == quote)
                {
                    if (pos > Quotes.Count - 1)
                        pos = Quotes.Count - 1;
                    SelectedQuote = Quotes[pos];
                }
            }
        }
    }
}

