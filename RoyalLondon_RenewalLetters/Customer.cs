namespace RoyalLondon_RenewalLetters
{
    public class Customer
    {
        //ID,Title,FirstName,Surname,ProductName,PayoutAmount,AnnualPremium
        public static int? ID { get; set; }
        public static string Title { get; set; }
        public static string Firstname { get; set; }
        public static string Surname { get; set; }
        public static string ProductName { get; set; }
        public static decimal? PayoutAmount { get; set; }
        public static decimal? AnnualPremium { get; set; }

        public Customer() { }
        public Customer(int? id, string title, string firstname, string surname, string productname, decimal? payoutamount, decimal? annualpremium) 
            => (ID, Title, Firstname, Surname, ProductName, PayoutAmount, AnnualPremium) = (id,title,firstname,surname,productname,payoutamount,annualpremium);

        public static Customer GetCustomer(string[] custDetl)
        {
            // Check values for ID, payout and premium are valid int and decimal values
            int chkID;
            decimal chkPayout, chkPremium;

            if(int.TryParse(custDetl[0], out chkID))
                ID = chkID;

            if (decimal.TryParse(custDetl[5], out chkPayout))
                PayoutAmount = chkPayout;

            if (decimal.TryParse(custDetl[6], out chkPremium))
                AnnualPremium = chkPremium;
                                 
            Title = custDetl[1];
            Firstname = custDetl[2];
            Surname = custDetl[3];
            ProductName = custDetl[4];

            return new Customer(ID, Title, Firstname, Surname, ProductName, PayoutAmount, AnnualPremium);
        }
    }
}
