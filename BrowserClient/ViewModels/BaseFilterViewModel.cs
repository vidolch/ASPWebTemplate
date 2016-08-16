using System;
using System.Linq.Expressions;
using DataAccess.Models;

namespace BrowserClient.ViewModels
{
    public abstract class BaseFilterViewModel<T> 
        where T : BaseEntity
    {
        public string Prefix { get; set; }
        public BasePaginationViewModel ParentPager { get; set; }
        public abstract Expression<Func<T, bool>> BuildFilter();
    }
}