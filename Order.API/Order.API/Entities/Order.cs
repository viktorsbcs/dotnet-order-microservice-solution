namespace Order.API.Entities
{
    public class Order
    {
        public double Price { get; set; }
        public Guid Id { get; set; }
        public string? PartName { get; set; }
        public PartType PartType { get; set; }

    }

    public enum PartType
    {
        Engine = 0,
        Suspension = 1,
        ExhaustSystem = 2,
        FuelSystem = 3
    }
}
