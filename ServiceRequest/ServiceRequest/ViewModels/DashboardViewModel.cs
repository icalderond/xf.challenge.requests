using ServiceRequest.Models;
using ServiceRequest.Services;
using System;
using System.Collections.ObjectModel;

namespace ServiceRequest.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        #region [ Constructor ]
        public DashboardViewModel()
        {
            LoadData();
        }

        #region [ Methods ]
        private async void LoadData()
        {
            try
            {
                IsBusy = true;
                var listRequests = await SrListService.GetSrList();

                Random r = new Random();
                listRequests.ForEach(x => x.StatusUI = r.Next(1, 3));

                RequesModelList = new ObservableCollection<RequestModel>(listRequests);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Enterado");
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion [ Methods ]

        #endregion [ Constructor ]

        #region [ Properties ]
        private ObservableCollection<RequestModel> _RequesModelList;
        public ObservableCollection<RequestModel> RequesModelList
        {
            get => _RequesModelList;
            set => Set(ref _RequesModelList, value);
        }

        private SrListService _SrListService;

        public SrListService SrListService
        {
            get { return _SrListService = _SrListService ?? new SrListService(); }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => Set(ref _IsBusy, value);
        }
        #endregion [ Properties ]

        #region [ Commands ]
        private ActionCommand _OrderByCommand;
        public ActionCommand OrderByCommand
        {
            get => _OrderByCommand= _OrderByCommand??new ActionCommand(()=> { 
            
            });
        }

        #endregion [ Commands ]
    }
}
