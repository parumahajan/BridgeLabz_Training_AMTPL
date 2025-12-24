using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabz_Training.ADO_.NET
{
    class Log
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

        // ===============================
        // SIGN UP
        // ===============================
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
                Console.WriteLine("✅ User registered successfully!");
                Console.WriteLine($"Your User ID: {userId}");
            }
            catch (SqlException)
            {
                Console.WriteLine("❌ Email already exists.");
            }
        }

        // ===============================
        // LOGIN
        // ===============================
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
                Console.WriteLine("❌ Invalid email or password.");
            else
                Console.WriteLine($"✅ Login successful! User ID: {result}");
        }

        // ===============================
        // PASSWORD VALIDATION
        // ===============================
        static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            string pattern =
                @"^(?=.*[a-z])       # at least one lowercase
                  (?=.*[A-Z])        # at least one uppercase
                  (?=.*\d)           # at least one digit
                  (?=.*[@$!%*?&])    # at least one special char
                  [A-Za-z\d@$!%*?&]{8,}$";  // min 8 chars, no spaces

            return Regex.IsMatch(password, pattern, RegexOptions.IgnorePatternWhitespace);
        }

        // ===============================
        // PASSWORD HASHING
        // ===============================
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
