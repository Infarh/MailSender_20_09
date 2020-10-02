using System.Windows.Controls;

namespace MailSender.Views
{
    public partial class RecipientEditor
    {
        public RecipientEditor() => InitializeComponent();

        private void OnDataValidationError(object? Sender, ValidationErrorEventArgs E)
        {
            var control = (Control)E.OriginalSource;
            if (E.Action == ValidationErrorEventAction.Added)
                control.ToolTip = E.Error.ErrorContent.ToString();
            else
                control.ClearValue(ToolTipProperty);
        }
    }
}
