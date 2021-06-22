using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Concrete
{
  public class Category: IEntity//IEntity Categorinin bir veritabanı tablosu olduğunu ifade eder.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
