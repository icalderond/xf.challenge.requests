using ServiceRequest.Models;
using ServiceRequest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceRequest.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        #region [ Variables ]
        public List<RequestModel> ListRequestsBase { get; set; }
        #endregion [ Variables ]

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
                ListRequestsBase = await SrListService.GetSrList();

                //ToDo: Remove this line
                ListRequestsBase = ListRequestsBase.Take(50).ToList();

                Random r = new Random();
                ListRequestsBase.ForEach(x => x.StatusUI = r.Next(1, 3));

                RequesModelList = new ObservableCollection<RequestModel>(ListRequestsBase);
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

        private string _QuerySearch;
        public string QuerySearch
        {
            get => _QuerySearch;
            set
            {
                Set(ref _QuerySearch, value);
                FilterList(_QuerySearch);
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => Set(ref _IsBusy, value);
        }
        #endregion [ Properties ]

        #region [ Methods ]
        private void FilterList(string querySearch)
        {
            if (querySearch.Length >= 3)
            {
                var filterList = ListRequestsBase.Where(x => x.SUMMARY.ToLower().Contains(querySearch));
                RequesModelList = new ObservableCollection<RequestModel>(filterList);
            }
            else if (RequesModelList.Count != ListRequestsBase.Count)
                RequesModelList = new ObservableCollection<RequestModel>(ListRequestsBase);
        }
        #endregion [ Methods ]

        #region [ Commands ]
        private ActionCommand<string> _OrderByCommand;
        public ActionCommand<string> OrderByCommand
        {
            get => _OrderByCommand = _OrderByCommand ?? new ActionCommand<string>((param) =>
            {
                var orderedByAsc = ListRequestsBase.OrderBy(x => x.GetType().GetProperty(param).GetValue(x, null)).ToList();
                var listToCompare = RequesModelList.ToList();

                if (listToCompare.SequenceEqual(orderedByAsc.ToList()))
                {
                    var orderedList = ListRequestsBase.OrderByDescending(x => x.GetType().GetProperty(param).GetValue(x, null));
                    RequesModelList = new ObservableCollection<RequestModel>(orderedList);
                }
                else
                {
                    var orderedList = ListRequestsBase.OrderBy(x => x.GetType().GetProperty(param).GetValue(x, null));
                    RequesModelList = new ObservableCollection<RequestModel>(orderedList);
                }
            });
        }

        #endregion [ Commands ]
    }
}
