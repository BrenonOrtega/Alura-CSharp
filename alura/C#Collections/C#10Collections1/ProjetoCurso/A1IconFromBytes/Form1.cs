using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace A1IconFromByteArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap bm = new Bitmap(32, 32);
            MemoryStream memStream;

            using (Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
            {
                memStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                int byteCount;

                do
                {
                    byteCount = stream.Read(buffer, 0, buffer.Length);
                    memStream.Write(buffer, 0, byteCount);
                } while (byteCount > 0);
            }

            bm = new Bitmap(Image.FromStream(memStream));

            Icon ic = Icon.FromHandle(bm.GetHicon());
            this.Icon = ic;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
