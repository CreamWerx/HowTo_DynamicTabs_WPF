using System.Windows;
using System.Windows.Controls;

namespace HowTo_DynamicTabs_WPF;
public partial class TabHeader : UserControl
{
    // Event used to indicate to MainWindow that user requested tab be closed
    public event EventHandler<TabItem>? TabCloseClicked;
    
    // Constructor required for designer
    public TabHeader()
    {
        InitializeComponent();
    }

    // Constructor required for dynamic creation
    public TabHeader(string headerName)
    {
        InitializeComponent();
        TabLabel.Content = headerName;
    }

    private void button_close_Click(object sender, RoutedEventArgs e)
    {
        // Get a reference to the tab item containing the clicked button
        //  and invoke event
        var parentTabItem = (TabItem)Parent;
        TabCloseClicked?.Invoke(this, parentTabItem);
    }
}
