
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

namespace TestPPMobile
{
	[Activity (Label = "ContactEdit")]			
	public class ContactEdit : BaseActivity
	{
		public static readonly String WORKORDER_ID_EXTRA = "workorderid";
		public static readonly String LOCATION_ID_EXTRA = "locationid";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Android.Resource.Id.Home:
				GoBack();
				return true;  
			default:
				return base.OnOptionsItemSelected(item);
			}
		}

		#region implemented abstract members of BaseActivity

		protected override int LayoutResource {
			get {
				return Resource.Layout.ContactEdit4;
			}
		}

		#endregion
	}
}


