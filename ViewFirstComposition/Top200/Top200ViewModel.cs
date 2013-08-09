using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;

namespace ViewFirstComposition
{
    public class Top200ViewModel : INotifyPropertyChanged
    {
        readonly FilmRepository _repository;
        readonly Func<FilmViewModel> _factory;
        readonly ObservableCollection<FilmViewModel> _films = new ObservableCollection<FilmViewModel>();
        readonly DelegateCommand _refreshCommand;

        internal Top200ViewModel() { } // for WPF designer

        public Top200ViewModel(FilmRepository repository, Func<FilmViewModel> factory)
        {
            _repository = repository;
            _factory = factory;
            _refreshCommand = new DelegateCommand(_ => Refresh());
        }

        async Task Refresh()
        {
            Films.Clear();

            var top200 = await _repository.GetTop200();
            top200.Select(ToViewModel).Foreach(Films.Add);
        }

        FilmViewModel ToViewModel(Film film)
        {
            var vm = _factory();
            Mapper.DynamicMap(film, vm);
            return vm;
        }

        public ObservableCollection<FilmViewModel> Films
        {
            get { return _films; }
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

        public ICommand RefreshTop200
        {
            get { return _refreshCommand; }
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
