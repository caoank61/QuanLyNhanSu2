//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Edit_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Edit_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
  
    ViewBag.Title = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
DefineSection("scripts", () => {

});


#line 3 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
using (Html.BeginForm())
{
    

#line default
#line hidden

#line 4 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
__o = Html.AntiForgeryToken();


#line default
#line hidden

#line 5 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
                            
    
    

#line default
#line hidden

#line 6 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
   __o = Html.ValidationSummary(true, "", new { @class = "text-danger" });


#line default
#line hidden

#line 7 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
   __o = Html.HiddenFor(model => model.IdCC);


#line default
#line hidden

#line 8 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
       __o = Html.LabelFor(model => model.NgayChamCong, htmlAttributes: new { @class = "control-label col-md-2" });


#line default
#line hidden

#line 9 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
           __o = Html.EditorFor(model => model.NgayChamCong, new { htmlAttributes = new { @class = "form-control" } });


#line default
#line hidden

#line 10 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
           __o = Html.ValidationMessageFor(model => model.NgayChamCong, "", new { @class = "text-danger" });


#line default
#line hidden

#line 11 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
       __o = Html.LabelFor(model => model.IdNV, "IdNV", htmlAttributes: new { @class = "control-label col-md-2" });


#line default
#line hidden

#line 12 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
           __o = Html.DropDownList("IdNV", null, htmlAttributes: new { @class = "form-control" });


#line default
#line hidden

#line 13 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
           __o = Html.ValidationMessageFor(model => model.IdNV, "", new { @class = "text-danger" });


#line default
#line hidden

#line 14 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
          
}

#line de                    __o = Url.Action("Index","ChamCongs");


#line default
#line hidden

#line 15 "C:\Users\ASUS\AppData\Local\Temp\0E98AC741E019D68503D515728FB28527F1C\4\QuanLyNhanSu\Views\ChamCongs\Edit.cshtml"
fault
#line hidden

#line 15 "C:\Users\ASUS
#line hidden
}
}
}
