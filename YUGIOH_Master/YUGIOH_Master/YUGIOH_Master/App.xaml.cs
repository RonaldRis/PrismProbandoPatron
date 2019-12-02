using DLToolkit.Forms.Controls;
using System.Threading.Tasks;
using Xamarin.Forms;
using YUGIOH_Master.Patterns;
using YUGIOH_Master.Views;

namespace YUGIOH_Master
{
    public partial class App : Application
    {

        public App()
        {
            //var tareas = new[]
            //{
            //    new Task(async()=>await Singleton.Instance.VerifyCardsJson()),
            //    new Task(async () =>
            //    {
            //        while (Singleton.Cards == null)
            //        {
            //            await Task.Delay(2000);
            //            await Singleton.Instance.VerifyCardsJson();
            //        }
            //    })
            //};
            //Task.WhenAll(tareas);
            Task.Run(async () => await Singleton.Instance.VerifyCardsJson()).Wait();

            InitializeComponent();
            FlowListView.Init();

            
            MainPage = new MainPage();
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
