namespace MyOnlineShop.Models.Entities
{
    public class MotherBoardEntity : PartsBaseEntity
    {
        public string ChipModel { get; set; }
        public string CpuSocket { get; set; }
        public string SoundSocket { get; set; }
        public int SoundCardCanalsNumber { get; set; }
        public string NetworkCard { get; set; }
        public string RearPanelConnectors { get; set; }
        public string MultiGpu { get; set; }
        public string MemoryType { get; set; }
        public string ConnectorType { get; set; }
        public int RamSlots { get; set; }
        public int Frequency { get; set; }
        public int Wattage { get; set; }
    }
}