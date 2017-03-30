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

            ((QuestionViewModel)BindingContext).LoadQuestions().Wait(-1);
            ((QuestionViewModel)BindingContext).ChooseNewQuestion();

            btnAnswerOne.Clicked += (sender, ea) =>
            {
                if (CheckIfCorrect(1)) DoAnswer();
                else
                {
                    ((Button)sender).IsEnabled = false;
                    lblMessage.Text = "No señor !!";
                    score = score / 2;
                }
            };

            btnAnswerTwo.Clicked += (sender, ea) =>
            {
                if (CheckIfCorrect(2)) DoAnswer();
                else
                {
                    ((Button)sender).IsEnabled = false;
                    lblMessage.Text = "Ups !!";
                    score = score / 2;
                }
            };

            btnAnswerThree.Clicked += (sender, ea) =>
            {
                if (CheckIfCorrect(3)) DoAnswer();
                else
                {
                    ((Button)sender).IsEnabled = false;
                    lblMessage.Text = "Casi !!";
                    score = score / 2;
                }
            };
        }

        private bool CheckIfCorrect(int correct)
        {
            if (_choice == correct)
            {
                AppSettings.Score += score;
                lblMessage.Text = "Correcto !!";
                return true;
            }
            return false;
        }

        private void DoAnswer()
        {
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
