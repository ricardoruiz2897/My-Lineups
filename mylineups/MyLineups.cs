
using System;
using System.IO;

using Mono.Data.Sqlite;

using Android.App;
using Android.Content;
using A_OS = Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace mylineups
{
	[Activity (Label = "MyLineups")]
	public class MyLineups : Activity
	{
		public static SqliteConnection connection;

		protected override void OnCreate (A_OS.Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.MyLineUps);

			Button enter = FindViewById<Button> (Resource.Id.ENTER);

			EditText team_name = FindViewById<EditText> (Resource.Id.TeamNameBox);
			enter.Enabled = false;

			team_name.TextChanged += delegate {
				enter.Enabled = true;
			};



			enter.Click += delegate {
				DataAccess (team_name.Text);	
			};
		}

		public void DataAccess (string teamName) {

			TextView [] names = {FindViewById<TextView> (Resource.Id.Player1),
								 FindViewById<TextView> (Resource.Id.Player2),
								 FindViewById<TextView> (Resource.Id.Player3),
				                 FindViewById<TextView> (Resource.Id.Player4),
				                 FindViewById<TextView> (Resource.Id.Player5),
				                 FindViewById<TextView> (Resource.Id.Player6),
				                 FindViewById<TextView> (Resource.Id.Player7),	
			                     FindViewById<TextView> (Resource.Id.Player8),
								 FindViewById<TextView> (Resource.Id.Player9),
				   			     FindViewById<TextView> (Resource.Id.Player10),
								 FindViewById<TextView> (Resource.Id.Player11) };
			
    		TextView [] positions = {FindViewById<TextView> (Resource.Id.position1),
									 FindViewById<TextView> (Resource.Id.position2),
									 FindViewById<TextView> (Resource.Id.position3),
									 FindViewById<TextView> (Resource.Id.position4),
									 FindViewById<TextView> (Resource.Id.position5),
									 FindViewById<TextView> (Resource.Id.position6),
									 FindViewById<TextView> (Resource.Id.position7),
									 FindViewById<TextView> (Resource.Id.position8),
									 FindViewById<TextView> (Resource.Id.position9),
									 FindViewById<TextView> (Resource.Id.position10),
									 FindViewById<TextView> (Resource.Id.position11) };

			//generate path 
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "lineup-db.db3");

			//check if exists
			bool exists = File.Exists (dbPath);

			//if doesn't exist, inform the user ther is no info
			if (!exists) {

				Toast.MakeText (this, "You dont have any line ups!", ToastLength.Short).Show ();

			} else {

				//access database to extract info
				connection = new SqliteConnection ("Data Source=" + dbPath);
				connection.Open ();

				//to iterate arrays
				int i = 0;
				int j = 0;

				using (var contents = connection.CreateCommand()) {

					contents.CommandText = "SELECT [team], [name], [position] from [players_table]";
					var r = contents.ExecuteReader ();

					while (r.Read()) {

						//only input if is on team
						if (r["team"].ToString() == teamName) { 
							
								names [i++].Text = r ["name"].ToString ();
								positions [j++].Text = r ["position"].ToString ();

						}

					}

				}

				connection.Close ();

			}

		}
	}
}
