namespace ModShop.Entities.OrderAggregates
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public int UnitPrice { get; set; }                
        public int Quantity { get; set; }
        public int TotalPrice => UnitPrice * Quantity;

   
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

        public Order? Order { get; set; }
        public Product? Product { get; set; }

        // ---------------------- Behavior ----------------------

        public static OrderDetail Create(
            Guid productId,
            string productName,
            int unitPrice,
            int quantity,
            string size,
            string color)
        {
            return new OrderDetail
            {
                Id = Guid.CreateVersion7(),
                ProductId = productId,
                ProductName = productName,
                UnitPrice = unitPrice,
                Quantity = quantity,
                Size = size,
                Color = color
            };
        }
    }
}

