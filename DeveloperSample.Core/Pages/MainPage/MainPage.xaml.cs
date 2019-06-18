using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Pages.MainPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BaseContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var test = new TestFrame();
            Teest<TestIf>(test);
        }

        public void Teest<T>(object otest)
        {
            this.Info($"1: {otest is TestIf}");
            this.Info($"2: {otest is TestFrame}");
            this.Info($"3: {otest.GetType().IsAssignableFrom(typeof(TestIf))}");
            this.Info($"4: {otest.GetType().IsAssignableFrom(typeof(TestFrame))}");
            this.Info($"5: {typeof(TestIf).IsAssignableFrom(otest.GetType())}");
            this.Info($"6: {typeof(TestFrame).IsAssignableFrom(otest.GetType())}");
            this.Info($"7: {otest is T}");
            this.Info($"8: {otest.GetType().IsAssignableFrom(typeof(T))}");
            this.Info($"9: {typeof(T).IsAssignableFrom(otest.GetType())}");
        }
    }


    public interface TestIf
    {
    }

    public class TestFrame : Frame, TestIf
    {
    }
}