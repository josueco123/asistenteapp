using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AsistenteJudicialApp
{
    class RadValidatorBehavior : Behavior<Entry>
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
            var radicacionEntry = sender as Entry;

            var radicacion = e.NewTextValue;

            if(radicacion.Length < 7)
            {
                radicacionEntry.TextColor = Color.Red;
            }
            else
            {
                radicacionEntry.TextColor = Color.Black;
            }
        }
    }
}
