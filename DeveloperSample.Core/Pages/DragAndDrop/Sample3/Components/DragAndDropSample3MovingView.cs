using DeveloperSample.Core.Pages.DragAndDrop.Sample3.Extensions;
using DeveloperSample.Core.Pages.DragAndDrop.Sample3.Interfaces;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3.Components
{
    public class DragAndDropSample3MovingView : Frame, IDragAndDropMovingView
    {
        public double ScreenX { get; set; }
        public double ScreenY { get; set; }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            this.InitializeDragAndDrop();
        }
    }
}