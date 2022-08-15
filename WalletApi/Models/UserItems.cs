namespace WalletApi.Models
{
    public class UserItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Familly { get; set; }
        public string NationalCode { get; set; }
        public long AccountNumber { get; set; }
        public long AccountBalance { get; set; }
        public bool IsComplete { get; set; }
    }
}
