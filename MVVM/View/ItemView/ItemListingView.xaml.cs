using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG7312_UI.MVVM.View.ItemView
{
    /// <summary>
    /// Interaction logic for ItemListingView.xaml
    /// </summary>
    public partial class ItemListingView : UserControl
    {


        public object IncomingItem
        {
            get { return (object)GetValue(IncomingItemProperty); }
            set { SetValue(IncomingItemProperty, value); }
        }

        public static readonly DependencyProperty IncomingItemProperty =
            DependencyProperty.Register("IncomingItem", typeof(object), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public object RemoveItem
        {
            get { return (object)GetValue(RemoveItemProperty); }
            set { SetValue(RemoveItemProperty, value); }
        }

        public static readonly DependencyProperty RemoveItemProperty =
            DependencyProperty.Register("RemoveItem", typeof(object), typeof(ItemListingView),
                 new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public ICommand ItemDropCommand
        {
            get { return (ICommand)GetValue(ItemDropCommandProperty); }
            set { SetValue(ItemDropCommandProperty, value); }
        }

        public static readonly DependencyProperty ItemDropCommandProperty =
            DependencyProperty.Register("ItemDropCommand", typeof(ICommand), typeof(ItemListingView),
                new PropertyMetadata(null));





        public ICommand ItemRemovedCommand
        {
            get { return (ICommand)GetValue(ItemRemovedCommandProperty); }
            set { SetValue(ItemRemovedCommandProperty, value); }
        }

        public static readonly DependencyProperty ItemRemovedCommandProperty =
            DependencyProperty.Register("ItemRemovedCommand", typeof(ICommand), typeof(ItemListingView),
                new PropertyMetadata(null));



        public ICommand ItemInsertCommand
        {
            get { return (ICommand)GetValue(ItemInsertCommandProperty); }
            set { SetValue(ItemInsertCommandProperty, value); }
        }

        public static readonly DependencyProperty ItemInsertCommandProperty =
            DependencyProperty.Register("ItemInsertCommand", typeof(ICommand), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));





        public object InsertedItem
        {
            get { return (object)GetValue(InsertedItemProperty); }
            set { SetValue(InsertedItemProperty, value); }
        }

        public static readonly DependencyProperty InsertedItemProperty =
            DependencyProperty.Register("InsertedItem", typeof(object), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public object TargetItem
        {
            get { return (object)GetValue(TargetItemProperty); }
            set { SetValue(TargetItemProperty, value); }
        }

        public static readonly DependencyProperty TargetItemProperty =
            DependencyProperty.Register("TargetItem", typeof(object), typeof(ItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public ItemListingView()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed &&
                sender is FrameworkElement frameworkElement)
            {
                object item = frameworkElement.DataContext;

                DragDropEffects dragDropResult = DragDrop.DoDragDrop(frameworkElement,
                    new DataObject(DataFormats.Serializable, item),
                    DragDropEffects.Move);

                if (dragDropResult == DragDropEffects.None)
                {
                    AddItem(item);
                }
            }
        }

        private void ListViewItem_DragOver(object sender, DragEventArgs e)
        {
            if (ItemInsertCommand?.CanExecute(null) ?? false)
            {
                if (sender is FrameworkElement element)
                {
                    TargetItem = element.DataContext;
                    InsertedItem = e.Data.GetData(DataFormats.Serializable);

                    ItemInsertCommand?.Execute(null);
                }
            }
        }
        private void lvItems_DragOver(object sender, DragEventArgs e)
        {
            object todoItem = e.Data.GetData(DataFormats.Serializable);
            AddItem(todoItem);
        }

        private void lvItems_DragLeave(object sender, DragEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(lvItems, e.GetPosition(lvItems));

            if (result == null)
            {
                if (ItemRemovedCommand?.CanExecute(null) ?? false)
                {
                    RemoveItem = e.Data.GetData(DataFormats.Serializable);
                    ItemRemovedCommand?.Execute(null);
                }
            }
        }

        private void AddItem(object todoItem)
        {
            if (ItemDropCommand?.CanExecute(null) ?? false)
            {
                IncomingItem = todoItem;
                ItemDropCommand?.Execute(null);
            }
        }
    }
}
