using TTGSnackBar;

namespace SampleSnackbar
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow? Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// create a new window instance based on the screen size
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			// create a UIViewController with a single UILabel
			var vc = new UIViewController();
			vc.View!.AddSubview(new UILabel(Window!.Frame)
			{
				BackgroundColor = UIColor.SystemBackground,
				TextAlignment = UITextAlignment.Center,
				Text = "Hello, iOS!",
				AutoresizingMask = UIViewAutoresizing.All,
			});
			Window.RootViewController = vc;

			// make the window visible
			Window.MakeKeyAndVisible();

			var snackbar = new TTGSnackbar("Hello Xamarin snackbar");
			snackbar.Duration = TimeSpan.FromSeconds(5);

			snackbar.AnimationType = TTGSnackbarAnimationType.FadeInFadeOut;

			snackbar.SeperateView.Alpha = 0;

			// Action 1
			snackbar.ActionText = "Yes";
			snackbar.ActionTextColor = UIColor.Green;
			snackbar.ActionBlock = (t) =>
			{
				Console.WriteLine("clicked yes");
			};

			// Action 2
			snackbar.SecondActionText = "No";
			snackbar.SecondActionTextColor = UIColor.Magenta;
			snackbar.SecondActionBlock = (t) => { Console.WriteLine("clicked no"); };

			// Dismiss Callback
			snackbar.DismissBlock = (t) => { Console.WriteLine("dismissed snackbar"); };

			snackbar.Icon = UIImage.FromBundle("AppIcon");
			snackbar.LocationType = TTGSnackbarLocation.Top;

			snackbar.Show();

			return true;
		}
	}
}