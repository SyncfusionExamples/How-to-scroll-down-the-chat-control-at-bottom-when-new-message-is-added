using System;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Chat;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GettingStarted
{
    public class GettingStattedViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> messages;

        /// <summary>
        /// current user of chat.
        /// </summary>
        private Author currentUser;

        public GettingStattedViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Nancy", Avatar = "People_Circle16.png" };
            this.GenerateMessages();

            this.SendMessage = new Command(async (args) =>
            {
                await Task.Delay(4000);
                PostTextAsync((args as SendMessageEventArgs).Message.Text);
            });

        }

        private async Task PostTextAsync(string inputText)
        {
            this.Messages.Add(new TextMessage()
            {
                DateTime = DateTime.Now,
                ShowAuthorName = true,
                Author = new Author() { Name = "Jena", Avatar = "People_Circle14" },
                Text = "This is an incoming message.",
                ShowAvatar = true,
            });

            this.Messages.Add(new TextMessage()
            {
                DateTime = DateTime.Now,
                ShowAuthorName = true,
                Author = new Author() { Name = "John", Avatar = "People_Circle2" },
                Text = "This is an incoming message.",
                ShowAvatar = false,
            });
        }

        private ICommand sendMessage;

        public ICommand SendMessage
        {
            get
            {
                return this.sendMessage;
            }
            set
            {
                this.sendMessage = value;
                RaisePropertyChanged("SendMessageCommand");
            }
        }

        /// <summary>
        /// Gets or sets the group message conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current author.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Andrea", Avatar = "People_Circle2.png" },
                Text = "Oh! That's great.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Harrison", Avatar = "People_Circle14.png" },
                Text = "That is good news.",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Margaret", Avatar = "People_Circle7.png" },
                Text = "What kind of application is it and when are we going to launch?",
                ShowAvatar = true,
            });

            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "A kind of Emergency Broadcast App.",
                ShowAvatar = true,
            });
        }
    }
}
