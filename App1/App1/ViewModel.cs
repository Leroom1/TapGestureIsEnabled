using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App1.Annotations;
using Xamarin.Forms;

namespace App1
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel(bool isInitiallyTapable)
        {
            ToggleIsLabelTapableCommand = new Command(ToggleIsLabelTapable);
            ChangeSlaveTextCommand = new Command(TapLabel);
            _isLabelTapable = isInitiallyTapable;
        }

        public ICommand ToggleIsLabelTapableCommand { get; }
        public ICommand ChangeSlaveTextCommand { get; }
        
        private bool _isLabelTapable;
        public bool IsTapable
        {
            get { return _isLabelTapable; }
            set
            {
                if (value != _isLabelTapable)
                {
                    _isLabelTapable = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private string _slaveLabelText = "Slave";
        public string SlaveLabelText
        {
            get { return _slaveLabelText; }
            set
            {
                if (_slaveLabelText != value)
                {
                    _slaveLabelText = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TapLabel()
        {
            SlaveLabelText = DateTime.Now.ToString();
        }

        private void ToggleIsLabelTapable()
        {
            IsTapable = !IsTapable;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}