#pragma checksum "C:\Users\FAREED\Desktop\LibaryManagementSystem\libarymanagementsystem\Views\DashBoard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9ee265efa936bc4f48ce8a86126c2ecd0b2e075"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashBoard_Index), @"mvc.1.0.view", @"/Views/DashBoard/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\FAREED\Desktop\LibaryManagementSystem\libarymanagementsystem\Views\_ViewImports.cshtml"
using LibaryManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FAREED\Desktop\LibaryManagementSystem\libarymanagementsystem\Views\_ViewImports.cshtml"
using LibaryManagementSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9ee265efa936bc4f48ce8a86126c2ecd0b2e075", @"/Views/DashBoard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed1e4ea1faf4fc30ffbb1371537647ac3c330429", @"/Views/_ViewImports.cshtml")]
    public class Views_DashBoard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LibaryManagementSystem.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\FAREED\Desktop\LibaryManagementSystem\libarymanagementsystem\Views\DashBoard\Index.cshtml"
  
    Layout = "_DashBoardLayout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FAREED\Desktop\LibaryManagementSystem\libarymanagementsystem\Views\DashBoard\Index.cshtml"
   ViewBag.Title = "DashBoard"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1 class=\"text-center\" style=\"color: blue\">Welcome Manager</h1>\n<br />\n\n");
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LibaryManagementSystem.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591