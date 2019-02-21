using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.DAO
{
    public class UserDAO
    {
        private IConfiguration _configuracoes;
        private readonly ILogger _logger;

        public UserDAO(IConfiguration config, ILogger<UserDAO> logger)
        {
            _configuracoes = config;
            _logger = logger;
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
            catch (Exception ex)
            {
                userExist = false;
                _logger.LogError("Error: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}", ex);
            }
        }
    }
}
