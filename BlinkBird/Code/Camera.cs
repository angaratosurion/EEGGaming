using Godot;
using System;
/// <summary>
///  This class controls the Camera of the Game
/// </summary>
public partial class Camera : Camera2D
{
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	 
	 
    public override void _Ready() 
	{ 
	      
       
        

    }
	/// <summary>
	/// Moves the camera and occurs when the frame is produced
	/// </summary>
	/// <param name="delta"></param>
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) 
	{
		 if ((World.player != null) && ((World.player.Position.X - 1000) > 0) 
			&& (World.player.Position.X>0) &&World.player.Position.X<13800) 
		{
			Position = new((World.player.Position.X-1000), 0);
		}
  
	}
}
