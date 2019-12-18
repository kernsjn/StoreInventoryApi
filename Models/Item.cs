using System;
// using System.ComponentModel.DataAnnotations; Only if Required Field

namespace StoreInventoryApi.Models
{
  public class Item
  {
    public int Id { get; set; }

    public int SKU { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public int NumberInStock { get; set; }

    public int Price { get; set; }

    public DateTime DateOrdered { get; set; }
  }
}