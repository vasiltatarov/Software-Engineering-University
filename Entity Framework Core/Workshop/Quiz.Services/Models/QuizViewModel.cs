using System.Collections.Generic;

namespace Quiz.Services.Models
{
    public class QuizViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
