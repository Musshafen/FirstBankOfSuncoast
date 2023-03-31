namespace FirstBankOfSuncoast
{
    public class Transaction
    {
        public string Account { get; set; }

        public int Amount { get; set; }

        public string Type { get; set; }


        public string Description()
        {
            var descriptionString = $"{Type} of ${Amount} to {Account}";

            return descriptionString;



        }

    }
}