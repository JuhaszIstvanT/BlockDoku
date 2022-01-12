
namespace BlockDoku
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._boardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._displayLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pointBox = new System.Windows.Forms.TextBox();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.játékToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._saveFileDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _boardLayoutPanel
            // 
            this._boardLayoutPanel.ColumnCount = 4;
            this._boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.Location = new System.Drawing.Point(20, 60);
            this._boardLayoutPanel.Name = "_boardLayoutPanel";
            this._boardLayoutPanel.RowCount = 4;
            this._boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._boardLayoutPanel.Size = new System.Drawing.Size(400, 400);
            this._boardLayoutPanel.TabIndex = 0;
            // 
            // _displayLayoutPanel
            // 
            this._displayLayoutPanel.ColumnCount = 2;
            this._displayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._displayLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._displayLayoutPanel.Location = new System.Drawing.Point(500, 160);
            this._displayLayoutPanel.Name = "_displayLayoutPanel";
            this._displayLayoutPanel.RowCount = 2;
            this._displayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._displayLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._displayLayoutPanel.Size = new System.Drawing.Size(200, 200);
            this._displayLayoutPanel.TabIndex = 1;
            // 
            // pointBox
            // 
            this.pointBox.Location = new System.Drawing.Point(20, 494);
            this.pointBox.Name = "pointBox";
            this.pointBox.ReadOnly = true;
            this.pointBox.Size = new System.Drawing.Size(125, 27);
            this.pointBox.TabIndex = 2;
            this.pointBox.Text = "0";
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.játékToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(782, 28);
            this._menuStrip.TabIndex = 3;
            this._menuStrip.Text = "Játék";
            // 
            // játékToolStripMenuItem
            // 
            this.játékToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openFileDialog,
            this._saveFileDialog});
            this.játékToolStripMenuItem.Name = "játékToolStripMenuItem";
            this.játékToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.játékToolStripMenuItem.Text = "Játék";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Name = "_openFileDialog";
            this._openFileDialog.Size = new System.Drawing.Size(224, 26);
            this._openFileDialog.Text = "Betöltés";
            this._openFileDialog.Click += new System.EventHandler(this.MenuGameLoad_Click);
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Name = "_saveFileDialog";
            this._saveFileDialog.Size = new System.Drawing.Size(224, 26);
            this._saveFileDialog.Text = "Mentés";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.pointBox);
            this.Controls.Add(this._displayLayoutPanel);
            this.Controls.Add(this._boardLayoutPanel);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _boardLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel _displayLayoutPanel;
        private System.Windows.Forms.TextBox pointBox;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem játékToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _saveFileDialog;
    }
}

