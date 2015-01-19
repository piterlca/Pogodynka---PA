namespace Pogodynka
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ChooseCityMenu = new System.Windows.Forms.MenuStrip();
            this.chooseCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.ChooseCityMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ChooseCityMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.778625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.22137F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ChooseCityMenu
            // 
            this.ChooseCityMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseCityMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseCityToolStripMenuItem});
            this.ChooseCityMenu.Location = new System.Drawing.Point(0, 0);
            this.ChooseCityMenu.Name = "ChooseCityMenu";
            this.ChooseCityMenu.Size = new System.Drawing.Size(568, 35);
            this.ChooseCityMenu.TabIndex = 1;
            this.ChooseCityMenu.Text = "menuStrip1";
            // 
            // chooseCityToolStripMenuItem
            // 
            this.chooseCityToolStripMenuItem.Name = "chooseCityToolStripMenuItem";
            this.chooseCityToolStripMenuItem.Size = new System.Drawing.Size(81, 31);
            this.chooseCityToolStripMenuItem.Text = "Choose city";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 38);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(562, 361);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.ChooseCityMenu;
            this.Name = "Form1";
            this.Text = "Pogodynka";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ChooseCityMenu.ResumeLayout(false);
            this.ChooseCityMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip ChooseCityMenu;
        private System.Windows.Forms.ToolStripMenuItem chooseCityToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;




    }
}

