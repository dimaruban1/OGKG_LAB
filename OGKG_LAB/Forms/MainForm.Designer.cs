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
            GeneratePointsButton = new Button();
            numberOfPointsTxt = new TextBox();
            xFromTxt = new TextBox();
            xToTxt = new TextBox();
            yFromTxt = new TextBox();
            yToTxt = new TextBox();
            PointsNumberLabel = new Label();
            xFromLable = new Label();
            yFromLabel = new Label();
            xToLabel = new Label();
            yToLabel = new Label();
            SolveButton = new Button();
            DeleteAllPointsButton = new Button();
            GenerateConvexHullButton = new Button();
            testBox = new RichTextBox();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.Location = new Point(100, 71);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(774, 649);
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
            // GeneratePointsButton
            // 
            GeneratePointsButton.Location = new Point(1175, 277);
            GeneratePointsButton.Name = "GeneratePointsButton";
            GeneratePointsButton.Size = new Size(153, 23);
            GeneratePointsButton.TabIndex = 4;
            GeneratePointsButton.Text = "Generate points";
            GeneratePointsButton.UseVisualStyleBackColor = true;
            GeneratePointsButton.Click += GeneratePointsButton_Click;
            // 
            // numberOfPointsTxt
            // 
            numberOfPointsTxt.Location = new Point(1175, 149);
            numberOfPointsTxt.Name = "numberOfPointsTxt";
            numberOfPointsTxt.Size = new Size(153, 23);
            numberOfPointsTxt.TabIndex = 5;
            // 
            // xFromTxt
            // 
            xFromTxt.Location = new Point(1175, 190);
            xFromTxt.Name = "xFromTxt";
            xFromTxt.Size = new Size(49, 23);
            xFromTxt.TabIndex = 6;
            // 
            // xToTxt
            // 
            xToTxt.Location = new Point(1279, 190);
            xToTxt.Name = "xToTxt";
            xToTxt.Size = new Size(49, 23);
            xToTxt.TabIndex = 7;
            // 
            // yFromTxt
            // 
            yFromTxt.Location = new Point(1175, 239);
            yFromTxt.Name = "yFromTxt";
            yFromTxt.Size = new Size(49, 23);
            yFromTxt.TabIndex = 8;
            // 
            // yToTxt
            // 
            yToTxt.Location = new Point(1279, 239);
            yToTxt.Name = "yToTxt";
            yToTxt.Size = new Size(49, 23);
            yToTxt.TabIndex = 9;
            // 
            // PointsNumberLabel
            // 
            PointsNumberLabel.AutoSize = true;
            PointsNumberLabel.Location = new Point(1068, 157);
            PointsNumberLabel.Name = "PointsNumberLabel";
            PointsNumberLabel.Size = new Size(101, 15);
            PointsNumberLabel.TabIndex = 10;
            PointsNumberLabel.Text = "Number of points";
            // 
            // xFromLable
            // 
            xFromLable.AutoSize = true;
            xFromLable.Location = new Point(1102, 198);
            xFromLable.Name = "xFromLable";
            xFromLable.Size = new Size(45, 15);
            xFromLable.TabIndex = 11;
            xFromLable.Text = "x from ";
            // 
            // yFromLabel
            // 
            yFromLabel.AutoSize = true;
            yFromLabel.Location = new Point(1102, 247);
            yFromLabel.Name = "yFromLabel";
            yFromLabel.Size = new Size(42, 15);
            yFromLabel.TabIndex = 12;
            yFromLabel.Text = "y from";
            // 
            // xToLabel
            // 
            xToLabel.AutoSize = true;
            xToLabel.Location = new Point(1235, 198);
            xToLabel.Name = "xToLabel";
            xToLabel.Size = new Size(18, 15);
            xToLabel.TabIndex = 13;
            xToLabel.Text = "to";
            // 
            // yToLabel
            // 
            yToLabel.AutoSize = true;
            yToLabel.Location = new Point(1235, 247);
            yToLabel.Name = "yToLabel";
            yToLabel.Size = new Size(18, 15);
            yToLabel.TabIndex = 14;
            yToLabel.Text = "to";
            // 
            // SolveButton
            // 
            SolveButton.Location = new Point(1175, 375);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new Size(153, 59);
            SolveButton.TabIndex = 15;
            SolveButton.Text = "Find solution";
            SolveButton.UseVisualStyleBackColor = true;
            SolveButton.Click += SolveButton_Click;
            // 
            // DeleteAllPointsButton
            // 
            DeleteAllPointsButton.Location = new Point(1190, 629);
            DeleteAllPointsButton.Name = "DeleteAllPointsButton";
            DeleteAllPointsButton.Size = new Size(138, 32);
            DeleteAllPointsButton.TabIndex = 16;
            DeleteAllPointsButton.Text = "Delete all points";
            DeleteAllPointsButton.UseVisualStyleBackColor = true;
            DeleteAllPointsButton.Click += DeleteAllPointsButton_Click;
            // 
            // GenerateConvexHullButton
            // 
            GenerateConvexHullButton.Location = new Point(1175, 326);
            GenerateConvexHullButton.Name = "GenerateConvexHullButton";
            GenerateConvexHullButton.Size = new Size(153, 32);
            GenerateConvexHullButton.TabIndex = 17;
            GenerateConvexHullButton.Text = "Generate convex hull";
            GenerateConvexHullButton.UseVisualStyleBackColor = true;
            GenerateConvexHullButton.Click += GenerateConvexHullButton_Click;
            // 
            // testBox
            // 
            testBox.Location = new Point(1175, 462);
            testBox.Name = "testBox";
            testBox.Size = new Size(153, 131);
            testBox.TabIndex = 18;
            testBox.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(testBox);
            Controls.Add(GenerateConvexHullButton);
            Controls.Add(DeleteAllPointsButton);
            Controls.Add(SolveButton);
            Controls.Add(yToLabel);
            Controls.Add(xToLabel);
            Controls.Add(yFromLabel);
            Controls.Add(xFromLable);
            Controls.Add(PointsNumberLabel);
            Controls.Add(yToTxt);
            Controls.Add(yFromTxt);
            Controls.Add(xToTxt);
            Controls.Add(xFromTxt);
            Controls.Add(numberOfPointsTxt);
            Controls.Add(GeneratePointsButton);
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
        private Button GeneratePointsButton;
        private TextBox numberOfPointsTxt;
        private TextBox xFromTxt;
        private TextBox xToTxt;
        private TextBox yFromTxt;
        private TextBox yToTxt;
        private Label PointsNumberLabel;
        private Label xFromLable;
        private Label yFromLabel;
        private Label xToLabel;
        private Label yToLabel;
        private Button SolveButton;
        private Button DeleteAllPointsButton;
        private Button GenerateConvexHullButton;
        private RichTextBox testBox;
    }
}