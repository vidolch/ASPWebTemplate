using DataAccess.Models;

namespace BrowserClient.ViewModels
{
    using System.Collections.Generic;

    public class BaseListViewModel<T, F>
        where T : BaseEntity
        where F : BaseFilterViewModel<T>
    {
        public IList<T> Items { get; set; }

        public BasePaginationViewModel Pager { get; set; }

        public F Filter { get; set; }
    }
}