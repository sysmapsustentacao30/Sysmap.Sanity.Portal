using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.DAO
{
    public class UserDAO
    {
        private IConfiguration _configuracoes;

        public UserDAO(IConfiguration config)
        {
            _configuracoes = config;
        }

        internal bool VerifyUser(string email, string password)
        {
            bool userExist = false;
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    int result = mysqlCon.Query<int>(@"SELECT count(*) FROM Sanity.User_Test where Email = @Email AND Password = @Password;", new { Email = email, Password = password }).First();

                    if(result == 1)
                    {
                        userExist = true;
                    }
                }

            }
            catch (Exception)
            {
                userExist = false;
            }

            return userExist;
        }

        internal bool CreateUser(User user)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"INSERT INTO Sanity.User_Test
                                (Email,
                                 Password,
                                TypeUser,
                                DateCreate)
                                VALUES
                                (@Email,
                                @Senha,
                                @TypeUser,
                                @DateCreate);";

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                     mysqlCon.Execute(query, new { Email = user.Email, Senha = user.Password, TypeUser = user.TypeUser, DateCreate = user.DateCreate });
                }

            }
            catch (Exception)
            {

            }

            return VerifyUser(user.Email, user.Password);
        }

        internal User GetUser(string email)
        {
            User user = new User();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    user = mysqlCon.Query<User>(@"SELECT * FROM Sanity.User_Test where Email = @Email;", new { Email = email}).SingleOrDefault();
                }

            }
            catch (Exception)
            {
                
            }


            return user;
        }

        internal List<User> GetAllUser()
        {
            List<User> user = new List<User>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                   var result = mysqlCon.Query<User>(@"SELECT * FROM Sanity.User_Test;");

                    foreach(User item in result)
                    {
                        user.Add(item);
                    }
                }

            }
            catch (Exception)
            {

            }


            return user;
        }

        internal void EditUser(User user)
        {
            try
            {
                string query = @"UPDATE Sanity.User_Test
                                SET
                                    Email = @Email,
                                    Password = @Password,
                                    TypeUser = @TypeUser
                                WHERE idUser = @idUser;";

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                  mysqlCon.Execute(query,new {Email = user.Email, Password = user.Password, TypeUser = user.TypeUser, idUser = user.idUser });
                }

            }
            catch (Exception)
            {

            }
        }

        internal void DeleteUser(User user)
        {
            try
            {
                string query = @"DELETE FROM Sanity.User_Test WHERE idUser = @idUser;";

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute(query, new { idUser = user.idUser });
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
