using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace graphviz_cSharp
{
    public partial class Form1 : Form
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

        
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            prograssbar1.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prograssbar1.Value += 1;
            prograssbar1.Text = prograssbar1.Value.ToString() + "%";

            if (prograssbar1.Value == 100)
            {
                timer1.Enabled = false;
                FormMenuPrincipal se_form = new FormMenuPrincipal();
                se_form.FormClosed += Logout;
                se_form.Show();
                this.Hide();
            }
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
  