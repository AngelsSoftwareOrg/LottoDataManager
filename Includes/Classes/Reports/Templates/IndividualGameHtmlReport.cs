﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace LottoDataManager.Includes.Classes.Reports.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using LottoDataManager.Includes.Model.Details;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\IndividualGameHtmlReport.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class IndividualGameHtmlReport : IndividualGameHTMLReportView
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n\r\n\r\n");
            this.Write("\r\n<!DOCTYPE html>\r\n<html>\r\n    <head>\r\n        <meta charset=\'utf-8\'>\r\n        <m" +
                    "eta http-equiv=\'X-UA-Compatible\'>\r\n        <meta name=\'viewport\' content=\'width=" +
                    "device-width, initial-scale=1\'>\r\n\r\n        <title> Lottery Report </title>\r\n    " +
                    "    ");
            this.Write("\r\n<!--link rel=\"stylesheet\" href=\"main_style.css\" type=\"text/css\" media=\"all\" -->" +
                    "\r\n<style>\r\n\r\nbody{\r\n    margin: 0px;\r\n}\r\n\r\n.dashboard-box{\r\n    width: 100%;\r\n  " +
                    "  height: 300px;\r\n    background-color: cornflowerblue;\r\n}\r\n.dashboard-box-conte" +
                    "nt{\r\n    vertical-align: middle;\r\n    /* border: 2px dashed #444; */\r\n    height" +
                    ": 50%;\r\n    display: flex;\r\n    justify-content: space-between;\r\n    transform: " +
                    "translate(0, 50%);\r\n}\r\n\r\n.dashboard-box-content .title-partition{\r\n    /* border" +
                    ": 2px dashed #444; */\r\n    width: 100%;\r\n    height: 100%;\r\n    vertical-align: " +
                    "middle;\r\n    margin: 0 10px 0 10px;\r\n\r\n}\r\n\r\n.dashboard-box-title{\r\n    font-weig" +
                    "ht: bold;\r\n    color: ghostwhite;\r\n    font-size: 4em;\r\n    text-shadow: 0 2px 2" +
                    "px rgba(0,0,0,.5);\r\n    font-family: Impact, Haettenschweiler, \'Arial Narrow Bol" +
                    "d\', sans-serif;\r\n}\r\n.dashboard-box-sub-title{\r\n    font-size: 2em;\r\n    text-sha" +
                    "dow: 0 2px 2px rgba(0,0,0,.5);\r\n    color: whitesmoke;\r\n    font-family: \'Trebuc" +
                    "het MS\', \'Lucida Sans Unicode\', \'Lucida Grande\', \'Lucida Sans\', Arial, sans-seri" +
                    "f;\r\n}\r\n\r\n.dashboard-box-sub-title-combine{\r\n    font-size: 1.2em;\r\n    text-shad" +
                    "ow: 0 2px 2px rgba(0,0,0,.5);\r\n    color: whitesmoke;\r\n    font-family: \'Trebuch" +
                    "et MS\', \'Lucida Sans Unicode\', \'Lucida Grande\', \'Lucida Sans\', Arial, sans-serif" +
                    ";\r\n}\r\n\r\n\r\n\r\n\r\n.dashboard-box-winnings{\r\n    font-weight: bold;\r\n    color: green" +
                    "yellow;\r\n    font-size: 5em;\r\n    text-shadow: 0 5px 1px rgba(101, 60, 60, 0.5);" +
                    "\r\n    font-family: Impact, Haettenschweiler, \'Arial Narrow Bold\', sans-serif;\r\n " +
                    "   text-align: center;\r\n}\r\n.dashboard-box-sub-winnings{\r\n    font-size: 1.3em;\r\n" +
                    "    font-style: italic;\r\n    text-shadow: 0 2px 2px rgba(0,0,0,.5);\r\n    color: " +
                    "whitesmoke;\r\n    font-family: \'Trebuchet MS\', \'Lucida Sans Unicode\', \'Lucida Gra" +
                    "nde\', \'Lucida Sans\', Arial, sans-serif;\r\n    text-align: center;\r\n}\r\n.page-space" +
                    "r{\r\n    width:100%;\r\n    height: 500px;\r\n}\r\n.zero-sum-color{\r\n    color: whitesm" +
                    "oke;\r\n}\r\n\r\n\r\n/*\r\n    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n    REPORT BOX CONTENT\r\n*/\r\n.report-box{" +
                    "\r\n    top: 50px;\r\n    font-family: Verdana, Geneva, Tahoma, sans-serif;\r\n}\r\n\r\n.o" +
                    "utline-container{\r\n    margin: 50px 10px 0px 10px;\r\n}\r\n\r\n.title-keyword{\r\n    fo" +
                    "nt-size: 1.5em;\r\n    color: mediumturquoise;\r\n    font-weight: bold;\r\n}\r\n\r\n.titl" +
                    "e-description{\r\n    color: green;\r\n    font-weight: bold;\r\n}\r\n\r\n.report-box .def" +
                    "ault-table {\r\n    width: 100%;\r\n    margin: 20px 30px 30px 30px;\r\n    border: 0p" +
                    "x solid black;\r\n}\r\n\r\n.report-box .default-table tr td:first-of-type{\r\n    width:" +
                    " 350px;\r\n    border: 0px solid black;\r\n}\r\n.report-box .default-table td{\r\n    bo" +
                    "rder: 0px solid black;\r\n    vertical-align: top;\r\n}\r\n\r\n.report-box .yearly-tally" +
                    "ing{\r\n    border: 2px solid black;\r\n    text-align: left;\r\n    width: 50%;\r\n    " +
                    "\r\n}\r\n\r\n.report-box .table-stats-style{\r\n    table-layout:auto;\r\n    text-align: " +
                    "left;\r\n    margin-left: 30px;\r\n    margin-top: 30px;\r\n}\r\n.table-stats-style tr t" +
                    "d{\r\n    border: 2px solid rgb(194, 189, 189);\r\n}\r\n.table-stats-style th{\r\n    bo" +
                    "rder: 2px solid rgb(194, 189, 189);\r\n    background-color:whitesmoke;\r\n}\r\n\r\n.tab" +
                    "le-stats-style tbody{\r\n    table-layout:auto;\r\n}\r\n\r\n.table-stats-style tr td:fir" +
                    "st-of-type{\r\n    min-width: 50px;\r\n}\r\n\r\n\r\n/*\r\n    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\r\n    INDIVID" +
                    "UAL CSS\r\n*/\r\n.claims-details-breakdown{\r\n    margin-bottom: 30px;\r\n}\r\n.claims-de" +
                    "tails-breakdown span{\r\n    font-weight: bold;\r\n    color: green;\r\n}\r\n</style>");
            this.Write("\r\n    </head>\r\n    <body>\r\n");
            this.Write("\r\n");
            this.Write("\r\n<div class=\"dashboard-box\">\r\n    <div class=\"dashboard-box-content\">\r\n        <" +
                    "div class=\"title-partition\">\r\n            <div class=\"dashboard-box-title\">\r\n   " +
                    "             ");
            
            #line 7 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments/DashboardBox_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.ReportTitle));
            
            #line default
            #line hidden
            this.Write("\r\n            </div>\r\n            <div class=\"dashboard-box-sub-title\">\r\n        " +
                    "        Profit and Loss Report\r\n            </div>\r\n            <div class=\"dash" +
                    "board-box-sub-title-combine\">\r\n                ");
            
            #line 13 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments/DashboardBox_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.ReportTitleGameList));
            
            #line default
            #line hidden
            this.Write("\r\n            </div>\r\n        </div>\r\n        <div class=\"title-partition\">\r\n    " +
                    "        <div class=\"dashboard-box-winnings\">\r\n                ");
            
            #line 18 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments/DashboardBox_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.LifeTimeWinnings));
            
            #line default
            #line hidden
            this.Write("\r\n            </div>\r\n            <div class=\"dashboard-box-sub-winnings\">\r\n     " +
                    "           Lifetime Winnings\r\n            </div>\r\n        </div>\r\n    </div>\r\n</" +
                    "div>\r\n");
            this.Write("\r\n");
            this.Write("<div class=\"report-box\">\r\n    ");
            this.Write(@"
<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Winning Digits</span>
        <span class=""title-description"">- Counting your lucky winning digits</span>
    </div>
    <div class=""outline-content"">
        <table class=""default-table"" cellspacing=""5"">
            <tbody>
                <tr>
                    <td>Lifetime Winnings: </td>
                    <td>");
            
            #line 13 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/WinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.LifeTimeWinnings));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Total" +
                    " Money you win so far: </td>\r\n                    <td>");
            
            #line 17 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/WinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalMoneyWinSoFar));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Highe" +
                    "st amount you won: </td>\r\n                    <td>");
            
            #line 21 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/WinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.HighestAmountWon));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Lowes" +
                    "t amount you won: </td>\r\n                    <td>");
            
            #line 25 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/WinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.LowestAmountWon));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r" +
                    "\n</div>");
            this.Write("\r\n    ");
            this.Write(@"<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Spending</span>
        <span class=""title-description"">- Your total spending categorized</span>
    </div>
    <div class=""outline-content"">
        <table class=""default-table"" cellspacing=""5"">
            <tbody>
                <tr>
                    <td>Total money you spent: </td>
                    <td>");
            
            #line 12 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Spending_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalMoneySpentSoFar));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Total" +
                    " Money you loose by Lucky Pick: </td>\r\n                    <td>");
            
            #line 16 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Spending_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalMoneyLooseSoFar));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Yearl" +
                    "y average of bet: </td>\r\n                    <td>");
            
            #line 20 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Spending_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalMoneyBettedYearlyAverage));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r" +
                    "\n</div>\r\n");
            this.Write("\r\n    ");
            this.Write(@"
<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Claims</span>
        <span class=""title-description"">- Total money you win and gotcha</span>
    </div>
    <div class=""outline-content"">
        <table class=""default-table"" cellspacing=""5"">
            <tbody>
                <tr>
                    <td>Total number of claims pending: </td>
                    <td>");
            
            #line 18 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalNumberOfClaims));
            
            #line default
            #line hidden
            this.Write(" claims</td>\r\n                </tr>\r\n                <tr>\r\n                    <t" +
                    "d>Total number of claims yet to redeem: </td>\r\n                    <td>");
            
            #line 22 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalNumberOfClaimsToRedeem));
            
            #line default
            #line hidden
            this.Write(" out of ");
            
            #line 22 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalNumberOfClaims));
            
            #line default
            #line hidden
            this.Write(" claims</td>\r\n                </tr>\r\n                <tr>\r\n                    <t" +
                    "d>Details of the claims</td>\r\n                    <td>\r\n                        " +
                    "");
            
            #line 27 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 foreach (var item in ProfitAndLossReport.ClaimDetailsList) { 
            
            #line default
            #line hidden
            this.Write("                             <div class=\"claims-details-breakdown\">\r\n            " +
                    "                    <span>");
            
            #line 29 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key));
            
            #line default
            #line hidden
            this.Write("</span>\r\n                                ");
            
            #line 30 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 foreach (LotteryBet bet in (List<LotteryBet>) item.Value) { 
            
            #line default
            #line hidden
            this.Write("                                    <div>\r\n                                      " +
                    "  ");
            
            #line 32 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bet.GetTargetDrawDateFormatted()));
            
            #line default
            #line hidden
            this.Write(" - \r\n                                        ");
            
            #line 33 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bet.GetGNUFormat()));
            
            #line default
            #line hidden
            this.Write(",\r\n                                        ");
            
            #line 34 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bet.GetLotteryWinningBet().GetWinningAmountInCurrency()));
            
            #line default
            #line hidden
            this.Write("\r\n                                        ");
            
            #line 35 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 if(!bet.GetLotteryWinningBet().IsClaimed()) { 
            
            #line default
            #line hidden
            this.Write("                                            , to redeem\r\n                        " +
                    "                ");
            
            #line 37 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                                    </div>\r\n                                ");
            
            #line 39 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                            </div>\r\n                        ");
            
            #line 41 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/Claims_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                    </td>\r\n                </tr>\r\n            </tbody>\r\n        <" +
                    "/table>\r\n    </div>\r\n</div>");
            this.Write("\r\n    ");
            this.Write(@"<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Tally Behavior</span>
        <span class=""title-description"">- Counting your specific behavior on betting</span>
    </div>
    <div class=""outline-content"">
        <table class=""default-table"" cellspacing=""5"">
            <tbody>
                <tr>
                    <td>How many bets you made so far?</td>
                    <td>");
            
            #line 12 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyBehavior_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.TotalBetsMade));
            
            #line default
            #line hidden
            this.Write(" bets</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>" +
                    "How much time pass since you started to bet: </td>\r\n                    <td>");
            
            #line 16 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyBehavior_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.ElapseTimeSinceEaliestBet));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r" +
                    "\n</div>");
            this.Write("\r\n    ");
            this.Write(@"<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Tallying Winning Digits</span>
        <span class=""title-description"">- Counting your winning combinations so far</span>
    </div>
    <div class=""outline-content"">
        <table class=""default-table"" cellspacing=""5"">
            <tbody>
                <tr>
                    <td>Tallying your combo wins</td>
                    <td>
                        <ul>
                            ");
            
            #line 14 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyWinningDigits_Fragment.tt"
 foreach (var item in ProfitAndLossReport.TimesWonPerBetCombinationDict) { 
            
            #line default
            #line hidden
            this.Write("                                <li>");
            
            #line 15 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyWinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Key));
            
            #line default
            #line hidden
            this.Write(": ");
            
            #line 15 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyWinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Value));
            
            #line default
            #line hidden
            this.Write("</li>\r\n                            ");
            
            #line 16 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyWinningDigits_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                        </ul>\r\n                    </td>\r\n                </tr>\r\n" +
                    "                <tr>\r\n                    <td>When was the last time you won: </" +
                    "td>\r\n                    <td>");
            
            #line 22 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/TallyWinningDigits_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProfitAndLossReport.WhenWasLastTimeYouWon));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r" +
                    "\n</div>");
            this.Write("\r\n    ");
            this.Write(@"<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Yearly Bets</span>
        <span class=""title-description"">- Tallying of your yearly spending on bets</span>
    </div>
    <div class=""outline-content"">
        <table class=""table-stats-style yearly-tallying"" cellspacing=""0"">
            <thead>
                <th>Year</th>
                <th>January</th>
                <th>February</th>
                <th>March</th>
                <th>April</th>
                <th>May</th>
                <th>June</th>
                <th>July</th>
                <th>August</th>
                <th>September</th>
                <th>October</th>
                <th>November</th>
                <th>December</th>
                <th>Annual</th>
            </thead>
            <tbody>
                ");
            
            #line 26 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 foreach (var item in ProfitAndLossReport.AllBetsInTabularMode) { 
            
            #line default
            #line hidden
            this.Write("                    <tr>\r\n                        ");
            
            #line 28 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 if(item[0]==0) { 
            
            #line default
            #line hidden
            this.Write("                            <td>Total</td>\r\n                        ");
            
            #line 30 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 }else{ 
            
            #line default
            #line hidden
            this.Write("                            <td>");
            
            #line 31 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[0]));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                        ");
            
            #line 32 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n                        ");
            
            #line 34 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 for (int x=1; x<=13; x++) { 
            
            #line default
            #line hidden
            this.Write("                            ");
            
            #line 35 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 if(item[x]==0) { 
            
            #line default
            #line hidden
            this.Write("                                <td class=\"zero-sum-color\">\r\n                    " +
                    "        ");
            
            #line 37 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 }else{ 
            
            #line default
            #line hidden
            this.Write("                                <td>\r\n                            ");
            
            #line 39 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                            ");
            
            #line 40 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[x].ToString("C")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                        ");
            
            #line 41 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                    </tr>\r\n                ");
            
            #line 43 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/YearlyBets_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
            this.Write("\r\n    ");
            this.Write(@"<div class=""outline-container"">
    <div class=""outline-title"">
        <span class=""title-keyword"">Day of Week Tally</span>
        <span class=""title-description"">- Tallying weekdays behavior in betting</span>
    </div>
    <div class=""outline-content"">
        <table class=""table-stats-style"" cellspacing=""0"">
            <thead>
                <th>Days</th>
                <th>Total Spending</th>
                <th>1 Digit Win</th>
                <th>2 Digit Win</th>
                <th>3 Digit Win</th>
                <th>4 Digit Win</th>
                <th>5 Digit Win</th>
                <th>6 Digit Win</th>
            </thead>
            <tbody>
                ");
            
            #line 20 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 foreach (var item in ProfitAndLossReport.AllBetsInTabularModeDaysOfWeek) { 
            
            #line default
            #line hidden
            this.Write("                     <tr>\r\n                        <td>");
            
            #line 22 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[0]));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                        <td>");
            
            #line 23 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(double.Parse(item[1]).ToString("C")));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\r\n                        ");
            
            #line 25 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 for (int x=2; x<=7; x++) { 
            
            #line default
            #line hidden
            this.Write("                            ");
            
            #line 26 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 if(double.Parse(item[x])==0) { 
            
            #line default
            #line hidden
            this.Write("                                <td class=\"zero-sum-color\">\r\n                    " +
                    "        ");
            
            #line 28 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 }else{ 
            
            #line default
            #line hidden
            this.Write("                                <td>\r\n                            ");
            
            #line 30 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                            ");
            
            #line 31 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item[x]));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                        ");
            
            #line 32 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("                    </tr>\r\n                ");
            
            #line 34 "D:\Development\WorkSpace00002\LottoDataManager\Includes\Classes\Reports\Templates\Fragments\ReportBox/DaysOfWeekTally_Fragment.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            this.Write("\r\n    <div class=\"page-spacer\"></div>\r\n</div>");
            this.Write("\r\n");
            this.Write("        </body>\r\n</html>");
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
