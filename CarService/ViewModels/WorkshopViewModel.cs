using CarService.Models;

namespace CarService.ViewModels
{
    public class WorkshopViewModel : ViewModelBase
    {
        private Workshop _model;
        public Workshop Model { get => _model; }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                Raise();
            }
        }
        public string Address
        {
            get => _model.Address;
            set
            {
                _model.Address = value;
                Raise();
            }
        }
        public string Phone
        {
            get => _model.Phone;
            set
            {
                _model.Phone = value;
                Raise();
            }
        }

        public WorkshopViewModel()
        {
        }

        public WorkshopViewModel(Workshop model)
        {
            _model = model;
        }
    }
}