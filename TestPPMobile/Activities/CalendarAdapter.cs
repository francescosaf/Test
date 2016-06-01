
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

namespace TestPPMobile
{
	[Activity (Label = "CalendarAdapter")]			
	public class CalendarAdapter : BaseAdapter
	{
		static int FIRST_DAY_OF_WEEK =0; // Sunday = 0, Monday = 1


		private Context mContext;

		private Calendar month;
		private Calendar selectedDate;
		private List<String> items;

		public CalendarAdapter(Context c, Calendar monthCalendar) {
			month = monthCalendar;
			selectedDate = (Calendar)monthCalendar.Clone ();
			mContext = c;
			month.Set(Calendar.DayOfMonth, 1);
			this.items = new List<String>();
			refreshDays();
		}

		public void setItems(List<String> items) {
			for(int i = 0;i != items.Count;i++){
				if(items[i].Length==1) {
					items[i]= "0" + items[i];
				}
			}
			this.items = items;
		}




		#region implemented abstract members of BaseAdapter

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}


		public override int Count {
			get {
				return days.Length;
			}
		}

		#endregion

		// create a new view for each item referenced by the Adapter
		public override View GetView (int position, View convertView, ViewGroup parent) {
			View v = convertView;
			TextView dayView;
			if (convertView == null) {  // if it's not recycled, initialize some attributes
				LayoutInflater inflater = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
				v = (View) inflater.Inflate(Resource.Layout.CalendarItem,null);
			}
			dayView = (TextView)v.FindViewById(Resource.Id.date);

			// disable empty days from the beginning
			if(days[position].Equals("")) {
				dayView.Clickable=false;
				dayView.Focusable=false;
			}
			else {
				// mark current day as focused
				if(month.Get(Calendar.Year)== selectedDate.Get(Calendar.Year) && month.Get(Calendar.Month)== selectedDate.Get(Calendar.Month) && days[position].Equals(""+selectedDate.Get(Calendar.DayOfMonth))) {
					v.SetBackgroundResource(Resource.Drawable.item_background_focused);
				}
				else {
					v.SetBackgroundResource(Resource.Drawable.list_item_background);
				}
			}
			dayView.Text=days[position];

			// create date string for comparison
			String date = days[position];

			if(date.Length==1) {
				date = "0"+date;
			}
			String monthStr = ""+(month.Get(Calendar.Month)+1);
			if(monthStr.Length==1) {
				monthStr = "0"+monthStr;
			}

			// show icon if date is not empty and it exists in the items array
			TextView pr= v.FindViewById<TextView>(Resource.Id.dateText);
			//ImageView iw = (ImageView)v.FindViewById(Resource.Id.date_icon);
			if(date.Length>0 && items!=null && items.Contains(date)) {        	
				pr.Visibility=ViewStates.Visible;

				pr.Text = "Today is "+items.Find(x=> x.Contains(date));
			}
			else {
				pr.Visibility=ViewStates.Invisible;
			}
			return v;
		}

		public void refreshDays()
		{
			// clear items
			items.Clear();

			int lastDay = month.GetActualMaximum(Calendar.DayOfMonth);
			int firstDay = (int)month.Get(Calendar.DayOfWeek);

			// figure size of the array
			if(firstDay==1){
				days = new String[lastDay+(FIRST_DAY_OF_WEEK*6)];
			}
			else {
				days = new String[lastDay+firstDay-(FIRST_DAY_OF_WEEK+1)];
			}

			int j=FIRST_DAY_OF_WEEK;

			// populate empty days before first real day
			if(firstDay>1) {
				for(j=0;j<firstDay-FIRST_DAY_OF_WEEK;j++) {
					days[j] = "";
				}
			}
			else {
				for(j=0;j<FIRST_DAY_OF_WEEK*6;j++) {
					days[j] = "";
				}
				j=FIRST_DAY_OF_WEEK*6+1; // sunday => 1, monday => 7
			}

			// populate days
			int dayNumber = 1;
			for(int i=j-1;i<days.Length;i++) {
				days[i] = ""+dayNumber;
				dayNumber++;
			}
		}

		// references to our items
		public String[] days;
	}
}

