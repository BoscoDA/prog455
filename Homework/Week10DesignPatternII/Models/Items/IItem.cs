namespace Week10DesignPatternII.Models.Items
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int StatChange { get; set; }
        string Type { get; set; }

        string Display();
    }
}