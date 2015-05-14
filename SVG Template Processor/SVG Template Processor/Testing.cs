using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SVG_Template_Processor
{
    class Testing
    {
         static void Main()
        {
            imageProcessingLibrary i = new imageProcessingLibrary();
            
                try
                {   Rectangle[] rNew = new Rectangle[10];
                Bitmap bNew = i.Transparent2Color(@"\\chptfs\Shared\Intern Projects\SVG Template Creation\pngTemplatesApetureAreas\Calendar_PatrioticBlueStars.png");
               // rNew = fileChange(@"\\chptfs\Shared\Intern Projects\SVG Template Creation\pngTemplatesApetureAreas\1141_2226x1047_11ozMug_4up_Misc_LoveNeverFailsLabel.png");
                bNew.Save("c:\\Users\\rschultz\\Desktop\\bNew.png", ImageFormat.Png);
                }
            catch(Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
            }
            finally{
                    
                }

        }

    }
}
