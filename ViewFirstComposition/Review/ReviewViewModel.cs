using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewFirstComposition
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        readonly Top200ViewModel _films;

        internal ReviewViewModel() { } // for WPF designer

        public ReviewViewModel(Top200ViewModel films)
        {
            _films = films;
            _selectedFilm = films.SelectedFilm;

            // Keep in sync with the selected film
            _films.PropertyChanged += (source, e) =>
            {
                if (e.PropertyName == "SelectedFilm")
                {
                    SelectedFilm = films.SelectedFilm;
                }
            };
        }

        FilmViewModel _selectedFilm;
        public FilmViewModel SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                if (_selectedFilm != value)
                {
                    _selectedFilm = value;
                    FirePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
