namespace BrowserClient.Common
{
    using System;

    public class FilterAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownTargetProperty { get; set; }
    }
}