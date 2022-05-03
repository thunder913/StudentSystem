namespace StudentSystemWinForms.MVVM.View
{
    partial class SearchStudentView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.searchResult = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.middleNameBox = new System.Windows.Forms.TextBox();
            this.facultyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.familyBox = new System.Windows.Forms.TextBox();
            this.courseBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.specialtyBox = new System.Windows.Forms.TextBox();
            this.streamBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.phoneNumberBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.facultyNumberBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(36, 34);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(143, 20);
            this.searchBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(197, 29);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(87, 29);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Търси";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // nameBox
            // 
            this.nameBox.Enabled = false;
            this.nameBox.Location = new System.Drawing.Point(305, 114);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(112, 20);
            this.nameBox.TabIndex = 2;
            // 
            // searchResult
            // 
            this.searchResult.HideSelection = false;
            this.searchResult.Location = new System.Drawing.Point(66, 94);
            this.searchResult.Name = "searchResult";
            this.searchResult.Size = new System.Drawing.Size(180, 300);
            this.searchResult.TabIndex = 4;
            this.searchResult.UseCompatibleStateImageBehavior = false;
            this.searchResult.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Име";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Презиме";
            // 
            // middleNameBox
            // 
            this.middleNameBox.Enabled = false;
            this.middleNameBox.Location = new System.Drawing.Point(451, 114);
            this.middleNameBox.Name = "middleNameBox";
            this.middleNameBox.Size = new System.Drawing.Size(112, 20);
            this.middleNameBox.TabIndex = 8;
            // 
            // facultyBox
            // 
            this.facultyBox.Enabled = false;
            this.facultyBox.Location = new System.Drawing.Point(451, 189);
            this.facultyBox.Name = "facultyBox";
            this.facultyBox.Size = new System.Drawing.Size(112, 20);
            this.facultyBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Факултет";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Фамилия";
            // 
            // familyBox
            // 
            this.familyBox.Enabled = false;
            this.familyBox.Location = new System.Drawing.Point(305, 189);
            this.familyBox.Name = "familyBox";
            this.familyBox.Size = new System.Drawing.Size(112, 20);
            this.familyBox.TabIndex = 9;
            // 
            // courseBox
            // 
            this.courseBox.Enabled = false;
            this.courseBox.Location = new System.Drawing.Point(451, 265);
            this.courseBox.Name = "courseBox";
            this.courseBox.Size = new System.Drawing.Size(112, 20);
            this.courseBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Курс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Специалност";
            // 
            // specialtyBox
            // 
            this.specialtyBox.Enabled = false;
            this.specialtyBox.Location = new System.Drawing.Point(305, 265);
            this.specialtyBox.Name = "specialtyBox";
            this.specialtyBox.Size = new System.Drawing.Size(112, 20);
            this.specialtyBox.TabIndex = 13;
            // 
            // streamBox
            // 
            this.streamBox.Enabled = false;
            this.streamBox.Location = new System.Drawing.Point(451, 335);
            this.streamBox.Name = "streamBox";
            this.streamBox.Size = new System.Drawing.Size(112, 20);
            this.streamBox.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Поток";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Група";
            // 
            // groupBox
            // 
            this.groupBox.Enabled = false;
            this.groupBox.Location = new System.Drawing.Point(305, 335);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(112, 20);
            this.groupBox.TabIndex = 17;
            // 
            // emailBox
            // 
            this.emailBox.Enabled = false;
            this.emailBox.Location = new System.Drawing.Point(451, 406);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(112, 20);
            this.emailBox.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(486, 390);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Имейл";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(313, 391);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Телефонен номер";
            // 
            // phoneNumberBox
            // 
            this.phoneNumberBox.Enabled = false;
            this.phoneNumberBox.Location = new System.Drawing.Point(305, 406);
            this.phoneNumberBox.Name = "phoneNumberBox";
            this.phoneNumberBox.Size = new System.Drawing.Size(112, 20);
            this.phoneNumberBox.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(381, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Факултетен Номер";
            // 
            // facultyNumberBox
            // 
            this.facultyNumberBox.Enabled = false;
            this.facultyNumberBox.Location = new System.Drawing.Point(375, 34);
            this.facultyNumberBox.Name = "facultyNumberBox";
            this.facultyNumberBox.Size = new System.Drawing.Size(112, 20);
            this.facultyNumberBox.TabIndex = 25;
            // 
            // SearchStudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.facultyNumberBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.phoneNumberBox);
            this.Controls.Add(this.streamBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.courseBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.specialtyBox);
            this.Controls.Add(this.facultyBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.familyBox);
            this.Controls.Add(this.middleNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchResult);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Name = "SearchStudentView";
            this.Size = new System.Drawing.Size(581, 441);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ListView searchResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox middleNameBox;
        private System.Windows.Forms.TextBox facultyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox familyBox;
        private System.Windows.Forms.TextBox courseBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox specialtyBox;
        private System.Windows.Forms.TextBox streamBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox groupBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox phoneNumberBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox facultyNumberBox;
    }
}
