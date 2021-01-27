using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Properties;

namespace LottoDataManager.Includes.Utilities
{
    public class ImageUtils : IDisposable
    {
        private static ImageList SMALL_IMAGE_LIST = new ImageList();
        private static readonly String IDX_STAR_WON = "STAR_MATCH_356a192b7913b04c54574d18c28d46e6395428ab";
        private static readonly String IDX_STAR_JACKPOT = "STAR_JACKPOT_da4b9237bacccdf19c0760cab7aec4a8359010b0";

        static ImageUtils(){
            SMALL_IMAGE_LIST.ColorDepth = ColorDepth.Depth32Bit;
            SMALL_IMAGE_LIST.ImageSize = SystemInformation.SmallIconSize;
            SMALL_IMAGE_LIST.Images.Add(IDX_STAR_WON, Resources.Stars6_20x);
            SMALL_IMAGE_LIST.Images.Add(IDX_STAR_JACKPOT, Resources.Stars2_20x);
        }
        private static Bitmap MultiplyBitmapHorizontally(Bitmap bitmap, int replicateCount)
        {
            if (replicateCount <= 0) replicateCount = 1;

            int paddingRight = 3;
            int width = 0;
            int height = 0;
            for(int ctr = 0; ctr < replicateCount; ctr++){
                width += bitmap.Width + paddingRight;
                height = Math.Max(height, bitmap.Height);
            }

            int incWidth = 3;
            Bitmap bitmapMerge = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmapMerge))
            {
                for (int ctr = 0; ctr < replicateCount; ctr++)
                {
                    g.DrawImage(bitmap, incWidth, 0);
                    incWidth += bitmap.Width + paddingRight;
                }
            }
            return bitmapMerge;
        }
        private static Bitmap GetImageListInstance(String key)
        {
            int idx = SMALL_IMAGE_LIST.Images.IndexOfKey(key);
            if (idx < 0) return null;
            return new Bitmap(SMALL_IMAGE_LIST.Images[idx]);
        }
        public static Bitmap GetStarWonImage(int replicateCount=1)
        {
            return MultiplyBitmapHorizontally(GetImageListInstance(IDX_STAR_WON), replicateCount);
        }
        public static Bitmap GetStarJackpotImage(int replicateCount=1)
        {
            return MultiplyBitmapHorizontally(GetImageListInstance(IDX_STAR_JACKPOT), replicateCount);
        }
        public void Dispose()
        {
            SMALL_IMAGE_LIST.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
