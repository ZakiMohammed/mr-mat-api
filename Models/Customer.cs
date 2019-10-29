namespace mr_mat_api.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Notification { get; set; }
        public int WorkLocationDistance { get; set; }
        public bool IsPrivate { get; set; }
    }
}