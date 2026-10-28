using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class ProductsModel : PageModel
{
    // This list holds the products from the database
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        // Initialize the list of products
        Products = new List<Product>();

        // Connects to the Northwind database
        string connectionString = "Data Source=../northwind.db;Mode=ReadOnly";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            // This will get the product name category name, and unit pricec
            string sql = @"SELECT p.ProductName, c.CategoryName, p.UnitPrice
                           FROM Products p
                           JOIN Categories c ON p.CategoryID = c.CategoryID";

            // Execute the SQL statement against the database
            using (SqliteCommand command = new SqliteCommand(sql, connection))
            {
                // Reads the results returned by the database
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    // Will loop through each product in the result
                    while (reader.Read())
                    {
                        Products.Add(new Product
                        {
                            ProductName = reader.GetString(0),
                            CategoryName = reader.GetString(1),
                            UnitPrice = (decimal)reader.GetDouble(2)
                        });
                    }
                }
            }
        }
    }
}

// Describes a product
public class Product
{
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public decimal UnitPrice { get; set; }
}