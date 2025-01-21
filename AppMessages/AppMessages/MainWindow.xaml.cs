using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using AppMessages.BL;
using AppMessages.Data;
using AppMessages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Lookups.V1;
using Twilio.Rest.Api.V2010.Account;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppMessages
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        SmallMessaging SmallMessaging = new SmallMessaging();
        public MainWindow()
        {
            this.InitializeComponent();
            LoadMessages();
        }

        private ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }








        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {

            string sentto = ToTextBox.Text; string message = MessageTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(sentto) || string.IsNullOrEmpty(message))
            {
                await new Windows.UI.Popups.MessageDialog("To and Message fields cannot be empty.").ShowAsync();
                return;
            }

            var twiliosettings = await SmallMessaging.GetTwilioSettings();

            TwilioClient.Init(twiliosettings.AccountSid, twiliosettings.AuthToken);

            var result = await SmallMessaging.InsertMessage(new Message() { SentTo = sentto, MessageText = message, Created = DateTime.Now });

            ToTextBox.Text = "";
            MessageTextBox.Text = "";

            var messageSent = await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber("+17069673030"),
                to: new Twilio.Types.PhoneNumber(sentto.ToString())
                );

            ToTextBox.Text = messageSent.Status.ToString();
            await SmallMessaging.InsertSentMessage(new SentMessage() { ConfirmationCode = messageSent.Status.ToString(), MessageId = result, Sent = DateTime.Now });
            LoadMessages();



        }

        private async void LoadMessages()
        {
            Messages = new ObservableCollection<Message>(await SmallMessaging.GetListMessage());
            MessagesListView.ItemsSource = Messages;

        }
    }
}
