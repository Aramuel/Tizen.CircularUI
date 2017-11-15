﻿using ElmSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms.CircularUI;

using Xamarin.Forms.Platform.Tizen;

namespace Xamarin.Forms.CircularUI.Renderer
{
    class CircleProgressBarSurfaceItemImplements : ElmSharp.Wearable.CircleProgressBar
    {
        CircleProgressBarSurfaceItem _item;

        public CircleProgressBarSurfaceItemImplements(CircleProgressBarSurfaceItem item, EvasObject parent, ElmSharp.Wearable.CircleSurface surface) : base(parent, surface)
        {
            _item = item;
            item.PropertyChanged += ItemPropertyChanged;

            BackgroundAngle = item.BackgroundAngle;
            BackgroundAngleOffset = item.BackgroundAngleOffset;
            if (item.BackgroundColor != default(Color)) BackgroundColor = item.BackgroundColor.ToNative();
            if (item.BackgroundLineWidth != -1) BackgroundLineWidth = item.BackgroundLineWidth;
            if (item.BackgroundRadius != -1) BackgroundRadius = item.BackgroundRadius;

            BarAngle = item.BarAngle;
            BarAngleOffset = item.BarAngleOffset;
            BarAngleMaximum = item.BarAngleMaximum;
            BarAngleMinimum = item.BarAngleMinimum;
            if (item.BarColor != default(Color)) BarColor = item.BarColor.ToNative();
            if (item.BarLineWidth != -1) BarLineWidth = item.BarLineWidth;
            if (item.BarRadius != -1) BarRadius = item.BarRadius;

            Minimum = 0;
            Maximum = 1;

            Value = item.Value;
            IsEnabled = item.IsEnabled;

            Console.WriteLine($"Visibility = {item.IsVisible}");

            if (item.IsVisible) Show();
            else Hide();

            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BackgroundAngle = {BackgroundAngle}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BackgroundAngleOffset = {BackgroundAngleOffset}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BackgroundColor = {BackgroundColor}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BackgroundLineWidth = {BackgroundLineWidth}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BackgroundRadius = {BackgroundRadius}");

            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarAngle = {BarAngle}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarAngleOffset = {BarAngleOffset}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarAngleMaximum = {BarAngleMaximum}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarAngleMinimum = {BarAngleMinimum}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarColor = {BarColor}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarLineWidth = {BarLineWidth}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.BarRadius = {BarRadius}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.Value = {Value}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.IsEnabled = {BackgroundAngle}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.IsVisible = {IsVisible}");

            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.Maximum = {Maximum}");
            Console.WriteLine($"CircleProgressBarSurfaceItemImplements.Minimum = {Minimum}");
        }

        void ItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            Console.WriteLine($"CircleProgressbarItem Property Changed => {args.PropertyName}");
            if (args.PropertyName == CircleProgressBarSurfaceItem.BackgroundAngleProperty.PropertyName)
            {
                BackgroundAngle = _item.BackgroundAngle;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BackgroundAngleOffsetProperty.PropertyName)
            {
                BackgroundAngleOffset = _item.BackgroundAngleOffset;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BackgroundColorProperty.PropertyName)
            {
                BackgroundColor = _item.BackgroundColor.ToNative();
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BackgroundLineWidthProperty.PropertyName)
            {
                BackgroundLineWidth = _item.BackgroundLineWidth;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BackgroundRadiusProperty.PropertyName)
            {
                BackgroundRadius = _item.BackgroundRadius;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarAngleProperty.PropertyName)
            {
                BarAngle = _item.BarAngle;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarAngleOffsetProperty.PropertyName)
            {
                BarAngleOffset = _item.BarAngleOffset;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarAngleMaximumProperty.PropertyName)
            {
                BarAngleMaximum = _item.BarAngleMaximum;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarAngleMinimumProperty.PropertyName)
            {
                BarAngleMinimum = _item.BarAngleMinimum;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarColorProperty.PropertyName)
            {
                BarColor = _item.BarColor.ToNative();
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarLineWidthProperty.PropertyName)
            {
                BarLineWidth = _item.BarLineWidth;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.BarRadiusProperty.PropertyName)
            {
                BarRadius = _item.BarRadius;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.IsVisibleProperty.PropertyName)
            {
                if (_item.IsVisible) Show();
                else Hide();
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.ValueProperty.PropertyName)
            {
                Value = _item.Value;
            }
            else if (args.PropertyName == CircleProgressBarSurfaceItem.IsEnabledProperty.PropertyName)
            {
                IsEnabled = _item.IsEnabled;
            }
        }
    }
}
