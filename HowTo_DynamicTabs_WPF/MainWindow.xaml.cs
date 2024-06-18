using System.Windows;
using System.Windows.Controls;

namespace HowTo_DynamicTabs_WPF;

public partial class MainWindow : Window
{

    List<int> _tabs = new List<int>();
    int countIndex = 0;

    public void AddNewTabItem(string headerName)
    {
        int newIndex = countIndex++;

        _tabs.Add(newIndex);

        TabItem newTab = CreateNewTabItem(newIndex, headerName);
        
        tabControl.Items.Add(newTab);
       
        tabControl.SelectedIndex = newIndex;
    }

    private TabItem CreateNewTabItem(int newIndex, string headerName)
    {
        var newTabHeader = new TabHeader(newIndex, headerName);
        newTabHeader.TabCloseClicked += NewTabHeader_TabCloseClicked;
        return new TabItem { Width = 100, Header = newTabHeader };
    }

    private void NewTabHeader_TabCloseClicked(object? sender, TabItem e)
    {
        CloseTab(e);
    }

    private void CloseTab(TabItem e)
    {
        tabControl.Items.Remove(e);
    }

    public void CloseTab(int tabId)
    {
        tabControl.Items.RemoveAt(_tabs.IndexOf(tabId));
        _tabs.Remove(tabId);
        countIndex--;
    }

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddNewTabItem(tbInput.Text);
    }
}