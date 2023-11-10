namespace WedStoreApp.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryId { get; set; }

        public int SellerId { get; set; }

        public string Discription { get; set; }

        public double Price { get; set; }
    }
}