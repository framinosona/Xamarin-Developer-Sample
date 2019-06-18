using DeveloperSample.Core.Pages.BasePageFiles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeveloperSample.Core.Pages.DragAndDrop.Sample3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DragAndDropSample3SenderView : ContentView
    {
        #region Color
        public Color Color
        {
            get { return (Color) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            nameof(Color),
            typeof(Color),
            typeof(DragAndDropSample3SenderView),
            Color.Blue,
            propertyChanged: OnColorChanged);

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is DragAndDropSample3SenderView dropSenderView)
                if (newValue is Color color)
                    dropSenderView.MainFrame.BackgroundColor = color;
        }
        #endregion
        public double ScreenX { get; private set; }
        public double ScreenY { get; private set; }
        public PanGestureRecognizer PanGestureRecognizer { get; set; }

        public DragAndDropSample3SenderView()
        {
            InitializeComponent();
            PanGestureRecognizer = new PanGestureRecognizer()
            {
                TouchPoints = 1
            };
            PanGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            GestureRecognizers.Add(PanGestureRecognizer);
        }

        void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var parent = this.GetFirstParentOfType<DragAndDropSample3Container>();

            // Update on Drop
            if (e.StatusType == GestureStatus.Completed)
            {
                parent?.SenderDropped(this);
            }

            // Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
            var screenCoordinates = this.GetScreenCoordinates();
            ScreenX = screenCoordinates.X + e.TotalX + Width / 2;
            ScreenY = screenCoordinates.Y + e.TotalY + Height / 2;

            // Move view
            if (e.StatusType == GestureStatus.Running)
                this.TranslateTo(e.TotalX, e.TotalY, 16); // 1000/16=62,5fps

            // Navigation back
            else if (e.StatusType == GestureStatus.Completed || (e.StatusType == GestureStatus.Canceled))
                this.TranslateTo(0, 0, 200);

            // Update on Hover
            parent?.UpdateHoverStatuses();
        }
    }
}
