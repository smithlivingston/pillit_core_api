using MongoDB.Bson;
using pillit.lib;
using Pillit.api.Contracts.IRepositories;
using Pillit.api.Contracts.IServices;
using Pillit.api.Models;
using Pillit.api.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pillit.api.Services
{
    public class UserService : IUserService
    {
        #region Declaration
        private readonly IUserRepository _UserRepository;
        #endregion

        #region Constructor
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        #endregion


        public Task<List<User>> GetAllAsync()
        {
            return _UserRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            return _UserRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateUser(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            { 
                var savedRecord = await _UserRepository.GetByIdAsync(user.UserId);
                
                if (savedRecord != null && savedRecord.UserId != Guid.Empty)
                {
                    user.UpdatedTimeStamp = DateTime.UtcNow;
                    //check valid user 
                    
                    if (savedRecord.Password == Utility.GenerateHashedPassword(user.Password, savedRecord.PasswordSalt))
                    {

                        //var objectId = new ObjectId(user.Id.ToString());
                        return await _UserRepository.UpdateAsync(user.UserId, user);
                        //return success message updated successfully
                    }
                    //throw error message wrong authentication to update record
                }
                else
                {
                    var newUser = new User();
                    newUser.UserId = Guid.NewGuid();
                    newUser.Email = user.Email;
                    newUser.Details = new UserDetails();
                    //geenrate salt 
                    newUser.PasswordSalt = Utility.GenerateSalt();
                    //generate hash 
                    newUser.Password = Utility.GenerateHashedPassword(user.Password, newUser.PasswordSalt);
                    
                    newUser.CreatedTimeStamp = DateTime.UtcNow;
                    newUser.UpdatedTimeStamp = DateTime.UtcNow;

                    //set User Details 
                    newUser.Details.UserId = user.UserId;
                    newUser.Details.UserId = user.UserId;
                    newUser.Details.FirstName = user.Details.FirstName;
                    newUser.Details.LastName = user.Details.LastName;
                    newUser.Details.DOB = user.Details.DOB;

                    return await _UserRepository.CreateAsync(newUser);
                    //return success message user created successfully
                }
            }
            return user;
        }

        public Task UpdateAsync(Guid id, User User)
        {
            return _UserRepository.UpdateAsync(id, User);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _UserRepository.DeleteAsync(id);
        }
    }
}
