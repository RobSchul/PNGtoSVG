using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVG_Template_Processor
{   
    class SVGCreationLibrary
    {   private string[] pngFiles;  
        SVGCreationLibrary(string[] pngFileLocations)
        {
            pngFiles = pngFileLocations;
        }

        private Rectangle[] getRegions(string file)
        {
            imageProcessingLibrary process = new imageProcessingLibrary(file);
            Rectangle[] rect = process.getTRegions(); 
            return rect;
        }

        public void buildSVG()
        {

        }
    }
}
