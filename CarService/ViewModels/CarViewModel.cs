using CarService.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarService.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        private Car _model;
        public Car Model { get => _model; }

        public string Grz
        {
            get => _model.Grz;
            set
            {
                _model.Grz = value;
                Raise();
            }
        }

        public DateTime Year
        {
            get => _model.Year;
            set
            {
                _model.Year = value;
                Raise();
            }
        }

        public int Power
        {
            get => _model.Power;
            set
            {
                _model.Power = value;
                Raise();
            }
        }

        public string Driverlicense
        {
            get => _model.Driverlicense;
            set
            {
                _model.Driverlicense = value;
                Raise();
            }
        }

        public string BrandName
        {
            get => _model.BrandName;
            set
            {
                _model.BrandName = value;
                Raise();
            }
        }

        public ObservableCollection<string> Driverlicenses { get; private set; }
        public ObservableCollection<string> Brands { get; private set; }

        public CarViewModel()
        {
        }

        public CarViewModel(Car model)
        {
            _model = model;
            using (var context = new Context())
            {
                Driverlicenses = new ObservableCollection<string>(context.Owners.ToList().Select(_ => _.Driverlicense));
                Brands = new ObservableCollection<string>(context.Brands.ToList().Select(_ => _.Name));
            }
        }
    }
}