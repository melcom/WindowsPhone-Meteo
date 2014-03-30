using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MeteoWP.ViewModel
{
    public class NavigationViewModelBase : ViewModelBase
    {
        private Action<bool> progressVisibility;
        private IDictionary<string, string> queryString;

        public async void AddParameters(IDictionary<string, string> queryString)
        {
            this.queryString = queryString;

            await Refresh();
        }

        public async Task Refresh()
        {
            progressVisibility(true);

            ClearData();
            await LoadData(queryString);

            progressVisibility(false);
        }

        protected virtual void ClearData()
        {
        }

        protected virtual Task LoadData(IDictionary<string, string> queryString)
        {
            return Task.FromResult(false);
        }

        protected bool CheckQueryString(IDictionary<string, string> queryString, string[] keys)
        {
            return keys.Any(key => !queryString.ContainsKey(key));
        }

        public void SetProgressVisibility(Action<bool> visibility)
        {
            progressVisibility = visibility;
        }
    }
}