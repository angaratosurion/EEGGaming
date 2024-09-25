using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using System;
using System.Linq;
/// <summary>
/// Adds a new user
/// </summary>
public partial class AddUserDetails : Control
{/// <summary>
 /// Called when the node enters the scene tree for the first time.
 ///  
 /// </summary>
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

		Button btnCancel = (Button)this.FindChild("btnCancel",true);
			 
		btnCancel.Pressed += BtnCancel_Pressed;
		Button btnCreateNewUser= (Button)this.FindChild("btnCreate", true);
		btnCreateNewUser.Pressed += BtnCreateNewUser_Pressed;
		;
	}
	/// <summary>
	/// called when the create new user button is pressed and adds the 
	/// new user to te database
	/// </summary>
	private void BtnCreateNewUser_Pressed()
	{
		LineEdit txtAge = (LineEdit)this.FindChild("txtAge",true);
		OptionButton optEducation = (OptionButton)this.FindChild("optEducation",true);
		OptionButton optSex= (OptionButton)this.FindChild("optionSex",true);
		LineEdit txtName = (LineEdit)this.FindChild("txtName", true);
		User user = new User();
		user.Age = Convert.ToInt32(txtAge.Text);
		user.Education=optEducation.Text;
		user.Sex = optSex.Text;
		user.Name=txtName.Text;
		
		UserManager userManager = new UserManager();
		userManager.CreateDatabase();
		userManager.AddNew(user);
		GD.Print(userManager.DbContext.Users.ToArray().Length);
		this.Hide();

	}
    /// <summary>
    /// Closes the window
    /// </summary>
    private void BtnCancel_Pressed()
	{
		this.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
