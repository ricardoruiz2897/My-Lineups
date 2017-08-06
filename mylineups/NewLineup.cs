using System;
using System.IO;

using Mono.Data.Sqlite;

using Android.App;
using A_OS = Android.OS;
using Android.Widget;

namespace mylineups
{
	[Activity (Label = "NewLineup")]
	public class NewLineup : Activity
	{
		public static SqliteConnection connection;

		protected override void OnCreate (A_OS.Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.NewLineUp);

			//To get name of team
			EditText team_Name = FindViewById<EditText> (Resource.Id.TeamNameBox);

			//RadioButtons control
			RadioButton radio_four_four_two = FindViewById<RadioButton> (Resource.Id.four_four_two);
			RadioButton radio_four_two_three_one = FindViewById<RadioButton> (Resource.Id.four_two_three_one);
			RadioButton radio_five_three_two = FindViewById<RadioButton> (Resource.Id.five_three_two);
			RadioButton radio_four_three_three = FindViewById<RadioButton> (Resource.Id.four_three_three);

			radio_four_four_two.Click += RadioButtonClick;
			radio_four_two_three_one.Click += RadioButtonClick;
			radio_five_three_two.Click += RadioButtonClick;
			radio_four_three_three.Click += RadioButtonClick;

			Button save_button = FindViewById<Button> (Resource.Id.SAVE);

			//each players editBox
			EditText [] players_name = {FindViewById<EditText> (Resource.Id.Player1),
										 FindViewById<EditText> (Resource.Id.Player2),
									 	 FindViewById<EditText> (Resource.Id.Player3),
										 FindViewById<EditText> (Resource.Id.Player4),
										 FindViewById<EditText> (Resource.Id.Player5),
										 FindViewById<EditText> (Resource.Id.Player6),
										 FindViewById<EditText> (Resource.Id.Player7),
										 FindViewById<EditText> (Resource.Id.Player8),
										 FindViewById<EditText> (Resource.Id.Player9),
										 FindViewById<EditText> (Resource.Id.Player10),
										 FindViewById<EditText> (Resource.Id.Player11)};
			
			 TextView [] player_position = { FindViewById<TextView> (Resource.Id.position1),
											FindViewById<TextView> (Resource.Id.position2),
											FindViewById<TextView> (Resource.Id.position3),
											FindViewById<TextView> (Resource.Id.position4),
											FindViewById<TextView> (Resource.Id.position5),
											FindViewById<TextView> (Resource.Id.position6),
											FindViewById<TextView> (Resource.Id.position7),
											FindViewById<TextView> (Resource.Id.position8),
											FindViewById<TextView> (Resource.Id.position9),
											FindViewById<TextView> (Resource.Id.position10),
											FindViewById<TextView> (Resource.Id.position11)};			

			//set all boxes to uneditable
			for (int i = 0; i < players_name.Length; i++) {
				players_name [i].Enabled = false;
			}

			save_button.Click += delegate {

				//perform sql here to save data
				SAVE_ALL (player_position, players_name, team_Name);
				Toast.MakeText (this, "Data was saved correctly", ToastLength.Long).Show();
				StartActivity (typeof(MainActivity));
			};


		}

		public void RadioButtonClick (object sender, EventArgs e) {

			//each players editBox
			EditText [] players_name = { FindViewById<EditText> (Resource.Id.Player1),
										 FindViewById<EditText> (Resource.Id.Player2),
									 	 FindViewById<EditText> (Resource.Id.Player3),
										 FindViewById<EditText> (Resource.Id.Player4),
										 FindViewById<EditText> (Resource.Id.Player5),
										 FindViewById<EditText> (Resource.Id.Player6),
										 FindViewById<EditText> (Resource.Id.Player7),
										 FindViewById<EditText> (Resource.Id.Player8),
										 FindViewById<EditText> (Resource.Id.Player9),
										 FindViewById<EditText> (Resource.Id.Player10),
										 FindViewById<EditText> (Resource.Id.Player11)};
			
			TextView [] player_position = { FindViewById<TextView> (Resource.Id.position1),
											FindViewById<TextView> (Resource.Id.position2),
											FindViewById<TextView> (Resource.Id.position3),
											FindViewById<TextView> (Resource.Id.position4),
											FindViewById<TextView> (Resource.Id.position5),
											FindViewById<TextView> (Resource.Id.position6),
											FindViewById<TextView> (Resource.Id.position7),
											FindViewById<TextView> (Resource.Id.position8),
											FindViewById<TextView> (Resource.Id.position9),
											FindViewById<TextView> (Resource.Id.position10),
											FindViewById<TextView> (Resource.Id.position11)};

			//activate editTexts
			for (int i = 0; i < players_name.Length; i++) {
				players_name [i].Enabled = true;
			}

			RadioButton rb = (RadioButton)sender;

			//Set text by radio button
			if (rb.Id == Resource.Id.four_four_two) {

				four_four_two (player_position);

			} else if (rb.Id == Resource.Id.four_two_three_one) {

				four_two_three_one (player_position);

			} else if (rb.Id == Resource.Id.five_three_two) {

				five_three_two (player_position);

			} else if (rb.Id == Resource.Id.four_three_three) {

				four_three_three (player_position);

			}

		}

		//this funtion sets text four four two line up
		public void four_four_two (TextView [] player_positions) {

			player_positions [0].Text = "GK";
			player_positions [1].Text = "CB";
			player_positions [2].Text = "CB";
			player_positions [3].Text = "RB";
			player_positions [4].Text = "LB";
			player_positions [5].Text = "CLM";
			player_positions [6].Text = "CRM";
			player_positions [7].Text = "LW";
			player_positions [8].Text = "RW";
			player_positions [9].Text = "CF";
			player_positions [10].Text = "CF";

		}

		public void four_two_three_one (TextView [] player_positions) {

			player_positions [0].Text = "GK";
			player_positions [1].Text = "CB";
			player_positions [2].Text = "CB";
			player_positions [3].Text = "RB";
			player_positions [4].Text = "LB";
			player_positions [5].Text = "CLM";
			player_positions [6].Text = "CRM";
			player_positions [7].Text = "LW";
			player_positions [8].Text = "RW";
			player_positions [9].Text = "COM";
			player_positions [10].Text = "CF";

			
		}

		public void four_three_three (TextView [] player_positions) { 

			player_positions [0].Text = "GK";
			player_positions [1].Text = "CB";
			player_positions [2].Text = "CB";
			player_positions [3].Text = "RB";
			player_positions [4].Text = "LB";
			player_positions [5].Text = "CLM";
			player_positions [6].Text = "CM";
			player_positions [7].Text = "CRM";
			player_positions [8].Text = "LW";
			player_positions [9].Text = "RW";
			player_positions [10].Text = "CF";

		}

		public void five_three_two (TextView [] player_positions) {

			player_positions [0].Text = "GK";
			player_positions [1].Text = "SW";
			player_positions [2].Text = "CB";
			player_positions [3].Text = "CM";
			player_positions [4].Text = "LWB";
			player_positions [5].Text = "RWB";
			player_positions [6].Text = "CM";
			player_positions [7].Text = "CLM";
			player_positions [8].Text = "CRM";
			player_positions [9].Text = "CF";
			player_positions [10].Text = "CF";

		}

		public void SAVE_ALL (TextView [] player_position, EditText [] player_name, EditText team_name) {

			//set path
			string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "lineup-db.db3");

			//check if path already exists
			bool exists = File.Exists (dbPath);

			//string array for each insert
			string [] sql_commands = new string [11];

			//push insert commands for each player to string array
			for (int i = 0; i< 11; i++) {

				sql_commands [i] = "INSERT INTO [players_table] ([team], [name], [position]) VALUES (" + "'" + team_name.Text + "'" + ", " + "'" + player_name [i].Text + "'" + ", " + "'" + player_position [i].Text + "')";
			
			}

			//if doesnt exists create db in path
			if (!exists) {

				//create database
				Mono.Data.Sqlite.SqliteConnection.CreateFile (dbPath);
				connection = new SqliteConnection ("Data Source=" + dbPath);


				//when db is created, create two tables, one for the players (team, name, team), and one for teams (team)
				var commands = new [] {

					"CREATE TABLE [players_table] (team ntext, name ntext, position ntext);",
					sql_commands[0], sql_commands[1], sql_commands[2], 
					sql_commands[3], sql_commands[4], sql_commands[5],
					sql_commands[6], sql_commands[7], sql_commands[8], 
					sql_commands[9], sql_commands[10]

				};

				//open connection
				connection.Open ();

				//insert commands
				foreach (var command in commands) {

					using (var c = connection.CreateCommand ()) {

						c.CommandText = command;
						var rowCount = c.ExecuteNonQuery ();
						Console.WriteLine ("\tExecuted " + command);

					}
				}

				//db already exists
			} else {

				Console.WriteLine ("Database already exists!");

				connection = new SqliteConnection ("Data Source=" + dbPath);

				connection.Open ();

				//just insert new elements into table
				var commands = new [] {

					sql_commands[0], sql_commands[1], sql_commands[2], 
					sql_commands[3], sql_commands[4], sql_commands[5],
					sql_commands[6], sql_commands[7], sql_commands[8], 
					sql_commands[9], sql_commands[10]

				};

				//insert commands
				foreach (var command in commands) {

					using (var c = connection.CreateCommand ()) {

						c.CommandText = command;
						var rowCount = c.ExecuteNonQuery ();
						Console.WriteLine ("\tExecuted " + command);

					}
				}

			}

			connection.Close ();

		}

	}
}
