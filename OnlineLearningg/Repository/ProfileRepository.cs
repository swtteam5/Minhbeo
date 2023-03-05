using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OnlineLearningg.Data;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using System.ComponentModel.Design;
namespace OnlineLearning.Repository
{
    public class ProfileRepository : IProfile
    {

        private readonly OnlineLearningContext _context;
        public User GetProfileByID(int id)
        {
            var profile = _context.Users.FirstOrDefault(x => x.UserId == id);
            return profile;
        }
        bool IProfile.Exist(int id)
        {
            return _context.Users.Any(x => x.UserId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool IProfile.UpdateProfile(int id, User user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
