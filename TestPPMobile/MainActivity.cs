using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace TestPPMobile
{
	[Activity (Label = "TestPPMobile", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};

			var locationDataRow = FindViewById<TextView> (Resource.Id.AppointmentAddEditLabel);
		
			locationDataRow.Click -= ContactEdit_Click;
			locationDataRow.Click += ContactEdit_Click;

			var testCalendar = FindViewById<TextView> (Resource.Id.TestCalendar);

			testCalendar.Click -= Calendar_Click;
			testCalendar.Click += Calendar_Click;

		}
		void Calendar_Click (object sender, EventArgs e)
		{
			var intent = new Intent (this, typeof(CalendarView));
			intent.PutExtra ("date", "2016-05-30");
			this.StartActivity (intent);
		}

		void ContactEdit_Click (object sender, EventArgs e)
		{
			var intent = new Intent (this, typeof(ContactList));
			intent.PutExtra (ContactEdit.WORKORDER_ID_EXTRA, 1);
			this.StartActivity (intent);
		}
	}
}


