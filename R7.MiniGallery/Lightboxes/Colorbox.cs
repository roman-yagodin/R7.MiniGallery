﻿//
// Lightbox.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014-2017
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

using System.Globalization;
using System.Web.UI;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Client;
using DotNetNuke.Web.Client.ClientResourceManagement;
using R7.MiniGallery.Models;

namespace R7.MiniGallery.Lightboxes
{
    public class Colorbox: ILightbox
    {
        public void Register (Page page)
        {
            JavaScript.RequestRegistration ("Colorbox");
            RegisterLocalizationScript (page);

            ClientResourceManager.RegisterScript (page, "~/DesktopModules/MVC/R7.MiniGallery/js/colorbox.min.js");
            ClientResourceManager.RegisterStyleSheet (page, "~/Resources/Libraries/Colorbox/01_06_04/example1/colorbox.css");
        }

        protected void RegisterLocalizationScript (Page page)
        {
            var lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (lang != "en") {
                var library = JavaScriptLibraryController.Instance.GetLibrary (L => L.LibraryName == "Colorbox");
                if (library != null) {
                    ClientResourceManager.RegisterScript (
                        page, $"~/Resources/Libraries/Colorbox/01_06_04/i18n/jquery.colorbox-{GetAvailableScriptLanguageName (lang)}.js",
                        library.PackageID + (int) FileOrder.Js.DefaultPriority + 1,
                        "DnnFormBottomProvider"
                    );
                }
            }
        }

        protected string GetAvailableScriptLanguageName (string lang)
        {
            if (lang == "pt") {
                return "pt-BR";
            }
             
            if (lang == "zh") {
                return "zh-CN";
            }

            return lang;
        }

        public string GetLinkAttributes (IImage image, int moduleId)
        {
            return $"{{\"data-colorbox\":\"gallery-{moduleId}\"}}";
        }
    }
}
