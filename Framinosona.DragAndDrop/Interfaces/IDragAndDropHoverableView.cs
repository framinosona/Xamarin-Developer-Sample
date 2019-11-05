using System.Collections.Generic;

namespace Framinosona.DragAndDrop.Interfaces
{
    public interface IDragAndDropHoverableView
    {
        void OnHovered(List<IDragAndDropMovingView> views);
        
    }
}