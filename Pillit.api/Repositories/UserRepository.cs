using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Pillit.api.Contracts.IRepositories;
using Pillit.api.Entities.Context;
using Pillit.api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pillit.api.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Declaration
        private readonly IMongoCollection<User> _collection;
        private readonly DbConfigurationContext _settings;
        #endregion



        #region Constructor
        public UserRepository(IOptions<DbConfigurationContext> settings)
        {
            _settings= settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<User>(_settings.CollectionName);
        }
        #endregion

        #region CreateUser
        /// <summary>
        /// Creates User Account
        /// </summary>
        /// <returns></returns>
        public User CreateUser()
        {
            return new User();
        }
        #endregion


        public Task<List<User>> GetAllAsync()
        {
            var data = _collection.Find(c => true).ToListAsync();
            return data;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            var _filter = Builders<User>.Filter.Eq("UserId", userId);
            var userData = _collection.Find(_filter).SingleOrDefault();
            return userData;
        }
        public async Task<User> CreateAsync(User user)
        {
            if (user != null)
            {
                await _collection.InsertOneAsync(user).ConfigureAwait(false);
            }
            return user;
        }

        public async Task<User> GetUserByEmail(string email) 
        {
            if (!string.IsNullOrEmpty(email))
            {
                var filter = Builders<User>.Filter.Eq("email", email);
                var record =  _collection.Find(filter).SingleOrDefault();
                if (record != null && record.UserId != Guid.Empty)
                    return record;
                else 
                    return new User();
            }
            return new User();
        }

        public async Task<User> UpdateAsync(Guid id, User user)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(user._objRefId.ToString()));
            user.Id =  _collection.Find(filter).SingleOrDefault().Id;
            await _collection.ReplaceOneAsync(filter, user);
            return await Task.FromResult(user);
        }
        public async Task<bool> DeleteAsync(Guid userId)
        {
            var result = await _collection.DeleteOneAsync(c => c.UserId == userId);
            if (result.IsAcknowledged)
                return true;
            else return false;
        }
        public Task<UserDetails> SaveUserDetails(UserDetails userDetails)
        {
            if (userDetails != null)
            {
                var filter = Builders<User>.Filter.Eq(x=>x.Details.UserId, userDetails.UserId);
                var savedUserDetails = _collection.Find(filter).SingleOrDefault().Details;


                if (savedUserDetails != null)
                {
                    //update record
                }
                else { 
                    
                }
            }
            return Task.FromResult(userDetails);
        }

    }
}
