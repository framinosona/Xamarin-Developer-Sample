using DeveloperSample.Core.Pages.BasePageFiles;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using DeveloperSample.Core.Helpers;

namespace DeveloperSample.Core.Pages.Sample3
{
    public partial class Sample3DragAndDropReceiverView : ContentView
    {
        public double ScreenTopLeftX => this.GetScreenCoordinates().X;
        public double ScreenTopLeftY => this.GetScreenCoordinates().Y;

        public Sample3DragAndDropReceiverView()
        {
            InitializeComponent();
        }

        public void OnHovered(List<Sample3DragAndDropSenderView> views)
        {
            this.Opacity = views.Any() ? .3 : 1;
        }

        public void OnDropped(Sample3DragAndDropSenderView view)
        {
            this.MainFrame.BackgroundColor = view.Color;
        }
    }
}
