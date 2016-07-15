namespace WebTamplate.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    
    public class BasePaginationViewModel
    {
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Prefix { get; set; }
        public IEnumerable<SelectListItem> PageSizeOptions
        {
            get
            {
                List<string> pageSizeOptionsStrings = new List<string>
                {
                   "1",
                   "2",
                   "3",
                   "4",
                   "5",
                   "6",
                   "7",
                   "8",
                   "9",
                   "10"
                };
                return pageSizeOptionsStrings.Select(p => new SelectListItem
                {
                    Text = p,
                    Value = p
                });
            }
            set
            {
            }
        }
    }
}