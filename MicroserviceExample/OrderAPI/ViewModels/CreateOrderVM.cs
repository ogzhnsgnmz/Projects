using OrderAPI.Models.Entities;
using OrderAPI.Models.Enums;

namespace OrderAPI.ViewModels;

public class CreateOrderVM
{
    public Guid BuyerID { get; set; }
    public List<CreateOrderItemVM> OrderItems { get; set; }
}

public class CreateOrderItemVM
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}