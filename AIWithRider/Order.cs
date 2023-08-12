namespace AIWithRider;

public class Order
{
    public List<OrderLineItem> OrderLineItems { get; private set; } = new();
    
    public void AddOrderLineItem(OrderLineItem newItem)
    {
        OrderLineItems.Add(newItem);
    }

    public decimal TotalPrice
    {
        get
        {
            var totalPrice = OrderLineItems.Sum(item => item.Price);

            if (totalPrice > 100m)
                return totalPrice * 0.9m;
            else if (totalPrice > 50m)
                return totalPrice * 0.95m;
            else
                return totalPrice;
        }
    }
}