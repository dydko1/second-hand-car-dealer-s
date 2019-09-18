namespace Komis_V002
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOtworzFolder = new System.Windows.Forms.Button();
            this.btnOdswiez = new System.Windows.Forms.Button();
            this.btnWstaw = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 363);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUsun);
            this.groupBox2.Controls.Add(this.btnOtworzFolder);
            this.groupBox2.Controls.Add(this.btnOdswiez);
            this.groupBox2.Controls.Add(this.btnWstaw);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operacje";
            // 
            // btnOtworzFolder
            // 
            this.btnOtworzFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOtworzFolder.Location = new System.Drawing.Point(153, 16);
            this.btnOtworzFolder.Name = "btnOtworzFolder";
            this.btnOtworzFolder.Size = new System.Drawing.Size(110, 35);
            this.btnOtworzFolder.TabIndex = 2;
            this.btnOtworzFolder.Text = "Otworz Folder";
            this.btnOtworzFolder.UseVisualStyleBackColor = true;
            this.btnOtworzFolder.Click += new System.EventHandler(this.btnOtworzFolder_Click);
            // 
            // btnOdswiez
            // 
            this.btnOdswiez.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOdswiez.Location = new System.Drawing.Point(78, 16);
            this.btnOdswiez.Name = "btnOdswiez";
            this.btnOdswiez.Size = new System.Drawing.Size(75, 35);
            this.btnOdswiez.TabIndex = 1;
            this.btnOdswiez.Text = "Odswież";
            this.btnOdswiez.UseVisualStyleBackColor = true;
            this.btnOdswiez.Click += new System.EventHandler(this.btnOdswiez_Click);
            // 
            // btnWstaw
            // 
            this.btnWstaw.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnWstaw.Location = new System.Drawing.Point(3, 16);
            this.btnWstaw.Name = "btnWstaw";
            this.btnWstaw.Size = new System.Drawing.Size(75, 35);
            this.btnWstaw.TabIndex = 0;
            this.btnWstaw.Text = "Wstaw";
            this.btnWstaw.UseVisualStyleBackColor = true;
            this.btnWstaw.Click += new System.EventHandler(this.btnWstaw_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUsun.Location = new System.Drawing.Point(671, 16);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 35);
            this.btnUsun.TabIndex = 3;
            this.btnUsun.Text = "Usun";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form2";
            this.Text = "Panel administratora";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnWstaw;
        private System.Windows.Forms.Button btnOtworzFolder;
        private System.Windows.Forms.Button btnOdswiez;
        private System.Windows.Forms.Button btnUsun;
    }
}