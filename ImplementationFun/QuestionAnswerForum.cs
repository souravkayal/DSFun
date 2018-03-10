using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.QuestionAnswerForun
{

    public enum Category
    {
        C, Cpp, Csp, Java, DotNet 
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public DateTime PostOn { get; set; }
        public User PostedBy { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public string AnswerTesxt { get; set; }
        public User AnswerBy { get; set; }
        public DateTime PostedOn { get; set; }
        public Boolean IsCorrectAnswer { get; set; }
        public bool IsSpam { get; set; }
        public int VoteCount { get; set; }
    }


    public interface IForum
    {
        List<Question> GetAllQuestions();
        List<Question> GetByWhere(Func<Question , bool> Where);
    }

    public class Forum : IForum
    {
        List<Question> Qns;
        List<Question> RptDuplicate;

        public Forum()
        {
            this.Qns = new List<Question>
            {
                new Question { Id = 1, QuestionText = "Question1" , Categories = new List<Category> { Category.DotNet , Category.Java} , PostOn = DateTime.Now},
                new Question { Id = 1, QuestionText = "Question1" , Categories = new List<Category> { Category.DotNet , Category.Java} , PostOn = DateTime.Now},
                new Question { Id = 1, QuestionText = "Question1" , Categories = new List<Category> { Category.DotNet , Category.Java} , PostOn = DateTime.Now}
            };

            this.RptDuplicate = new List<Question>();
        }
        public List<Question> GetAllQuestions()
        {
            return this.Qns;
        }
        public List<Question> GetByWhere(Func<Question, bool> Where)
        {
            return this.Qns.Where(Where).ToList();
        }
        public void SetAnswerAsSpam(int QuestionId , int AnsId)
        {
            var item = this.Qns.Where(f => f.Id == QuestionId).Single().Answers.Where(f => f.Id == AnsId).FirstOrDefault();
            item.IsSpam = true;
        }
        public void RemoveAnswer(int QuestionId, int AnsId)
        {
            var ItemQns = this.Qns.Where(f => f.Id == QuestionId).FirstOrDefault();
            if(ItemQns != null)
            {
                var ItemAns = ItemQns.Answers.Where(f => f.Id == AnsId).FirstOrDefault();
                ItemQns.Answers.Remove(ItemAns);
            }
        }
        public void ReportDuplidate(Question DupQuestion)
        {
            this.RptDuplicate.Add(DupQuestion);
        }

    }


}
