namespace WellboreVolume
{
    partial class WellboreForm
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
            components = new System.ComponentModel.Container();
            calculateButton = new Button();
            resultLabel = new Label();
            dataAtDepthBindingSource = new BindingSource(components);
            dataLoaderBindingSource = new BindingSource(components);
            dataAtDepthBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataAtDepthBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLoaderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataAtDepthBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(12, 12);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(130, 23);
            calculateButton.TabIndex = 1;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.Location = new Point(12, 48);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(776, 19);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "Volume (m3): ";
            // 
            // dataAtDepthBindingSource
            // 
            dataAtDepthBindingSource.DataSource = typeof(BoreholeVolume.Data.DataAtDepth);
            // 
            // dataLoaderBindingSource
            // 
            dataLoaderBindingSource.DataSource = typeof(BoreholeVolume.DataLoader);
            // 
            // dataAtDepthBindingSource1
            // 
            dataAtDepthBindingSource1.DataSource = typeof(BoreholeVolume.Data.DataAtDepth);
            // 
            // WellboreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultLabel);
            Controls.Add(calculateButton);
            Name = "WellboreForm";
            Text = "Borehole Volume";
            ((System.ComponentModel.ISupportInitialize)dataAtDepthBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLoaderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataAtDepthBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button calculateButton;
        private Label resultLabel;
        private BindingSource dataLoaderBindingSource;
        private BindingSource dataAtDepthBindingSource;
        private BindingSource dataAtDepthBindingSource1;
    }
}