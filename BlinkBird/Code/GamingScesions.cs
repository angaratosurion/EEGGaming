using CsvHelper.Expressions;
using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using EEGGaming.Core.Tools;
using Godot;
using System;
using System.Collections.Generic;
using System.IO;

public partial class GamingScesions : Window
{
	// Called when the node enters the scene tree for the first time.
	Button btnDelete, btnExportToCSV, btnMakeGraphs, btnClose, btnImportCSV;
	FileDialog OpenFileDialog;

    const string Graphsdir = "Graphs",CSVdir="CSV";
	ItemList lstGamingsessions;
	GamingSesion gamingSesion;
	string filename;
	public override void _Ready()
	{
		if (Menu.SelectedUser != null)
		{
			 btnDelete = (Button)this.FindChild("btnDelete", true);
			btnExportToCSV = (Button)this.FindChild("btnExportToCSV", true);
			btnMakeGraphs = (Button)this.FindChild("btnMakeGraphs", true);
			btnClose = (Button)this.FindChild("btnClose", true);
			btnClose.Pressed += BtnClose_Pressed;
			btnExportToCSV.Pressed += BtnExportToCSV_Pressed;
			btnMakeGraphs.Pressed += BtnMakeGraphs_Pressed;
			btnDelete.Pressed += BtnDelete_Pressed;
			 lstGamingsessions = (ItemList)this.FindChild("lstGamingsessions", true);
			btnImportCSV = (Button)this.FindChild("btnImportCSV");
            btnImportCSV.Pressed += BtnImportCSV_Pressed;
			OpenFileDialog =(FileDialog) this.FindChild("OpenFileDialog");
            OpenFileDialog.FileSelected += OpenFileDialog_FileSelected;
            var sessions = Menu.gamingSesionManager.ListasViewModel();
			if (sessions != null)
			{
				foreach (var session in sessions)
				{
					String tex = String.Format("{0} - {1} - {2} - {3} - {4}  ", session.Id, session.UserName,session.Start, session.End,  session.Score);
					lstGamingsessions.AddItem(tex);
				}
			}
			lstGamingsessions.ItemSelected += LstGamingsessions_ItemSelected;
		}
	}

    private void OpenFileDialog_FileSelected(string path)
    {
		filename = path;
    }

    private void BtnImportCSV_Pressed()
    {
		OpenFileDialog.Show();
		
        GD.Print("FILENAME:" + filename);
        GD.Print("Gaming Sesion id:" + Convert.ToString(this.gamingSesion.Id));
        GD.Print("User id:" + this.gamingSesion.User);
        
        if (filename != null)
		{
			Menu.recordManager.LoadCsv(filename);
            GD.Print("Recs count :" + Menu.recordManager.Records.Count);
            if ( this.gamingSesion!=null)
			{
				Menu.recordManager.ActiveGamingSessionId = this.gamingSesion.Id;
				Menu.recordManager.ActiveUserId = this.gamingSesion.User;
				Menu.recordManager.SavetoDatabse();
			}

		}
		
    }

    private void LstGamingsessions_ItemSelected(long index)
	{
		int[] selecteditem = this.lstGamingsessions.GetSelectedItems();
		if (selecteditem != null)
		{
			string seltex = lstGamingsessions.GetItemText(selecteditem[0]);
			string[] text = seltex.Split("-");
			string username = text[1];

			GD.Print(username);
			if (Menu.gamingSesionManager == null)
			{
				Menu.gamingSesionManager = new GamingSesionManager();
			}
			
				int id = int.Parse(text[0]);
			   GamingSesion sesion = Menu.gamingSesionManager.Get(id);
				GD.Print(text[0]);
				//GD.Print(user.Name);
				this.gamingSesion=sesion;
		   

			
		}
	}

	private void BtnClose_Pressed()
	{
		this.Hide();
	}

	private void BtnMakeGraphs_Pressed()
	{
		string filename, folder ,tfilename;
		//CommonTools.GetAppRootDataFolderAbsolutePath()
		folder = Path.Combine(CommonTools.GetAppRootDataFolderAbsolutePath(), Graphsdir);
		if (!Directory.Exists(folder))
		{
			Directory.CreateDirectory(folder);

		}
		tfilename =  DateTime.Now.ToString().Replace("/", "-");
		tfilename = tfilename.Replace(":", ".");
		filename =Path.Combine(folder, tfilename);

		Menu.recordManager.GetBrainwavesFromDBByGamingSessionId(gamingSesion.Id);
		

		Menu.recordManager.MakeGraphs(filename); 

	}

	private void BtnExportToCSV_Pressed()
	{
		string path = Path.Combine(CommonTools.GetAppRootDataFolderAbsolutePath(),CSVdir);
		string filename = DateTime.Now.ToString().Replace("/", "-") + ".csv";
		filename = filename.Replace(":", ".");
		Menu.recordManager.GetBrainwavesFromDBByGamingSessionId(gamingSesion.Id);
		Menu.recordManager.SaveToCSV(Path.Combine(path, filename));

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	  


	}
	private void BtnDelete_Pressed()
	{

		Menu.gamingSesionManager.Delete(gamingSesion.Id);
	}
}
