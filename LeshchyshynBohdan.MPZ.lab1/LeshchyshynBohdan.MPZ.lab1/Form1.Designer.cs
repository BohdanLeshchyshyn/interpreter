namespace LeshchyshynBohdan.MPZ.lab1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SyntaxBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OperatorsBox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ConsoleBox = new System.Windows.Forms.RichTextBox();
            this.InputBox = new System.Windows.Forms.RichTextBox();
            this.InfoBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(392, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поле вводу";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Основні функції";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.91623F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.08377F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 497F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.InputBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.InfoBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1262, 479);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(389, 439);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(375, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 17);
            this.tabControl1.Location = new System.Drawing.Point(764, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 0);
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(498, 479);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tabPage1.Controls.Add(this.SyntaxBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(490, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Syntax Analiz";
            // 
            // SyntaxBox
            // 
            this.SyntaxBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SyntaxBox.BackColor = System.Drawing.Color.Turquoise;
            this.SyntaxBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SyntaxBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SyntaxBox.Location = new System.Drawing.Point(0, -1);
            this.SyntaxBox.Margin = new System.Windows.Forms.Padding(0);
            this.SyntaxBox.Name = "SyntaxBox";
            this.SyntaxBox.ReadOnly = true;
            this.SyntaxBox.Size = new System.Drawing.Size(494, 455);
            this.SyntaxBox.TabIndex = 1;
            this.SyntaxBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tabPage2.Controls.Add(this.OperatorsBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(490, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operators";
            // 
            // OperatorsBox
            // 
            this.OperatorsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperatorsBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.OperatorsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperatorsBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperatorsBox.Location = new System.Drawing.Point(0, 0);
            this.OperatorsBox.Margin = new System.Windows.Forms.Padding(0);
            this.OperatorsBox.Name = "OperatorsBox";
            this.OperatorsBox.ReadOnly = true;
            this.OperatorsBox.Size = new System.Drawing.Size(490, 455);
            this.OperatorsBox.TabIndex = 2;
            this.OperatorsBox.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ConsoleBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(490, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Console";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleBox.BackColor = System.Drawing.Color.Honeydew;
            this.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleBox.Location = new System.Drawing.Point(0, 0);
            this.ConsoleBox.Margin = new System.Windows.Forms.Padding(0);
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.ReadOnly = true;
            this.ConsoleBox.Size = new System.Drawing.Size(490, 455);
            this.ConsoleBox.TabIndex = 3;
            this.ConsoleBox.Text = "";
            // 
            // InputBox
            // 
            this.InputBox.AcceptsTab = true;
            this.InputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputBox.Location = new System.Drawing.Point(389, 20);
            this.InputBox.Margin = new System.Windows.Forms.Padding(0);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(375, 419);
            this.InputBox.TabIndex = 1;
            this.InputBox.Text = "";
            // 
            // InfoBox
            // 
            this.InfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.InfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoBox.Location = new System.Drawing.Point(0, 20);
            this.InfoBox.Margin = new System.Windows.Forms.Padding(0);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.InfoBox, 2);
            this.InfoBox.Size = new System.Drawing.Size(389, 459);
            this.InfoBox.TabIndex = 7;
            this.InfoBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox InfoBox;
        private System.Windows.Forms.RichTextBox InputBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox SyntaxBox;
        private System.Windows.Forms.RichTextBox OperatorsBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox ConsoleBox;

    }
}

