namespace AIWithRiderTests;

public class OrderTests
{
    [Fact]
    public void Test_AddOrderLineItem()
    {
        // Arrange
        var order = new Order();
        var item = new OrderLineItem() {Price = 100};

        // Act
        order.AddOrderLineItem(item);

        // Assert
        Assert.Contains(item, order.OrderLineItems);
    }

    [Fact]
    public void Test_TotalPrice_NoItems()
    {
        // Arrange
        var order = new Order();

        // Act
        var total = order.TotalPrice;

        // Assert
        Assert.Equal(0, total);
    }

    [Fact]
    public void TotalPrice_LessThanOrEqualTo50_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 25m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 25m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(50m, totalPrice);
    }

    [Fact]
    public void TotalPrice_JustAbove50_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 26m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 25m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(51 * 0.95m, totalPrice);
    }

    [Fact]
    public void TotalPrice_LessThanOrEqualTo100_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 50m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 50m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(100 * 0.95m, totalPrice);
    }

    [Fact]
    public void TotalPrice_JustAbove100_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 51m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 50m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(101 * 0.9m, totalPrice);
    }

    [Fact]
    public void TotalPrice_GreaterThan100_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 55m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 55m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(110 * 0.9m, totalPrice);
    }

    [Fact]
    public void TotalPrice_JustBelow50_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 24m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 25m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(49m, totalPrice);
    }

    [Fact]
    public void TotalPrice_JustBelow100_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 49m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 50m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(99 * 0.95m, totalPrice);
    }

    [Fact]
    public void TotalPrice_MiddleOfRangeBelow50_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 12m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 13m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(25m, totalPrice);
    }

    [Fact]
    public void TotalPrice_MiddleOfRangeBelow100AndAbove50_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 35m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 40m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(75 * 0.95m, totalPrice);
    }

    [Fact]
    public void TotalPrice_Above100_ReturnsCorrectTotal()
    {
        // Arrange
        var order = new Order();
        order.OrderLineItems.Add(new OrderLineItem {Price = 75m});
        order.OrderLineItems.Add(new OrderLineItem {Price = 75m});

        // Act
        var totalPrice = order.TotalPrice;

        // Assert
        Assert.Equal(150 * 0.9m, totalPrice);
    }
}