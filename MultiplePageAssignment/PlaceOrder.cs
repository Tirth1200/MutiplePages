using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MultiplePageAssignment
{
    [Activity(Label = "PlaceOrder")]
    public class PlaceOrder : Activity
    {

        public static Button BackBtn, FinalBtn;
        public static TextView welcome,payment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page2);
            // Create your application here
            BackBtn = (Button)FindViewById(Resource.Id.btback);
            FinalBtn = (Button)FindViewById(Resource.Id.btfinal);
            welcome = (TextView)FindViewById(Resource.Id.etwelcome);
            payment = (TextView)FindViewById(Resource.Id.etfinal);

            welcome.Text = MainActivity.Name.Text;

            FinalBtn.Click += delegate
            {
                double pay = MainActivity.total * 1.13;
                payment.Text = pay.ToString();
            };

            BackBtn.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}