// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using MyTrips.Model;

namespace MyTrips.iOS
{
	public partial class SettingsDetailViewController : UIViewController
	{
		public Setting Setting { get; set; }

		public SettingsDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			settingsDetailTableView.Source = new SettingsDetailTableViewSource(Setting);
		}
	}

	public class SettingsDetailTableViewSource : UITableViewSource
	{
		Setting setting;

		public SettingsDetailTableViewSource(Setting setting)
		{
			this.setting = setting;
		}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			return setting.Name;
		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			var header = headerView as UITableViewHeaderFooterView;
			header.TextLabel.TextColor = Colors.BLUE;
			header.TextLabel.Font = UIFont.FromName("AvenirNext-Bold", 14);
			header.TextLabel.Text = TitleForHeader(tableView, section);
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			setting.Value = setting.PossibleValues[indexPath.Row];

			var cells = tableView.VisibleCells;
			int i = 0;
			foreach (var cell in cells)
			{
				var value = setting.PossibleValues[i];
				if (setting.Value != value)
				{
					cell.Accessory = UITableViewCellAccessory.None;
				}
				else
				{
					cell.Accessory = UITableViewCellAccessory.Checkmark;
				}

				i++;
			}
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return setting.PossibleValues.Count;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("SETTING__DETAIL_VALUE_CELL") as SettingDetailTableViewCell;

			cell.Name = setting.PossibleValues[indexPath.Row];
			cell.Accessory = UITableViewCellAccessory.None;

			if (cell.Name == setting.Value)
				cell.Accessory = UITableViewCellAccessory.Checkmark;

			return cell;
		}
	}	
}
