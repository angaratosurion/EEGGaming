using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using ScottPlot.AxisRules;
using System;
using System.Drawing;

public partial class World : Node2D
{
	// Called when the node enters the scene tree for the first time.
	 PackedScene packedScene;
	DateTime started = new DateTime();
	Label lblElapsed, lblScore;
	public const float RAISESCOREBY = (float)(1);
	public static double Score = 0;
	
	public static GamingSesion gamingSesion = new GamingSesion();
	public static Timer  timer;
    public static Mountains Mountains;
	public static Player player;
    //Camera2D camera;
    public static Label speedvalue;
    public static HSlider HslSpeed;
	public static Camera Camera;
    
    private void HSdrHorizontalSpeed_ValueChanged(double value)
    {
         speedvalue.Text = Convert.ToString(HslSpeed.Value);
    }

	
    public override void _Ready()
	{
        Camera = (Camera)this.FindChild("Camera",true);
        packedScene = (PackedScene)GD.Load("res://Scenes/Mountains.tscn");
		TextureRect background = (TextureRect)this.FindChild("Background", true);
         
        player =(Player) this.FindChild("Player", true);
        HslSpeed = (HSlider)this.FindChild("HSdrHorizontalSpeed",true);
        HslSpeed.ValueChanged += HSdrHorizontalSpeed_ValueChanged;
        speedvalue = GetNode<Label>("/root/World/HSdrHorizontalSpeed/lblSpeedPercent");

		GD.Print(Camera.Name);

        if (background != null  )
		{

			Vector2 winsize = this.GetWindow().Size;
			winsize.Y = winsize.Y + 250;
			background.Size = winsize;
             

        }
		
		if (Menu.recordManager.Sensor != null &&
			Menu.recordManager.Sensor.State== NeuroSDK.SensorState.StateInRange)
		{
			started = DateTime.Now;
			
			timer = (Timer)this.FindChild("TmrTimer", true);
			timer.Timeout += Timer_Timeout;
			timer.Start();
			lblElapsed = (Label)this.FindChild("lblElapsed", true);
			lblScore = (Label)this.FindChild("lblScore", true);


			

			gamingSesion.Start = DateTime.Now
	;
			gamingSesion.User = Menu.SelectedUser.Id;
			gamingSesion.Score = 0;
			gamingSesion = Menu.gamingSesionManager.AddGamingSession(gamingSesion);
			Menu.recordManager.ActiveGamingSessionId = gamingSesion.Id;
			

            Menu.recordManager.ActiveUserId = Menu.SelectedUser.Id;
            GD.Print("SESS ID : " + Menu.recordManager.ActiveGamingSessionId);

            GD.Print("USER ID: " + Menu.recordManager.ActiveUserId);
            
			Menu.recordManager.UsesDb = true;
            Menu.recordManager.Start();
           

        }
        Mountains = (Mountains)packedScene.Instantiate();
       // GD.Print("MOUNTINS ADDED");
        this.AddChild(Mountains);
		Mountains.ZIndex = 2;
		speedvalue.Text = Convert.ToString(HslSpeed.Value);






    }
     

    private void Timer_Timeout()
	{
		if (lblElapsed != null)
		{
			TimeSpan timediff = DateTime.Now.Subtract(started);
			lblElapsed.Text = String.Format("{0} : {1} : {2} : {3}",timediff.Hours, timediff.Minutes,timediff.Seconds,timediff.Milliseconds);
			lblScore.Text = Convert.ToString(World.Score);



		}
		 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		




	}
	}


