using CarService.Models;

namespace CarService.ViewModels
{
    public class OrderQualificationViewModel : ViewModelBase
    {
        private OrderQualification _model;
        public OrderQualification Model { get => _model; }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                Raise();
            }
        }

        public OrderQualificationViewModel()
        {
        }

        public OrderQualificationViewModel(OrderQualification model)
        {
            _model = model;
        }
    }
}