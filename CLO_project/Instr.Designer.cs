
namespace CLO_project
{
    partial class Instr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instr));
            this.Instruction = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Instruction
            // 
            this.Instruction.Location = new System.Drawing.Point(0, 0);
            this.Instruction.Name = "Instruction";
            this.Instruction.ReadOnly = true;
            this.Instruction.Size = new System.Drawing.Size(788, 438);
            this.Instruction.TabIndex = 0;
            this.Instruction.Text = "";
            // 
            // Instr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 422);
            this.Controls.Add(this.Instruction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 460);
            this.MinimumSize = new System.Drawing.Size(800, 460);
            this.Name = "Instr";
            this.Text = "Руководство к конфигуратору CLO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Instruction;
    }
}