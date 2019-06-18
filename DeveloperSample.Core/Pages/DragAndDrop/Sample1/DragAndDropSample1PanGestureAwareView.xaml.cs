using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample1
{
    [DesignTimeVisible(true)]
    public partial class DragAndDropSample1PanGestureAwareView
    {
        public DragAndDropSample1PanGestureAwareView()
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
            StatusLabel.Text = e.StatusType.ToString(); // Canceled, Completed, Running, Started
            GestureIdLabel.Text = e.GestureId.ToString();
            TotalXLabel.Text = Math.Round(e.TotalX, 1).ToString(CultureInfo.InvariantCulture);
            TotalYLabel.Text = Math.Round(e.TotalY, 1).ToString(CultureInfo.InvariantCulture);
        }
    }
}