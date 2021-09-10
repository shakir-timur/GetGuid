using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GetGuid
{
    public class GuidViewModel : INotifyPropertyChanged
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CutToClipBoard { get; }

        public ICommand Refresh { get; }

        public GuidViewModel()
        {
            Refresh = new QuickCommand(() =>
            {
                this.GUID = Guid.NewGuid().ToString();
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(GUID)));
            });

            CutToClipBoard = new QuickCommand(() =>
            {
                Clipboard.SetData(DataFormats.Text, this.GUID);
                this.GUID = "";
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(GUID)));
            });
        }
    }
}
