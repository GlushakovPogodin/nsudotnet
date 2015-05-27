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
    public class CTNListViewModel : PropertyChangedBase
    {
        private ObservableCollection<CTNViewModel> _CTNList;
        private IService<CTN> _CTNService;
        private CTNViewModel _selectedCTN;

        public CTNListViewModel(IService<CTN> CTNService)
        {
            _CTNService = CTNService;
            ItemInit();
            _CTNList = new ObservableCollection<CTNViewModel>();
            foreach (var CTN in new List<CTN>(_CTNService.GetAll()))
            {
                var vm = new CTNViewModel();
                vm.SetCTN(CTN);
                _CTNList.Add(vm);
            }
        }

        private void ItemInit()
        {
            _selectedCTN = new CTNViewModel();
            _selectedCTN.SetCTN(new CTN());
        }

        public CTNViewModel SelectedCTN
        {
            get { return _selectedCTN; }
            set
            {
                if (_selectedCTN == value)
                    return;

                _selectedCTN = value;
                NotifyOfPropertyChange(() => SelectedCTN);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<CTN, CTN>();
                _CTNService.Create(Mapper.Map<CTN, CTN>(_selectedCTN.CTNEntity));
                RefreshList();

            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedCTN.CTNEntity.Id == 0)
                return;
            try
            {
                _CTNService.Update(_selectedCTN.CTNEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedCTN);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedCTN.CTNEntity.Id == 0)
                return;
            try
            {
                _CTNService.Delete(_selectedCTN.CTNEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedCTN);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _CTNList.Clear();

            _CTNList = new ObservableCollection<CTNViewModel>();
            foreach (var CTN in new List<CTN>(_CTNService.GetAll()))
            {
                var vm = new CTNViewModel();
                vm.SetCTN(CTN);
                _CTNList.Add(vm);
            }
            NotifyOfPropertyChange(() => CTNList);
        }

        public ObservableCollection<CTNViewModel> CTNList
        {
            get { return _CTNList; }
        }
    }
}
