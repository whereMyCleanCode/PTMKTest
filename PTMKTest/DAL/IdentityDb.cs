using System;
using PTMKTest.Models;
using Dapper;
using Npgsql;
using BenchmarkDotNet.Attributes;

namespace PTMKTest.DAL
{
    [MemoryDiagnoser]
    [RankColumn]
    public class IdentityDb : IIdentityDb
    {
        [Benchmark]
        public async Task<int> CreateUser(UserModel model)
        {
            using (var connection = new NpgsqlConnection(PTMKTest.Hepler.DbHelper._conString))
            {
                await connection.OpenAsync();

                string sqlResponse =
                @"insert into users (FirstName, SecondName, FatherName, Gender, Birthday) 
                values (@FirstName, @SecondName, @FatherName, @Gender, @Birthday);
                SELECT currval(pg_get_serial_sequence('users','userid'));";

                return await connection.QuerySingleAsync<int>(sqlResponse, model);
            }
        }

        [Benchmark]
        public async Task<List<UserModel>> GetUniqUsers()
        {
            using (var connection = new NpgsqlConnection(PTMKTest.Hepler.DbHelper._conString))
            {
                await connection.OpenAsync();

                 var userModels =  await connection.QueryMultipleAsync(
                 @"Select Distinct FirstName, SecondName, FatherName, Gender, Birthday
                 From Users
                 Order By FirstName ,SecondName,FatherName;");

                 return userModels.Read<UserModel>().ToList();

            }
        }

        [Benchmark]
        public async Task<List<UserModel>> GetUniqUsers(string param)
        {
            using (var connection = new NpgsqlConnection(PTMKTest.Hepler.DbHelper._conString))
            {
                await connection.OpenAsync();

                var userModels = await connection.QueryMultipleAsync(
                @"Select Distinct FirstName, SecondName, FatherName, Gender, Birthday
                From Users
                Where Gender = 'Male' and
                SecondName Like 'F%' and
                FatherName Like 'F%'
                Order By SecondName;");

                return userModels.Read<UserModel>().ToList();

            }
        }

        [Benchmark]
        public async Task<UserModel> GetUser(int id)
        {
            using (var connection = new NpgsqlConnection(PTMKTest.Hepler.DbHelper._conString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select Email, Password, Salt, Id, NickName
                From Users where Id = @id", new { id = id }) ?? new UserModel();
            }
        }

        [Benchmark]
        public async Task<UserModel> GetUser(string secondname)
        {
            using (var connection = new NpgsqlConnection(PTMKTest.Hepler.DbHelper._conString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select FirstName, SecondName, FatherName, Gender
                From Users where  SecondName = @secondname", new { secondname = secondname }) ?? new UserModel();

            }
        }
    }
}

