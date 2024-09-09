using Godot;
using System;

public partial class GameOver :Window// Control
{
	// Called when the node enters the scene tree for the first time.
	 
	public override void _Ready()
	{
		Label lblScore = (Label)this.FindChild("lblScore", true);
		lblScore.Text = Convert.ToString(World.Score);
		 
		Node2D mount = this.GetNode<Node2D>("/root/World/Mountains");
		mount.Hide();
		mount.ZIndex = 0;
		//this.ZIndex = 100;
		//GD.Print(mount.Name);
		//this.Position = new Vector2(0, -500);
		GD.Print("rec count " +Menu.recordManager.Records.Count);
		Vector2 winsize = this.GetWindow().Size;
		Menu.recordManager.StopAndSavetoDatabse();
        Menu.recordManager.SavetoDatabse();

        //this.Size = winsize;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
