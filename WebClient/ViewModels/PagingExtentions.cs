using Services.EntityServices;

namespace WebClient.ViewModels
{ 
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Web;
    using Mapping;
    using DataAccess.Models;
    using DataAccess.Repositories;

    public static class PagingExtentions
    {
        public static TListViewModel PopulatePagingData<T, TListViewModel, TViewModel, TFilter>(this TListViewModel model, BaseService<T> service, NameValueCollection query, string controller, string action = "Index")
            where TViewModel : BaseEntityViewModel
            where T : BaseEntity
            where TFilter : BaseFilterViewModel<T>
            where TListViewModel : BaseListViewModel<T, TFilter>, new()
        {
            model.Filter.Prefix = "Filter.";
            int resultCount = service.Count(model.Filter.BuildFilter());
            string prefix = "Pager.";
            model.Pager = new BasePaginationViewModel(resultCount, model.Pager.CurrentPage, model.Pager.PageSize, prefix, action, controller);
            model.Filter.ParentPager = model.Pager;
            model.Items = service.GetAll(model.Filter.BuildFilter(), (model.Pager.CurrentPage - 1) * model.Pager.PageSize.Value , model.Pager.PageSize.Value).ToList();

            return model;
        }
    }
}