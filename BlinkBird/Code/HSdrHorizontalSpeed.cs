using Godot;
using System;

public partial class HSdrHorizontalSpeed : HSlider
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        GD.Print(this.Name);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if ((World.Camera != null) && ((World.Camera.Position.X) > 0)) 
        {
            Position = new(World.Camera.Position.X, 0);
        }
    }
}
