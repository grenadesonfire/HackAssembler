namespace HackAssembler
{
    partial class AssemblerForm
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
            this.AssemblyTextBox = new System.Windows.Forms.TextBox();
            this.MachineCodeTextBox = new System.Windows.Forms.TextBox();
            this.LoadAssemblyButton = new System.Windows.Forms.Button();
            this.AssembleButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AssemblyTextBox
            // 
            this.AssemblyTextBox.Location = new System.Drawing.Point(12, 12);
            this.AssemblyTextBox.Multiline = true;
            this.AssemblyTextBox.Name = "AssemblyTextBox";
            this.AssemblyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.AssemblyTextBox.Size = new System.Drawing.Size(352, 495);
            this.AssemblyTextBox.TabIndex = 0;
            // 
            // MachineCodeTextBox
            // 
            this.MachineCodeTextBox.Location = new System.Drawing.Point(451, 12);
            this.MachineCodeTextBox.Multiline = true;
            this.MachineCodeTextBox.Name = "MachineCodeTextBox";
            this.MachineCodeTextBox.Size = new System.Drawing.Size(145, 495);
            this.MachineCodeTextBox.TabIndex = 1;
            // 
            // LoadAssemblyButton
            // 
            this.LoadAssemblyButton.Location = new System.Drawing.Point(370, 241);
            this.LoadAssemblyButton.Name = "LoadAssemblyButton";
            this.LoadAssemblyButton.Size = new System.Drawing.Size(75, 23);
            this.LoadAssemblyButton.TabIndex = 2;
            this.LoadAssemblyButton.Text = "Load File";
            this.LoadAssemblyButton.UseVisualStyleBackColor = true;
            this.LoadAssemblyButton.Click += new System.EventHandler(this.LoadAssemblyButton_Click);
            // 
            // AssembleButton
            // 
            this.AssembleButton.Location = new System.Drawing.Point(370, 270);
            this.AssembleButton.Name = "AssembleButton";
            this.AssembleButton.Size = new System.Drawing.Size(75, 23);
            this.AssembleButton.TabIndex = 3;
            this.AssembleButton.Text = "Assemble";
            this.AssembleButton.UseVisualStyleBackColor = true;
            this.AssembleButton.Click += new System.EventHandler(this.AssembleButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(370, 299);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AssemblerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 519);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AssembleButton);
            this.Controls.Add(this.LoadAssemblyButton);
            this.Controls.Add(this.MachineCodeTextBox);
            this.Controls.Add(this.AssemblyTextBox);
            this.Name = "AssemblerForm";
            this.Text = "AssemblerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AssemblyTextBox;
        private System.Windows.Forms.TextBox MachineCodeTextBox;
        private System.Windows.Forms.Button LoadAssemblyButton;
        private System.Windows.Forms.Button AssembleButton;
        private System.Windows.Forms.Button SaveButton;
    }
}