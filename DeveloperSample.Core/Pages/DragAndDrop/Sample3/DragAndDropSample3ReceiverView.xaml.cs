using System.Collections.Generic;
using System.Linq;
using DeveloperSample.Core.Pages.BasePageFiles;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3
{
    public partial class DragAndDropSample3ReceiverView : ContentView
    {
        public double ScreenTopLeftX => this.GetScreenCoordinates().X;
        public double ScreenTopLeftY => this.GetScreenCoordinates().Y;

        public DragAndDropSample3ReceiverView()
        {
            InitializeComponent();
        }

        public void OnHovered(List<DragAndDropSample3SenderView> views)
        {
            this.Opacity = views.Any() ? .3 : 1;
        }

        public void OnDropped(DragAndDropSample3SenderView view)
        {
            this.MainFrame.BackgroundColor = view.Color;
        }
    }
}
