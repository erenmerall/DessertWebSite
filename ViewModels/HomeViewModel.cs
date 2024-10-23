using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalMutfak.Models;

namespace BalMutfak.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }
        public List<Customers> Customers { get; set; }
    }
}