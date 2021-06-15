using AlcoholProject.Model;
using AlcoholProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlcoholProject.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            alcohols = GetAlcohols();
        }

        ObservableCollection<Alcohol> alcohols
            ;
        public ObservableCollection<Alcohol> Alcohols

        {
            get { return alcohols; }
            set
            {
                alcohols = value;
                OnPropertyChanged();
            }
        }

        private Alcohol selectedAlcohol;
        public Alcohol SelectedAlcohol
        {
            get { return selectedAlcohol; }
            set
            {
                selectedAlcohol = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayAlcohol);

        private void DisplayAlcohol()
        {
            if (selectedAlcohol != null)
            {
                var viewModel = new DetailsViewModel { SelectedAlcohol = selectedAlcohol, Alcohols = alcohols, Position = alcohols.IndexOf(selectedAlcohol) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Alcohol> GetAlcohols()
        {
            return new ObservableCollection<Alcohol>
            {
                new Alcohol { Name = "RUM", Price = 129.99f, Image = "rum.jpg", Description = "Whether by land or by sea, rum is the perfect partner to a day of fun in the sun. But festive tropical beverages can take a lot out of you."},
                new Alcohol { Name = "GIN", Price = 69.99f, Image = "gin.jpg", Description = "The whole point of gin is that it is infused with delicious botanicals. Most of the gin options which may be available in your budget at the local liquor store just taste like alcohol."},
                new Alcohol { Name = "VODKA", Price = 67.99f, Image = "vodka.jpg", Description = "You want quality, you get quality. Drink some vodka!"},
                new Alcohol { Name = "BEER", Price = 23.99f, Image = "beer.jpg", Description = "The Beer Bat by Maryland Workshop is the perfect addition to any home, kitchen, bar or man cave. A fun fathers day gift for dad."},
                new Alcohol { Name = "CHAMPAGNE", Price = 39.99f, Image = "champagne.jpg", Description = "Champagne flute is perfect for catered events, parties, bars, nightclubs or any other event where you require an economical alternative to permanent glassware."},
                new Alcohol { Name = "TEQUILA", Price = 19.99f, Image = "tequila.jpg", Description = "AN ABSOLUTE MUST FOR THE CONNOISSEUR AND SAVANT: Every bar should have this impressive display decanter and glasses."}
            };
        }
    }
}
