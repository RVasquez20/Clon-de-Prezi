
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Threading;

namespace graphviz_cSharp
{
    public partial class FormPrincipal : Form
    {
        private int nodeCounter = 0;
        Presentar v1;
        int iterador = 1;
        Queue<Bitmap> cola1 = new Queue<Bitmap>();
        string codGraph = "digraph G {";
        string codGraphT = "";
        string dir = @"C:\Users\rodri\Downloads\graphviz_cSharp\";
        string dir2 = @"C:\Users\rodri\Downloads\graphviz_cSharp\bin\Debug\";
        string Nombre = "", Rol = "";
        public FormPrincipal()
        {
            InitializeComponent();

           

        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            
                pictureBox1.Image.Dispose();
            
            File.Delete(dir + "grapht.dot");
            File.Delete(dir + "grapht.jpg");
            codGraph +="\n}";
            this.addNode.Enabled = false;
            this.mergeNodes.Enabled = false;


            TextWriter sw = new StreamWriter(dir+"graph.dot");
            
                sw.Write(codGraph);
            sw.Close();
            

            try {
                  
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    string it = iterador.ToString();
                    process.StartInfo.Arguments = @"dot -Tjpg " + dir+ "graph.dot -o " + dir+ "graph.jpg";
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
                File.Delete(dir+ @"graph.dot");
                    if (Application.OpenForms["Presentar"] == null)
                    {
                    
                    Presentar v1 = new Presentar(cola1);
                        
                        v1.Show();
                    v1.FormClosed += Logout;

                }
                   
                   
                    fromNode.Text = "";
                    towardsNode.Text = "";
               } catch (Exception exception) {
                    MessageBox.Show("Error\n\n"+exception.Message);
             }
            for (int h = 1; h <= iterador; h++)
            {
                File.Delete(dir2 + h + ".jpg");
            }
        }

       

        private void addNode_Click(object sender, EventArgs e)
        {
            if (this.nodeValueTextBox != null && this.nodeValueTextBox.Text != "")
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                this.drawButton.Enabled = true;
                codGraph += "\n  " + this.nodeNameTextBox.Text + " [label=" + "\"" + this.nodeValueTextBox.Text + "\"];";
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

                this.Invoke(new Action(() => { pictureBox1.Refresh(); }));
                string texto = "";
                texto = @"" + this.nodeNameTextBox.Text + " [label=" + "\"" + this.nodeValueTextBox.Text + "\"];";
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
                MessageBox.Show("null entries is not allowed");
            }
        }

        private void mergeNodes_Click(object sender, EventArgs e)
        {
            
            
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            pictureBox1.Image = null;
            cola1.Clear();

        }

    }
}