using CR.CricketerRanking.Data.Contract;
using CR.CricketerRanking.Type.Types;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CR.CricketerRanking.Common;
using Role = CR.CricketerRanking.Common.Role;
using DapperParameters;
using System.Data;
using CR.CricketerRanking.Type.HelperType;

namespace CR.CricketerRanking.Data.Implement
{
    public class UserRepository : IUserRepository
    {
        string ConString = "Server=CHANDAN-PC;Database=CricketerRanking;Trusted_Connection=True;";
       
        public List<User> GetBatsman()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                var query = $@"SELECT u.* FROM [User] u
                            JOIN [UserRole] ur ON u.UserID = ur.UserID                                                                        
                            JOIN [Role] r ON r.RoleID = ur.RoleID
                            WHERE r.RoleID = 1
                            AND u.IsActive = 1";
                con.Open();
                var batsman = con.Query<User>(query).ToList();
                con.Close();
                return batsman;
            };
        }

        public List<User> GetBowlers()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                var query = $@"SELECT u.* FROM [User] u
                            JOIN [UserRole] ur ON u.UserID = ur.UserID 
                            JOIN [Role] r ON r.RoleID = ur.RoleID
                            WHERE r.RoleID = 2 
                            AND u.IsActive = 1";
                con.Open();
                var bowler = con.Query<User>(query).ToList();
                con.Close();
                return bowler;
            };
        }

        public void AddOrUpdateUserPoll(List<UserPoll> userPolls)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                var parameters = new DynamicParameters();
                parameters.AddTable<UserPoll>("@UserPoll", "UserPoll", userPolls);
                con.Query("CR_AddOrUpdateUserPoll", parameters, commandType: CommandType.StoredProcedure);           
            }
        }

        public List<CricktersPoll> GetUserPoll()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                var userPolls = con.Query<CricktersPoll>("CR_GetCricketersPoll", commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return userPolls;
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Firstname", user.Firstname);
                parameters.Add("@Lastname", user.Lastname);

                con.Query("CR_RegisterUser", parameters, commandType: CommandType.StoredProcedure);
            };
        }

        public User authenticateUser(string Username, string Password)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                var quary = $"SELECT * FROM [User] WHERE Username = '{Username}' AND Password = '{Password}'";
                con.Open();
                var check = con.Query<User>(quary).ToList().FirstOrDefault();

                return check;
            };
        }
    }
}
