namespace OcrFromScreenShot
{
    partial class Home
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
            button1 = new Button();
            TextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1, 2);
            button1.Name = "button1";
            button1.Size = new Size(303, 62);
            button1.TabIndex = 0;
            button1.Text = "PrintScreen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TextBox
            // 
            TextBox.Location = new Point(1, 84);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.Size = new Size(310, 253);
            TextBox.TabIndex = 1;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 338);
            Controls.Add(TextBox);
            Controls.Add(button1);
            Name = "Home";
            Text = "Form1";
            Resize += On_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox TextBox;
    }
}