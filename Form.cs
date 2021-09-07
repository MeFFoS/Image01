using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image01
{
    public partial class form : System.Windows.Forms.Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void DDA_Click(object sender, EventArgs e)
        {
            Image.Draw(Image.DDAOtsech(Image.InitPixels(Color.AliceBlue), Color.DeepSkyBlue, Image.Figure, 0.2f, 0.3f, 0.8f, 0.8f), picture);
        }

        private void bresenham_Click(object sender, EventArgs e)
        {
            Image.Draw(Image.BresenhamOtsech(Image.InitPixels(Color.AliceBlue), Color.DeepSkyBlue, Image.Figure, 0.4f, 0.2f, 0.8f, 1f), picture);
        }

        private void DDArast_Click(object sender, EventArgs e)
        {
            Image.Draw(Image.DDARaster(Image.InitPixels(Color.AliceBlue), Color.DeepSkyBlue, Image.Figure), picture);
        }

        private void bresenhamRast_Click(object sender, EventArgs e)
        {
            Image.Draw(Image.BresenhamRaster(Image.InitPixels(Color.AliceBlue), Color.DeepSkyBlue, Image.Figure), picture);
        }
    }
}
