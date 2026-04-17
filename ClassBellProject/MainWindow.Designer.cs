namespace ClassBellProject
{
    partial class MainWindow
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
            labelWelcome = new Label();
            buttonPrimary = new Button();
            buttonGymnasium = new Button();
            buttonStartEntranceTonePrimary = new Button();
            buttonStartExitTonePrimary = new Button();
            buttonStartEntranceToneGymnasium = new Button();
            buttonStartExitToneGymnasium = new Button();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(343, 51);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(117, 25);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Bine ati venit!";
            // 
            // buttonPrimary
            // 
            buttonPrimary.Location = new Point(143, 112);
            buttonPrimary.Name = "buttonPrimary";
            buttonPrimary.Size = new Size(235, 34);
            buttonPrimary.TabIndex = 1;
            buttonPrimary.Text = "Ciclul primar";
            buttonPrimary.UseVisualStyleBackColor = true;
            buttonPrimary.Click += buttonPrimary_Click;
            // 
            // buttonGymnasium
            // 
            buttonGymnasium.Location = new Point(424, 112);
            buttonGymnasium.Name = "buttonGymnasium";
            buttonGymnasium.Size = new Size(235, 34);
            buttonGymnasium.TabIndex = 2;
            buttonGymnasium.Text = "Ciclul gimnazial";
            buttonGymnasium.UseVisualStyleBackColor = true;
            buttonGymnasium.Click += buttonGymnasium_Click;
            // 
            // buttonStartEntranceTonePrimary
            // 
            buttonStartEntranceTonePrimary.Location = new Point(143, 197);
            buttonStartEntranceTonePrimary.Name = "buttonStartEntranceTonePrimary";
            buttonStartEntranceTonePrimary.Size = new Size(235, 34);
            buttonStartEntranceTonePrimary.TabIndex = 3;
            buttonStartEntranceTonePrimary.Text = "Start Ton Intrare Primar";
            buttonStartEntranceTonePrimary.UseVisualStyleBackColor = true;
            buttonStartEntranceTonePrimary.Click += buttonStartEntranceTonePrimary_Click;
            // 
            // buttonStartExitTonePrimary
            // 
            buttonStartExitTonePrimary.Location = new Point(424, 197);
            buttonStartExitTonePrimary.Name = "buttonStartExitTonePrimary";
            buttonStartExitTonePrimary.Size = new Size(235, 34);
            buttonStartExitTonePrimary.TabIndex = 4;
            buttonStartExitTonePrimary.Text = "Start Ton Iesire Primar";
            buttonStartExitTonePrimary.UseVisualStyleBackColor = true;
            buttonStartExitTonePrimary.Click += buttonStartExitTonePrimary_Click;
            // 
            // buttonStartEntranceToneGymnasium
            // 
            buttonStartEntranceToneGymnasium.Location = new Point(143, 288);
            buttonStartEntranceToneGymnasium.Name = "buttonStartEntranceToneGymnasium";
            buttonStartEntranceToneGymnasium.Size = new Size(235, 34);
            buttonStartEntranceToneGymnasium.TabIndex = 5;
            buttonStartEntranceToneGymnasium.Text = "Start Ton Intrare Gimnaziu";
            buttonStartEntranceToneGymnasium.UseVisualStyleBackColor = true;
            buttonStartEntranceToneGymnasium.Click += buttonStartEntranceToneGymnasium_Click;
            // 
            // buttonStartExitToneGymnasium
            // 
            buttonStartExitToneGymnasium.Location = new Point(424, 288);
            buttonStartExitToneGymnasium.Name = "buttonStartExitToneGymnasium";
            buttonStartExitToneGymnasium.Size = new Size(235, 34);
            buttonStartExitToneGymnasium.TabIndex = 6;
            buttonStartExitToneGymnasium.Text = "Start Ton Iesire Gimnaziu";
            buttonStartExitToneGymnasium.UseVisualStyleBackColor = true;
            buttonStartExitToneGymnasium.Click += buttonStartExitToneGymnasium_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 450);
            Controls.Add(buttonStartExitToneGymnasium);
            Controls.Add(buttonStartEntranceToneGymnasium);
            Controls.Add(buttonStartExitTonePrimary);
            Controls.Add(buttonStartEntranceTonePrimary);
            Controls.Add(buttonGymnasium);
            Controls.Add(buttonPrimary);
            Controls.Add(labelWelcome);
            Name = "MainWindow";
            Text = "MainWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Button buttonPrimary;
        private Button buttonGymnasium;
        private Button buttonStartEntranceTonePrimary;
        private Button buttonStartExitTonePrimary;
        private Button buttonStartEntranceToneGymnasium;
        private Button buttonStartExitToneGymnasium;
    }
}
