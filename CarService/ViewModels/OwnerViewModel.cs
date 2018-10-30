using CarService.Models;

namespace CarService.ViewModels
{
    public class OwnerViewModel : ViewModelBase
    {
        private Owner _model;
        public Owner Model { get => _model; }

        public string Driverlicense
        {
            get => _model.Driverlicense;
            set
            {
                _model.Driverlicense = value;
                Raise();
            }
        }

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

        public OwnerViewModel()
        {
        }

        public OwnerViewModel(Owner model)
        {
            _model = model;
        }
    }
}