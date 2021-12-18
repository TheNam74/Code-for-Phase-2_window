using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Contract;
using Path = System.Windows.Shapes.Path;

namespace Batch_Rename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        Dictionary<string,IStringOperation> _prototypes = new Dictionary<string, IStringOperation>();


        BindingList<IStringOperation> _actions = new BindingList<IStringOperation>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Nạp dll để biết những khả năng đổi tên mình có thể
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            var fis = new DirectoryInfo(exePath).GetFiles("*.dll");


            foreach (var f in fis) // Lần lượt duyệt qua các file dll
            {
                var assembly = Assembly.LoadFile(f.FullName);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {

                    if (t.IsClass && typeof(IStringOperation).IsAssignableFrom(t))
                    {
                        IStringOperation c = (IStringOperation)Activator.CreateInstance(t);//do các luật có hàm tạo, new Args rồi nên không cần load class Args như trước nữa

                        _prototypes.Add(c.Name,c);//Replace, AddPrefix,...
                    }

                }
            }

            PrototypesComboBox.ItemsSource = _prototypes;//bản mẫu cho người dùng xem, nếu người dùng Add thì clone ra

            OperationsListView.ItemsSource = _actions;//là Binding list, thêm xóa sửa _action thì giao diện tự cập nhập
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var element =
                PrototypesComboBox.SelectedItem is KeyValuePair<string, IStringOperation> ? (KeyValuePair<string, IStringOperation>) PrototypesComboBox.SelectedItem : default;//selected item có kiểu keyValue pair<string,IStringOperation>, ép kiểu lại để xài
            var action = element.Value;//value là luật ( IStringOperation)
            _actions.Add(action.Clone());

        }


        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = OperationsListView.SelectedIndex;

            _actions.RemoveAt(index);
        }


        private void Up_Click(object sender, RoutedEventArgs e)
        {
            var index = OperationsListView.SelectedIndex;
            if (index >= 0)
            {
                var temp = _actions[index];
                _actions.RemoveAt(index);
                _actions.Insert(index - 1, temp);
            }

        }

        private void Run_OnClick(object sender, RoutedEventArgs e)
        {
            //test
            string temp = "todo.txt";
            foreach (var stringOperation in _actions)
            {

                temp = stringOperation.Operate(temp);
            }
            System.IO.File.Move(@"C:\Users\ThinkPro\OneDrive\Desktop\Project 1 - Batch rename\todo.txt", @"C:\Users\ThinkPro\OneDrive\Desktop\Project 1 - Batch rename\" + temp);

        }

        private void OperationsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var operation =
                OperationsListView.SelectedItem as IStringOperation;
            if (operation is not null)//Luc mà delete xong, thằng event này sủa dơ, nên cần check null để app k crash
            {
                ParamsEdit.Content = operation.ConfigUC;
            }

        }
    }
}
