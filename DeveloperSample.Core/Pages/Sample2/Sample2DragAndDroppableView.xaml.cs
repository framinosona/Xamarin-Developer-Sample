using System;
using Xamarin.Forms;
using DeveloperSample.Core.Pages.BasePageFiles;

namespace DeveloperSample.Core.Pages.Sample2
{
    public partial class Sample2DragAndDroppableView
    {
        public PanGestureRecognizer PanGestureRecognizer { get; set; }
        public Sample2DragAndDroppableView()
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
            TotalXLabel.Text = Math.Round(e.TotalX, 1).ToString();
            TotalYLabel.Text = Math.Round(e.TotalY, 1).ToString();

            // Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
            var screenCoordinates = this.GetScreenCoordinates();
            ViewXLabel.Text = Math.Round(screenCoordinates.X + e.TotalX + Width / 2, 1).ToString();
            ViewYLabel.Text = Math.Round(screenCoordinates.Y + e.TotalY + Height / 2, 1).ToString();

            // Move view
            if (e.StatusType == GestureStatus.Running)
                this.TranslateTo(e.TotalX, e.TotalY, 16); // 1000/16=62,5fps
            else if (e.StatusType == GestureStatus.Completed || (e.StatusType == GestureStatus.Canceled))
                this.TranslateTo(0, 0, 200);
        }
    }
}
