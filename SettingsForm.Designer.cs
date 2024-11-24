namespace CrosshairFree
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TrackBar sizeSlider;
        private System.Windows.Forms.TrackBar lineWidthSlider;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label lineWidthLabel;
        private System.Windows.Forms.Label colorLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.previewPanel = new System.Windows.Forms.Panel();
            this.sizeSlider = new System.Windows.Forms.TrackBar();
            this.lineWidthSlider = new System.Windows.Forms.TrackBar();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.lineWidthLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthSlider)).BeginInit();

            this.SuspendLayout();

            // previewPanel
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Location = new System.Drawing.Point(100, 20);
            this.previewPanel.Size = new System.Drawing.Size(200, 200);

            // sizeSlider
            this.sizeSlider.Location = new System.Drawing.Point(120, 250);
            this.sizeSlider.Minimum = 10;
            this.sizeSlider.Maximum = 200;
            this.sizeSlider.Value = 40;

            // sizeLabel
            this.sizeLabel.Text = "Crosshair Size:";
            this.sizeLabel.Location = new System.Drawing.Point(30, 250);

            // lineWidthSlider
            this.lineWidthSlider.Location = new System.Drawing.Point(120, 300);
            this.lineWidthSlider.Minimum = 1;
            this.lineWidthSlider.Maximum = 10;
            this.lineWidthSlider.Value = 2;

            // lineWidthLabel
            this.lineWidthLabel.Text = "Line Width:";
            this.lineWidthLabel.Location = new System.Drawing.Point(30, 300);

            // colorPickerButton
            this.colorPickerButton.Text = "Pick Color";
            this.colorPickerButton.BackColor = System.Drawing.Color.Red;
            this.colorPickerButton.Location = new System.Drawing.Point(120, 350);

            // colorLabel
            this.colorLabel.Text = "Crosshair Color:";
            this.colorLabel.Location = new System.Drawing.Point(30, 350);

            // applyButton
            this.applyButton.Text = "Apply";
            this.applyButton.BackColor = System.Drawing.Color.LightBlue;
            this.applyButton.Location = new System.Drawing.Point(120, 400);

            // SettingsForm
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.sizeSlider);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.lineWidthSlider);
            this.Controls.Add(this.lineWidthLabel);
            this.Controls.Add(this.colorPickerButton);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.applyButton);
            this.Text = "Crosshair Settings";

            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

