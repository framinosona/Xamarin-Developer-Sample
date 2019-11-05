using System.Collections.Generic;
using System.Linq;
using Framinosona.DragAndDrop.Interfaces;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3.Components
{
    public class DragAndDropSample3ReceivingView : Frame, IDragAndDropHoverableView, IDragAndDropReceivingView
    {
        public void OnHovered(List<IDragAndDropMovingView> views)
        {
            Opacity = views.Any() ? .3 : 1;
        }

        public void OnDropReceived(IDragAndDropMovingView view)
        {
            if (view is DragAndDropSample3MovingView sender)
                BackgroundColor = sender.BackgroundColor;
        }
    }
}