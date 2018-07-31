using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Media.Core;
using HomeWork11.Commands;
using HomeWork11.Models.Crew;
using HomeWork11.Models.Departure;
using HomeWork11.Models.Flight;
using HomeWork11.Models.Plane;
using HomeWork11.Services;

namespace HomeWork11.ViewModels
{
    public class DepartureViewModel : CrudViewModelBase<Departure, EditableDepartureFields>
    {
        private ObservableCollection<Crew> _crews;
        private ObservableCollection<Flight> _flights;
        private ObservableCollection<Plane> _planes;

        public ObservableCollection<Crew> Crews
        {
            get { return _crews; }
            set
            {
                if (_crews != value)
                {
                    _crews = value;
                    OnPropertyChanged(nameof(Crews));
                }
            }
        }

        public ObservableCollection<Flight> Flights
        {
            get { return _flights; }
            set
            {
                if (_flights != value)
                {
                    _flights = value;
                    OnPropertyChanged(nameof(Flights));
                }
            }
        }

        public ObservableCollection<Plane> Planes
        {
            get { return _planes;}
            set
            {
                if (_planes != value)
                {
                    _planes = value;
                    OnPropertyChanged(nameof(Flights));
                }
            }
        }

        public DepartureViewModel() : base ("departures")
        {
            CreateEntity.DepartureDate = DateTime.Now;
        }

        protected override EditableDepartureFields ConvertToUpdateObject(Departure entity)
        {
            return new EditableDepartureFields()
            {
                DepartureDate = entity.DepartureDate,
                CrewId = entity.Crew.Id,
                FlightId = entity.Flight.Id,
                PlaneId = entity.Plane.Id
            };
        }

        protected override async Task InitializeData()
        {
            var crewService = new WebApiEntityService<Crew, EditableCrewFields>("crews");
            var flightService = new WebApiEntityService<Flight, EditableFlightFields>("flights");
            var planeService = new WebApiEntityService<Plane, EditablePlaneFields>("planes");
            Planes = new ObservableCollection<Plane>(await planeService.GetAll());
            Crews = new ObservableCollection<Crew>(await crewService.GetAll());
            Flights = new ObservableCollection<Flight>(await flightService.GetAll());
            OnPropertyChanged(nameof(SelectedEntity));
        }
    }
}