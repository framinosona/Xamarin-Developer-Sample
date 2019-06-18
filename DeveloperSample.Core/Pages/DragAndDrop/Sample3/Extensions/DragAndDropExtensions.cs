using System;
using System.Linq;
using DeveloperSample.Core.Helpers;
using DeveloperSample.Core.Pages.DragAndDrop.Sample3.Interfaces;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3.Extensions
{
    public static class DragAndDropExtensions
    {
        #region IDragAndDropMovingView

        private static VisualElement GetContainer(this IDragAndDropMovingView view)
        {
            if (!(view is VisualElement visualElement))
                throw new Exception($"{nameof(IDragAndDropMovingView)} can only be an interface on a {nameof(View)}");
            var dropContainer = visualElement.GetFirstParentOfType<IDragAndDropContainer>();
            if (dropContainer is VisualElement output) return output;
            return visualElement.GetFirstParentOfType<Page>();
        }

        public static void InitializeDragAndDrop(this IDragAndDropMovingView view)
        {
            if (!(view is View output))
                throw new Exception($"{nameof(IDragAndDropMovingView)} can only be an interface on a {nameof(View)}");
            var panGestureRecognizer = new PanGestureRecognizer
            {
                TouchPoints = 1
            };
            panGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            output.GestureRecognizers.Clear();
            output.GestureRecognizers.Add(panGestureRecognizer);
        }

        private static void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (!(sender is VisualElement visualElement) ||
                !(sender is IDragAndDropMovingView dragAndDropMovingView))
                throw new Exception($"{nameof(IDragAndDropMovingView)} can only be an interface on a {nameof(View)}");

            var dropContainer = dragAndDropMovingView.GetContainer();
            // Update on Drop
            if (e.StatusType == GestureStatus.Completed)
                dropContainer?.DragAndDroppableViewDropped(dragAndDropMovingView);

            // Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
            var (X, Y) = visualElement.GetScreenCoordinates();
            dragAndDropMovingView.ScreenX = X + e.TotalX + visualElement.Width / 2;
            dragAndDropMovingView.ScreenY = Y + e.TotalY + visualElement.Height / 2;

            // Move view
            if (e.StatusType == GestureStatus.Running)
                visualElement.TranslateTo(e.TotalX, e.TotalY, 16); // 1000/16=62,5fps

            // Navigation back
            else if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
                visualElement.TranslateTo(0, 0, 200);

            // Update on Hover
            dropContainer?.UpdateHoverStatuses();
        }

        #endregion

        #region IDragAndDropContainer

        private static void UpdateHoverStatuses(this VisualElement view)
        {
            var allReceivers = view.GetAllChildrenOfType<IDragAndDropHoverableView>();
            var allSenders = view.GetAllChildrenOfType<IDragAndDropMovingView>();

            foreach (var receiver in allReceivers)
            {
                if (!(receiver is VisualElement veReceiver)) continue;
                var x = veReceiver.GetScreenCoordinates().X;
                var y = veReceiver.GetScreenCoordinates().Y;
                var width = veReceiver.Width;
                var height = veReceiver.Height;
                receiver.OnHovered(allSenders.Where(sender => sender.ScreenX >= x &&
                                                              sender.ScreenX <= x + width &&
                                                              sender.ScreenY >= y &&
                                                              sender.ScreenY <= y + height
                ).ToList());
            }
        }

        private static void DragAndDroppableViewDropped(this VisualElement view, IDragAndDropMovingView sender)
        {
            var allReceivers = view.GetAllChildrenOfType<IDragAndDropReceivingView>();

            foreach (var receiver in allReceivers)
            {
                if (!(receiver is VisualElement veReceiver)) continue;
                var x = veReceiver.GetScreenCoordinates().X;
                var y = veReceiver.GetScreenCoordinates().Y;
                var width = veReceiver.Width;
                var height = veReceiver.Height;
                if (sender.ScreenX >= x &&
                    sender.ScreenX <= x + width &&
                    sender.ScreenY >= y &&
                    sender.ScreenY <= y + height)
                    receiver.OnDropReceived(sender);
            }
        }

        #endregion
    }
}