using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using MeteoWP.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MeteoWP.View
{
    public abstract class ViewBase : PhoneApplicationPage
    {
        private readonly ProgressIndicator progressIndicator;

        protected ViewBase()
        {
            progressIndicator = new ProgressIndicator
            {
                IsVisible = false,
                IsIndeterminate = true,
                Text = "Chargement ..."
            };

            SystemTray.SetProgressIndicator(this, progressIndicator);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var viewModel = DataContext as NavigationViewModelBase;
            if (viewModel != null)
            {
                viewModel.SetProgressVisibility(a => progressIndicator.IsVisible = a);
                viewModel.AddParameters(NavigationContext.QueryString);
            }
        }

        protected async void Refresh()
        {
            var viewModel = DataContext as NavigationViewModelBase;
            if (viewModel != null)
            {
                await viewModel.Refresh();
            }
        }

        protected void UpdateBinding()
        {
            var currenTextBox = FocusManager.GetFocusedElement() as TextBox;
            if (currenTextBox != null)
            {
                BindingExpression binding = currenTextBox.GetBindingExpression(TextBox.TextProperty);
                if (binding != null)
                    binding.UpdateSource();
            }
        }
    }
}