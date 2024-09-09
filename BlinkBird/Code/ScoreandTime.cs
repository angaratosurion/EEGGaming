using Godot;
using NLog.Targets;
using System;

public partial class ScoreandTime : HSplitContainer
{
    // Called when the node enters the scene tree for the first time.
     
    public override void _Ready()
	{
         
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        if ((World.Camera != null) && ((World.Camera.Position.X ) > 0)) 
        {
            Position = new(World.Camera.Position.X  , 0);
            
            World.HslSpeed.Position= new(World.Camera.Position.X+this.Size.X, this.Position.Y);
        }
    }
}
