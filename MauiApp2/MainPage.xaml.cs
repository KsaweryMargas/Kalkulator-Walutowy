using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Convert(object sender, EventArgs e)
        {
            if (!double.TryParse(value.Text, out double usd))
            {
                result.Text = "Nieprawidłowa wartość USD.";
                return;
            }

            double converted = 0;
            string currency = "";

            if (idr.IsChecked)
            {
                if (double.TryParse(idrRate.Text, out double idrValue))
                {
                    converted = usd * idrValue;
                    currency = "IDR";
                }
                else
                {
                    result.Text = "Nieprawidłowy kurs IDR.";
                    return;
                }
            }
            else if (pln.IsChecked)
            {
                if (double.TryParse(plnRate.Text, out double plnValue))
                {
                    converted = usd * plnValue;
                    currency = "PLN";
                }
                else
                {
                    result.Text = "Nieprawidłowy kurs PLN.";
                    return;
                }
            }
            else if (czk.IsChecked)
            {
                if (double.TryParse(czkRate.Text, out double czkValue))
                {
                    converted = usd * czkValue;
                    currency = "CZK";
                }
                else
                {
                    return;
                }
            }

            result.Text = $"Wartość w {currency}: {converted:N2}";
        }
    }
}
