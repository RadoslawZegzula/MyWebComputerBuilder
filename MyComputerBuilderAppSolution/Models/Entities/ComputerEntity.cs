namespace MyOnlineShop.Models.Entities
{
    public class ComputerEntity : PartsBaseEntity
    {
        public string UserId { get; set; }
        public int CpuId { get; set; }
        public int GpuId { get; set; }
        public int MotherboardId { get; set; }
        public int RamId { get; set; }
        public int PowerSupplyId { get; set; }
        public int Comments { get; set; }
        public int Likes { get; set; }
    }
}