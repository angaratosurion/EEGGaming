using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using Godot;
using System;

public partial class ShowUsers : Window
{
    // Called when the node enters the scene tree for the first time.
    ItemList lstUser;
	Button btnShowUserDetails, btnAddNew, btnCancel;
    PackedScene   NewUserDetailsPackedScene, SelectUserScene ;

    public override void _Ready()
    {
        lstUser = (ItemList)this.FindChild("lstUsers", true);
        btnShowUserDetails = (Button)this.FindChild("btnShowUserDetails", true);
        btnAddNew = (Button)this.FindChild("btnAddNew", true);
        btnCancel = (Button)this.FindChild("btnCancel", true);
        var users = Menu.userManager.List();
        if (users != null && users.Count > 0)
        {
            foreach (var user in users)
            {
                String tex = String.Format("{0} - {1} - {2} - {3} - {4} ", user.Id, user.Name, user.Sex, user.Age, user.Education);

                lstUser.AddItem(tex);


            }
        }
        lstUser.ItemSelected += LstUser_ItemSelected;
        btnShowUserDetails.Pressed += BtnShowUserDetails_Pressed;
        btnAddNew.Pressed += BtnAddNew_Pressed;
        btnCancel.Pressed += BtnCancel_Pressed;


    }

    private void BtnCancel_Pressed()
    {
        this.Hide();
    }

    private void BtnAddNew_Pressed()
    {
        NewUserDetailsPackedScene = (PackedScene)GD.Load("res://Scenes/AddUserDetails.tscn");
        Control control = (Control)NewUserDetailsPackedScene.Instantiate();
        this.AddSibling(control);
        this.Hide();
    }

    private void BtnShowUserDetails_Pressed()
    {
        SelectUserScene = (PackedScene)GD.Load("res://Scenes/ShowUserDetails.tscn");
        Control control = (Control)SelectUserScene.Instantiate();
        this.AddSibling(control);
        this.Hide();
        
    }

    private void LstUser_ItemSelected(long index)
	{

		int[] selecteditem = this.lstUser.GetSelectedItems();
		if(selecteditem !=null)
		{
			string seltex=lstUser.GetItemText(selecteditem[0]);
            string[] text =   seltex.Split("-");
            string username = text[1];
           
			GD.Print(username);
            if ( Menu.userManager==null)
            {
                Menu.userManager = new  UserManager();
            }
			User user=Menu.userManager.GetUser(username);
            if (user != null)
            {


                GD.Print(user.Name);
                Menu.SelectedUser = user;
            }
            else
            {
                int id= int.Parse(text[0]);
                user = Menu.userManager.GetUser(id);
                GD.Print(text[0]);
                //GD.Print(user.Name);
                Menu.SelectedUser = user;
                GD.Print(Menu.SelectedUser);

            }
		}

    }
    

     

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
