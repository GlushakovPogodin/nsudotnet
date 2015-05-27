using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Caliburn.Micro;
using CityTelephoneNetwork.Logic;
using CityTelephoneNetwork.Data;

namespace CityTelephoneNetwork.UI.ViewModels.Lists
{
    public class ATSTypeListViewModel : PropertyChangedBase
    {
        private ObservableCollection<ATSTypeViewModel> _atsTypeList;
        private IService<ATSType> _atsTypeService;
        private ATSTypeViewModel _selectedATSType;

        public ATSTypeListViewModel(IService<ATSType> atsTypeService)
        {
            _atsTypeService = atsTypeService;
            ItemInit();
            _atsTypeList = new ObservableCollection<ATSTypeViewModel>();
            foreach (var atsType in new List<ATSType>(_atsTypeService.GetAll()))
            {
                var vm = new ATSTypeViewModel();
                vm.SetATSType(atsType);
                _atsTypeList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedATSType = new ATSTypeViewModel();
            _selectedATSType.SetATSType(new ATSType());
        }

        public ATSTypeViewModel SelectedATSType
        {
            get { return _selectedATSType; }
            set
            {
                if (_selectedATSType == value)
                    return;

                _selectedATSType = value;
                NotifyOfPropertyChange(() => SelectedATSType);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<ATSType, ATSType>();
                _atsTypeService.Create(Mapper.Map<ATSType, ATSType>(_selectedATSType.ATSTypeEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedATSType.ATSTypeEntity.Id == 0)
                return;
            try
            {
                _atsTypeService.Update(_selectedATSType.ATSTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedATSType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedATSType.ATSTypeEntity.Id == 0)
                return;
            try
            {
                _atsTypeService.Delete(_selectedATSType.ATSTypeEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedATSType);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _atsTypeList.Clear();

            _atsTypeList = new ObservableCollection<ATSTypeViewModel>();
            foreach (var atsType in new List<ATSType>(_atsTypeService.GetAll()))
            {
                var vm = new ATSTypeViewModel();
                vm.SetATSType(atsType);
                _atsTypeList.Add(vm);
            }
            NotifyOfPropertyChange(() => ATSTypeList);
        }

        public ObservableCollection<ATSTypeViewModel> ATSTypeList
        {
            get { return _atsTypeList; }
        }
    }
}
