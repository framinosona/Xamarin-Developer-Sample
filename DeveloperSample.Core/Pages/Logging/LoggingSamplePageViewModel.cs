using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using NLog;
using NLog.Targets;
using Prism.Navigation;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Logging
{
    public class LoggingSamplePageViewModel : BaseViewModel
    {
        private string _logFileContent;

        public LoggingSamplePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Logging";
        }

        public string LogFileContent
        {
            get => _logFileContent;
            set => SetProperty(ref _logFileContent, value);
        }

        public ICommand AddTrace =>
            new Command(() =>
            {
                typeof(LoggingSamplePageViewModel).Trace(
                    "Here is some raw data I received at this point : { 'name': 'yolo' }");
                ReadLogFile();
            });

        public ICommand AddWarn =>
            new Command(() =>
            {
                typeof(LoggingSamplePageViewModel).Warn("I don't like this, something weird happened ...");
                ReadLogFile();
            });

        public ICommand AddWarnWithException =>
            new Command(() =>
            {
                try
                {
                    throw new Exception("Wow you are exceptional !");
                }
                catch (Exception e)
                {
                    typeof(LoggingSamplePageViewModel).Warn("I'm warning you :", e);
                }

                ReadLogFile();
            });

        public ICommand AddInfo =>
            new Command(() =>
            {
                typeof(LoggingSamplePageViewModel).Info("For your information, this is happening right now");
                ReadLogFile();
            });

        public ICommand AddErrorWithException =>
            new Command(() =>
            {
                try
                {
                    throw new Exception("This was a mistake ...");
                }
                catch (Exception e)
                {
                    typeof(LoggingSamplePageViewModel).Error("Oh oh :", e);
                }

                ReadLogFile();
            });

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ReadLogFile();
        }

        private void ReadLogFile()
        {
            try
            {
                var fileTarget = (from t in LogManager.Configuration.AllTargets
                    where t is FileTarget
                    select (FileTarget) t).FirstOrDefault();
                var logEventInfo = new LogEventInfo {TimeStamp = DateTime.Now};
                var filePath = fileTarget?.FileName.Render(logEventInfo);
                LogFileContent = filePath != null
                    ? File.ReadAllText(filePath, Encoding.UTF8)
                    : "File not found";
            }
            catch (Exception e)
            {
                LogFileContent = e.ToString();
            }
        }
    }
}