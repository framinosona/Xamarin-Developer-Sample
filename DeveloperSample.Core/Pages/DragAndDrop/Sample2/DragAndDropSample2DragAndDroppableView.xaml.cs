using System;
using System.Globalization;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.BasePageFiles;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample2
{
    public partial class DragAndDropSample2DragAndDroppableView
    {
        public PanGestureRecognizer PanGestureRecognizer { get; set; }
        public DragAndDropSample2DragAndDroppableView()
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
            StatusLabel.Text = e.StatusType.ToString();
            TotalXLabel.Text = Math.Round(e.TotalX, 1).ToString(CultureInfo.InvariantCulture);
            TotalYLabel.Text = Math.Round(e.TotalY, 1).ToString(CultureInfo.InvariantCulture);

            // Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
            var screenCoordinates = this.GetScreenCoordinates();
            ViewXLabel.Text = Math.Round(screenCoordinates.X + e.TotalX + Width / 2, 1).ToString(CultureInfo.InvariantCulture);
            ViewYLabel.Text = Math.Round(screenCoordinates.Y + e.TotalY + Height / 2, 1).ToString(CultureInfo.InvariantCulture);

            switch (e.StatusType)
            {
                // Move view
                case GestureStatus.Running:
                    this.TranslateTo(e.TotalX, e.TotalY, 16); // 1000/16=62,5fps
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    this.TranslateTo(0, 0, 200);
                    this.Info($"Gesture {e.GestureId} {e.StatusType} at X:{e.TotalX} Y:{e.TotalY}");
                    break;
                case GestureStatus.Started:
                    this.Info($"Gesture {e.GestureId} {e.StatusType}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
