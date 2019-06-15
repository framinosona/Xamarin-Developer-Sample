using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.Sample1
{
    [DesignTimeVisible(true)]
    public partial class Sample1PanGestureAwareView
    {

        public PanGestureRecognizer PanGestureRecognizer { get; set; }

        public Sample1PanGestureAwareView()
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
            GestureIdLabel.Text = e.GestureId.ToString();
            TotalXLabel.Text = Math.Round(e.TotalX, 1).ToString();
            TotalYLabel.Text = Math.Round(e.TotalY, 1).ToString();
        }
    }
}
