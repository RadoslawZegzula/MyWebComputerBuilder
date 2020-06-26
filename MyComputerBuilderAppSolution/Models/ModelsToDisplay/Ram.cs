namespace MyOnlineShop.Models.ModelsToDisplay
{
    public class Ram : DisplayBaseModel
    {
        public string ConnectorType { get; set; }
        public string MemoryType { get; set; }
        public string Cooling { get; set; }
        public int MemorySize { get; set; }
        public int ModulesNumber { get; set; }
        public int Frequency { get; set; }
        public string Latency { get; set; }
        public float Wattage { get; set; }
        public string Color { get; set; }
        public string BackLight { get; set; }
    }
}