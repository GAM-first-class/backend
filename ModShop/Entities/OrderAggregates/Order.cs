namespace ModShop.Entities.OrderAggregates
{
    public sealed class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }                
        public int TotalAmount { get; set; }              
        public int ItemsCount { get; set; }
        public int ShippingCost { get; set; }             
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public ICollection<OrderDetail> Items { get; set; } = new List<OrderDetail>();

        // ---------------------- Behavior ----------------------

        public static Order Create(Guid userId)
        {
            return new Order
            {
                Id = Guid.CreateVersion7(),
                UserId = userId,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                ShippingCost = 0
            };
        }



        public void AddItem(OrderDetail item)
        {
            Items.Add(item);
            Recalculate();
        }

        public void RemoveItem(Guid orderItemId)
        {
            var item = Items.FirstOrDefault(x => x.Id == orderItemId);
            if (item != null)
            {
                Items.Remove(item);
                Recalculate();
            }
        }

        public void Recalculate()
        {
            ItemsCount = Items.Sum(x => x.Quantity);
            TotalAmount = Items.Sum(x => x.TotalPrice) + ShippingCost;
        }
    }
}
