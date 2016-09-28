namespace STG_RestaurantBuzzer
{
    public class Party
    {
        public long Id { get; set; }
        public short PartySize { get; set; }
        public string Name { get; set; }
        public short WaitMinutes { get; set; }
        public bool IsSeated { get; set; }
        public string Description => $"Party of {PartySize}";
    }
}