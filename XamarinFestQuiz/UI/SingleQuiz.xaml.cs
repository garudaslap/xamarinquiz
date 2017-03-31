using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFestQuiz
{
    public partial class SingleQuiz : ContentPage
    {
        int _choice = 0;
        int score = 100;

        public SingleQuiz()
        {
            InitializeComponent();
            ((QuestionViewModel)BindingContext).LoadQuestions();

            btnAnswerOne.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(1)) DoAnswer();
                else
                {
                    ((Button)sender).IsEnabled = false;
                    score = score / 2;
                }
            };

            btnAnswerTwo.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(2)) DoAnswer();
                else
                {
                    ((Button)sender).IsEnabled = false;
                    score = score / 2;
                }
            };

            btnAnswerThree.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(3))
                {
                    DoAnswer();
                }
                else
                {
                    ((Button)sender).IsEnabled = false;
                    score = score / 2;
                }
            };
        }

        private void DoAnswer()
        {
            AppSettings.Score += score;
            if (AppSettings.CurrentQuestion < AppSettings.QUESTIONS_COUNT)
            {
                AppSettings.CurrentQuestion++;
                ((QuestionViewModel)BindingContext).ChooseNewQuestion();
            }
            else
            {
                NavigateToEndPage();
            }
        }

        private void NavigateToEndPage()
        {
            Application.Current.MainPage = new ThanksForPlaying();
        }
    }
}
