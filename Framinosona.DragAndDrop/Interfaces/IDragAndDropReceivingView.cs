namespace Framinosona.DragAndDrop.Interfaces
{
    public interface IDragAndDropReceivingView
    {
        void OnDropReceived(IDragAndDropMovingView view);
    }
}