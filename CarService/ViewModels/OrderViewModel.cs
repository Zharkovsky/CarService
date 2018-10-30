using CarService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarService.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private Order _model;
        public Order Model { get => _model; }

        public int Id
        {
            get => _model.Id;
            set
            {
                _model.Id = value;
                Raise();
            }
        }

        public int Cost
        {
            get => _model.Cost;
            set
            {
                _model.Cost = value;
                Raise();
            }
        }

        public DateTime StartDate
        {
            get => _model.StartDate;
            set
            {
                _model.StartDate = value;
                Raise();
            }
        }

        public DateTime PlannedDate
        {
            get => _model.PlannedDate;
            set
            {
                _model.PlannedDate = value;
                Raise();
            }
        }

        public DateTime? RealDate
        {
            get => _model.RealDate;
            set
            {
                _model.RealDate = value;
                Raise();
            }
        }

        public string Grz
        {
            get => _model.Grz;
            set
            {
                _model.Grz = value;
                Raise();
            }
        }

        public string MechanicId
        {
            get => Mechanics[MechanicsId.IndexOf(Model.MechanicId)];
            set
            {
                _model.MechanicId = MechanicsId[Mechanics.IndexOf(value)];
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

        public string OrderQualificationName
        {
            get => _model.OrderQualificationName;
            set
            {
                _model.OrderQualificationName = value;
                Raise();
            }
        }

        public ObservableCollection<string> Cars { get; private set; }
        public ObservableCollection<string> Mechanics { get; private set; }
        public ObservableCollection<string> Workshops { get; private set; }
        public ObservableCollection<string> OrderQualifications { get; private set; }

        private List<int> MechanicsId { get; set; }
        private List<int> WorkshopsId { get; set; }


        public OrderViewModel()
        {
        }

        public OrderViewModel(Order model)
        {
            _model = model;
            using (var context = new Context())
            {
                Cars = new ObservableCollection<string>(context.Cars.ToList().Select(_ => _.Grz));
                Mechanics = new ObservableCollection<string>(context.Mechanics.ToList().Select(_ => _.Name));
                Workshops = new ObservableCollection<string>(context.Workshops.ToList().Select(_ => _.Name));
                OrderQualifications = new ObservableCollection<string>(context.OrderQualifications.ToList().Select(_ => _.Name));

                MechanicsId = new List<int>(context.Mechanics.ToList().Select(_ => _.Id));
                WorkshopsId = new List<int>(context.Workshops.ToList().Select(_ => _.Id));
            }
        }
    }
}