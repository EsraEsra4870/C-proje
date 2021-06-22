using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal:IEntityRepository<Product>//Dal katmanlar için kullanılır.product ile ilgili veritabnında operasyonların yapılacağı interfacedir.Opresyonlarda:Güncelle,sil gibi şeylerdir.
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
//Concrete klasörü somut şeylerin atılacağı yerdir.
//Ürünleri kategoriye göre listele