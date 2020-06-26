namespace MyOnlineShop.Models.Entities
{
    public class CpuEntity : PartsBaseEntity
    {
        public int Frequency { get; set; }
        public int Cores { get; set; }
        public string Socket { get; set; }
        public float Tdp { get; set; }
    }
}