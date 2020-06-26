namespace MyOnlineShop.Models.ModelsToDisplay
{
    public class Cpu : DisplayBaseModel
    {
        public int Frequency { get; set; }
        public int Cores { get; set; }
        public string Socket { get; set; }
        public float Tdp { get; set; }
    }
}