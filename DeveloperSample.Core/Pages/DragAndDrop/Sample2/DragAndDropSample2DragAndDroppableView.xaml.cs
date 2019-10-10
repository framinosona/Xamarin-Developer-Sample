using System;
using System.Globalization;
using DeveloperSample.Core.Helpers;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample2
{
    public partial class DragAndDropSample2DragAndDroppableView
    {
        public DragAndDropSample2DragAndDroppableView()
        {
            InitializeComponent();
            PanGestureRecognizer = new PanGestureRecognizer
            {
                TouchPoints = 1
            };
            PanGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            GestureRecognizers.Add(PanGestureRecognizer);
        }

        public PanGestureRecognizer PanGestureRecognizer { get; set; }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            StatusLabel.Text = e.StatusType.ToString();
// Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
            var screenCoordinates = this.GetScreenCoordinates();

            switch (e.StatusType)
            {
                // Move view
                case GestureStatus.Running:
                    TranslationX = (Device.RuntimePlatform == Device.Android ? TranslationX : 0) + e.TotalX;
                    TranslationY = (Device.RuntimePlatform == Device.Android ? TranslationY : 0) + e.TotalY;
                    TotalXLabel.Text = Math.Round(TranslationX, 1).ToString(CultureInfo.InvariantCulture);
                    TotalYLabel.Text = Math.Round(TranslationY, 1).ToString(CultureInfo.InvariantCulture);
                    ViewXLabel.Text = Math.Round(screenCoordinates.X + TranslationX + Width / 2, 1).ToString(CultureInfo.InvariantCulture);
                    ViewYLabel.Text = Math.Round(screenCoordinates.Y + TranslationY + Height / 2, 1).ToString(CultureInfo.InvariantCulture);
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    this.TranslateTo(0, 0, 200);
                    TotalXLabel.Text = "0";
                    TotalYLabel.Text = "0";
                    ViewXLabel.Text = Math.Round(screenCoordinates.X + Width / 2, 1).ToString(CultureInfo.InvariantCulture);
                    ViewYLabel.Text = Math.Round(screenCoordinates.Y + Height / 2, 1).ToString(CultureInfo.InvariantCulture);
                    break;
                case GestureStatus.Started:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}