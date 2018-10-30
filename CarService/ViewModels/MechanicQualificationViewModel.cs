using CarService.Models;

namespace CarService.ViewModels
{
    public class MechanicQualificationViewModel : ViewModelBase
    {
        private MechanicQualification _model;
        public MechanicQualification Model { get => _model; }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                Raise();
            }
        }

        public MechanicQualificationViewModel()
        {
        }

        public MechanicQualificationViewModel(MechanicQualification model)
        {
            _model = model;
        }
    }
}