using System;
using System.Drawing;
using System.Windows.Forms;

public class Class1
{

    private Bitmap MyImage;
    public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
    {
        // Sets up an image object to be displayed. 
        if (MyImage != null)
        {
            MyImage.Dispose();
        }

        PictureBox pictureBox1 = new PictureBox();
        // Stretches the image to fit the pictureBox.
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        MyImage = new Bitmap(fileToDisplay);
        pictureBox1.ClientSize = new Size(xSize, ySize);
        pictureBox1.Image = (Image)MyImage;
    }
}