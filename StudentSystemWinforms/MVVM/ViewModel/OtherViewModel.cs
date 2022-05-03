using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemWinForms.Models
{
    public sealed class OtherViewModel : ViewModelBase
    {
        private StringBuilder _otherFunText;
        public string OtherFunText
        {
            get => _otherFunText.ToString() != String.Empty ? _otherFunText.ToString() : "This is the 'Other' View.\r\n\r\nIt just displays text, but it could easily be something more, like a collection of controls or some other cool stuff.";
            set
            {
                _otherFunText.Clear();

                _otherFunText.Append(value);

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(OtherFunText)));
            }

        }
        public OtherViewModel()
        {
            _otherFunText = new StringBuilder();
        }
    }
}
