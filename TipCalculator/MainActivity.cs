using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);        
            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += OnCalculateClick;
        }

        private void OnCalculateClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCalculateClick)}");
            double billAmount;

            bool validBill = double.TryParse(inputBill.Text, out billAmount);

            if(validBill == false)
            {
                System.Diagnostics.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCalculateClick)}:  Invalid bill entered:  [{inputBill.Text}]");
                return;
            }

            var tip15 = billAmount * 0.15;
            var total = billAmount + tip15;

            outputTip.Text = $"{tip15:C}";
            outputTotal.Text = $"{total:C}";
        }
    }
}

