using AlcoholProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AlcoholProject.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {
        ObservableCollection<Alcohol> alcohols;
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

        private int position;
        public int Position
        {
            get
            {
                if (position != alcohols.IndexOf(selectedAlcohol))
                    return alcohols.IndexOf(selectedAlcohol);

                return position;
            }
            set
            {
                position = value;
                selectedAlcohol = alcohols[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedAlcohol));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = alcohols.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == alcohols.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }

        }

    }
}
