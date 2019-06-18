using System.Linq;
using DeveloperSample.Core.Pages.BasePageFiles;
using Xamarin.Forms;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3
{
    public class DragAndDropSample3Container : Grid
    {

        public void UpdateHoverStatuses()
        {
            var allReceivers = this.GetAllChildrenOfType<DragAndDropSample3ReceiverView>();
            var allSenders = this.GetAllChildrenOfType<DragAndDropSample3SenderView>();

            foreach (var receiver in allReceivers)
            {
                var x = receiver.ScreenTopLeftX;
                var y = receiver.ScreenTopLeftY;
                var width = receiver.Width;
                var height = receiver.Height;
                receiver.OnHovered(allSenders.Where(sender => (
                    sender.ScreenX >= x &&
                    sender.ScreenX <= x + width &&
                    sender.ScreenY >= y &&
                    sender.ScreenY <= y + height)
                ).ToList());
            }
        }


        public void SenderDropped(DragAndDropSample3SenderView sender)
        {
            var allReceivers = this.GetAllChildrenOfType<DragAndDropSample3ReceiverView>();

            foreach (var receiver in allReceivers)
            {
                var x = receiver.ScreenTopLeftX;
                var y = receiver.ScreenTopLeftY;
                var width = receiver.Width;
                var height = receiver.Height;
                if (sender.ScreenX >= x &&
                    sender.ScreenX <= x + width &&
                    sender.ScreenY >= y &&
                    sender.ScreenY <= y + height)
                    receiver.OnDropped(sender);
            }
        }
    }
}
