
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
	[Activity (Label = "ContactList")]			
	public class ContactList : BaseActivity
	{
		ContactListAdapter contactsAdapter;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			contactsAdapter = new ContactListAdapter (this);
			var contactsListView = FindViewById<ListView> (Resource.Id.ContactsListView);
			contactsListView.Adapter = contactsAdapter;

			contactsListView.ItemClick += lv_ItemClick;


			LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
			View footer = (View) inflater.Inflate(Resource.Layout.ContactListFooter, contactsListView,	false);
			contactsListView.AddFooterView(footer, null, false);
			var locationDataRow = FindViewById<TextView> (Resource.Id.addContact);

			locationDataRow.Click -= ContactEdit_Click;
			locationDataRow.Click += ContactEdit_Click;
			//var tv = FindViewById<TextView> (Resource.Id.addContact);
			//contactsListView.AddFooterView(tv);
			// Create your application here

		}
		void lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			
			var item2 = this.contactsAdapter[e.Position];
			var item = this.contactsAdapter.GetItemId(e.Position);
			var intent = new Intent (this, typeof(ContactEdit));
			intent.PutExtra (ContactEdit.WORKORDER_ID_EXTRA, 1);
			this.StartActivity (intent);
		}
		void ContactEdit_Click (object sender, EventArgs e)
		{
			var intent = new Intent (this, typeof(ContactEdit));
			intent.PutExtra (ContactEdit.WORKORDER_ID_EXTRA, 1);
			this.StartActivity (intent);
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
				return Resource.Layout.ContactsList;
			}
		}

		#endregion
	}
}

