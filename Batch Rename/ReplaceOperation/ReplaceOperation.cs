using System;
using System.ComponentModel;
using System.Windows.Controls;
using Contract;

namespace ReplaceOperation
{
    public class ReplaceOperation:IStringOperation
    {
        public StringArgs Args { get; set; }
        public string Name => "Replace";
        public string Description
        {
            get
            {
                var args = Args as ReplaceArgs;
                return $"Replace from {args.From} to {args.To}";
            }
        }
        public UserControl ConfigUC => new ReplaceConfigUC(this);
        public ReplaceOperation()//constructor 
        {
            Args = new ReplaceArgs();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public IStringOperation Clone()
        {
            var oldArgs = Args as ReplaceArgs;
            return new ReplaceOperation()
            {
                Args = new ReplaceArgs()
                {
                    From = oldArgs.From,
                    To = oldArgs.To
                }
            };
        }
        public string Operate(string origin)
        {
            ReplaceArgs args = Args as ReplaceArgs;
            string from = args.From;
            string to = args.To;

            return origin.Replace(from, to);
        }
        public void DescriptionChangedNotify()//Sử dụng khi sửa tham số, cần notify cho giao diện rằng thuộc tính đc Binding Description đã thay đổi
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs("Description"));
        }


    }
}
