using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class Mountain : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
  public	PackedScene packedScene { get; set; }
	
	public override void _Ready()
	{
		//timer = World.timer;// (Timer)this.GetNode<Timer>("/root/World/TmrTimer");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	//Timer timer;
	
    public override void _Process(double delta)
	{
		
		
		if (World.player != null && World.player.Visible==true)
		{
			if (GetRect().HasPoint(ToLocal(World.player.Position)) && World.timer!=null)
            {

                World.player.Hide();
                this.packedScene = (PackedScene)GD.Load("res://Scenes/GameOver.tscn");
                Window sprite = (Window)this.packedScene.Instantiate();


                this.AddSibling(sprite);

                World.timer.Stop();

				Menu.SaveDataToDb();

                this.Hide();
               this.Free();


            } else if ( GetRect().End.X<= World.player.Position.X)
			{
				//GD.Print("mountain x: "+GetRect().End.X);
				//            GD.Print("player x: " + player.Position.X);
				double score = World.Score + (World.RAISESCOREBY / (40 * 30));// *1000);

				World.Score =  (double)Math.Round(score,3);
			}
		}
	
		

	}

}
