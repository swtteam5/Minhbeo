using OnlineLearningg.Models;
namespace OnlineLearningg.Interface
{
    public interface IProfile
    {
        User GetProfileByID(int profile_id);
        bool UpdateProfile(int id, User user);      
        bool Exist(int id);
        bool Save();
    }
}
