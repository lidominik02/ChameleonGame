
namespace ChameleonGame
{
    partial class ChameleonForm
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
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._settingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._threeByThreeNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this._fiveByFiveNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this._sevenBySevenNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this._tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._statusBar = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._menuStrip.SuspendLayout();
            this._statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(966, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _settingMenuItem
            // 
            this._settingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveMenuItem,
            this._loadMenuItem,
            this._newGameMenuItem});
            this._settingMenuItem.Name = "_settingMenuItem";
            this._settingMenuItem.Size = new System.Drawing.Size(57, 20);
            this._settingMenuItem.Text = "Opciók";
            // 
            // _saveMenuItem
            // 
            this._saveMenuItem.Name = "_saveMenuItem";
            this._saveMenuItem.Size = new System.Drawing.Size(158, 22);
            this._saveMenuItem.Text = "Játék mentése";
            // 
            // _loadMenuItem
            // 
            this._loadMenuItem.Name = "_loadMenuItem";
            this._loadMenuItem.Size = new System.Drawing.Size(158, 22);
            this._loadMenuItem.Text = "Játék betöltése";
            // 
            // _newGameMenuItem
            // 
            this._newGameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._threeByThreeNewGame,
            this._fiveByFiveNewGame,
            this._sevenBySevenNewGame});
            this._newGameMenuItem.Name = "_newGameMenuItem";
            this._newGameMenuItem.Size = new System.Drawing.Size(158, 22);
            this._newGameMenuItem.Text = "Új Játék indítása";
            // 
            // _threeByThreeNewGame
            // 
            this._threeByThreeNewGame.Name = "_threeByThreeNewGame";
            this._threeByThreeNewGame.Size = new System.Drawing.Size(100, 22);
            this._threeByThreeNewGame.Text = "3 x 3";
            // 
            // _fiveByFiveNewGame
            // 
            this._fiveByFiveNewGame.Name = "_fiveByFiveNewGame";
            this._fiveByFiveNewGame.Size = new System.Drawing.Size(100, 22);
            this._fiveByFiveNewGame.Text = "5 x 5 ";
            // 
            // _sevenBySevenNewGame
            // 
            this._sevenBySevenNewGame.Name = "_sevenBySevenNewGame";
            this._sevenBySevenNewGame.Size = new System.Drawing.Size(100, 22);
            this._sevenBySevenNewGame.Text = "7 x 7";
            // 
            // _tableLayout
            // 
            this._tableLayout.ColumnCount = 2;
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayout.Location = new System.Drawing.Point(0, 24);
            this._tableLayout.Name = "_tableLayout";
            this._tableLayout.RowCount = 2;
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayout.Size = new System.Drawing.Size(966, 919);
            this._tableLayout.TabIndex = 1;
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "openFileDialog1";
            // 
            // _statusBar
            // 
            this._statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel});
            this._statusBar.Location = new System.Drawing.Point(0, 921);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Size = new System.Drawing.Size(966, 22);
            this._statusBar.TabIndex = 2;
            this._statusBar.Text = "statusStrip1";
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // CameleonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(966, 943);
            this.Controls.Add(this._statusBar);
            this.Controls.Add(this._tableLayout);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "CameleonForm";
            this.Text = "Cameleon";
            this.Load += new System.EventHandler(this.CameleonForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusBar.ResumeLayout(false);
            this._statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _settingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _loadMenuItem;
        private System.Windows.Forms.TableLayoutPanel _tableLayout;
        private System.Windows.Forms.ToolStripMenuItem _newGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _threeByThreeNewGame;
        private System.Windows.Forms.ToolStripMenuItem _fiveByFiveNewGame;
        private System.Windows.Forms.ToolStripMenuItem _sevenBySevenNewGame;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.StatusStrip _statusBar;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
    }
}

