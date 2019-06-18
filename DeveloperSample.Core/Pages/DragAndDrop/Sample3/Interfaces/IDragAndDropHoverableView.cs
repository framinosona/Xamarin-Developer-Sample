using System.Collections.Generic;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3.Interfaces
{
    public interface IDragAndDropHoverableView
    {
        void OnHovered(List<IDragAndDropMovingView> views);
    }
}