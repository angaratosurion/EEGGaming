using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using System;
using System.Collections.Generic;
/// <summary>
/// Shows the details fo a user
/// </summary>
public partial class ShowUserDetails : Control//Node2D
{
	LineEdit txtAge;
	OptionButton optEducation;

    OptionButton optSex;
	LineEdit txtName;
	OptionButton optUsers;
	UserManager userManager = new UserManager();
	Boolean isInEditMode;
	Button btnEdit;
	PackedScene packedScene;
	// Called when the node enters the scene tree for the first time.
	/// <summary>
	/// Filsl the objects with user's info
	/// </summary>
	public override void _Ready()
	{
		this.isInEditMode = false;
		List<User> lstusers;
		lstusers = userManager.List();
		 optUsers = (OptionButton)this.FindChild("optUser", true);
		

        optUsers.AddItem(" ");
        if ( lstusers != null  && optUsers!=null )
		{
			foreach (User user in lstusers)
			{
				optUsers.AddItem(user.Name);
			}
		}
		optUsers.ItemSelected += OptUsers_ItemSelected;
		Button btnEnableEdit = (Button)this.FindChild("btnEnableEdit", true);
		btnEnableEdit.Pressed += BtnEnableEdit_Pressed;
	 txtAge = (LineEdit)this.FindChild("txtAge", true);
         optEducation = (OptionButton)this.FindChild("optEducation", true);
        optSex = (OptionButton)this.FindChild("optionSex", true);
		 txtName = (LineEdit)this.FindChild("txtName", true);
		Button btnCancel = (Button)this.FindChild("btnCancel", true);

		btnCancel.Pressed += BtnCancel_Pressed;
		//GD.Print(btnCancel.Name);
		btnEdit=(Button)this.FindChild("btnEdit", true);
		btnEdit.Pressed += BtnEdit_Pressed;
		Button btnSelectuser = (Button)this.FindChild("brnSelect",true);
		btnSelectuser.Pressed += BtnSelectuser_Pressed;
		 
		Button btnDelete = (Button)this.FindChild("btnDelete", true);
        btnDelete.Pressed += BtnDelete_Pressed;
		Button btnGamingSessions = (Button)this.FindChild("btnGamingSessions", true);
        btnGamingSessions.Pressed += BtnGamingSessions_Pressed;
		//GD.Print("user" + Menu.SelectedUser.Name);
        if (Menu.SelectedUser != null)
		{ 
			User []userar=  lstusers.ToArray();
			int id = 0;

			for (int i = 0; i < userar.Length; i++)
			{
				if (userar[i].Id == Menu.SelectedUser.Id)
				{
					id = i;
				}
			}
			if ( id==0)
			{
				id = 1;
			}
            optUsers.Select(id);
			//GD.Print("list id"+id);
			this.OptUsers_ItemSelected(id);
        }

    }
	/// <summary>
	/// shows the gaming sessions
	/// </summary>
    private void BtnGamingSessions_Pressed()
    {
        string usernmae = this.optUsers.GetItemText(optUsers.Selected);
        User user = this.userManager.GetUser(usernmae);
        Menu.SelectedUser = user;
        PackedScene ShowusersScene = (PackedScene)GD.Load("res://Scenes/GamingScesions.tscn");
        Window control = (Window)ShowusersScene.Instantiate();
        this.AddSibling(control);
        this.Hide();

    }
	/// <summary>
	/// deletes the slected user
	/// </summary>
    private void BtnDelete_Pressed()
    {
        string usernmae = this.optUsers.GetItemText(optUsers.Selected);
		this.userManager.Delete(usernmae);
		this.Hide();
    }
	/// <summary>
	/// Selects the user
	/// </summary>
    private void BtnSelectuser_Pressed()
	{
		string usernmae = this.optUsers.GetItemText(optUsers.Selected);
		User user = this.userManager.GetUser(usernmae);
		Menu.SelectedUser = user;
		this.Hide();

	}
	/// <summary>
	/// Saves the new info to the database
	/// </summary>
	private void BtnEdit_Pressed()
	{
		string usernmae = this.optUsers.GetItemText(optUsers.Selected);
		User user = this.userManager.GetUser(usernmae);
		user.Name = txtName.Text;
		user.Age = Convert.ToInt32(txtAge.Text);
		user.Sex=optSex.Text;
		user.Education=optEducation.Text;
		this.userManager.Edit(user.Id, user);
		
		this.Hide();

	}
	/// <summary>
	/// cancels and clsoes the window
	/// </summary>
	private void BtnCancel_Pressed()
	{
		//Control mainwin = (Control)this.GetNode<Control>("/root/MainWin");
		//GD.Print(mainwin.Name);
		//mainwin.Show();
		
		this.Hide();
		 
		
		

	}
	/// <summary>
	/// Gives the ability to edit user's info
	/// </summary>
	private void BtnEnableEdit_Pressed()
	{
		this.txtAge.Editable = true;
		//this.optEducation.Editable = true;
		this.txtName.Editable = true;
		this.isInEditMode = true;
		
	}
	/// <summary>
	/// Sets the user to the activeoption
	/// </summary>
	/// <param name="index"></param>
	private void OptUsers_ItemSelected(long index)
	{
		string usernmae=this.optUsers.GetItemText((int)index);
		User use = userManager.GetUser(usernmae);
		if (use != null)
		{
			this.txtName.Text = use.Name;
			 
			this.txtAge.Text = Convert.ToString(use.Age);
			optEducation.Text = use.Education;
			this.optSex.Text = use.Sex;

			
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
