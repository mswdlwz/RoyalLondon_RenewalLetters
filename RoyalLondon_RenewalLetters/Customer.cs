namespace RoyalLondon_RenewalLetters
{
    public class Customer
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Customer(int id, string title, string firstname, string surname)
            => (ID, Title, Firstname, Surname) = (id, title, firstname, surname);
    }
}
