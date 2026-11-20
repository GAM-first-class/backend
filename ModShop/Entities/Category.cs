namespace ModShop.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public Guid? ParentCategoryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }


        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();


        //Behavior

        public static Category Create(string name,string description,Guid? parentcategoryid,bool isactive)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                ParentCategoryId = parentcategoryid,
                CreatedAt = DateTime.UtcNow,
                IsActive = isactive
            };
        }

        public void Update(string name, string description, Guid? parentcategoryid, bool isactive)
        {
            Name = name;
            Description = description;
            ParentCategoryId = parentcategoryid;
            IsActive = isactive;
        }
    }
}
