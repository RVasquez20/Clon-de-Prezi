using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace graphviz_cSharp
{
  
    public partial class Presentar : Form
    {
        Queue<Bitmap> cola1 = new Queue<Bitmap>();
        Bitmap bitmap = null;
        public Presentar(Queue<Bitmap> cola2)
        {
            InitializeComponent();
            cola1 = cola2;
            while (cola1.Count != 0)
            {
                imageSlider1.Images.Add(cola1.Dequeue());
            }
            if (File.Exists(@"C:\Users\rodri\Downloads\graphviz_cSharp\graph.jpg"))
            {
                 bitmap = null;
            using (Stream bmpStream = System.IO.File.Open(@"C:\Users\rodri\Downloads\graphviz_cSharp\graph.jpg", System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }


                File.Delete(@"C:\Users\rodri\Downloads\graphviz_cSharp\graph.jpg");
                pictureBox1.Image = bitmap;
                
            }
            else
            {
                pictureBox1.Image = null;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cola1.Count != 0)
            {
               pictureBox1.Image = cola1.Dequeue();
             
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            imageSlider1.Images.Clear();
            this.Close();
        }

        private void Presentar_Load(object sender, EventArgs e)
        {
            this.Invoke(new Action(() => { pictureBox1.Refresh(); }));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Imagen|*.jpeg";
            string archivo;
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo = SaveFile.FileName;
                    
                    bitmap.Save(archivo, System.Drawing.Imaging.ImageFormat.Jpeg);
                
                    
                }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image,100,150);
        }
    }
}
