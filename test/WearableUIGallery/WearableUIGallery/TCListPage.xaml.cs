﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearableUIGallery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TCListPage : CirclePage
    {
		public TCListPage ()
		{
			InitializeComponent ();
            this.AutomationId = "HomePage";
		}

        public void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            if (args.Item == null) return;

            var desc = args.Item as TCDescribe;
            if (desc != null && desc.Class != null)
            {
                Page page;
                if (desc.Class.Count == 1)
                {
                    Type pageType = desc.Class;
                    page = Activator.CreateInstance(pageType) as Page;
                }
                else
                {
                    var types = desc.Class;
                    page = new TCSubListPage
                    {
                        AutomationId = desc.Title + "Page"
                    };
                    page.BindingContext = types;
                }
                NavigationPage.SetHasNavigationBar(page, false);
                App.MainNavigation.PushAsync(page);
            }
        }
    }

    class DetailTextConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            var count = (int)value;
            return count > 1 ? $"{count} TC" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AutomationBinding
    {
        #region AutomationId Attached Property
        public static readonly BindableProperty AutomationIdProperty = BindableProperty.CreateAttached (nameof(AutomationIdProperty), typeof(string),
           typeof(AutomationBinding), string.Empty, propertyChanged: OnAutomationIdChanged);

        public static string GetAutomationId(BindableObject target)
        {
            return (string)target.GetValue(AutomationIdProperty);
        }

        public static void SetAutomationId(BindableObject target, string value)
        {
            target.SetValue(AutomationIdProperty, value);
        }

        #endregion

        static void OnAutomationIdChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Element has the AutomationId property
            var element = bindable as Element;
            string id = (newValue == null) ? "" : newValue.ToString();

            // we can only set the AutomationId once, so only set it when we have a reasonable value since
            // sometimes bindings will fire with null the first time
            if (element != null && element.AutomationId == null && !string.IsNullOrEmpty(id))
            {
                element.AutomationId = id;
            }
        }
    }
}