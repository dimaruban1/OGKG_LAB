namespace OGKG_LAB
{
    partial class MainForm
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
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            greetingLabel = new Label();
            actionsLabel = new Label();
            showTaskButton = new Button();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.Location = new Point(100, 71);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(830, 449);
            plotView1.TabIndex = 0;
            plotView1.Text = "S";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // greetingLabel
            // 
            greetingLabel.AutoSize = true;
            greetingLabel.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            greetingLabel.Location = new Point(82, 23);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(143, 26);
            greetingLabel.TabIndex = 1;
            greetingLabel.Text = "Visualisation";
            // 
            // actionsLabel
            // 
            actionsLabel.AutoSize = true;
            actionsLabel.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            actionsLabel.Location = new Point(1205, 35);
            actionsLabel.Name = "actionsLabel";
            actionsLabel.Size = new Size(87, 26);
            actionsLabel.TabIndex = 2;
            actionsLabel.Text = "Actions";
            // 
            // showTaskButton
            // 
            showTaskButton.Location = new Point(1175, 71);
            showTaskButton.Name = "showTaskButton";
            showTaskButton.Size = new Size(153, 23);
            showTaskButton.TabIndex = 3;
            showTaskButton.Text = "Show task";
            showTaskButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(showTaskButton);
            Controls.Add(actionsLabel);
            Controls.Add(greetingLabel);
            Controls.Add(plotView1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label greetingLabel;
        private Label actionsLabel;
        private Button showTaskButton;
    }
}