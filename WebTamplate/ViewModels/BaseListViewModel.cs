namespace WebTamplate.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;

    public class BaseListViewModel<T> : BasePaginationViewModel
    {
        public BaseListViewModel()
        {
            this.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageSize"]);
        }

        public IList<T> Items { get; set; }
    }
}