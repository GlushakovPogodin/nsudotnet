using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using Caliburn.Micro;
using CTNDAL;
using CTNDb;

namespace CTNWPF.ViewModels.Lists
{
    public class ATSListViewModel : PropertyChangedBase
    {
        private ObservableCollection<ATSViewModel> _atsList;
        private ObservableCollection<ATSTypeViewModel> _atsTypeList;
        private ObservableCollection<CTNViewModel> _ctnList; 
        private IService<ATS> _atsService;
        private IService<ATSType> _atsTypeService;
        private IService<CTN> _ctnService;
        private ATSViewModel _selectedATS;

        public ATSListViewModel(IService<ATS> atsService, IService<ATSType> atsTypeService, IService<CTN> ctnService)
        {
            _atsService = atsService;
            _ctnService = ctnService;
            _atsTypeService = atsTypeService;
            ItemInit();
            _atsList = new ObservableCollection<ATSViewModel>();
            _atsTypeList = new ObservableCollection<ATSTypeViewModel>();
            _ctnList = new BindableCollection<CTNViewModel>();

            foreach (var ats in new List<ATS>(_atsService.GetAll()))
            {
                var vm = new ATSViewModel();
                vm.SetATS(ats);
                _atsList.Add(vm);
            }
            foreach (var atsType in _atsTypeService.GetAll().ToList())
            {
                var vm = new ATSTypeViewModel();
                vm.SetATSType(atsType);
                _atsTypeList.Add(vm);
            }
            foreach (var ctn in _ctnService.GetAll().ToList())
            {
                var vm = new CTNViewModel();
                vm.SetCTN(ctn);
                _ctnList.Add(vm);
            }
        }
        private void ItemInit()
        {
            _selectedATS = new ATSViewModel();
            _selectedATS.SetATS(new ATS());
        }

        public ATSViewModel SelectedATS
        {
            get { return _selectedATS; }
            set
            {
                if (_selectedATS == value)
                    return;

                _selectedATS = value;
                NotifyOfPropertyChange(() => SelectedATS);
            }
        }

        public void Add()
        {
            try
            {
                Mapper.CreateMap<ATS, ATS>();
                _atsService.Create(Mapper.Map<ATS, ATS>(_selectedATS.ATSEntity));
                RefreshList();
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Update()
        {
            if (_selectedATS.ATSEntity.Id == 0)
                return;
            try
            {
                _atsService.Update(_selectedATS.ATSEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedATS);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void Delete()
        {
            if (_selectedATS.ATSEntity.Id == 0)
                return;
            try
            {
                _atsService.Delete(_selectedATS.ATSEntity);
                RefreshList();
                ItemInit();
                NotifyOfPropertyChange(() => SelectedATS);
            }
            catch (DbUpdateException e)
            {

            }
        }

        public void RefreshList()
        {
            _atsList.Clear();          
            _atsList = new ObservableCollection<ATSViewModel>();
            foreach (var ats in _atsService.GetAll().ToList())
            {
                var vm = new ATSViewModel();
                vm.SetATS(ats);
                _atsList.Add(vm);
            }
            NotifyOfPropertyChange(() => ATSTypeList);
            NotifyOfPropertyChange(() => CTNList);
            NotifyOfPropertyChange(() => ATSList);
        }

        public ObservableCollection<ATSViewModel> ATSList
        {
            get { return _atsList; }
        }

        public ObservableCollection<CTNViewModel> CTNList
        {
            get { return _ctnList; }
        }

        public ObservableCollection<ATSTypeViewModel> ATSTypeList
        {
            get { return _atsTypeList; }
        }
    }
}
