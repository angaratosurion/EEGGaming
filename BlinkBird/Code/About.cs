using EEGGaming.Core.Tools;
using Godot;
using System;
/// <summary>
/// This is the window that shows the info about the app
/// </summary>
// Called when the node enters the scene tree for the first time.
public partial class About : Node2D
{
	/// <summary>
	/// Executes when the node isready andfills the info in the window
	/// </summary>
	public override void _Ready()
	{
		Label lblAppNameAndVersion = (Label)this.FindChild("lblAppNameAndVersion", true);
		GD.Print("fff"+CommonTools.GetBlinkBirdbVersion());
		lblAppNameAndVersion.Text += CommonTools.GetBlinkBirdbVersion();
		Label lblCoreVersion = (Label)this.FindChild("lblCoreVersion", true);
		lblCoreVersion.Text= CommonTools.GetEEGGamingCoreVersion();
		Label lblCoreCopyright = (Label)this.FindChild("lblCoreCopyRight", true);
		lblCoreCopyright.Text = CommonTools.GetEEGGamingCoreCopyright();
		Label lblDeveloper = (Label)this.FindChild("lblCoreDeveloper", true);
		lblDeveloper.Text=CommonTools.GetEEGGamingCoreDeveloper();
		
		Label lblCoreLastModified = (Label)this.FindChild("lblCoreLastModified", true);
		lblCoreLastModified.Text= CommonTools.GetEEGGamingCoreLastModifiedDateUTC();
		
		Button btnClose = (Button)this.FindChild("btnClose", true);
		btnClose.Pressed += BtnClose_Pressed;


	}
	/// <summary>
	/// Closes the window
	/// </summary>
	private void BtnClose_Pressed()
	{
		this.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
