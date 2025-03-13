using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo1.Models;

namespace EntityFrameworkDemo1.Controllers
{
    public class NorthWindController : Controller
    {

        //NorthwndContext cnt=new NorthwndContext();

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult spainCustomers()
        //{
        //    var spaincustomers = from cust in cnt.Customers
        //                         where cust.Country == "Spain"
        //                         select new Customer
        //                         {
        //                            CustomerId= cust.CustomerId,
        //                           ContactName=  cust.ContactName,
        //                           CompanyName=  cust.CompanyName
        //                         };
        //    return View(spaincustomers);
        //}

        //public IActionResult SearchCustomer(string contactname)
        //{
        //    var searchcustomer = from cust in cnt.Customers
        //                         where cust.ContactName == contactname
        //                         select new Customer
        //                         {
        //                             CustomerId = cust.CustomerId,
        //                             ContactName = cust.ContactName,
        //                             CompanyName = cust.CompanyName
        //                         };

        //    var query1 = searchcustomer.Single();
        //    return View(query1);
        //}

        //public IActionResult ProductsInCategory(string categoryname)
        //{
        //    var productsincategory = from prod in cnt.Products
        //                             where prod.Category.CategoryName == categoryname
        //                             select new ProdCat
        //                             {
        //                                 prodname=prod.ProductName,
        //                                 catname=prod.Category.CategoryName
        //                             };

            

        //return View(productsincategory); 
        //}


        //public IActionResult OrderRange(string range)
        //{
        //    int range1=Convert.ToInt32(range);
        //    var customerordercount = from cust in cnt.Customers
        //                             where cust.Orders.Count > range1
        //                             select new CustomerRange
        //                             {
        //                                 CustomerId = cust.CustomerId,
        //                                 ContactName = cust.ContactName,
        //                                 orderscount = cust.Orders.Count,
        //                             };
        //    return View(customerordercount);
        //}
    }
}
