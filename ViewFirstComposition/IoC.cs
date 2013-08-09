using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;

namespace ViewFirstComposition
{
    public class IoC
    {
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.RegisterAttached("ViewType", typeof(Type),
            typeof(IoC), new PropertyMetadata(default(Type), OnViewTypeChanged));

        [AttachedPropertyBrowsableForType(typeof(ContentPresenter))]
        public static Type GetViewType(ContentPresenter cp)
        {
            return (Type)cp.GetValue(ViewTypeProperty);
        }

        public static void SetViewType(ContentPresenter cp, Type value)
        {
            cp.SetValue(ViewTypeProperty, value);
        }

        static void OnViewTypeChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(source))
                throw new NotImplementedException("Design-time support is not implemented yet");

            var cp = (ContentPresenter) source;
            var type = GetViewType(cp);
            var view = ServiceLocator.Current.GetInstance(type);
            cp.Content = view;
        }
    }
}
