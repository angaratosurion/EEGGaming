using Godot;
using System;

public partial class Camera : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	 
	 
    public override void _Ready() 
	{ 
	      
       
        

    }

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
