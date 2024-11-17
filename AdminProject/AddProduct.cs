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
    public class AddProduct
    {
        public int AddNewProduct(string connectionDb)
        {
            int count = 0;
            string toContinue = "";
            string Category, Name, Description, Price, ImageUrl;
            while (toContinue != "n")
            {
                Console.WriteLine("enter categoryId");
                Category = Console.ReadLine();
                Console.WriteLine("enter Name");
                Name = Console.ReadLine();
                Console.WriteLine("enter Description");
                Description = Console.ReadLine();
                Console.WriteLine("enter Price");
                Price = Console.ReadLine();
                Console.WriteLine("enter ImageUrl");
                ImageUrl = Console.ReadLine();
                string query = "INSERT INTO product(Category_ID,Name,Description,Price,Image_url)" +
                        "VALUES(@Category_ID,@Name,@Description,@Price,@Image_url)";
                using (SqlConnection connection = new SqlConnection(connectionDb))
                    using(SqlCommand cmd=new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Category_ID", SqlDbType.Int).Value=int.Parse( Category);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value= Name;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value= Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Money).Value= Price;
                    cmd.Parameters.Add("@Image_url", SqlDbType.NVarChar).Value= ImageUrl;
                    connection.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    connection.Close();
                    count+= rowsAfected;
                }
                Console.WriteLine("Are you want to continue? (y/n)");
                toContinue = Console.ReadLine();
            }
            return (count);
        }


        public void getData(string connectionDb)
        {
            string query = "select p.Name,p.Description,p.Image_url,p.Price,p.ID,c.Name as 'CategoryName' from Category c\r\njoin Product p\r\non c.ID=p.Category_ID";
            using (SqlConnection connection = new SqlConnection(connectionDb))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                reader.Close();
            }

        }

    }


}
