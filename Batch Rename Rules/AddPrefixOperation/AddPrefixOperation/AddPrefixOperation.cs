    using System;
    using System.ComponentModel;
    using System.Windows.Controls;
    using Contract;

    namespace AddPrefixOperation
{
    public class AddPrefixOperation : IStringOperation
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void DescriptionChangedNotify()
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs("Description"));
        }

        public StringArgs Args { get; set; }
        public string Name => "Add Prefix";
        public string Description
        {
            get
            {
                var args = Args as AddPrefixArgs;
                return $"Add prefix {args.Prefix}";
            }
        }
        public UserControl ConfigUC => new AddPrefixConfigUC(this);
        public AddPrefixOperation()
        {
            Args = new AddPrefixArgs();
        }

        public IStringOperation Clone()
        {
            var oldArgs = Args as AddPrefixArgs;
            return new AddPrefixOperation()
            {
                Args = new AddPrefixArgs()
                {
                    Prefix = oldArgs.Prefix
                }
            };
        }
        public string Operate(string origin)
        {
            var args = Args as AddPrefixArgs;
            var prefix = args.Prefix;
            return prefix + origin;
        }
    }
}
