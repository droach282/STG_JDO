namespace STG_RestaurantBuzzer
{
    public class Group
    {
        public long Id { get; set; }
        public short PartySize { get; set; }
        public string Name { get; set; }
        public short WaitMinutes { get; set; }
        public string Description => $"Party of {PartySize}";
    }
}