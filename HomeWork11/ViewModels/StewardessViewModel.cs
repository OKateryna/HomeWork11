using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Media.Core;
using HomeWork11.Models.Stewardess;
using HomeWork11.Services;

namespace HomeWork11.ViewModels
{
    public class StewardessViewModel : ViewModelBase
    {
        private readonly WebApiEntityService<Stewardess, EditableStewardessFields> _webApiEntityService;
        
        public ObservableCollection<Stewardess> Stewardesses { get; set; }
        private Stewardess _selectedStewardess;

        public Stewardess SelectedStewardess
        {
            get { return _selectedStewardess; }
            set
            {
                if (_selectedStewardess != value)
                {
                    _selectedStewardess = value;
                    OnPropertyChanged(nameof(SelectedStewardess));
                }
            }
        }

        public StewardessViewModel()
        {
            _webApiEntityService = new WebApiEntityService<Stewardess, EditableStewardessFields>("stewardesses");
            Stewardesses = new ObservableCollection<Stewardess>();
            Initialization = Initialize();
        }

        public async Task Initialize()
        {
            var stewardesses = await _webApiEntityService.GetAll();
            foreach (var stewardess in stewardesses)
            {
                Stewardesses.Add(stewardess);
            }
            await Task.Delay(100);
        }
    }
}