﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Flora License, Version 1.1 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://floralicense.org/license/
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Globalization;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearableUIGallery.TC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TCCircleSliderSurfaceItem2 : CirclePage
    {
        CircleSliderSurfaceItem _slider1;
        CircleSliderSurfaceItem _slider2;
        string _focusedItem;

        public TCCircleSliderSurfaceItem2()
        {
            InitializeComponent ();

            _slider1 = new CircleSliderSurfaceItem
            {
                BackgroundColor = Color.Blue,
                BackgroundRadius = 170,
                BackgroundLineWidth = 20,
                BackgroundAngleOffset = 90,
                BackgroundAngle = 270,
                BarColor = Color.Red,
                BarRadius = 170,
                BarLineWidth = 18,
                BarAngleOffset = 90,
                BarAngleMaximum = 180,
                BarAngleMinimum = 10,
                Increment = 1,
                Value = 1,
            };

            _slider2 = new CircleSliderSurfaceItem
            {
                BackgroundColor = Color.LightGray,
                BackgroundRadius = 140,
                BackgroundLineWidth = 15,
                BarColor = Color.Green,
                BarRadius = 140,
                BarLineWidth = 13,
                Maximum = 6,
                Minimum = 1,
                Increment = 0.5,
                Value = 3,
            };

            label1.SetBinding(Label.TextProperty, "Value", BindingMode.Default, new ValueConverter1());
            label2.SetBinding(Label.TextProperty, "Value", BindingMode.Default, new ValueConverter2());
            label1.BindingContext = _slider1;
            label2.BindingContext = _slider2;

            CircleSurfaceItems.Add(_slider1);
            CircleSurfaceItems.Add(_slider2);

            _focusedItem = "slider1";
            RotaryFocusObject = _slider1;
        }


        void OnClick(object sender, EventArgs args)
        {
            if(_focusedItem.Equals("slider1"))
            {
                RotaryFocusObject = _slider2;
                _focusedItem = "slider2";
            }
            else
            {
                RotaryFocusObject = _slider1;
                _focusedItem = "slider1";
            }
        }

        class ValueConverter1 : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string str = $"Slider1 :{string.Format("{0:0}", (double)value)}";
                return str;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
        }

        class ValueConverter2 : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string str = $"Slider2 :{string.Format("{0:F1}", (double)value)}";
                return str;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
        }

    }
}