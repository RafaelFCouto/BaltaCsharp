
using Blog.Models.Domain;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog
{
    class Program
    {
        private const string connectionString =
            "Server=localhost;Database=Blog;Integrated Security=SSPI;trusted_connection = true;TrustServerCertificate=true";
        static void Main(string [] args)
        {
            
            //ReadUsers();
            //ReadUser(2);
            //CreateUser();
            //UpdateUser();
            DeleteUser();


        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
            
        }
        public static void ReadUser(int? id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(id);
                Console.WriteLine(user.Name);
            }
            
        }

        
        
        public static void CreateUser()
        {
            var user = new User();
            user.Name = "Silmara Lima";
            user.Email = "silmara@email.com";
            user.Bio = "Developer JS";
            user.Image = "https://";
            user.PasswordHash = "HASH";
            user.Slug = "silmara-lima";
            

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso.");
            }
        
        }
        
        
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Engineer",
                Email = "gabriel@email.com",
                Image = "https://",
                Name = "Gabriel Freire",
                PasswordHash = "HASH",
                Slug = "gabriel-freire"
            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualização realizada com sucesso");

            }
            
        }
        
        
        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var user = connection.Get<User>(2);
                connection.Delete(user);
                Console.WriteLine("Exclusão realizada com sucesso");




            }
        }
         
         
        
        
    }
}