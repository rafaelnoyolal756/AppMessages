using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.Models
{
    public class Message : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        private string sentto;
        public string SentTo 
        {
            get { return sentto; }
            set { sentto = value; RaisePropertyChanged(); }
        }

        private string message;
        public string MessageText 
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged([CallerMemberName] string nameProperty = null)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                changed(this, new PropertyChangedEventArgs(nameProperty));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
