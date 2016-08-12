namespace DataAccess.Models
{
    public interface ISelectItem
    {
        bool Selected { get; set; }
        bool Disabled { get; set; }
        string Text { get; set; }
        string Value { get; set; }
    }
}