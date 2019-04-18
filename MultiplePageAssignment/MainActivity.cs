using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MultiplePageAssignment
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static Spinner menuNames;
        public static TextView ProductPriceTv, TotalPriceTv;
        public static EditText Name;
        public static double total;
        public static Button btnadd, btnorder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            double[] foodPriceArray = { 3, 8, 12, 2, 2.5, 4 };
            ProductPriceTv = (TextView)FindViewById(Resource.Id.etprice);
            TotalPriceTv = (TextView)FindViewById(Resource.Id.ettotal);
            menuNames = (Spinner)FindViewById(Resource.Id.spinproduct);
            btnadd = (Button)FindViewById(Resource.Id.btadd);
            btnorder = (Button)FindViewById(Resource.Id.btorder);
            Name = (EditText)FindViewById(Resource.Id.etname);

            var uNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.foodArray, Android.Resource.Layout.SimpleSpinnerItem);
            menuNames.Adapter = uNamesAdapter;

            menuNames.ItemSelected += delegate

            {
                long i = menuNames.SelectedItemId;
                ProductPriceTv.Text = foodPriceArray[i].ToString();
                total = foodPriceArray[i];
                Toast.MakeText(this, "The Selected Food is : " + menuNames.SelectedItem, ToastLength.Long).Show();
            };

            btnadd.Click += delegate

            {
                TotalPriceTv.Text = ProductPriceTv.Text;
            };

            btnorder.Click += delegate
            {
                Intent intent = new Intent(this, typeof(PlaceOrder));
                StartActivity(intent);
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

