using Godot;
using NLog.Targets;
using System;


/// <summary>
/// The Horizontal Split container that gorupss the scoreand the timer 
/// together
/// </summary>
public partial class ScoreandTime : HSplitContainer
{
    // Called when the node enters the scene tree for the first time.
     
    public override void _Ready()
	{
         
    }
    /// <summary>
    /// Checks if the camera moves and moves
    /// </summary>
    /// <param name="delta"></param>
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        if ((World.Camera != null) && ((World.Camera.Position.X ) > 0)) 
        {
            Position = new(World.Camera.Position.X  , 0);
            
            World.HslSpeed.Position= new(World.Camera.Position.X+this.Size.X+100, this.Position.Y);
        }
    }
}
