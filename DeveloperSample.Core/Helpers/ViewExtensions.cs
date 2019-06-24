using System.Collections.Generic;
using Xamarin.Forms;

namespace DeveloperSample.Core.Helpers
{
    public static class ViewExtensions
    {
        public static List<T> GetAllChildrenOfType<T>(this Element view)
        {
            if (view is ContentPage page) view = page.Content;

            var output = new List<T>();

            if (view is T tview)
                output.Add(tview);

            if (view is Layout layout)
                foreach (var child in layout.Children)
                    if (child is Element elementChild)
                        output.AddRange(elementChild.GetAllChildrenOfType<T>());

            return output;
        }

        public static T GetFirstParentOfType<T>(this Element view)
        {
            var output = view;
            while (output.Parent != null)
            {
                if (output.Parent is T parent)
                    return parent;
                output = output.Parent;
            }

            return default;
        }

        /// <summary>
        ///     Gets the screen coordinates from top left corner.
        /// </summary>
        /// <returns>The screen coordinates.</returns>
        /// <param name="view">View.</param>
        public static (double X, double Y) GetScreenCoordinates(this VisualElement view)
        {
            // A view's default X- and Y-coordinates are LOCAL with respect to the boundaries of its parent,
            // and NOT with respect to the screen. This method calculates the SCREEN coordinates of a view.
            // The coordinates returned refer to the top left corner of the view.

            // Initialize with the view's "local" coordinates with respect to its parent
            var screenCoordinateX = view.X;
            var screenCoordinateY = view.Y;

            // Get the view's parent (if it has one...)
            if (view.Parent.GetType() != typeof(App))
            {
                var parent = (VisualElement) view.Parent;

                // Loop through all parents
                while (parent != null)
                {
                    // Add in the coordinates of the parent with respect to ITS parent
                    screenCoordinateX += parent.X;
                    screenCoordinateY += parent.Y;

                    // If the parent of this parent isn't the app itself, get the parent's parent.
                    if (parent.Parent.GetType() == typeof(App))
                        parent = null;
                    else
                        parent = (VisualElement) parent.Parent;
                }
            }

            // Return the final coordinates...which are the global SCREEN coordinates of the view
            return (screenCoordinateX, screenCoordinateY);
        }
    }
}