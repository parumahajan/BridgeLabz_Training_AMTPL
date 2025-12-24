//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
//using Microsoft.IdentityModel.Protocols;

//namespace BridgeLabz_Training.NUnit
//{
//    class Practice
//    {
//        static void Main(string[] args)
//        {
//            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

//            using (SqlConnection con = new SqlConnection(cs))
//            {
//                con.Open();
//                SqlTransaction transaction = con.BeginTransaction();

//                try
//                {

//                    // 1. Insert Bill

//                    SqlCommand billCmd = new SqlCommand(
//                        "INSERT INTO Bills (BillDate, TotalAmount) OUTPUT INSERTED.BillId VALUES (@date, @total)",
//                        con, transaction);

//                    billCmd.Parameters.AddWithValue("@date", DateTime.Now);
//                    billCmd.Parameters.AddWithValue("@total", 1500);

//                    int billId = (int)billCmd.ExecuteScalar();


//                    // Bill Items (Sample Data)

//                    List<(int productId, int quantity)> items = new List<(int, int)>
//                    {
//                        (1, 2),
//                        (2, 3)
//                    };

//                    foreach (var item in items)
//                    {

//                        // 2. Check Stock

//                        SqlCommand stockCmd = new SqlCommand(
//                            "SELECT Stock, Price FROM Inventory WHERE ProductId = @pid",
//                            con, transaction);

//                        stockCmd.Parameters.AddWithValue("@pid", item.productId);

//                        SqlDataReader reader = stockCmd.ExecuteReader();

//                        if (!reader.Read())
//                        {
//                            reader.Close();
//                            throw new Exception("Product not found");
//                        }

//                        int availableStock = Convert.ToInt32(reader["Stock"]);
//                        decimal price = Convert.ToDecimal(reader["Price"]);
//                        reader.Close();

//                        if (availableStock < item.quantity)
//                        {
//                            throw new Exception($"Insufficient stock for Product ID {item.productId}");
//                        }


//                        // 3. Insert BillItem

//                        SqlCommand itemCmd = new SqlCommand(
//                            "INSERT INTO BillItems (BillId, ProductId, Quantity, Price) VALUES (@billId, @pid, @qty, @price)",
//                            con, transaction);

//                        itemCmd.Parameters.AddWithValue("@billId", billId);
//                        itemCmd.Parameters.AddWithValue("@pid", item.productId);
//                        itemCmd.Parameters.AddWithValue("@qty", item.quantity);
//                        itemCmd.Parameters.AddWithValue("@price", price);

//                        itemCmd.ExecuteNonQuery();


//                        // 4. Reduce Inventory

//                        SqlCommand updateStockCmd = new SqlCommand(
//                            "UPDATE Inventory SET Stock = Stock - @qty WHERE ProductId = @pid",
//                            con, transaction);

//                        updateStockCmd.Parameters.AddWithValue("@qty", item.quantity);
//                        updateStockCmd.Parameters.AddWithValue("@pid", item.productId);

//                        updateStockCmd.ExecuteNonQuery();
//                    }

//                    // 5. Commit Transaction

//                    transaction.Commit();
//                    Console.WriteLine("Bill generated successfully.");
//                }
//                catch (Exception ex)
//                {

//                    // Rollback on Failure

//                    transaction.Rollback();
//                    Console.WriteLine("Transaction failed.");
//                    Console.WriteLine(ex.Message);
//                }
//            }

//            Console.ReadLine();
//        }
//    }
//}
