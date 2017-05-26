# Simple Xamarin Quiz
Hello ! This is a sample app that was used for Xamarin Dev Days in Buenos Aires.

Since it was for a demo, please follow this steps to get it working:

1) Go to your Azure Portal (portal.azure.com), and create two easy tables:
- XamarinQuiz (Question(text),CorrectAnswer(number),Answer1(text),Answer2(text),Answer3(text))
- UserScore (Id,Username,Score)

2) Go to App.xaml.cs and change the sample azure website url to your website url:

_mobileServiceClient = new MobileServiceClient("--your azure website url--");

 Ready to test !!!
