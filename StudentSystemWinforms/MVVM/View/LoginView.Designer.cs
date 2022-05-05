using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using StudentSystemWinForms.Models;

namespace StudentSystemWinForms.Views
{
    partial class LoginView
    {
        #region Designer Created
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;             // When doing this properly, you would want to make a collection of your components within this UserControl.

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordSuggestionBox = new System.Windows.Forms.Integration.ElementHost();
            this.suggestTextBox2 = new StudentSystemCommon.Controls.SuggestTextBox();
            this.usernameSuggestionBox = new System.Windows.Forms.Integration.ElementHost();
            this.suggestTextBox1 = new StudentSystemCommon.Controls.SuggestTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Студентска Система";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Потребителско име";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Парола";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(378, 166);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(116, 38);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Влез";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(378, 288);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(116, 38);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "Регистрирай се";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ако нямаш акаунт";
            // 
            // passwordSuggestionBox
            // 
            this.passwordSuggestionBox.Location = new System.Drawing.Point(357, 105);
            this.passwordSuggestionBox.Name = "passwordSuggestionBox";
            this.passwordSuggestionBox.Size = new System.Drawing.Size(159, 26);
            this.passwordSuggestionBox.TabIndex = 9;
            this.passwordSuggestionBox.Text = "elementHost1";
            this.passwordSuggestionBox.Child = this.suggestTextBox2;
            // 
            // usernameSuggestionBox
            // 
            this.usernameSuggestionBox.Location = new System.Drawing.Point(357, 77);
            this.usernameSuggestionBox.Name = "usernameSuggestionBox";
            this.usernameSuggestionBox.Size = new System.Drawing.Size(159, 22);
            this.usernameSuggestionBox.TabIndex = 8;
            this.usernameSuggestionBox.Text = "elementHost1";
            this.usernameSuggestionBox.Child = this.suggestTextBox1;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.passwordSuggestionBox);
            this.Controls.Add(this.usernameSuggestionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(736, 471);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label1;
        #endregion

        private Label label2;
        private Label label3;
        private Button loginButton;
        private Button registerButton;
        private Label label4;
        private System.Windows.Forms.Integration.ElementHost usernameSuggestionBox;
        private StudentSystemCommon.Controls.SuggestTextBox suggestTextBox1;
        private System.Windows.Forms.Integration.ElementHost passwordSuggestionBox;
        private StudentSystemCommon.Controls.SuggestTextBox suggestTextBox2;
    }
}
