﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace LottoDataManager.Includes.Classes.Reports.Templates.Fragments.ReportBox
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WinningBetTally_Fragment : IndividualGameHTMLReportView
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("<div class=\"outline-container\">\r\n    <div class=\"outline-title\">\r\n        <span c" +
                    "lass=\"title-keyword\">");
            
            #line 4 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LBL("pal_form_labels_rpt_box_tally_win_bet_1")));
            
            #line default
            #line hidden
            this.Write("</span>\r\n        <span class=\"title-description\">");
            
            #line 5 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LBL("pal_form_labels_rpt_box_tally_win_bet_2")));
            
            #line default
            #line hidden
            this.Write("</span>\r\n    </div>\r\n    <div class=\"outline-content\">\r\n        <table class=\"tab" +
                    "le-stats-style\" cellspacing=\"0\">\r\n            <thead>\r\n                <th>");
            
            #line 10 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LBL("pal_form_labels_rpt_box_tally_win_bet_3")));
            
            #line default
            #line hidden
            this.Write("</th>\r\n                <th>");
            
            #line 11 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(LBL("pal_form_labels_rpt_box_tally_win_bet_4")));
            
            #line default
            #line hidden
            this.Write("</th>\r\n            </thead>\r\n            <tbody>\r\n                ");
            
            #line 14 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
 foreach (var item in ProfitAndLossReport.AllBetsInTabularModeWinningBet) { 
            
            #line default
            #line hidden
            this.Write("                     <tr>\r\n                        <td>");
            
            #line 16 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[0]));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                        <td>");
            
            #line 17 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[1]));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                    </tr>\r\n                ");
            
            #line 19 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox\WinningBetTally_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}