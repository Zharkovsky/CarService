using CarService.Models;

namespace CarService.ViewModels
{
    public class BrandViewModel : ViewModelBase
    {
        private Brand _model;
        public Brand Model { get => _model; }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                Raise();
            }
        }

        public BrandViewModel()
        {
        }

        public BrandViewModel(Brand model)
        {
            _model = model;
        }
    }
}