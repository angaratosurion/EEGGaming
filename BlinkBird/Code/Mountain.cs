using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;
/// <summary>
/// The main obstacle of the avatar
/// </summary>
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

	/// <summary>
	/// It checks whenver the avatar is in the area of the mounntain and 
	/// after it kills the avatar it shows the gameover screen or it increases the 
	/// score
	/// </summary>
	/// <param name="delta"></param>
	
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

				double score = World.Score + (World.RAISESCOREBY / (40 * 30));

				World.Score =  (double)Math.Round(score,3);
			}
		}
	
		

	}

}
