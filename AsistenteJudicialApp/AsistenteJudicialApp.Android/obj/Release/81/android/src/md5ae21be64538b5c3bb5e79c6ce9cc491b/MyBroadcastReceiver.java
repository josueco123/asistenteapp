package md5ae21be64538b5c3bb5e79c6ce9cc491b;


public class MyBroadcastReceiver
	extends md513d040a829b3f298fbeeee5a6e2c042a.GcmBroadcastReceiverBase_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AsistenteJudicialApp.Droid.MyBroadcastReceiver, AsistenteJudicialApp.Android", MyBroadcastReceiver.class, __md_methods);
	}


	public MyBroadcastReceiver ()
	{
		super ();
		if (getClass () == MyBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("AsistenteJudicialApp.Droid.MyBroadcastReceiver, AsistenteJudicialApp.Android", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
