using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PMS.Models;

namespace PMS.Controllers
{
    public class ProductMasterController : Controller
    {
        private Business_Logic obj_logic;

        public ProductMasterController(IConfiguration _configuration)
        {
            obj_logic = new Business_Logic(_configuration);
        }



        public IActionResult AddProduct()
        {
            return View();
        }


        public IActionResult UpdateProduct()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            return View();
        }

        public IActionResult t()
        {
            return View();
        }
        public IActionResult CategoryPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategorySearch([FromBody]cls_for_all obj)
        {
            DataSet dataSet = obj_logic.CategorySearch(obj.is_active, obj.spmode);
            return Ok(dataSet);
        }

        [HttpPost]
        public IActionResult Insert_Product([FromBody] AddProduct obj)
        {
            //data
            DataSet dataSet = obj_logic.Insert_Product(obj.ProductName, obj.Product_Price, obj.Product_Quantity, obj.IsActive, obj.Created_By, obj.spmode);
            return Ok(dataSet);
        }

        [HttpPost]
        public IActionResult Update_Product([FromBody] UpdateProduct obj)
        {

            DataSet dataSet = obj_logic.Insert_Product(obj.ProductName, obj.Product_Price, obj.Product_Quantity, obj.IsActive, obj.Created_By, obj.spmode);
            return Ok(dataSet);
        }

        [HttpGet]
        public IActionResult GetProduct(int? sku = null)
        {
            DataSet dataSet = obj_logic.GetProduct();
            return Ok(dataSet);
        }






    }

}

public class cls_for_all
{
    public int is_active { get; set; }
    public int spmode { get; set; }
}
public class AddProduct
{
    public string ProductName;
    public int Product_Price;
    public int Product_Quantity;
    public int IsActive;
    public string Created_By;
    public int spmode;

}


public class UpdateProduct
{
    public int ProductId;
    public string ProductName;
    public int Product_Price;
    public int Product_Quantity;
    public int IsActive;
    public string Created_By;
    public int spmode;

}

//public class GetProduct
//{
//    public int ProductId;
//    public string ProductName;
//    public int Product_Price;
//    public int Product_Quantity;
//    public int IsActive;
//    public string Created_By;
//    public int spmode;

//}