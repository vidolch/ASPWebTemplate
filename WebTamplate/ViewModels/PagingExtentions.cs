namespace WebTamplate.ViewModels
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
        public static TListViewModel PopulatePagingData<T, TListViewModel, TViewModel>(this TListViewModel viewModel, IRepository<T> repo, NameValueCollection query, string controller, string action = "Index")
            where TListViewModel : BaseListViewModel<TViewModel>, new()
            where T : BaseEntity
        {
            var itemsCount = repo.All().Count();

            viewModel.Prefix = viewModel.GetType().ToString().Split('.').Last();

            string currentPageKey = viewModel.Prefix + "_CurrentPage";
            if (query[currentPageKey] != null)
            {
                viewModel.CurrentPage = Convert.ToInt32(query[currentPageKey]);
            }
            else
            {
                viewModel.CurrentPage = 1;
            }

            string pageSizeKey = viewModel.Prefix + "_PageSize";
            if (query[pageSizeKey] != null)
            {
                viewModel.PageSize = Convert.ToInt32(query[pageSizeKey]);
            }

            viewModel.PageCount = Convert.ToInt32(Math.Ceiling((double)itemsCount / viewModel.PageSize));
            viewModel.Items = repo.All(viewModel.PageSize * (viewModel.CurrentPage - 1), viewModel.PageSize).To<TViewModel>().ToList();
            viewModel.Controller = controller;
            viewModel.Action = action;

            return viewModel;
        }
    }
}