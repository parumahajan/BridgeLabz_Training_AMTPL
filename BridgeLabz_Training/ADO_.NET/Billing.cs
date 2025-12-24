/*

Question:
Billing Transaction Consistency (Critical – POS System)

Scenario:
In a billing application, when a bill is generated:
- Insert record into Bills table
- Insert multiple records into BillItems table
- Reduce stock in Inventory table

Problem:
Write an ADO.NET program that ensures all operations succeed or none happen.

Constraints:

- Use SqlTransaction
- If any product stock is insufficient → rollback
- Do not use Entity Framework
 
 */

using System;
using Microsoft.Data.SqlClient;

namespace BridgeLabz_Training.ADO_.NET
{
    public class Billing
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Data Source=PRANAV\SQLEXPRESS;
                  Initial Catalog=BILLING;
                  Integrated Security=True;
                  TrustServerCertificate=True;";
            /*
            
            Data Source
            - Tells where SQL Server is running
            - PRANAV -> Machine name
            - SQLEXPRESS -> SQL Server instance name
     
            
            Initial Catalog
            - Specifies WHICH DATABASE to connect to

            Integrated Security
            - Uses Windows Authentication
            - SQL Server trusts your Windows login
            - Tells how to authenticate
            
            Trust_Server_Certificate
            - Bypasses SSL certificate validation
            - “Even if the SSL certificate isn’t trusted, connect anyway.”

             */

            using SqlConnection connection = new SqlConnection(connectionString);
            
            // SqlConnection represents a physical connection between C# application and SQL Server.


            connection.Open();
            // Opens the database connection


            using SqlTransaction transaction = connection.BeginTransaction();
            // SqlTransaction ensures:
            // - Either ALL operations succeed
            // - Or ALL operations fail (rollback)

            try
            {                
                // STEP 1: SHOW AVAILABLE PRODUCTS
                string productQuery =
                    "SELECT ProductId, ProductName, StockQty, Price FROM Inventory";

                using (SqlCommand cmd = new SqlCommand(productQuery, connection, transaction))
                // SqlCommand - is an object that represents a SQL query/command which we want to execute on SQL Server.

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // SqlDataReader - is an object used to read data returned from a SELECT query, one row at a time, forward only.

                    // ExecuteReader() - executes the SQL SELECT query and returns the result row by row (provides a stream of rows).

                    Console.WriteLine("ID \t Name \t \t Stock \t Price"); // no space
                    // \t inserts a TAB (horizontal tab) space in a string.

                    while (reader.Read()) // Read each row returned from Inventory table
                    {
                        Console.WriteLine(
                            $"{reader["ProductId"]} \t {reader["ProductName"]} \t {reader["StockQty"]} \t {reader["Price"]}");
                    }
                }
                
                // STEP 2: USER INPUT (SAFE)
               
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid Product ID.");
                    return;
                }
                /*
                 TRY PARSE
                 - TryParse is a safe conversion method.
                 - It doesn't throw an exception.
                 - Doesn't need try-catch unlike int.Parse
                 - Its program never crahses

                 OUT
                 - It is a keyword used to return values from a method.
                 - Returns:
                 1) true or false (success/failure)
                 2) The converted integer

                 Logic: “If the conversion succeeds, put the result inside the variable mentioned.”

                ! is the logical NOT operator




                */
                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Invalid Quantity.");
                    return;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                    return;
                }

                
                // STEP 3: CREATE BILL
               
                string insertBillQuery =
                    @"INSERT INTO Bills (BillDate, TotalAmount)
                      VALUES (GETDATE(), 0);
                      SELECT SCOPE_IDENTITY();";

                int billId;
                using (SqlCommand cmd = new SqlCommand(insertBillQuery, connection, transaction))
                {
                    billId = Convert.ToInt32(cmd.ExecuteScalar());
                }

              
                // STEP 4: CHECK STOCK & PRICE
               
                int stockAvailable;
                decimal price;

                string stockQuery =
                    "SELECT StockQty, Price FROM Inventory WHERE ProductId = @pid";

                using (SqlCommand cmd = new SqlCommand(stockQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                        throw new Exception("Product not found.");

                    stockAvailable = (int)reader["StockQty"];
                    price = (decimal)reader["Price"];
                }

                if (stockAvailable < quantity)
                    throw new Exception("Insufficient stock.");

               
                // STEP 5: INSERT BILL ITEM
             
                string insertItemQuery =
                    @"INSERT INTO BillItems (BillId, ProductId, Quantity, Price)
                      VALUES (@bid, @pid, @qty, @price)";

                using (SqlCommand cmd = new SqlCommand(insertItemQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@bid", billId);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }

              
                // STEP 6: UPDATE INVENTORY
              
                string updateStockQuery =
                    "UPDATE Inventory SET StockQty = StockQty - @qty WHERE ProductId = @pid";

                using (SqlCommand cmd = new SqlCommand(updateStockQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.ExecuteNonQuery();
                }

                // STEP 7: UPDATE BILL TOTAL
           
                decimal totalAmount = price * quantity;

                string updateBillQuery =
                    "UPDATE Bills SET TotalAmount = @total WHERE BillId = @bid";

                using (SqlCommand cmd = new SqlCommand(updateBillQuery, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@total", totalAmount);
                    cmd.Parameters.AddWithValue("@bid", billId);
                    cmd.ExecuteNonQuery();
                }

                // -----------------------------
                // STEP 8: COMMIT TRANSACTION
                // -----------------------------
                transaction.Commit();
                Console.WriteLine("\n✅ Billing completed successfully!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("\n❌ Transaction failed:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
