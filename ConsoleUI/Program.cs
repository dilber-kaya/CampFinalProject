// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


ProductManager productManager = new ProductManager(new EfProductDal());
//IProductDal (interface) InMemoryProductDal' ın referansını tutar

foreach (var product in productManager.GetByUnitPrice(40,100))
{
    Console.WriteLine(product.ProductName);
}