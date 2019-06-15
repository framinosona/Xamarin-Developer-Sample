using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Sample1PanGestureDetection
{
    [DesignTimeVisible(true)]
    public partial class Sample1PanGestureDetectionView : Frame
    {

        public string StatusText
        {
            get => (string) GetValue(StatusTextProperty);
            set => SetValue(StatusTextProperty, value);
        }

        public static readonly BindableProperty StatusTextProperty = BindableProperty.Create(
            nameof(StatusText), // Public name to use
            typeof(string), // Type to return
            typeof(Sample1PanGestureDetectionView), // Parent type (this control)
            "Completed" // Default value
        );

        public int GestureId
        {
            get => (int) GetValue(GestureIdProperty);
            set => SetValue(GestureIdProperty, value);
        }

        public static readonly BindableProperty GestureIdProperty = BindableProperty.Create(
            nameof(GestureId), // Public name to use
            typeof(int), // Type to return
            typeof(Sample1PanGestureDetectionView), // Parent type (this control)
            -1 // Default value
        );

        public double TotalX
        {
            get => (double) GetValue(TotalXProperty);
            set => SetValue(TotalXProperty, value);
        }

        public static readonly BindableProperty TotalXProperty = BindableProperty.Create(
            nameof(TotalX), // Public name to use
            typeof(double), // Type to return
            typeof(Sample1PanGestureDetectionView) // Parent type (this control)
        );

        public double TotalY
        {
            get => (double) GetValue(TotalYProperty);
            set => SetValue(TotalYProperty, value);
        }

        public static readonly BindableProperty TotalYProperty = BindableProperty.Create(
            nameof(TotalY), // Public name to use
            typeof(double), // Type to return
            typeof(Sample1PanGestureDetectionView) // Parent type (this control)
        );

        public PanGestureRecognizer PanGestureRecognizer { get; set; }
        public Sample1PanGestureDetectionView()
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
            GestureId = e.GestureId;
            TotalX = Math.Round(e.TotalX, 1);
            TotalY = Math.Round(e.TotalY, 1);
        }
    }
}
