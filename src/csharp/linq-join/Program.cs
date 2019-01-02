using System;
using System.Linq;
using System.ComponentModel;

using linqshared;

namespace linq_join
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq102();
//            Linq103();
//            Linq104();
//            Linq105();
        }

        [Category("Join Operators")]
        [Description("This sample shows how to perform a simple inner equijoin of two sequences to produce a flat result set that consists of each element in suppliers that has a matching element in customers.")]
        static void Linq102()
        {
            var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };

            var products = GetProductList();

            var q = categories
                .Join(products, c => c, p => p.Category, (c, p) => 
                    new
                    {
                        Category = c, 
                        p.ProductName
                    });

            q.ForEach(v => Console.WriteLine($"Category: {v.Category}: Product {v.ProductName}"));
        }

        [Category("Join Operators")]
        [Description("A group join produces a hierarchical sequence. The following query is an inner join that produces a sequence of objects, each of which has a key and an inner sequence of all matching elements.")]
        static void Linq103()
        {
            var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  

            var products = GetProductList(); 
  
            var q = categories
                .GroupJoin(products, c => c, p => p.Category, (c, ps) => 
                    new
                    {
                        Category = c, 
                        Products = ps
                    }); 
  
            q.ForEach((v) => 
            {
                Console.WriteLine(v.Category + ":"); 
                v.Products.ForEach(p => Console.WriteLine($"\t{p.ProductName}"));
            });
        }

        [Category("Join Operators")]
        [Description("The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.")]
        static void Linq104()
        {
            var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  

            var products = GetProductList();

            var prodByCategory = categories
                .GroupJoin(products, cat => cat, prod => prod.Category, 
                    (category, prods) => 
                        new
                        {
                            category, 
                            prods
                        })
                .SelectMany(x => 
                    x.prods, (x, plist) => 
                    new
                    {
                        Category = x.category, 
                        plist.ProductName
                    });

            prodByCategory.ForEach(item => Console.WriteLine($"{item.ProductName }: {item.Category}"));
        }
        [Category("Join Operators")]
        [Description("A left outer join produces a result set that includes all the left hand side elements at least once, even if they don't match any right hand side elements.")]
        static void Linq105()
        {
            var categories = new [] {"Beverages","Condiments","Vegetables","Dairy Products","Seafood" };  
  
            var products = GetProductList(); 
  
            var q = categories
                .GroupJoin(products, cat => cat, prod => prod.Category, (category, prods) => 
                    new
                    {
                        category, 
                        prods
                    })
                .SelectMany(x => x.prods.DefaultIfEmpty(),(x, p) => 
                    new
                    {
                        Category = x.category, 
                        ProductName = p == null ? "(No products)" : p.ProductName
                    }); 
  
            q.ForEach(item => Console.WriteLine($"{item.ProductName }: {item.Category}"));
        }
    }
}
