using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace XamarinFestQuiz
{
    public class QuestionViewModel
    {
        public int CorrectAnswer { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public bool Answer1Enabled { get; set; }
        public string Answer2 { get; set; }
        public bool Answer2Enabled { get; set; }
        public string Answer3 { get; set; }
        public bool Answer3Enabled { get; set; }
        List<XamarinQuiz> QuestionList { get; set; }
        Random rnd = new Random();
        public bool IsLoading { get; set; }
        public string Message { get; set; }

        public QuestionViewModel()
        {
            LoadQuestions();
        }

        public async Task LoadQuestions()
        {
            IsLoading = true;
            MobileServiceClient client = AppSettings.MobileService;
            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = client.GetTable<XamarinQuiz>();

            IEnumerable<XamarinQuiz> items = await xamarinQuizTable
              .ToEnumerableAsync();

            List<XamarinQuiz> quizList = new List<XamarinQuiz>(items);
            IsLoading = false;
        }

        public void ChooseNewQuestion() {
            IsLoading = true;

            int questionNumber = rnd.Next(0, QuestionList.Count);
            XamarinQuiz selectedItem = QuestionList[questionNumber];

            Answer1Enabled = true;
            Answer2Enabled = true;
            Answer3Enabled = true;

            Question = selectedItem.Question;
            Answer1 = selectedItem.Answer1;
            Answer2 = selectedItem.Answer2;
            Answer3 = selectedItem.Answer3;

            IsLoading = false;
        }
    }
}
