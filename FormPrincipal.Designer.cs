namespace graphviz_cSharp
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawButton = new System.Windows.Forms.Button();
            this.addNode = new System.Windows.Forms.Button();
            this.mergeNodes = new System.Windows.Forms.Button();
            this.fromNode = new System.Windows.Forms.ComboBox();
            this.towardsNode = new System.Windows.Forms.ComboBox();
            this.nodeNameTextBox = new System.Windows.Forms.TextBox();
            this.nodeValueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.Enabled = false;
            this.drawButton.Location = new System.Drawing.Point(434, 254);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(302, 50);
            this.drawButton.TabIndex = 0;
            this.drawButton.Text = "Presentar";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // addNode
            // 
            this.addNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.addNode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.addNode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.addNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.addNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.addNode.ForeColor = System.Drawing.SystemColors.Control;
            this.addNode.Location = new System.Drawing.Point(434, 183);
            this.addNode.Name = "addNode";
            this.addNode.Size = new System.Drawing.Size(150, 52);
            this.addNode.TabIndex = 2;
            this.addNode.Text = "Agregar nodo";
            this.addNode.UseVisualStyleBackColor = false;
            this.addNode.Click += new System.EventHandler(this.addNode_Click);
            // 
            // mergeNodes
            // 
            this.mergeNodes.Location = new System.Drawing.Point(621, 193);
            this.mergeNodes.Name = "mergeNodes";
            this.mergeNodes.Size = new System.Drawing.Size(136, 23);
            this.mergeNodes.TabIndex = 3;
            this.mergeNodes.Text = "Unir";
            this.mergeNodes.UseVisualStyleBackColor = true;
            this.mergeNodes.Click += new System.EventHandler(this.mergeNodes_Click);
            // 
            // fromNode
            // 
            this.fromNode.FormattingEnabled = true;
            this.fromNode.Location = new System.Drawing.Point(648, 29);
            this.fromNode.Name = "fromNode";
            this.fromNode.Size = new System.Drawing.Size(102, 21);
            this.fromNode.TabIndex = 4;
            // 
            // towardsNode
            // 
            this.towardsNode.FormattingEnabled = true;
            this.towardsNode.Location = new System.Drawing.Point(648, 64);
            this.towardsNode.Name = "towardsNode";
            this.towardsNode.Size = new System.Drawing.Size(102, 21);
            this.towardsNode.TabIndex = 5;
            // 
            // nodeNameTextBox
            // 
            this.nodeNameTextBox.Enabled = false;
            this.nodeNameTextBox.Location = new System.Drawing.Point(472, 29);
            this.nodeNameTextBox.Name = "nodeNameTextBox";
            this.nodeNameTextBox.Size = new System.Drawing.Size(112, 20);
            this.nodeNameTextBox.TabIndex = 6;
            this.nodeNameTextBox.Text = "node1";
            // 
            // nodeValueTextBox
            // 
            this.nodeValueTextBox.Location = new System.Drawing.Point(472, 65);
            this.nodeValueTextBox.Name = "nodeValueTextBox";
            this.nodeValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.nodeValueTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "De:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Para:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(924, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nodeValueTextBox);
            this.Controls.Add(this.nodeNameTextBox);
            this.Controls.Add(this.towardsNode);
            this.Controls.Add(this.fromNode);
            this.Controls.Add(this.mergeNodes);
            this.Controls.Add(this.addNode);
            this.Controls.Add(this.drawButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button addNode;
        private System.Windows.Forms.Button mergeNodes;
        private System.Windows.Forms.ComboBox fromNode;
        private System.Windows.Forms.ComboBox towardsNode;
        private System.Windows.Forms.TextBox nodeNameTextBox;
        private System.Windows.Forms.TextBox nodeValueTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox codeGraphRichTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

