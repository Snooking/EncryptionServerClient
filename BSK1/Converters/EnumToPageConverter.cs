﻿using BSK1.Models;
using BSK1.Views;
using System;
using System.Globalization;

namespace BSK1.Converters
{
    internal class EnumToPageConverter : BaseValueConverter<EnumToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ApplicationPage currentPage))
            {
                return new SendView();
            }
            switch (currentPage)
            {
                case ApplicationPage.Send:
                    return new SendView();
                case ApplicationPage.Receive:
                    return new ReceiveView();
                case ApplicationPage.Users:
                    return new UsersView();
                case ApplicationPage.Register:
                    return new RegisterView();
                default:
                    return new SendView();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
