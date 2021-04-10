﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace LottoDataManager.Includes.Classes.Reports.Templates.Fragments
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\CSS_Fragment.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class CSS_Fragment : IndividualGameHTMLReportView
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n<!--link rel=\"stylesheet\" href=\"main_style.css\" type=\"text/css\" media=\"all\" -->" +
                    "\r\n<style>\r\n\r\nbody{\r\n    margin: 0px;\r\n}\r\n.report-header{\r\n    width: 100%;\r\n    " +
                    "height: 40px;\r\n    background-color: #354535;\r\n    font-weight: bold;\r\n    color" +
                    ": ghostwhite;\r\n    font-size: 2em;\r\n    text-shadow: 0 2px 2px rgba(0,0,0,.5);\r\n" +
                    "    font-family: -apple-system, BlinkMacSystemFont, \'Segoe UI\', Roboto, Oxygen, " +
                    "Ubuntu, Cantarell, \'Open Sans\', \'Helvetica Neue\', sans-serif;\r\n}\r\n\r\n.dashboard-b" +
                    "ox{\r\n    width: 100%;\r\n    height: 300px;\r\n    background-color: #498aff;\r\n}\r\n.d" +
                    "ashboard-box-content{\r\n    vertical-align: middle;\r\n    /* border: 2px dashed #4" +
                    "44; */\r\n    height: 50%;\r\n    display: flex;\r\n    justify-content: space-between" +
                    ";\r\n    transform: translate(0, 50%);\r\n}\r\n\r\n.dashboard-box-content .title-partiti" +
                    "on{\r\n    /* border: 2px dashed #444; */\r\n    width: 100%;\r\n    height: 100%;\r\n  " +
                    "  vertical-align: middle;\r\n    margin: 0 10px 0 10px;\r\n\r\n}\r\n\r\n.dashboard-box-tit" +
                    "le{\r\n    font-weight: bold;\r\n    color: ghostwhite;\r\n    font-size: 4em;\r\n    te" +
                    "xt-shadow: 0 2px 2px rgba(0,0,0,.5);\r\n    font-family: Impact, Haettenschweiler," +
                    " \'Arial Narrow Bold\', sans-serif;\r\n}\r\n.dashboard-box-sub-title{\r\n    font-size: " +
                    "2em;\r\n    text-shadow: 0 2px 2px rgba(0,0,0,.5);\r\n    color: whitesmoke;\r\n    fo" +
                    "nt-family: \'Trebuchet MS\', \'Lucida Sans Unicode\', \'Lucida Grande\', \'Lucida Sans\'" +
                    ", Arial, sans-serif;\r\n}\r\n\r\n.dashboard-box-sub-title-combine{\r\n    font-size: 1.2" +
                    "em;\r\n    text-shadow: 0 2px 2px rgba(0,0,0,.5);\r\n    color: whitesmoke;\r\n    fon" +
                    "t-family: \'Trebuchet MS\', \'Lucida Sans Unicode\', \'Lucida Grande\', \'Lucida Sans\'," +
                    " Arial, sans-serif;\r\n}\r\n\r\n\r\n\r\n\r\n.dashboard-box-winnings{\r\n    font-weight: bold;" +
                    "\r\n    color: greenyellow;\r\n    font-size: 5em;\r\n    text-shadow: 0 5px 1px rgba(" +
                    "101, 60, 60, 0.5);\r\n    font-family: Impact, Haettenschweiler, \'Arial Narrow Bol" +
                    "d\', sans-serif;\r\n    text-align: center;\r\n}\r\n.dashboard-box-sub-winnings{\r\n    f" +
                    "ont-size: 1.3em;\r\n    font-style: italic;\r\n    text-shadow: 0 2px 2px rgba(0,0,0" +
                    ",.5);\r\n    color: whitesmoke;\r\n    font-family: \'Trebuchet MS\', \'Lucida Sans Uni" +
                    "code\', \'Lucida Grande\', \'Lucida Sans\', Arial, sans-serif;\r\n    text-align: cente" +
                    "r;\r\n}\r\n.page-spacer{\r\n    width:100%;\r\n    height: 500px;\r\n}\r\n.zero-sum-color{\r\n" +
                    "    color: whitesmoke;\r\n}\r\n\r\n\r\n/*\r\n    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n    REPORT BOX CONTENT" +
                    "\r\n*/\r\n.report-box{\r\n    top: 50px;\r\n    font-family: Verdana, Geneva, Tahoma, sa" +
                    "ns-serif;\r\n}\r\n\r\n.outline-container{\r\n    margin: 50px 10px 0px 10px;\r\n}\r\n\r\n.titl" +
                    "e-keyword{\r\n    font-size: 1.5em;\r\n    color: mediumturquoise;\r\n    font-weight:" +
                    " bold;\r\n}\r\n\r\n.title-description{\r\n    color: green;\r\n    font-weight: bold;\r\n}\r\n" +
                    "\r\n.report-box .default-table {\r\n    width: 100%;\r\n    margin: 20px 30px 30px 30p" +
                    "x;\r\n    border: 0px solid black;\r\n}\r\n\r\n.report-box .default-table tr td:first-of" +
                    "-type{\r\n    width: 350px;\r\n    border: 0px solid black;\r\n}\r\n.report-box .default" +
                    "-table td{\r\n    border: 0px solid black;\r\n    vertical-align: top;\r\n}\r\n\r\n.report" +
                    "-box .yearly-tallying{\r\n    border: 2px solid black;\r\n    text-align: left;\r\n   " +
                    " width: 50%;\r\n    \r\n}\r\n\r\n.report-box .table-stats-style{\r\n    table-layout:auto;" +
                    "\r\n    text-align: left;\r\n    margin-left: 30px;\r\n    margin-top: 30px;\r\n}\r\n.tabl" +
                    "e-stats-style tr td{\r\n    border: 2px solid rgb(194, 189, 189);\r\n}\r\n.table-stats" +
                    "-style th{\r\n    border: 2px solid rgb(194, 189, 189);\r\n    background-color:whit" +
                    "esmoke;\r\n}\r\n\r\n.table-stats-style tbody{\r\n    table-layout:auto;\r\n}\r\n\r\n.table-sta" +
                    "ts-style tr td:first-of-type{\r\n    min-width: 50px;\r\n}\r\n\r\n\r\n/*\r\n    ~~~~~~~~~~~~" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                    "~~~~~\r\n    INDIVIDUAL CSS\r\n*/\r\n.claims-details-breakdown{\r\n    margin-bottom: 30" +
                    "px;\r\n}\r\n.claims-details-breakdown span{\r\n    font-weight: bold;\r\n    color: gree" +
                    "n;\r\n}\r\n</style>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
