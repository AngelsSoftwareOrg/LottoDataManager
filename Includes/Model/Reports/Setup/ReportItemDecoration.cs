using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Model.Reports.Setup
{
    public class ReportItemDecoration
    {
        public static Color COLOR_NO_FOCUS = Color.Gray;
        public static Color COLOR_ATTENTION_HIGHLIGHT = Color.GreenYellow;
        public static Color COLOR_LINK_CLICKABLE = Color.Blue;

        private Color highlightColor;
        private bool isHighlightColor;
        private Color fontColor;
        private bool isHyperLink;
        public ReportItemDecoration()
        {
            HighlightColor = Color.Empty;
            IsHighlightColor = false;
            FontColor = Color.Black;
            IsHyperLink = false;
        }
        public Color HighlightColor { get => highlightColor; set => highlightColor = value; }
        public bool IsHighlightColor { get => isHighlightColor; set => isHighlightColor = value; }
        public Color FontColor { get => fontColor; set => fontColor = value; }
        public bool IsHyperLink { get => isHyperLink; set => isHyperLink = value; }
    }
}
