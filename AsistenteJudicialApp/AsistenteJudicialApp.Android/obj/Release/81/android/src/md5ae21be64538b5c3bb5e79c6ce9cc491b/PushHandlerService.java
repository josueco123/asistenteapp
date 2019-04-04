package md5ae21be64538b5c3bb5e79c6ce9cc491b;


public class PushHandlerService
	extends md513d040a829b3f298fbeeee5a6e2c042a.GcmServiceBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AsistenteJudicialApp.Droid.PushHandlerService, AsistenteJudicialApp.Android", PushHandlerService.class, __md_methods);
	}


	public PushHandlerService (java.lang.String p0)
	{
		super (p0);
		if (getClass () == PushHandlerService.class)
			mono.android.TypeManager.Activate ("AsistenteJudicialApp.Droid.PushHandlerService, AsistenteJudicialApp.Android", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public PushHandlerService ()
	{
		super ();
		if (getClass () == PushHandlerService.class)
			mono.android.TypeManager.Activate ("AsistenteJudicialApp.Droid.PushHandlerService, AsistenteJudicialApp.Android", "", this, new java.lang.Object[] {  });
	}

	public PushHandlerService (java.lang.String[] p0)
	{
		super ();
		if (getClass () == PushHandlerService.class)
			mono.android.TypeManager.Activate ("AsistenteJudicialApp.Droid.PushHandlerService, AsistenteJudicialApp.Android", "System.String[], mscorlib", this, new java.lang.Object[] { p0 });
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
