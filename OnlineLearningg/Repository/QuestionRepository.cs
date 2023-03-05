using Microsoft.Extensions.Hosting;
using OnlineLearningg.Data;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using System.ComponentModel.Design;

namespace OnlineLearningg.Repository
{
    public class QuestionRepository : IQuestion
    {
        private readonly OnlineLearningContext _context;
        bool IQuestion.Exist(int id)
        {
            return _context.Questions.Any(x => x.QuestionId == id);
        }

        Question IQuestion.GetQuestionByID(int Question_Id)
        {
            var question = _context.Questions.FirstOrDefault(x => x.QuestionId == Question_Id);
            return question;
        }

        ICollection<Question> IQuestion.GetQuestions()
        {
            return _context.Questions.ToList();
        }

        bool IQuestion.Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
