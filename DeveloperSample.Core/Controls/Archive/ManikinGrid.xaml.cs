using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DeveloperSample.Core.Controls
{
    public partial class ManikinGrid : ContentView
    {
        #region ItemDataTemplate
        public DataTemplate ItemDataTemplate
        {
            get { return (DataTemplate) GetValue(ItemDataTemplateProperty); }
            set { SetValue(ItemDataTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemDataTemplateProperty = BindableProperty.Create(
            nameof(ItemDataTemplate),
            typeof(DataTemplate),
            typeof(ManikinGrid),
            new DataTemplate(typeof(ManikinCell)),
            propertyChanged: OnGridLayoutChanged);
        #endregion

        #region Columns

        public double Columns
        {
            get => (double) GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
        public static readonly BindableProperty ColumnsProperty = BindableProperty.Create(
            nameof(ColumnsProperty),
            typeof(double),
            typeof(ManikinGrid),
            2d,
            propertyChanged: OnGridLayoutChanged);
        #endregion

        #region Rows

        public double Rows
        {
            get => (double) GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }
        public static readonly BindableProperty RowsProperty = BindableProperty.Create(
            nameof(RowsProperty),
            typeof(double),
            typeof(ManikinGrid),
            2d,
            propertyChanged: OnGridLayoutChanged);
        #endregion

        private static void OnGridLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var manikinGrid = (ManikinGrid) bindable;
            manikinGrid.UpdateLayout();
        }

        public void UpdateLayout()
        {
            MainGrid.Children.Clear();
            MainGrid.ColumnDefinitions.Clear();
            MainGrid.RowDefinitions.Clear();

            for (var col = 1; col <= Columns; col++)
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            for (var row = 1; row <= Rows; row++)
                MainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            if (ItemDataTemplate != null)
                for (var col = 0; col < Columns; col++)
                    for (var row = 0; row < Rows; row++)
                    {
                        var itemTemplate = ItemDataTemplate.CreateContent() as View;
                        MainGrid.Children.Add(itemTemplate, col, row);
                    }
        }

        public ManikinGrid()
        {
            InitializeComponent();
            UpdateLayout();
        }

        public List<View> Cells => MainGrid.Children.ToList();
    }
}
