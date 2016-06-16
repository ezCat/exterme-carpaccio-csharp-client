namespace xCarpaccio.client
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests {
        public void JeTesteQqch()
        {
            new Order()
            {
                Country = "DE",
                Reduction = "STANDARD",
                Prices = new[] { 12.0m, 23.2m },
                Quantities = new[] { 2, 23 }
            };

            

            }

    }
}