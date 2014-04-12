﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Tmc.Vision
{
    class SorterVision : ICamera
    {
        public void hi()
        {
            String win1 = "Test Window"; //The name of the window
            CvInvoke.cvNamedWindow(win1); //Create the window using the specific name

            Image<Bgr, Byte> img = new Image<Bgr, byte>(400, 200, new Bgr(255, 0, 0)); //Create an image of 400x200 of Blue color
            MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0); //Create the font

            img.Draw("Hello, world", ref f, new System.Drawing.Point(10, 80), new Bgr(0, 255, 0)); //Draw "Hello, world." on the image using the specific font

            CvInvoke.cvShowImage(win1, img); //Show the image
            CvInvoke.cvWaitKey(0);  //Wait for the key pressing event
            CvInvoke.cvDestroyWindow(win1); //Destory the window
        }
    }
}