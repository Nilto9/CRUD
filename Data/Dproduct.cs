using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class Dproduct
    {
        private string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=tecsup;Password=tecsup";

        public List<Product> Get()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abre la conexión

                string query = "ListarProducto";

                using (SqlCommand command = new SqlCommand("ListarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                product_id = reader.GetInt32(reader.GetOrdinal("product_id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                price = reader.GetDecimal(reader.GetOrdinal("price")),
                                stock = reader.GetInt32(reader.GetOrdinal("stock")),
                                active = reader.GetBoolean(reader.GetOrdinal("active"))
                            };

                            productList.Add(product);
                        }
                    }
                }
            }
            return productList;
        }
    }
}
