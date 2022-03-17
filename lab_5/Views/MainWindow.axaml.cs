using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab_5.ViewModels;
using System.IO;

namespace lab_5.Views
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
#if DEBUG
                this.AttachDevTools();
#endif

                this.FindControl<Button>("OpenFile").Click += async delegate
                {
                    var TaskGetPathToFile = new OpenFileDialog()
                    {
                        Title = "Open File",
                        Filters = null
                    }.ShowAsync((Window)this.VisualRoot);

                    string[]? PathToFile = await TaskGetPathToFile;
                    var Temp = this.DataContext as MainWindowViewModel;
                    if (PathToFile != null)
                    {
                        StreamReader FReader = new StreamReader(string.Join(@"\", PathToFile));
                        Temp.Text = FReader.ReadToEnd();
                    }
                };

                this.FindControl<Button>("SaveFile").Click += async delegate
                {
                    SaveFileDialog SaveFileWindowBox = new SaveFileDialog();
                    SaveFileWindowBox.Title = "Save File";      
                    var PathToFile = await SaveFileWindowBox.ShowAsync((Window)this.VisualRoot);
                    if (PathToFile != null)
                    {
                        var Temp = this.DataContext as MainWindowViewModel;
                        File.WriteAllText(PathToFile, Temp.Result);
                    }
                };
                
            }     

            private void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }

            private void MyClickEventHandler(object? Sender, RoutedEventArgs e)
            {
                var Temp = new DialogRegexWindow();
                Temp.OkNotification += delegate (string str)
                {
                    var t = this.DataContext as MainWindowViewModel;
                    t.RegilarString = str;
                    t.Result = t.FindRegex();
                };
                Temp.Show((Window)this.VisualRoot);
            }
    }
}
