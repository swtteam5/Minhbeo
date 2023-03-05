using OnlineLearningg.Models;
namespace OnlineLearningg.Interface
{
    public interface IQuestion
    {
        ICollection<Question> GetQuestions();
        Question GetQuestionByID(int Question_Id);     
        bool Exist(int id);
        bool Save();
    }
}
