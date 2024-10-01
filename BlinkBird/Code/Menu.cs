using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using NeuroSDK;
using System;
using System.Threading;

/// <summary>
/// The Main menu of the game
/// </summary>
public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	PackedScene newGamepackedScene,NewUserDetailsPackedScene,SelectUserScene,AboutScene,ShowusersScene;
	Button btnNewGame;
	public static BrainWaveRecordManager recordManager = new BrainWaveRecordManager();
	public static GamingSesionManager gamingSesionManager = new GamingSesionManager();
	public static UserManager userManager = new UserManager();
	Label lblDeviceName, lblDeviceState;

    public static User SelectedUser = null;// new User();
	public static bool ignoreUserselectionandconstateofdevice = false,enabletheuseofhs=true;
	/// <summary>
	/// Save the data to database
	/// </summary>
    public static  void SaveDataToDb()
    {
        if (World.gamingSesion != null)
        {
            World.gamingSesion.Score = World.Score;
             gamingSesionManager.Update(World.gamingSesion);
            recordManager.StopAndSavetoDatabse();
        }
    }
	/// <summary>
	/// Creates the winndow
	/// </summary>
	public override void _Ready()
	{

		BaseManager bm = new BaseManager();
		bm.CreateDatabase();
		var t = bm.DbContext.Database.ProviderName;
		GD.Print(t);
		btnNewGame = (Button)this.FindChild("btnNewGame");
		GD.Print(btnNewGame.Name);
		btnNewGame.Pressed += bbtnNewGame_pressed;
		Button btnNewuser = (Button)this.FindChild("btnAddNewUser");
		btnNewuser.Pressed += BtnNewuser_Pressed;
		Button btnSelectUser = (Button)this.FindChild("btnSelectUser");
		btnSelectUser.Pressed += BtnSelectUser_Pressed;
		Button btnExit = (Button)this.FindChild("btnExit", true);
		btnExit.Pressed += BtnExit_Pressed;
		Button btnAbout = (Button)this.FindChild("btnAbout", true);
		btnAbout.Pressed += BtnAbout_Pressed;
		Button btnConnectEEGDevice = (Button)this.FindChild("btnConnectEEGDevice", true);
		btnConnectEEGDevice.Pressed += BtnConnectEEGDevice_Pressed;
		Button btnShowUsers = (Button)this.FindChild("btnShowUsers", true);
		btnShowUsers.Pressed += BtnShowUsers_Pressed;
		enabletheuseofhs = AppSettingsManager.GetEnableUseOfHeadset();
		HSplitContainer DeviceInfoPanel = (HSplitContainer)this.FindChild("DeviceInfoPanel");

        if (enabletheuseofhs)
		{
			ignoreUserselectionandconstateofdevice = false;
		}
		else
		{
			ignoreUserselectionandconstateofdevice = true;
		}

		GD.Print("Enabled Use of Headset :" + AppSettingsManager.GetEnableUseOfHeadset());

		if (Menu.SelectedUser == null)
		{
			btnNewGame.Disabled = true;

		}
		if (enabletheuseofhs)
		{
			BrainWaveRecordManager.scanner.Start();
			var sensors = BrainWaveRecordManager.scanner.Sensors;
			lblDeviceName = (Label)this.FindChild("lblDeviceName", true);

			lblDeviceState = (Label)this.FindChild("lblDeviceState", true);
			if (sensors.Count > 0)
			{

				lblDeviceName.Text = sensors[0].Name;

				recordManager.Connect(sensors[0]);
				lblDeviceState.Text = recordManager.Sensor.State.ToString();
				BrainWaveRecordManager.scanner.Stop();

			}

			//if (ignoreUserselectionandconstateofdevice)
			//{
			//	lblDeviceName.Text = "BrainBit";
			//	lblDeviceState.Text = SensorState.StateInRange.ToString();

			//}
		}
		else
		{
            btnConnectEEGDevice.Disabled = true;

			DeviceInfoPanel.Hide();

        }




    }
	/// <summary>
	/// This shows the window with all the users 
	/// </summary>
	private void BtnShowUsers_Pressed()
	{
		ShowusersScene = (PackedScene)GD.Load("res://Scenes/ShowUsers.tscn");
		Window control = (Window  )ShowusersScene.Instantiate();
		this.AddSibling(control);
		
	}
	/// <summary>
	/// Connects to the EEG headset
	/// </summary>
	private void BtnConnectEEGDevice_Pressed()
	{
		var sensors = BrainWaveRecordManager.scanner.Sensors;
		BrainWaveRecordManager.scanner.Start();
		Thread.Sleep(1500);
		GD.Print(sensors.Count);
		if (sensors.Count > 0)
		{
			 lblDeviceName = (Label)this.FindChild("lblDeviceName", true);
			lblDeviceName.Text = sensors[0].Name;
			 lblDeviceState = (Label)this.FindChild("lblDeviceState", true);
			recordManager.Connect(sensors[0]);
			lblDeviceState.Text = recordManager.Sensor.State.ToString();
			BrainWaveRecordManager.scanner.Stop();
			recordManager.Connect(sensors[0]);
			if (  ignoreUserselectionandconstateofdevice)
			{
				lblDeviceName.Text = "BrainBit";
                lblDeviceState.Text=SensorState.StateInRange.ToString();	

            }
			

		}
	   
		   

		
	}
	/// <summary>
	/// Shows the About window
	/// </summary>
	private void BtnAbout_Pressed()
	{
		AboutScene = (PackedScene)GD.Load("res://Scenes/About.tscn");
		Node2D control = (Node2D)AboutScene.Instantiate();
		this.AddSibling(control);
		//this.Hide();
	}
	/// <summary>
	/// Cloes the game
	/// </summary>
	private void BtnExit_Pressed()
	{
		this.Free();
	}
	/// <summary>
	/// Shows the user for selection
	/// </summary>
	private void BtnSelectUser_Pressed()
	{
		SelectUserScene = (PackedScene)GD.Load("res://Scenes/ShowUserDetails.tscn");
		Control control = (Control)SelectUserScene.Instantiate();
		this.AddSibling(control);
		//this.Hide();
	}
	/// <summary>
	/// Shwos the new user creation window
	/// </summary>
	private void BtnNewuser_Pressed()
	{
		 NewUserDetailsPackedScene= (PackedScene)GD.Load("res://Scenes/AddUserDetails.tscn");
		Control control = (Control)NewUserDetailsPackedScene.Instantiate();
		this.AddSibling(control);
		 
	}
	/// <summary>
	/// checks whever a user is selected or anEEG headest is conencted
	/// </summary>
	/// <param name="delta"></param>
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if ((SelectedUser == null || BrainWaveRecordManager.scanner.Sensors.Count==0) &&(!ignoreUserselectionandconstateofdevice))
		{
			btnNewGame.Disabled = true;

		}
		else
		{
			btnNewGame.Disabled = false;

		}
		var sensors = BrainWaveRecordManager.scanner.Sensors;
		 
	}
	/// <summary>
	/// Starts  new game 
	/// </summary>
	public void bbtnNewGame_pressed()
	{
		newGamepackedScene = (PackedScene)GD.Load("res://Scenes/World.tscn");
		Node2D sprite = (Node2D)newGamepackedScene.Instantiate();
		this.AddSibling(sprite);
		 
		


	}
}
