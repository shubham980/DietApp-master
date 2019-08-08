namespace DietApp.Models
{
    public enum MenuItemType
    {
        Exercise,
        Diet,
        Notes
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
