package md5efed3477e17807f3cc42d2dd9b8f031b;


public class CalendarView
	extends md5efed3477e17807f3cc42d2dd9b8f031b.BaseActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TestPPMobile.CalendarView, TestPPMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CalendarView.class, __md_methods);
	}


	public CalendarView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CalendarView.class)
			mono.android.TypeManager.Activate ("TestPPMobile.CalendarView, TestPPMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
