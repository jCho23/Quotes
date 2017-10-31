using Xamarin.Forms;
using GreatQuotes.Data;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(QuoteViewModel quote)
        {
            BindingContext = App.MainViewModel.SelectedQuote;
            App.MainViewModel.SelectedQuote = null;
            InitializeComponent ();
        }
    }
}

