using Android.App;
using Android.Widget;
using Android.OS;

namespace mylineups
{
	[Activity (Label = "my-lineups", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button mbutton = FindViewById<Button> (Resource.Id.mButton);
			Button nbutton = FindViewById<Button> (Resource.Id.nButton);

			//open my lineups activity
			mbutton.Click += delegate { StartActivity (typeof (MyLineups)); };

			//open new lineup activity
			nbutton.Click += delegate { StartActivity (typeof (NewLineup)); };

		}
	}
}

