
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
using Java.Util;
using Java.Lang;

namespace TestPPMobile
{
	[Activity (Label = "CalendarViewSampleActivity")]			
	public class CalendarView : BaseActivity
	{
		public Calendar month;
		public CalendarAdapter adapter;
		public Handler handler;
		public List<string> items; // container to store some random calendar items

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			month = Calendar.GetInstance(Java.Util.TimeZone.Default);
			onNewIntent(this.Intent);
			items = new List<string>();
			adapter = new CalendarAdapter(this, month);

			GridView gridview = (GridView) FindViewById(Resource.Id.gridview);
			gridview.SetAdapter(adapter);

			//handler = new Handler();
			//handler.Post(calendarUpdater);
			Refresh();
			TextView title  = (TextView) FindViewById(Resource.Id.title);
			title.Text=Android.Text.Format.DateFormat.Format("MMMM yyyy", month);

			TextView previous  = (TextView) FindViewById(Resource.Id.previous);
			previous.Click+= (object sender, EventArgs e) => {
				if(month.Get(Calendar.Month)== month.GetActualMinimum(Calendar.Month)) {				
					month.Set((month.Get(Calendar.Year)-1),month.GetActualMaximum(Calendar.Month),1);
				} else {
					month.Set(Calendar.Month,month.Get(Calendar.Month)-1);
				}
				refreshCalendar();
			};

			TextView next  = (TextView) FindViewById(Resource.Id.next);
			next.Click+= (object sender, EventArgs e) => {
				if(month.Get(Calendar.Month)== month.GetActualMaximum(Calendar.Month)) {				
					month.Set((month.Get(Calendar.Year)+1),month.GetActualMinimum(Calendar.Month),1);
				} else {
					month.Set(Calendar.Month,month.Get(Calendar.Month)+1);
				}
				refreshCalendar();
			};

			// Create your application here
		}

		public void refreshCalendar()
		{
			TextView title  = (TextView) FindViewById(Resource.Id.title);

			adapter.refreshDays();
			adapter.NotifyDataSetChanged();				
			Refresh ();		
			title.Text=Android.Text.Format.DateFormat.Format("MMMM yyyy", month);


		}


		public void onNewIntent(Intent intent) {
			string date = intent.GetStringExtra("date");
			string[] dateArr = date.Split(new Char[]{'-'}); // date format is yyyy-mm-dd
			month.Set(Convert.ToInt32(dateArr[0]), Convert.ToInt32(dateArr[1]), Convert.ToInt32(dateArr[2]));
		}

		#region implemented abstract members of BaseActivity

		protected override int LayoutResource {
			get {
				return Resource.Layout.Calendar;
			}
		}

		#endregion

		private void Refresh(){
			items.Clear();
			// format random values. You can implement a dedicated class to provide real values
			for(int i=0;i<31;i++) {
				Java.Util.Random r = new Java.Util.Random();

				if(r.NextInt(10)>6)
				{
					items.Add(i.ToString());
				}
			}
			adapter.setItems(items);
			adapter.NotifyDataSetChanged();
		}
		/*
		private Java.Lang.Runnable calendarUpdater = new Java.Lang.Runnable(() =>
			{
				Refresh();
			});
	
		public Runnable calendarUpdater = new Runnable() {


			public void run() {
				items.clear();
				// format random values. You can implement a dedicated class to provide real values
				for(int i=0;i<31;i++) {
					Random r = new Random();

					if(r.nextInt(10)>6)
					{
						items.add(Integer.toString(i));
					}
				}

				adapter.SetItems(items);
				adapter.NotifyDataSetChanged();
			}
		};*/
	}



}

