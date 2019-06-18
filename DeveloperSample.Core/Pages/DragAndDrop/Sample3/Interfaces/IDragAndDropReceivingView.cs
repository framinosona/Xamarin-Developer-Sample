namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3.Interfaces
{
    public interface IDragAndDropReceivingView
    {
        void OnDropReceived(IDragAndDropMovingView view);
    }
}