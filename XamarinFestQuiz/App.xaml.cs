using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace XamarinFestQuiz
{
    public class AppSettings
    {
        public const int QUESTIONS_COUNT = 5;
        public static int CurrentQuestion = 1;
        public static int Score = 0;
        public static string Username = "";

        private static MobileServiceClient _mobileServiceClient;

        public static MobileServiceClient MobileService
        {
            get
            {
                if (_mobileServiceClient == null)
                    _mobileServiceClient = new MobileServiceClient("https://xamarinquiz.azurewebsites.net");
                return _mobileServiceClient;
            }
        }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
