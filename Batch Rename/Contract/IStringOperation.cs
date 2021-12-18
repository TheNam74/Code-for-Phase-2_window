using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace Contract
{
    public interface IStringOperation : INotifyPropertyChanged
    {
        StringArgs Args { get; set; }
        string Name { get; }
        string Description { get; }
        public UserControl ConfigUC { get; }

        event PropertyChangedEventHandler PropertyChanged;
        IStringOperation Clone();

        string Operate(string origin);
        void DescriptionChangedNotify();
    }
}
