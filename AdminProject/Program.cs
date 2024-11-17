using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AdminProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = "data source=srv2\\pupils;initial catalog=Web_Api_328306782;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            AddProduct product = new AddProduct();
            //int result=product.AddNewProduct(connection);
            //Console.WriteLine($"{result} lines are affected");
            //Console.ReadLine();
            product.getData(connection);
            Console.ReadLine();
        }
    }
}
