using CarService.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarService.ViewModels
{
    public class MechanicViewModel : ViewModelBase
    {
        private Mechanic _model;
        public Mechanic Model { get => _model; }

        public int Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
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
        public string MechanicQualificationName
        {
            get => _model.MechanicQualificationName;
            set
            {
                _model.MechanicQualificationName = value;
                Raise();
            }
        }

        public string WorkshopId
        {
            get => Workshops[WorkshopsId.IndexOf(Model.WorkshopId)];
            set
            {
                _model.WorkshopId = WorkshopsId[Workshops.IndexOf(value)];
                Raise();
            }
        }

        public ObservableCollection<string> MechanicQualifications { get; private set; }
        public ObservableCollection<string> Workshops { get; private set; }

        private List<int> WorkshopsId { get; set; }

        public MechanicViewModel()
        {
        }

        public MechanicViewModel(Mechanic model)
        {
            _model = model;
            
            using (var context = new Context())
            {
                MechanicQualifications = new ObservableCollection<string>(context.MechanicQualifications.ToList().Select(_ => _.Name));
                Workshops = new ObservableCollection<string>(context.Workshops.ToList().Select(_ => _.Name));

                WorkshopsId = new List<int>(context.Workshops.ToList().Select(_ => _.Id));
            }
        }
    }
}