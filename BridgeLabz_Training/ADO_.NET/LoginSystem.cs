using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BridgeLabz_Training.ADO_.NET
{
    class LoginSystem
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Data Source=PRANAV\SQLEXPRESS;
                  Initial Catalog=AUTH_SYSTEM;
                  Integrated Security=True;
                  TrustServerCertificate=True;";

            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Login");
            Console.Write("Choose option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                return;

            if (choice == 1)
                SignUp(connectionString);
            else if (choice == 2)
                Login(connectionString);
        }

      
        // SIGN UP
     
        static void SignUp(string cs)
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (!IsValidPassword(password))
            {
                Console.WriteLine("Password does not meet security rules.");
                return;
            }

            string passwordHash = HashPassword(password);
            Guid userId = Guid.NewGuid();

            using SqlConnection con = new SqlConnection(cs);
            con.Open();

            string insertQuery =
                @"INSERT INTO Users (UserId, Email, PasswordHash, CreatedAt)
                  VALUES (@uid, @email, @pwd, GETDATE())";

            try
            {
                using SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd", passwordHash);

                cmd.ExecuteNonQuery();
                Console.WriteLine("User registered successfully!");
                Console.WriteLine($"Your User ID: {userId}");
            }
            catch
            {
                Console.WriteLine("❌ Email already exists.");
            }
        }

 
        // LOGIN
       
        static void Login(string cs)
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string passwordHash = HashPassword(password);

            using SqlConnection con = new SqlConnection(cs);
            con.Open();

            string loginQuery =
                @"SELECT UserId FROM Users
                  WHERE Email = @email AND PasswordHash = @pwd";

            using SqlCommand cmd = new SqlCommand(loginQuery, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", passwordHash);

            object result = cmd.ExecuteScalar();

            if (result == null)
                Console.WriteLine("Invalid email or password.");
            else
                Console.WriteLine($"Login successful! User ID: {result}");
        }

        // PASSWORD VALIDATION (IF–ELSE)

        static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < 8)
                return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char ch in password)
            {
                if (char.IsWhiteSpace(ch))
                    return false;   // No spaces allowed

                if (char.IsUpper(ch))
                    hasUpper = true;
                else if (char.IsLower(ch))
                    hasLower = true;
                else if (char.IsDigit(ch))
                    hasDigit = true;
                else
                    hasSpecial = true;
            }

            if (!hasUpper) return false;
            if (!hasLower) return false;
            if (!hasDigit) return false;
            if (!hasSpecial) return false;

            return true;
        }

        // PASSWORD HASHING
   
        static string HashPassword(string password)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}