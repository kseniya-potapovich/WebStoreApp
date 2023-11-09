namespace WedStoreApp.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string VendorCode { get; set; }

        public string Discription { get; set; }

        public double Price { get; set; }

        public List<User> Users { get; set; }
    }
}