
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
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace TestPPMobile
{
	public abstract class BaseActivity : AppCompatActivity
	{
		public Android.Support.V7.Widget.Toolbar Toolbar {
			get;
			set;
		}

		protected abstract int LayoutResource {
			get;
		}

		protected int ActionBarIcon {
			set{ Toolbar.SetNavigationIcon (value); }
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (LayoutResource);

			Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);

			if (Toolbar != null) {
				SetSupportActionBar (Toolbar);
				SupportActionBar.SetDisplayHomeAsUpEnabled (true);
				SupportActionBar.SetHomeButtonEnabled (true);
			}


		}

		public override void OnBackPressed()
		{
			base.OnBackPressed();
			GoBack();
		}

		public void GoBack()
		{
			Finish();
			OverridePendingTransition(Resource.Animation.slide_in_left, Resource.Animation.slide_out_right);
		}

	}
}

