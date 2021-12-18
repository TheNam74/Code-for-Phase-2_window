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

namespace AddPrefixOperation
{
    /// <summary>
    /// Interaction logic for AddPrefixConfigUC.xaml
    /// </summary>
    public partial class AddPrefixConfigUC : UserControl
    {
        private readonly AddPrefixOperation _operation;
        public AddPrefixConfigUC(AddPrefixOperation operation)//class la 1 reference variable, nên nếu được thay đổi ở đây tức là thay biến gốc
        {

            InitializeComponent();
            _operation = operation;
            var args = _operation.Args as AddPrefixArgs;
            PrefixTextBox.Text = args.Prefix;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var args = new AddPrefixArgs()
            {
                Prefix = PrefixTextBox.Text,
            };
            _operation.Args = args;
            _operation.DescriptionChangedNotify();

        }
    }
}
