using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors.Controls;
using System.Threading;
using System.Diagnostics;

namespace graphviz_cSharp
{
    public partial class FormMenuPrincipal : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
           (
           int nLeftRect,
           int nTopRect,
           int RightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse

           );
        private int nodeCounter = 0;
        imprimir v1;
        int iterador = 1;
        Queue<Bitmap> cola1 = new Queue<Bitmap>();
        Queue<Bitmap> cola2 = new Queue<Bitmap>();
        string codGraph = "digraph G {";
        string codGraphT = "";
        string dir = @"C:\Users\rodri\Downloads\graphviz_cSharp\";
        string dir2 = @"C:\Users\rodri\Downloads\graphviz_cSharp\bin\Debug\";
        string[] Shapes = { "box", "ellipse", "oval", "circle", "point", "egg", "triangle", "plaintext",
"plain", "diamond", "trapezium", "parallelogram", "house", "pentagon", "hexagon",
"septagon", "octagon", "doublecircle", "doubleoctagon", "tripleoctagon", "invtriangle",
"invtrapezium", "invhouse", "mdiamond", "msquare", "mcircle", "rect", "rectangle",
"square", "star", "none", "underline",  "cylinder", "note", "tab", "folder","box3d",
"component","promoter","cds","terminator","utr","primersite","restrictionsite",
"fivepoverhang","threepoverhang","noverhang","assembly","signature","insulator",
"ribosite","rnastab","proteasesite","proteinstab","rpromoter","rarrow","larrow",
"lpromoter"
};

        string[] Colors = {"antiquewhite","aquamarine1","azure3","bisque","blueviolet","blue","brown1",
"cadetblue","burlywood4","chartreuse","cadetblue4","coral1","coral","cornflowerblue",
"darkgoldenrod1","darkgoldenrod","darkorchid1","darkred","darkolivegreen1",
"darkolivegreen","darkorchid1","deeppink4","darkseagreen4","deeppink2","darkslategrey",
"deepskyblue4","gold","gold4","aquamarine2","azure2","chartreuse3","coral3","darkcyan",
"gray12","greenyellow","khaki","indianred2","lightblue","lightsalmon4","lightslateblue",
"mediumseagreen","midnightblue","peru","powderblue","purple4","pink1","lightseagreen",
"mediumslateblue","white" };


        public FormMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            CargarDatos();

        }

        private void CargarDatos()
        {
            foreach (string item in Shapes)
            {
                this.Shape.Items.Add(item);
            }
            foreach (string item in Colors)
            {
                this.Fill.Items.Add(item);
            }
        }

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
           
            pictureBox1.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
       
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO------------------------------------------------------
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            pictureBox1.Size = new Size(sw, sh);
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            pictureBox1.Size= new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {


            this.Close();
                
            
        }

        //METODOS PARA ANIMACION DE MENU SLIDING--
        private void btnMenu_Click(object sender, EventArgs e)
        {
            //-------CON EFECTO SLIDING
            if (panelMenu.Width == 230)
            {
                this.tmContraerMenu.Start();
            }
            else if (panelMenu.Width == 55)
            {
                this.tmExpandirMenu.Start();
            }

        }

       

       

      

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
            
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            
            string forma = Shape.Text;
            string Color = Fill.Text;
            lblConfirmada.Visible = false;
            lblErrorMessagge.Visible = false;
            pictureBox2.Image = null;
            if (this.nodeValueTextBox != null && this.nodeValueTextBox.Text != "")
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                if (Shape.Text.Equals(""))
                {
                    forma = "circle";
                }
                if (Fill.Text.Equals(""))
                {
                    Color = "aqua";
                }
                Shape.Text = "";
                Fill.Text = "";
                this.drawButton.Enabled = true;
                codGraph += "\n  " + this.nodeNameTextBox.Text + " [shape="+"\""+ forma + "\""+ "style="+"\"filled"+"\""+" fillcolor="+Color+" label=" + "\"" + this.nodeValueTextBox.Text + "\"];";
                codGraphT = "";
                codGraphT = codGraph;
                codGraphT += "}";
                using (StreamWriter sw = new StreamWriter(dir + "grapht.dot"))
                {
                    sw.Write(codGraphT);
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Arguments = @"dot -Tjpg " + dir + "grapht.dot -o " + dir + "grapht.jpg";
                process.Start();
                process.WaitForExit();
                Bitmap bitmap = null;
                using (Stream bmpStream = System.IO.File.Open(dir + "grapht.jpg", System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    bitmap = new Bitmap(image);
                }
                File.Delete(dir + "grapht.jpg");
                pictureBox1.Image = bitmap;
                this.Invoke(new Action(() => { pictureBox1.Refresh(); }));
                msgconfirmada("Agregado Correctamente");
                string texto = "";
                texto = @"" + this.nodeNameTextBox.Text + " [shape=" + "\"" + forma + "\"" + "style=" + "\"filled" + "\"" + " fillcolor=" +  Color  + " label =" + "\"" + this.nodeValueTextBox.Text + "\"];";
                this.fromNode.Items.Add(this.nodeValueTextBox.Text);
                this.towardsNode.Items.Add(this.nodeValueTextBox.Text);
                this.nodeCounter++;
                this.nodeNameTextBox.Text = ("node" + (nodeCounter + 1));
                this.nodeValueTextBox.Text = null;
                TextWriter tw = new StreamWriter(dir2 + iterador.ToString() + ".dot");
                tw.WriteLine("digraph G {");
                tw.WriteLine(texto);
                tw.WriteLine("}");
                tw.Close();
                ProcessStartInfo ps = new ProcessStartInfo();
                ps.FileName = "powershell.exe";
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                string it = iterador.ToString();
                ps.Arguments = "dot -Tjpg " + it + ".dot -o " + it + ".jpg";
                Process.Start(ps);
                Thread.Sleep(5000);
                File.Delete(it + ".dot");
                cola1.Enqueue(new Bitmap(Image.FromFile(dir2 + it + ".jpg")));

                iterador++;
            }
            else
            {
                msgError("No se permiten entradas Nulas");
            }
        }

        private void Unir_Click(object sender, EventArgs e)
        {

            lblConfirmada.Visible = false;
            lblErrorMessagge.Visible = false;
            if (nodeCounter < 2)
            {
                msgError("Haga Mas Nodos");
            }
            else if (this.fromNode.Text == "" || this.towardsNode.Text == "")
            {
                msgError("Seleccione 2 Nodos");
            }
            else
            {
                if (this.addNode.Enabled == true)
                    this.addNode.Enabled = false;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                if (this.Shape.Enabled == true)
                    this.Shape.Enabled = false;
                codGraph += "\n  node" + (this.fromNode.SelectedIndex + 1) + " -> node" + (this.towardsNode.SelectedIndex + 1) + ";";
                codGraphT = "";
                codGraphT = codGraph;
                codGraphT += "}";
                using (StreamWriter sw = new StreamWriter(dir + "grapht.dot"))
                {
                    sw.Write(codGraphT);
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Arguments = @"dot -Tjpg " + dir + "grapht.dot -o " + dir + "grapht.jpg";
                process.Start();
                process.WaitForExit();

                Bitmap bitmap = null;
                using (Stream bmpStream = System.IO.File.Open(dir + "grapht.jpg", System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    bitmap = new Bitmap(image);
                }
                File.Delete(dir + "grapht.jpg");
                pictureBox1.Image = bitmap;
                this.Invoke(new Action(() => { pictureBox1.Refresh(); }));
                cola2.Enqueue(new Bitmap(Image.FromFile(dir2 + (this.fromNode.SelectedIndex+1).ToString() + ".jpg")));
                cola2.Enqueue(new Bitmap(Image.FromFile(dir2 + (this.towardsNode.SelectedIndex+1).ToString() + ".jpg")));
                msgconfirmada("Unido:"+this.fromNode.Text + "-> " + this.towardsNode.Text);
            }
        }
        private void msgconfirmada(string msg)
        {
            lblConfirmada.Text = "      " + msg;
            lblConfirmada.Visible = true;

        }
        private void Presentar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            lblConfirmada.Visible = false;
            lblErrorMessagge.Visible = false;
            File.Delete(dir + "grapht.dot");
            File.Delete(dir + "grapht.jpg");
            codGraph += "\n}";
            this.addNode.Enabled = false;
            this.mergeNodes.Enabled = false;


            TextWriter sw = new StreamWriter(dir + "graph.dot");

            sw.Write(codGraph);
            sw.Close();


            try
            {

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                string it = iterador.ToString();
                process.StartInfo.Arguments = @"dot -Tjpg " + dir + "graph.dot -o " + dir + "graph.jpg";
                process.Start();
                process.WaitForExit();


                iterador = 1;
                codGraph = "digraph G {";
                this.nodeCounter = 0;
                this.nodeNameTextBox.Text = "node1";
                this.nodeValueTextBox.Text = null;
                this.fromNode.Items.Clear();
                this.towardsNode.Items.Clear();
                this.addNode.Enabled = true;
                this.mergeNodes.Enabled = true;
                File.Delete(dir + @"graph.dot");
                imprimir v1;
                if (Application.OpenForms["Presentar"] == null)
                {
                    if (cola2==null) {
                         v1 = new imprimir(cola1);
                    }
                    else
                    {
                         v1 = new imprimir(cola2);
                    }

                    v1.Show();
                    v1.FormClosed += Logout;

                }


                fromNode.Text = "";
                towardsNode.Text = "";
            }
            catch (Exception exception)
            {
                msgError("Error\n\n" + exception.Message);
            }
          
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 55)
                this.tmContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

        private void msgError(string msg)
        {
            lblErrorMessagge.Text = "      " + msg;
            lblErrorMessagge.Visible = true;

        }

        private void Shape_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarPrevisualizacion(Shape.Text);

        }

        public void MostrarPrevisualizacion(String shape)
        {
            lblErrorMessagge.Visible = false;
            try
            {
                pictureBox2.Image = Image.FromFile(@"../../Recursos/" + shape + ".png");
                this.Invoke(new Action(() => { pictureBox2.Refresh(); }));
            }catch(Exception e) { msgError(e.Message); }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kimberly Jemima Tomas Montes De Oca\n1290-19-11531\nProgramación III", "Presentación_Grafos");
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Image = null;
            for (int h = 1; h <= iterador; h++)
            {
                File.Delete(dir2 + h + ".jpg");
            }
            Shape.Enabled = true;
            cola1.Clear();

        }

        //METODO PARA HORA Y FECHA ACTUAL ----------------------------------------------------------
        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }
        


        

    }
}
