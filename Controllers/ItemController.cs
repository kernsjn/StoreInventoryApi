
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoreInventoryApi.Models;

namespace StoreInventoryApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ItemController : ControllerBase
  {

    [HttpGet]

    public ActionResult GetAllItems()
    {
      var db = new DatabaseContext();
      return Ok(db.Items.OrderBy(items => items.SKU));
    }



    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(it => it.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    [HttpPost]
    public ActionResult CreateItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(Item item)
    {
      var db = new DatabaseContext();
      var prevItem = db.Items.FirstOrDefault(it => it.Id == item.Id);
      if (prevItem == null)
      {
        return NotFound();
      }
      else
      {
        prevItem.Name = item.Name;
        prevItem.SKU = item.SKU;
        prevItem.ShortDescription = item.ShortDescription;
        prevItem.NumberInStock = item.NumberInStock;
        prevItem.Price = item.Price;
        prevItem.DateOrdered = DateTime.Now;
        db.SaveChanges();
        return Ok(prevItem);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(it => it.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }


    [HttpGet("{stock}")]
    public ActionResult GetInStock(int NumberInStock)
    {
      var db = new DatabaseContext();
      return Ok(db.Items.Where(item => item.NumberInStock == 0));

    }


    

  }
}
