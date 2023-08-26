using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Products;

public class ProductCreateViewModel
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
}
