namespace DataAccess.Models
{
    public class SelectItem : ISelectItem
    {
        public bool Selected { get; set; }

        public bool Disabled { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }
    }
}
