using System;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Sample2MoveView
{
    public partial class Sample2MoveViewView : Frame
    {
        public string StatusText
        {
            get => (string) GetValue(StatusTextProperty);
            set => SetValue(StatusTextProperty, value);
        }

        public static readonly BindableProperty StatusTextProperty = BindableProperty.Create(
            nameof(StatusText), // Public name to use
            typeof(string), // Type to return
            typeof(Sample2MoveViewView), // Parent type (this control)
            "Completed" // Default value
        );

        public double TotalX
        {
            get => (double) GetValue(TotalXProperty);
            set => SetValue(TotalXProperty, value);
        }

        public static readonly BindableProperty TotalXProperty = BindableProperty.Create(
            nameof(TotalX), // Public name to use
            typeof(double), // Type to return
            typeof(Sample2MoveViewView) // Parent type (this control)
        );

        public double TotalY
        {
            get => (double) GetValue(TotalYProperty);
            set => SetValue(TotalYProperty, value);
        }

        public static readonly BindableProperty TotalYProperty = BindableProperty.Create(
            nameof(TotalY), // Public name to use
            typeof(double), // Type to return
            typeof(Sample2MoveViewView) // Parent type (this control)
        );

        public PanGestureRecognizer PanGestureRecognizer { get; set; }
        public Sample2MoveViewView()
        {
            InitializeComponent();
            PanGestureRecognizer = new PanGestureRecognizer()
            {
                TouchPoints = 1
            };
            PanGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            GestureRecognizers.Add(PanGestureRecognizer);
        }

        void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            StatusText = e.StatusType.ToString();
            TotalX = Math.Round(e.TotalX, 1);
            TotalY = Math.Round(e.TotalY, 1);

            if (e.StatusType == GestureStatus.Running)
                this.TranslateTo(e.TotalX, e.TotalY, 16);
            else if (e.StatusType == GestureStatus.Completed || (e.StatusType == GestureStatus.Canceled))
                this.TranslateTo(0, 0, 200);
        }
    }
}
