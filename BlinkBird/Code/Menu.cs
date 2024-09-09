using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using System;
using System.Threading;

public partial class Menu : Control
{
	// Called when the node enters the scene tree for the first time.
	PackedScene newGamepackedScene,NewUserDetailsPackedScene,SelectUserScene,AboutScene,ShowusersScene;
	Button btnNewGame;
	public static BrainWaveRecordManager recordManager = new BrainWaveRecordManager();
	public static GamingSesionManager gamingSesionManager = new GamingSesionManager();
	public static UserManager userManager = new UserManager();

	public static User SelectedUser = null;// new User();
	bool ignoreUserselectionandconstateofdevice = false;
    public static  void SaveDataToDb()
    {
        if (World.gamingSesion != null)
        {
            World.gamingSesion.Score = World.Score;
             gamingSesionManager.Update(World.gamingSesion);
            recordManager.StopAndSavetoDatabse();
        }
    }
    public override void _Ready()
	{
		//Label appname=this.GetNode<Label>("lblAppName");
		//appname.Size = new Vector2(1000, 1000);
		BaseManager bm= new BaseManager();
		bm.CreateDatabase();
		var t = bm.DbContext.Database.ProviderName;
		GD.Print(t);
		  btnNewGame = (Button)this.FindChild("btnNewGame");
		GD.Print(btnNewGame.Name);
		btnNewGame.Pressed += bbtnNewGame_pressed;
		Button btnNewuser= (Button)this.FindChild("btnAddNewUser");
		btnNewuser.Pressed += BtnNewuser_Pressed;
		Button btnSelectUser = (Button) this.FindChild("btnSelectUser");
		btnSelectUser.Pressed += BtnSelectUser_Pressed;
		Button btnExit = (Button)this.FindChild("btnExit", true);
		btnExit.Pressed += BtnExit_Pressed;
		Button btnAbout = (Button)this.FindChild("btnAbout", true);
		btnAbout.Pressed += BtnAbout_Pressed;
		Button btnConnectEEGDevice = (Button)this.FindChild("btnConnectEEGDevice", true);
		btnConnectEEGDevice.Pressed += BtnConnectEEGDevice_Pressed;
		Button btnShowUsers = (Button)this.FindChild("btnShowUsers", true);
		btnShowUsers.Pressed += BtnShowUsers_Pressed;



		if ( Menu.SelectedUser ==null)
		{
			btnNewGame.Disabled = true;
			
		}
 	BrainWaveRecordManager.scanner.Start();
		var sensors = BrainWaveRecordManager.scanner.Sensors;
		//while (  sensors.Count == 0)
		//{
		//	BrainWaveRecordManager.scanner.Start();
		//	GD.Print(sensors.Count);
			
		//}

		
		if (  sensors.Count > 0)
		{
			Label lblDeviceName = (Label)this.FindChild("lblDeviceName", true);
			lblDeviceName.Text = sensors[0].Name;
			Label lblDeviceState = (Label)this.FindChild("lblDeviceState", true);
			recordManager.Connect(sensors[0]);
			lblDeviceState.Text = recordManager.Sensor.State.ToString();
			BrainWaveRecordManager.scanner.Stop();

		}




	}

	private void BtnShowUsers_Pressed()
	{
		ShowusersScene = (PackedScene)GD.Load("res://Scenes/ShowUsers.tscn");
		Window control = (Window  )ShowusersScene.Instantiate();
		this.AddSibling(control);
		
	}

	private void BtnConnectEEGDevice_Pressed()
	{
		var sensors = BrainWaveRecordManager.scanner.Sensors;
		BrainWaveRecordManager.scanner.Start();
		Thread.Sleep(1500);
		GD.Print(sensors.Count);
		if (sensors.Count > 0)
		{
			Label lblDeviceName = (Label)this.FindChild("lblDeviceName", true);
			lblDeviceName.Text = sensors[0].Name;
			Label lblDeviceState = (Label)this.FindChild("lblDeviceState", true);
			recordManager.Connect(sensors[0]);
			lblDeviceState.Text = recordManager.Sensor.State.ToString();
			BrainWaveRecordManager.scanner.Stop();
			recordManager.Connect(sensors[0]);
			

		}
	   
		   

		
	}

	private void BtnAbout_Pressed()
	{
		AboutScene = (PackedScene)GD.Load("res://Scenes/About.tscn");
		Node2D control = (Node2D)AboutScene.Instantiate();
		this.AddSibling(control);
		//this.Hide();
	}

	private void BtnExit_Pressed()
	{
		this.Free();
	}

	private void BtnSelectUser_Pressed()
	{
		SelectUserScene = (PackedScene)GD.Load("res://Scenes/ShowUserDetails.tscn");
		Control control = (Control)SelectUserScene.Instantiate();
		this.AddSibling(control);
		//this.Hide();
	}

	private void BtnNewuser_Pressed()
	{
		 NewUserDetailsPackedScene= (PackedScene)GD.Load("res://Scenes/AddUserDetails.tscn");
		Control control = (Control)NewUserDetailsPackedScene.Instantiate();
		this.AddSibling(control);
		//this.Hide();
	}

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
		//if (sensors != null && sensors.Count > 0)
		//{
		//	Label lblDeviceName = (Label)this.FindChild("lblDeviceName", true);
		//	lblDeviceName.Text = sensors[0].Name;
		//	Label lblDeviceState = (Label)this.FindChild("lblDeviceState", true);
		//	recordManager.Connect(sensors[0]);
		//	lblDeviceState.Text = recordManager.Sensor.State.ToString();
  //          BrainWaveRecordManager.scanner.Stop();

  //      }
		//else
		//{
		////	BrainWaveRecordManager.scanner.Stop();
  //      }
	}
	public void bbtnNewGame_pressed()
	{
		newGamepackedScene = (PackedScene)GD.Load("res://Scenes/World.tscn");
		Node2D sprite = (Node2D)newGamepackedScene.Instantiate();
		this.AddSibling(sprite);
		//this.Hide();
		


	}
}
