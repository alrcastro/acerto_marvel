using Firebase.Database;
using MarvelCore.Helpers;
using MarvelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelCore.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(User user);
        Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {
        FirebaseClient firebase;

        public UserService() {
            firebase = new FirebaseClient(Constants.FirebaseURL);             
        }
       
        public async Task<User> Authenticate(User userModel)
        {
            var users = await GetAll();
            var user = users.SingleOrDefault(x => x.Login == userModel.Login && x.Password == userModel.Password);
            
            if (user == null)
                return null;
            
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            List<User> userList;

            var objList = await firebase.Child("users").OnceAsync<User>();
            userList = objList.Select(o => { o.Object.Id = o.Key; return o.Object; }).ToList();
            
            return userList;
        }
    }
}
