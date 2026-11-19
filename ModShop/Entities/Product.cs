namespace ModShop.Entities
{
    public sealed class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }


        
        //Behavior

        public static Product Create(string name ,string description ,int price ,int discountprice
            ,Guid categoryid ,Guid brandid, bool isactive) 
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                DiscountPrice = discountprice,
                CategoryId = categoryid,
                BrandId = brandid,
                CreatedAt = DateTime.UtcNow,
                IsActive = isactive
            };
        }

        public void Update(string name, string description, int price, int discountprice
            , Guid categoryid, Guid brandid, bool isactive) 
        {
            Name = name;
            Description = description;
            Price = price;
            DiscountPrice = discountprice;
            CategoryId = categoryid;
            BrandId = brandid;
            IsActive = isactive;
        }



    }
}
