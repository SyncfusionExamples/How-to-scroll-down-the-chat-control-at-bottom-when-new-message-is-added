# How-to-scroll-down-the-chat-control-at-bottom-when-new-message-is-added

##About the sample

This repository contains sample that demonstrates how to scroll chat messages by programmatically. 

```XAML
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:sfChat="clr-namespace:Syncfusion.XForms.Chat;assembly=Syncfusion.SfChat.XForms"
             xmlns:local="clr-namespace:GettingStarted"
             x:Class="GettingStarted.MainPage">

    <ContentPage.BindingContext>
        <local:GettingStattedViewModel x:Name="viewModel"/>
    </ContentPage.BindingContext>
    <ContentPage.Behaviors>
        <local:MainPageBehavior></local:MainPageBehavior>
    </ContentPage.Behaviors>
    
    <ContentPage.Content>
        <sfChat:SfChat x:Name="sfChat"
                       Messages="{Binding Messages}"
                       SendMessageCommand="{Binding SendMessage}"
                       CurrentUser="{Binding CurrentUser}" />
    </ContentPage.Content>

</ContentPage>

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


```

## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.