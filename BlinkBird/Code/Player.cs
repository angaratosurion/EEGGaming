using EEGGaming.Core.Managers;
using Godot;
using System;
using System.Diagnostics.Eventing.Reader;

public partial class Player : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public const float YMOVEMENT = (0.025f)*16;  
    public const float XMOVEMENT = (0.025f)  ;  
     
    PackedScene packedScene;
	
	public override void _Ready()
	{
		 
	}

	 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
        if (this.Position.Y >=0 && World.HslSpeed!=null)
		{
			

			this.Position += new Vector2(+XMOVEMENT * (float)World.HslSpeed.Value, +0);
			if (Menu.recordManager.Blinked)
			{
				this.Position += new Vector2(+0, -YMOVEMENT ); 

				//GD.Print("blinked");
			}
			if (Input.IsKeyPressed(Key.Space))
			{

				this.Position += new Vector2(+0, -YMOVEMENT);
			}
			else
			{
				this.Position += new Vector2(+0, +YMOVEMENT / 8);
			}
			
		}
		else
		{
            this.Position += new Vector2(+0, +(YMOVEMENT / 8) );
        }
		if( this.Position.X> 14000  ) ///14832
		{
            this.Hide();
            packedScene = (PackedScene)GD.Load("res://Scenes/GameOver.tscn");
            Window sprite = (Window)packedScene.Instantiate();


            this.AddSibling(sprite);
			if (World.timer != null)
			{
				World.timer.Stop();
			}

            Menu.SaveDataToDb();
            this.Hide();
            //this.Free();
			//World.Mountains.Free();

        }

    




	}
}

