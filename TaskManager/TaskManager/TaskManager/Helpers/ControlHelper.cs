using Xamarin.Forms;

namespace TaskManager.Helpers
{
    public class FormControlHelper
    {
        public static Label CreateStandardLabel(string labelText)
        {
            return new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("#ade845"),
                Text = labelText
            };
        }

        public static Entry CreateStandardPhoneEntry(string placeholder)
        {
            return new Entry
            {
                FontSize = 20,
                TextColor = Color.FromHex("#ade845"),
                Placeholder = placeholder,
                Keyboard = Keyboard.Telephone
            };
        }

        public static Entry CreateStandardTextEntry(string placeholder)
        {
            return new Entry
            {
                FontSize = 20,
                TextColor = Color.FromHex("#ade845"),
                Placeholder = placeholder,
                Keyboard = Keyboard.Text
            };
        }

        public static Entry CreateStandardNumberEntry(string placeholder)
        {
            return new Entry
            {
                FontSize = 20,
                TextColor = Color.FromHex("#ade845"),
                Placeholder = placeholder,
                Keyboard = Keyboard.Numeric
            };
        }

        public static Entry CreateStandardEmailEntry(string placeholder)
        {
            return new Entry
            {
                FontSize = 20,
                TextColor = Color.FromHex("#ade845"),
                Placeholder = placeholder,
                Keyboard = Keyboard.Email
            };
        }

        public static Button CreateStandardButton(string buttonText)
        {
            return new Button
            {
                Text = buttonText,
                FontSize = 20,
                BackgroundColor = Color.FromHex("#0087e0"),
                TextColor = Color.White,
            };
        }
    }
}
