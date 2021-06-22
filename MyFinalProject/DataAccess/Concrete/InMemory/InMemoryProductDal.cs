using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal//InMemoryProductDal hafızadaki ürünlerin katmanıdır.
    {
        List<Product> _products; //Global olduğu için alt çizgi kullanılur.
        public InMemoryProductDal() //consracter bellekte referans aldığı zaman oluşacak blok
        {
            //Oracle,Sql server,Postgres,MongoDb geliyomuş gibi
            _products = new List<Product> {//Bir sürü ürünü barındıran liste
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInstock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInstock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInstock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInstock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInstock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);//Veritabanından gelen ürünü ekliyoruz.
        }

        public void Delete(Product product)
        {
            //LINQ:Language Integrated Query:Dile gömülü sorgulama
            Product productToDelete= _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//Link kullanımı SingleOrDefault(p=>)kodu yukarıdaki foreachyi yapıyor aslında.p takma isimdir her p için diye okunur.


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğm ürün idsine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInstock = product.UnitsInstock;
            
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
         return _products.Where(p => p.CategoryId == categoryId).ToList();//where yeni bir liste haline getirir.ve dönderir.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
