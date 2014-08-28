using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Common.Utilities;

namespace R7.MiniGallery
{
	public partial class SettingsMiniGallery : MiniGalleryModuleSettingsBase
	{
		/// <summary>
		/// Handles the loading of the module setting for this control
		/// </summary>
		public override void LoadSettings ()
		{
			try
			{
				if (!IsPostBack)
				{
					// fill columns list
					/*ddlRows.Items.Add (new ListItem (
						Localization.GetString ("Auto.Text", LocalResourceFile), 
						Null.NullInteger.ToString ()));*/

					ddlColumns.Items.Add (new ListItem (
						Localization.GetString ("Auto.Text", LocalResourceFile), 
						Null.NullInteger.ToString ()));

					for (var i = 1; i <= 50; i++)
					{
						// ddlRows.Items.Add (new ListItem (i.ToString ()));
						ddlColumns.Items.Add (new ListItem (i.ToString ()));
					}

					Utils.SelectByValue (ddlColumns, MiniGallerySettings.Columns); 
					/*// row number value have meaning only if columns number is set
					if (MiniGallerySettings.Columns != Null.NullInteger)
						Utils.SelectByValue (ddlRows, MiniGallerySettings.Rows, 0); */
					// Localize ();	
                	
					textImageWidth.Text = MiniGallerySettings.ImageWidth.ToString ();
					textImageHeight.Text = MiniGallerySettings.ImageHeight.ToString ();

					textFrameWidth.Text = MiniGallerySettings.FrameWidth.ToString ();
					textFrameHeight.Text = MiniGallerySettings.FrameHeight.ToString ();

					//textViewerCssClass.Text = settings.ViewerCssClass;
					textStyleSet.Text = MiniGallerySettings.StyleSet;

					textMaxHeight.Text = 
						(MiniGallerySettings.MaxHeight >= 0) ? MiniGallerySettings.MaxHeight.ToString () : string.Empty;

					// 0 = none, 1 = other
					Utils.SelectByValue (ddlTarget, MiniGallerySettings.Target, 1);
					if (ddlTarget.SelectedIndex == 1)
						textTarget.Text = MiniGallerySettings.Target;

					// TODO: realize 
					checkUseViewer.Checked = MiniGallerySettings.UseViewer;
					checkUseScrollbar.Checked = MiniGallerySettings.UseScrollbar;

					checkShowTitles.Checked = MiniGallerySettings.ShowTitles;
					checkExpand.Checked = MiniGallerySettings.ExpandColumns;

					// read text before  / text after
					var module = new ModuleController ().GetTabModule (TabModuleId);
					editorHeader.Text = module.Header;
					editorFooter.Text = module.Footer;
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// handles updating the module settings for this control
		/// </summary>
		public override void UpdateSettings ()
		{
			try
			{
				// style
				MiniGallerySettings.StyleSet = textStyleSet.Text;

				// max. height
				int maxHeight;
				MiniGallerySettings.MaxHeight = int.TryParse (textMaxHeight.Text, out maxHeight) ? maxHeight : -1;

				// parse and store image size
				
				MiniGallerySettings.ImageWidth = Utils.ParseToNullableInt (textImageWidth.Text);
				MiniGallerySettings.ImageHeight = Utils.ParseToNullableInt (textImageHeight.Text);

				if (!string.IsNullOrWhiteSpace(textFrameWidth.Text))
					MiniGallerySettings.FrameWidth = Unit.Parse(textFrameWidth.Text);
				else
					MiniGallerySettings.FrameWidth = Unit.Empty;

				if (!string.IsNullOrWhiteSpace(textFrameHeight.Text))
					MiniGallerySettings.FrameHeight = Unit.Parse(textFrameHeight.Text);
				else
					MiniGallerySettings.FrameHeight = Unit.Empty;

				// MiniGallerySettings.FrameWidth = Utils.ParseToUnit (textImageWidth.Text, 1).ToString ();
				// MiniGallerySettings.FrameHeight = Utils.ParseToUnit (textImageHeight.Text, 1).ToString ();
/*
				try 
				{
					var width = Unit.Parse (textImageWidth.Text);
					if (width.Value <= 0)
						settings.ImageWidth = string.Empty;
					else
						settings.ImageWidth = width.ToString();
				}
				catch 
				{
					settings.ImageWidth = string.Empty;
				}*/

				// link target, 1 = other
				MiniGallerySettings.Target = (ddlTarget.SelectedIndex != 1) ?
					 ddlTarget.SelectedValue : textTarget.Text;

				// columns & rows
				MiniGallerySettings.Columns = int.Parse (ddlColumns.SelectedValue);
				
				// settings.UserScrollbar = checkUseScrollbar.Checked;
				// settings.UseViewer = checkUseViewer.Checked;

				MiniGallerySettings.ShowTitles = checkShowTitles.Checked;
				MiniGallerySettings.ExpandColumns = checkExpand.Checked;

				// store text before / text after
				var mctrl = new ModuleController ();
				var module = mctrl.GetTabModule (TabModuleId);
				module.Header = editorHeader.Text;
				module.Footer = editorFooter.Text;
				mctrl.UpdateModule (module);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
	}
}

