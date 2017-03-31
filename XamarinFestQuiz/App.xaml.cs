using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace XamarinFestQuiz
{
    public class AppSettings
    {
        public const int QUESTIONS_COUNT = 1;
        public static int CurrentQuestion = 1;
        public static int Score = 0;
        public static string Username = "";

        private static MobileServiceClient _mobileServiceClient;

        public static MobileServiceClient MobileService
        {
            get
            {
                if (_mobileServiceClient == null)
                    _mobileServiceClient = new MobileServiceClient("https://xamarinfestquiz.azurewebsites.net");
                return _mobileServiceClient;
            }
        }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*
            XamarinQuiz item = new XamarinQuiz()
            {
                Question = "La sigla PCL se refiere a...",
                Answer1 = "Portable Class Library",
                Answer2 = "Power Class Library",
                Answer3 = "Portable Code Library",
                CorrectAnswer = 1
            };

            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = AppSettings.MobileService.GetTable<XamarinQuiz>();

            xamarinQuizTable.InsertAsync(item);
            */
            MainPage = new UserSignUp();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
