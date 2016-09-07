using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.WebUI.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Produts { get; set; }

        IEnumerable<Product> ProductsItem { get; set; }
    }
}
