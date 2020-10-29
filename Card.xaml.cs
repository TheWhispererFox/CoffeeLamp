using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeLamp
{
    /// <summary>
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public static readonly DependencyProperty CardImageSourceProperty = DependencyProperty.Register(nameof(CardImageSource), typeof(ImageSource), typeof(Card), new FrameworkPropertyMetadata(new BitmapImage(new Uri("/Resources/3840x2563-a-cozy-cup-of-coffee.jpg", UriKind.Relative)), FrameworkPropertyMetadataOptions.AffectsRender, (sender, e) => (sender as Card).CardImageSource = e.NewValue as ImageSource));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(Card), new FrameworkPropertyMetadata("Title", FrameworkPropertyMetadataOptions.AffectsRender, (o, args) => (o as Card).Title = args.NewValue as string));
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(string), typeof(Card), new FrameworkPropertyMetadata("Description", FrameworkPropertyMetadataOptions.AffectsRender, (o, args) => (o as Card).Description = args.NewValue as string));
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(nameof(Price), typeof(double), typeof(Card), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender, (o, args) => (o as Card).Price = (double)args.NewValue));
        public static readonly DependencyProperty WeightValueProperty = DependencyProperty.Register(nameof(WeightValue),
            typeof(double), typeof(Card),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender,
                (o, args) => (o as Card).WeightValue = (double) args.NewValue));
        public static readonly DependencyProperty WeightMeasureProperty = DependencyProperty.Register(nameof(WeightMeasure), typeof(string), typeof(Card), new FrameworkPropertyMetadata("мЛ", FrameworkPropertyMetadataOptions.AffectsRender, (o, args) => (o as Card).WeightMeasure = args.NewValue as string));

        public Card()
        {
            InitializeComponent();
        }

        public ImageSource CardImageSource
        {
            get => GetValue(CardImageSourceProperty) as ImageSource;
            set
            {
                SetValue(CardImageSourceProperty, value);
                ImageBackground.Background = new ImageBrush(CardImageSource);
            }
        }

        public string Title
        {
            get => GetValue(TitleProperty) as string;
            set
            {
                SetValue(TitleProperty, value);
                TitleTBlock.Text = value;
            }
        }

        public string Description
        {
            get => GetValue(DescriptionProperty) as string;
            set
            {
                SetValue(DescriptionProperty, value);
                DescriptionTBlock.Text = value;
            }
        }

        public double Price
        {
            get => (double) GetValue(PriceProperty);
            set
            {
                SetValue(PriceProperty, value);
                PriceTBlock.Text = Price.ToString(CultureInfo.CurrentCulture) + " " + CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            }
        }

        public double WeightValue
        {
            get => (double) GetValue(WeightValueProperty);
            set
            {
                SetValue(WeightValueProperty, value);
            }
        }

        public string WeightMeasure
        {
            get => GetValue(WeightMeasureProperty) as string;
            set
            {
                SetValue(WeightMeasureProperty, value);
            }
        }

        //public string Weight
        //{
        //    get => $"{WeightValue} {WeightMeasure}";
        //}
    }
}
