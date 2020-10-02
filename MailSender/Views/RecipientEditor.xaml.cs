using System.Windows.Controls;

namespace MailSender.Views
{
    public partial class RecipientEditor
    {
        public RecipientEditor() => InitializeComponent();

        private void OnDataValidationError(object? Sender, ValidationErrorEventArgs E)
        {
            var control = (Control)Sender;
            if (E.Action == ValidationErrorEventAction.Added)
                control.ToolTip = E.Error.ErrorContent.ToString();
            else
                control.ClearValue(ToolTipProperty);
        }
    }
}
