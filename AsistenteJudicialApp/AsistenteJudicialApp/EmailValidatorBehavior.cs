using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AsistenteJudicialApp
{
    class EmailValidatorBehavior : Behavior<Entry> 
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;

            var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

            var correoEntry = sender as Entry;
            
            if (Regex.IsMatch(email, emailPattern))
            {
                correoEntry.TextColor = Color.Black;
            } else
            {
                correoEntry.TextColor = Color.Red;
            }
        }
    }
}
