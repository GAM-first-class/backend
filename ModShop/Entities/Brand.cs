namespace ModShop.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        //behavior

        public static Brand Create(string name, string description, bool isactive)
        {
            return new Brand
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreatedAt = DateTime.UtcNow,
                IsActive = isactive
            };
        }

        public void Update(string name, string description, bool isactive)
        {
            Name = name;
            Description = description;
            IsActive = isactive;
        }

    }
}
