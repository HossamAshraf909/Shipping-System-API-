﻿using Shipping.DAL.Entities;

public class Order_Product
{
    public int ProductId { get; set; }  
    public virtual Product? Product { get; set; }

    public int OrderId { get; set; }
    public virtual Order? Order { get; set; }
}
