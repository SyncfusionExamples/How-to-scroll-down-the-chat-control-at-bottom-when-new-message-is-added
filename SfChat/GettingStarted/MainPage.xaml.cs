using Syncfusion.XForms.Chat;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class MainPageBehavior: Behavior<MainPage>
    {

       private GettingStattedViewModel viewModel;

       private SfChat sfChat;
        public MainPageBehavior()
        {

        }

        protected override void OnAttachedTo(MainPage bindable)
        {
            this.sfChat = bindable.FindByName<SfChat>("sfChat");
            this.viewModel = bindable.FindByName<GettingStattedViewModel>("viewModel");
            this.viewModel.Messages.CollectionChanged += Messages_CollectionChanged;

            base.OnAttachedTo(bindable);
        }

        private async void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var chatItem in e.NewItems)
                {
                    TextMessage textMessage = chatItem as TextMessage;
                    if (textMessage != null && textMessage.Author == this.viewModel.CurrentUser)
                    {
                        textMessage.ShowAvatar = false;
                    }
                    else
                    {
                        await Task.Delay(50);
                        this.sfChat.ScrollToMessage(chatItem);
                    }
                }
            }

        }

        protected override void OnDetachingFrom(MainPage bindable)
        {
            this.viewModel.Messages.CollectionChanged -= Messages_CollectionChanged;
            this.sfChat = null;
            this.viewModel = null;
            base.OnDetachingFrom(bindable);
        }


    }
}
