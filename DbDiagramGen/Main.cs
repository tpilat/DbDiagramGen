using DbDiagramGen.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace DbDiagramGen
{
	public class Main
	{
		private bool m_ShowFullMenus = false;

		//Called Before EA starts to check Add-In Exists
		public String EA_Connect(EA.Repository Repository)
		{
			//No special processing required.
			return "DbDiagramGen";
		}

		//Called when user Click Add-Ins Menu item from within EA.
		//Populates the Menu with our desired selections.
		public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
		{
			EA.Package aPackage = Repository.GetTreeSelectedPackage();
			switch (MenuName)
			{
				case "":
					return "-&DbDiagramGen";
				case "-&DbDiagramGen":
					string[] ar = { "&Generate", "About..." };
					return ar;
			}
			return "";
		}

		//Sets the state of the menu depending if there is an active project or not
		bool IsProjectOpen(EA.Repository Repository)
		{
			try
			{
				EA.Collection c = Repository.Models;
				return true;
			}
			catch
			{
				return false;
			}
		}

		//Called once Menu has been opened to see what menu items are active.
		public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
		{
			if (IsProjectOpen(Repository))
			{
				if (ItemName == "&Generate")
					IsChecked = m_ShowFullMenus;
				else if (ItemName == "Menu2")
					IsEnabled = m_ShowFullMenus;
			}
			else
				// If no open project, disable all menu options
				IsEnabled = false;
		}

		private EA.Package GetCurrentPackage(EA.Repository repository)
		{
			EA.Package selectedEAPackage = repository.GetTreeSelectedPackage();
			return selectedEAPackage;
		}

		private EA.Package GetCurrentModelPackage(EA.Repository repository)
		{
			EA.Package selectedEAPackage = GetCurrentPackage(repository);
			return GetModel(repository, selectedEAPackage);
		}

		private EA.Package GetModel(EA.Repository repository, EA.Package package)
		{
			if (package.ParentID == 0)
				return package;

			return GetModel(repository, repository.GetPackageByID(package.ParentID));
		}

		//Called when user makes a selection in the menu.
		//This is your main exit point to the rest of your Add-in
		public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
		{
			EA.Package selectedEAPackage = GetCurrentPackage(Repository);
			//if (selectedEAPackage.ParentID != 0)
			//{
			//	MessageBox.Show("no Model selected. In Project Browser select model and try again.", "Model");
			//	return;
			//}

			switch (ItemName)
			{
				case "&Generate":
					var gf = new MainForm(Repository);

					gf.ShowDialog();
					break;
				case "About...":
					EA.Package eap = GetCurrentModelPackage(Repository);
					if (eap.ParentID != 0)
					{
						MessageBox.Show("no Model selected. In Project Browser select model and try again.", "Model");
						break;
					}

					var aboutForm = new AboutForm();
					aboutForm.ShowDialog();
					break;
			}
		}

		private void ReadPackage(EA.Package package, string packagesPath)
		{
			if (package != null)
			{
				foreach (var p in package.Packages)
				{
					EA.Package eap = p as EA.Package;
					ReadPackage(eap, packagesPath + " >> " + eap.Name);
				}
			}
			else
			{
				Console.WriteLine(packagesPath);
			}
		}
	}
}




