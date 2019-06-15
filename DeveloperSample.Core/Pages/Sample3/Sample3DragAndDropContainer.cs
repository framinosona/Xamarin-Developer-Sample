using System;
using Xamarin.Forms;
using System.Collections.Generic;
using DeveloperSample.Core.Pages.BasePageFiles;
using System.Linq;

namespace DeveloperSample.Core.Pages.Sample3
{
    public class Sample3DragAndDropContainer : Grid
    {
        public Sample3DragAndDropContainer()
        {
        }

        public void UpdateHoverStatuses()
        {
            var allReceivers = this.GetAllChildrenOfType<Sample3DragAndDropReceiverView>();
            var allSenders = this.GetAllChildrenOfType<Sample3DragAndDropSenderView>();

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


        public void SenderDropped(Sample3DragAndDropSenderView sender)
        {
            var allReceivers = this.GetAllChildrenOfType<Sample3DragAndDropReceiverView>();

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
