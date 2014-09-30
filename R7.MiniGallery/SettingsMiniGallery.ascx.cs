//
// SettingsMiniGallery.ascx.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
		protected override void OnInit (EventArgs e)
		{
			base.OnInit (e);
			
			// fill columns combo
			comboColumns.AddItem (LocalizeString ("Auto.Text"), Null.NullInteger.ToString ());

			for (var i = 1; i <= 50; i++)
				comboColumns.AddItem (i.ToString (), i.ToString());

			// fill target combo
			comboTarget.AddItem (LocalizeString ("ddlTargetItemNone.Text"), "none");
			comboTarget.AddItem (LocalizeString ("ddlTargetItemOther.Text"), "other");
			comboTarget.AddItem ("_blank", "_blank");
			comboTarget.AddItem ("_top", "_top");
			comboTarget.AddItem ("_parent", "_parent");
			comboTarget.AddItem ("_self", "_self");

			comboTarget.Select ("_blank", false);
			
			comboLightboxType.AddItem (LocalizeString ("None.Text"), LightboxType.None.ToString());
			comboLightboxType.AddItem (LightboxType.LightBox.ToString(), LightboxType.LightBox.ToString());
			comboLightboxType.AddItem (LightboxType.ColorBox.ToString(), LightboxType.ColorBox.ToString());

			comboLightboxType.SelectedIndex = 0;

		}

		/// <summary>
		/// Handles the loading of the module setting for this control
		/// </summary>
		public override void LoadSettings ()
		{
			try
			{
				if (!IsPostBack)
				{
					comboColumns.Select (MiniGallerySettings.Columns.ToString(), false);

					comboLightboxType.Select (MiniGallerySettings.LightboxType.ToString(), false);

					if (!Null.IsNull (MiniGallerySettings.ThumbWidth))
						textThumbWidth.Text = MiniGallerySettings.ThumbWidth.ToString ();

					if (!Null.IsNull (MiniGallerySettings.ThumbHeight))
						textThumbHeight.Text = MiniGallerySettings.ThumbHeight.ToString ();

					if (!Null.IsNull (MiniGallerySettings.NumberOfRecords))
						textNumberOfRecords.Text = MiniGallerySettings.NumberOfRecords.ToString ();

					textImageHandlerParams.Text = MiniGallerySettings.ImageHandlerParams;

					textImageWidth.Text = MiniGallerySettings.ImageWidth.ToString ();
					textImageHeight.Text = MiniGallerySettings.ImageHeight.ToString ();

					//textViewerCssClass.Text = settings.ViewerCssClass;
					textStyleSet.Text = MiniGallerySettings.StyleSet;

					textMaxHeight.Text = 
						(MiniGallerySettings.MaxHeight >= 0) ? MiniGallerySettings.MaxHeight.ToString () : string.Empty;

					var item = comboTarget.FindItemByValue (MiniGallerySettings.Target);
					if (item != null)
					{
						item.Selected = true;
					}
					else
					{
						comboTarget.SelectedIndex = 1; // other
						textTarget.Text = MiniGallerySettings.Target;
					}

					// DESC sorting done if "-SortIndex" value
					checkSortOrder.Checked = MiniGallerySettings.SortOrder == "SortIndex";
					checkUseScrollbar.Checked = MiniGallerySettings.UseScrollbar;
					checkUseImageHandler.Checked = MiniGallerySettings.UseImageHandler;
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
				
				MiniGallerySettings.ThumbWidth = Utils.TryParseInt32 (textThumbWidth.Text, Null.NullInteger);
				MiniGallerySettings.ThumbHeight = Utils.TryParseInt32 (textThumbHeight.Text, Null.NullInteger);
				
				MiniGallerySettings.NumberOfRecords = Utils.TryParseInt32 (textNumberOfRecords.Text, Null.NullInteger);

				MiniGallerySettings.ImageHandlerParams = textImageHandlerParams.Text;
				
				// MiniGallerySettings.ImageWidth = Utils.ParseToUnit (textImageWidth.Text, 1);
				// MiniGallerySettings.ImageHeight = Utils.ParseToUnit (textImageHeight.Text, 1);

				if (!string.IsNullOrWhiteSpace(textImageWidth.Text))
					MiniGallerySettings.ImageWidth = Unit.Parse(textImageWidth.Text);
				else
					MiniGallerySettings.ImageWidth = Unit.Empty;

				if (!string.IsNullOrWhiteSpace(textImageHeight.Text))
					MiniGallerySettings.ImageHeight = Unit.Parse(textImageHeight.Text);
				else
					MiniGallerySettings.ImageHeight = Unit.Empty;

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
				MiniGallerySettings.Target = (comboTarget.SelectedIndex != 1) ?
					 comboTarget.SelectedValue : textTarget.Text;

				// columns & rows
				MiniGallerySettings.Columns = int.Parse (comboColumns.SelectedValue);

				MiniGallerySettings.LightboxType = (LightboxType)Enum.Parse (typeof(LightboxType), comboLightboxType.SelectedValue);

				MiniGallerySettings.SortOrder = checkSortOrder.Checked? "SortIndex" : "-SortIndex";
				MiniGallerySettings.UseScrollbar = checkUseScrollbar.Checked;
				MiniGallerySettings.ShowTitles = checkShowTitles.Checked;
				MiniGallerySettings.ExpandColumns = checkExpand.Checked;
				MiniGallerySettings.UseImageHandler = checkUseImageHandler.Checked;

				// store text before / text after
				var mctrl = new ModuleController ();
				var module = mctrl.GetTabModule (TabModuleId);
				module.Header = editorHeader.Text;
				module.Footer = editorFooter.Text;
				mctrl.UpdateModule (module);

				Utils.SynchronizeModule (this);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
	}
}

