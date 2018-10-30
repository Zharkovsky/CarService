using CarService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.ViewModels
{
    public class RootViewModel : ViewModelBase
    {
        public ObservableCollection<WorkshopViewModel> Workshops { get; private set; }
        public ObservableCollection<OwnerViewModel> Owners { get; private set; }
        public ObservableCollection<CarViewModel> Cars { get; private set; }
        public ObservableCollection<OrderViewModel> Orders { get; private set; }
        public ObservableCollection<MechanicViewModel> Mechanics { get; private set; }
        public ObservableCollection<BrandViewModel> Brands { get; private set; }
        public ObservableCollection<MechanicQualificationViewModel> MechanicQualifications { get; private set; }
        public ObservableCollection<OrderQualificationViewModel> OrderQualifications { get; private set; }

        private WorkshopViewModel _selectedWorkshop;
        public WorkshopViewModel SelectedWorkshop
        {
            get => _selectedWorkshop;
            set
            {
                _selectedWorkshop = value;
                Message = "";
                Raise();
            }
        }

        private OwnerViewModel _selectedOwner;
        public OwnerViewModel SelectedOwner
        {
            get => _selectedOwner;
            set
            {
                _selectedOwner = value;
                Message = "";
                Raise();
            }
        }

        private CarViewModel _selectedCar;
        public CarViewModel SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                Message = "";
                Raise();
            }
        }

        private OrderViewModel _selectedOrder;
        public OrderViewModel SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                Message = "";
                Raise();
            }
        }

        private MechanicViewModel _selectedMechanic;
        public MechanicViewModel SelectedMechanic
        {
            get => _selectedMechanic;
            set
            {
                _selectedMechanic = value;
                Message = "";
                Raise();
            }
        }

        private BrandViewModel _selectedBrand;
        public BrandViewModel SelectedBrand
        {
            get => _selectedBrand;
            set
            {
                _selectedBrand = value;
                Message = "";
                Raise();
            }
        }

        private MechanicQualificationViewModel _selectedMechanicQualification;
        public MechanicQualificationViewModel SelectedMechanicQualification
        {
            get => _selectedMechanicQualification;
            set
            {
                _selectedMechanicQualification = value;
                Message = "";
                Raise();
            }
        }

        private OrderQualificationViewModel _selectedOrderQualification;
        public OrderQualificationViewModel SelectedOrderQualification
        {
            get => _selectedOrderQualification;
            set
            {
                _selectedOrderQualification = value;
                Message = "";
                Raise();
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                Raise();
            }
        }

        public RootViewModel()
        {
            InitData();
            InitCommands();
        }

        private void InitData()
        {
            using (var context = new Context())
            {
                Workshops = new ObservableCollection<WorkshopViewModel>(context.Workshops.ToList().Select(_ => new WorkshopViewModel(_)));
                Owners = new ObservableCollection<OwnerViewModel>(context.Owners.ToList().Select(_ => new OwnerViewModel(_)));
                Cars = new ObservableCollection<CarViewModel>(context.Cars.ToList().Select(_ => new CarViewModel(_)));
                Orders = new ObservableCollection<OrderViewModel>(context.Orders.ToList().Select(_ => new OrderViewModel(_)));
                Mechanics = new ObservableCollection<MechanicViewModel>(context.Mechanics.ToList().Select(_ => new MechanicViewModel(_)));
                Brands = new ObservableCollection<BrandViewModel>(context.Brands.ToList().Select(_ => new BrandViewModel(_)));
                MechanicQualifications = new ObservableCollection<MechanicQualificationViewModel>(context.MechanicQualifications.ToList().Select(_ => new MechanicQualificationViewModel(_)));
                OrderQualifications = new ObservableCollection<OrderQualificationViewModel>(context.OrderQualifications.ToList().Select(_ => new OrderQualificationViewModel(_)));
            }

            SelectedWorkshop = Workshops.FirstOrDefault();
            SelectedOwner = Owners.FirstOrDefault();
            SelectedCar = Cars.FirstOrDefault();
            SelectedOrder = Orders.FirstOrDefault();
            SelectedMechanic = Mechanics.FirstOrDefault();
            SelectedBrand = Brands.FirstOrDefault();
            SelectedMechanicQualification = MechanicQualifications.FirstOrDefault();
            SelectedOrderQualification = OrderQualifications.FirstOrDefault();
        }

        private void InitCommands()
        {
            RemoveWorkshopCommand = new RelayCommand(RemoveWorkshop);
            AddWorkshopCommand = new RelayCommand(AddWorkshop);
            SaveWorkshopCommand = new RelayCommand(SaveWorkshop);

            RemoveOwnerCommand = new RelayCommand(RemoveOwner);
            AddOwnerCommand = new RelayCommand(AddOwner);
            SaveOwnerCommand = new RelayCommand(SaveOwner);

            RemoveBrandCommand = new RelayCommand(RemoveBrand);
            AddBrandCommand = new RelayCommand(AddBrand);
            SaveBrandCommand = new RelayCommand(SaveBrand);

            RemoveCarCommand = new RelayCommand(RemoveCar);
            AddCarCommand = new RelayCommand(AddCar);
            SaveCarCommand = new RelayCommand(SaveCar);

            RemoveMechanicCommand = new RelayCommand(RemoveMechanic);
            AddMechanicCommand = new RelayCommand(AddMechanic);
            SaveMechanicCommand = new RelayCommand(SaveMechanic);

            RemoveOrderCommand = new RelayCommand(RemoveOrder);
            AddOrderCommand = new RelayCommand(AddOrder);
            SaveOrderCommand = new RelayCommand(SaveOrder);

            RemoveOrderQualificationCommand = new RelayCommand(RemoveOrderQualification);
            AddOrderQualificationCommand = new RelayCommand(AddOrderQualification);
            SaveOrderQualificationCommand = new RelayCommand(SaveOrderQualification);

            RemoveMechanicQualificationCommand = new RelayCommand(RemoveMechanicQualification);
            AddMechanicQualificationCommand = new RelayCommand(AddMechanicQualification);
            SaveMechanicQualificationCommand = new RelayCommand(SaveMechanicQualification);
        }

        #region Workshops

        public RelayCommand RemoveWorkshopCommand { get; private set; }
        public RelayCommand AddWorkshopCommand { get; private set; }
        public RelayCommand SaveWorkshopCommand { get; private set; }

        private void RemoveWorkshop(object parameter)
        {
            var viewModel = parameter as WorkshopViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Workshops.FirstOrDefault(_ => _.Id == viewModel.Model.Id);
                if(model != null) context.Workshops.Remove(model);
                context.SaveChanges();
            }
            SelectedWorkshop = null;
            Workshops.Remove(viewModel);
        }

        private void AddWorkshop(object obj)
        {
            var item = new Workshop();
            var viewModel = new WorkshopViewModel(item);
            Workshops.Add(viewModel);
            SelectedWorkshop = viewModel;
        }

        private void SaveWorkshop(object parameter)
        {
            var viewModel = parameter as WorkshopViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Workshops.FirstOrDefault(_ => _.Id == viewModel.Model.Id);
                if(model == null)
                    context.Workshops.Add(viewModel.Model);
                else
                {
                    model.Name = viewModel.Name;
                    model.Address = viewModel.Address;
                    model.Phone = viewModel.Phone;
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region Owners

        public RelayCommand RemoveOwnerCommand { get; private set; }
        public RelayCommand AddOwnerCommand { get; private set; }
        public RelayCommand SaveOwnerCommand { get; private set; }

        private void RemoveOwner(object parameter)
        {
            var viewModel = parameter as OwnerViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Owners.FirstOrDefault(_ => _.Driverlicense == viewModel.Model.Driverlicense);
                if (model != null) context.Owners.Remove(model);
                context.SaveChanges();
            }
            SelectedOwner = null;
            Owners.Remove(viewModel);
        }

        private void AddOwner(object obj)
        {
            var item = new Owner();
            var viewModel = new OwnerViewModel(item)
            {
                IsNew = true
            };
            Owners.Add(viewModel);
            SelectedOwner = viewModel;
        }

        private void SaveOwner(object parameter)
        {
            var viewModel = parameter as OwnerViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Owners.FirstOrDefault(_ => _.Driverlicense == viewModel.Model.Driverlicense);
                if (model == null)
                {
                    context.Owners.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if(!viewModel.IsNew)
                {
                    model.Driverlicense = viewModel.Driverlicense;
                    model.Name = viewModel.Name;
                    model.Address = viewModel.Address;
                    model.Phone = viewModel.Phone;

                    Message = "";
                }
                else
                {
                    Message = "Такое водительское удостоверение уже зарегестрировано!";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region Brands

        public RelayCommand RemoveBrandCommand { get; private set; }
        public RelayCommand AddBrandCommand { get; private set; }
        public RelayCommand SaveBrandCommand { get; private set; }

        private void RemoveBrand(object parameter)
        {
            var viewModel = parameter as BrandViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Brands.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model != null) context.Brands.Remove(model);
                context.SaveChanges();
            }
            SelectedBrand = null;
            Brands.Remove(viewModel);
        }

        private void AddBrand(object obj)
        {
            var item = new Brand();
            var viewModel = new BrandViewModel(item)
            {
                IsNew = true
            };
            Brands.Add(viewModel);
            SelectedBrand = viewModel;
        }

        private void SaveBrand(object parameter)
        {
            var viewModel = parameter as BrandViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Brands.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model == null)
                {
                    context.Brands.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew)
                {
                    model.Name = viewModel.Name;

                    Message = "";
                }
                else
                {
                    Message = "Такая модель уже есть!";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region Cars

        public RelayCommand RemoveCarCommand { get; private set; }
        public RelayCommand AddCarCommand { get; private set; }
        public RelayCommand SaveCarCommand { get; private set; }

        private void RemoveCar(object parameter)
        {
            var viewModel = parameter as CarViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Cars.FirstOrDefault(_ => _.Grz == viewModel.Model.Grz);
                if (model != null) context.Cars.Remove(model);
                context.SaveChanges();
            }
            SelectedCar = null;
            Cars.Remove(viewModel);
        }

        private void AddCar(object obj)
        {
            var item = new Car();
            var viewModel = new CarViewModel(item)
            {
                IsNew = true
            };
            Cars.Add(viewModel);
            SelectedCar = viewModel;
        }

        private void SaveCar(object parameter)
        {
            var viewModel = parameter as CarViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Cars.FirstOrDefault(_ => _.Grz == viewModel.Model.Grz);
                var inError = String.IsNullOrWhiteSpace(viewModel.BrandName) || String.IsNullOrWhiteSpace(viewModel.Driverlicense)
                    || String.IsNullOrWhiteSpace(viewModel.Grz);
                if (model == null && !inError)
                {
                    context.Cars.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew && !inError)
                {
                    model.Grz = viewModel.Grz;
                    model.Year = viewModel.Year;
                    model.Power = viewModel.Power;
                    model.Owner = context.Owners.FirstOrDefault(_ => _.Driverlicense == viewModel.Driverlicense);
                    model.Brand = context.Brands.FirstOrDefault(_ => _.Name == viewModel.BrandName);

                    Message = "";
                }
                else
                {
                    Message = "Проверьте данные";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region Mechanics

        public RelayCommand RemoveMechanicCommand { get; private set; }
        public RelayCommand AddMechanicCommand { get; private set; }
        public RelayCommand SaveMechanicCommand { get; private set; }

        private void RemoveMechanic(object parameter)
        {
            var viewModel = parameter as MechanicViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Mechanics.FirstOrDefault(_ => _.Id == viewModel.Model.Id);
                if (model != null) context.Mechanics.Remove(model);
                context.SaveChanges();
            }
            SelectedMechanic = null;
            Mechanics.Remove(viewModel);
        }

        private void AddMechanic(object obj)
        {
            var item = new Mechanic();
            var viewModel = new MechanicViewModel(item);
            Mechanics.Add(viewModel);
            SelectedMechanic = viewModel;
        }

        private void SaveMechanic(object parameter)
        {
            var viewModel = parameter as MechanicViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Mechanics.FirstOrDefault(_ => _.Id == viewModel.Model.Id);

                var inError = String.IsNullOrWhiteSpace(viewModel.WorkshopId) || String.IsNullOrWhiteSpace(viewModel.MechanicQualificationName);
                if (model == null && !inError)
                {
                    context.Mechanics.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew && !inError)
                {
                    model.Id = viewModel.Id;
                    model.MechanicQualification = context.MechanicQualifications.FirstOrDefault(_ => _.Name == viewModel.MechanicQualificationName);
                    model.Name = viewModel.Name;
                    model.Address = viewModel.Address;
                    model.Phone = viewModel.Phone;
                    model.Workshop = context.Workshops.FirstOrDefault(_ => _.Id == viewModel.Model.WorkshopId);

                    Message = "";
                }
                else
                {
                    Message = "Проверьте данные";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region Orders

        public RelayCommand RemoveOrderCommand { get; private set; }
        public RelayCommand AddOrderCommand { get; private set; }
        public RelayCommand SaveOrderCommand { get; private set; }

        private void RemoveOrder(object parameter)
        {
            var viewModel = parameter as OrderViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Orders.FirstOrDefault(_ => _.Id == viewModel.Model.Id);
                if (model != null) context.Orders.Remove(model);
                context.SaveChanges();
            }
            SelectedOrder = null;
            Orders.Remove(viewModel);
        }

        private void AddOrder(object obj)
        {
            var item = new Order();
            var viewModel = new OrderViewModel(item)
            {
                IsNew = true
            };
            Orders.Add(viewModel);
            SelectedOrder = viewModel;
        }

        private void SaveOrder(object parameter)
        {
            var viewModel = parameter as OrderViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.Orders.FirstOrDefault(_ => _.Id == viewModel.Model.Id);
                var inError = String.IsNullOrWhiteSpace(viewModel.Grz) || String.IsNullOrWhiteSpace(viewModel.MechanicId)
                    || String.IsNullOrWhiteSpace(viewModel.OrderQualificationName) || String.IsNullOrWhiteSpace(viewModel.WorkshopId);
                if (model == null && !inError)
                {
                    context.Orders.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew && !inError)
                {
                    model.Id = viewModel.Id;
                    model.Cost = viewModel.Cost;
                    model.StartDate = viewModel.StartDate;
                    model.PlannedDate = viewModel.PlannedDate;
                    model.RealDate = viewModel.RealDate;
                    model.Car = context.Cars.FirstOrDefault(_ => _.Grz == viewModel.Grz);
                    model.Mechanic = context.Mechanics.FirstOrDefault(_ => _.Id == viewModel.Model.MechanicId);
                    model.Workshop = context.Workshops.FirstOrDefault(_ => _.Id == viewModel.Model.WorkshopId);
                    model.OrderQualification = context.OrderQualifications.FirstOrDefault(_ => _.Name == viewModel.OrderQualificationName);

                    Message = "";
                }
                else
                {
                    Message = "Проверьте данные";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region MechanicQualification

        public RelayCommand RemoveMechanicQualificationCommand { get; private set; }
        public RelayCommand AddMechanicQualificationCommand { get; private set; }
        public RelayCommand SaveMechanicQualificationCommand { get; private set; }

        private void RemoveMechanicQualification(object parameter)
        {
            var viewModel = parameter as MechanicQualificationViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.MechanicQualifications.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model != null) context.MechanicQualifications.Remove(model);
                context.SaveChanges();
            }
            SelectedMechanicQualification = null;
            MechanicQualifications.Remove(viewModel);
        }

        private void AddMechanicQualification(object obj)
        {
            var item = new MechanicQualification();
            var viewModel = new MechanicQualificationViewModel(item)
            {
                IsNew = true
            };
            MechanicQualifications.Add(viewModel);
            SelectedMechanicQualification = viewModel;
        }

        private void SaveMechanicQualification(object parameter)
        {
            var viewModel = parameter as MechanicQualificationViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.MechanicQualifications.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model == null)
                {
                    context.MechanicQualifications.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew)
                {
                    model.Name = viewModel.Name;

                    Message = "";
                }
                else
                {
                    Message = "Такая квалификация уже есть!";
                }
                context.SaveChanges();
            }
        }

        #endregion

        #region OrderQualifications

        public RelayCommand RemoveOrderQualificationCommand { get; private set; }
        public RelayCommand AddOrderQualificationCommand { get; private set; }
        public RelayCommand SaveOrderQualificationCommand { get; private set; }

        private void RemoveOrderQualification(object parameter)
        {
            var viewModel = parameter as OrderQualificationViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.OrderQualifications.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model != null) context.OrderQualifications.Remove(model);
                context.SaveChanges();
            }
            SelectedOrderQualification = null;
            OrderQualifications.Remove(viewModel);
        }

        private void AddOrderQualification(object obj)
        {
            var item = new OrderQualification();
            var viewModel = new OrderQualificationViewModel(item)
            {
                IsNew = true
            };
            OrderQualifications.Add(viewModel);
            SelectedOrderQualification = viewModel;
        }

        private void SaveOrderQualification(object parameter)
        {
            var viewModel = parameter as OrderQualificationViewModel;
            if (viewModel == null) return;
            using (var context = new Context())
            {
                var model = context.OrderQualifications.FirstOrDefault(_ => _.Name == viewModel.Model.Name);
                if (model == null)
                {
                    context.OrderQualifications.Add(viewModel.Model);
                    viewModel.IsNew = false;
                    Message = "";
                }
                else if (!viewModel.IsNew)
                {
                    model.Name = viewModel.Name;

                    Message = "";
                }
                else
                {
                    Message = "Такая квалификация уже есть!";
                }
                context.SaveChanges();
            }
        }

        #endregion
    }
}
