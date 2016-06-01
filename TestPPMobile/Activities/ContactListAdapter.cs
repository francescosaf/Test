
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestPPMobile
{
	class ContactListAdapter : BaseAdapter<Contact>
	{
		#region implemented abstract members of BaseAdapter
		private List<Contact> _contactList=new List<Contact>();
		Activity _activity;

		public ContactListAdapter (Activity activity)
		{
			_activity = activity;
			FillContacts ();
		}

		void FillContacts ()
		{
			Contact co = new Contact ();
			co.DisplayName = "Pippo";
			co.Id = 1;
			_contactList.Add (co);
			co = new Contact ();
			co.DisplayName = "Pippa";
			co.Id = 2;
			_contactList.Add (co);
		}

		public override int Count {
			get { return _contactList.Count; }
		}

		public override Java.Lang.Object GetItem (int position) {
			// could wrap a Contact in a Java.Lang.Object
			// to return it here if needed
			return null;
		}

		public override long GetItemId (int position) {
			return _contactList [position].Id;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? _activity.LayoutInflater.Inflate (
				Resource.Layout.ContactListItem, parent, false);
			var contactName = view.FindViewById<TextView> (Resource.Id.ContactName);
			var contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
			contactName.Text = _contactList [position].DisplayName;


			contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
			contactImage.SetImageResource (Resource.Drawable.white_chevron_small);
		
			return view;
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Contact this [int index] {
			get {
				return _contactList[index];	
			}
		}

		#endregion


	}

	class Contact
	{
		public long Id { get; set; }
		public string DisplayName{ get; set; }
	}
}

