using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace ReplaceOperation
{
    /// <summary>
    /// Interaction logic for ReplaceConfigUC.xaml
    /// </summary>
    public partial class ReplaceConfigUC : UserControl
    {
        private readonly ReplaceOperation _operation;
        //cần thay đổi cài đặt này thành delegate event!
        public ReplaceConfigUC(ReplaceOperation operation)//class la 1 reference variable, nên nếu được thay đổi ở đây tức là thay biến gốc
        {

            InitializeComponent();
            _operation = operation;
            var args = _operation.Args as ReplaceArgs;
            FromTextBox.Text = args.From;
            ToTextBox.Text = args.To;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var args = new ReplaceArgs()
            {
                From = FromTextBox.Text ?? "",
                To = ToTextBox.Text ?? ""
            };
            _operation.Args = args;
            _operation.DescriptionChangedNotify();//notify thuộc tính description đã thay đổi
        }
    }
}
