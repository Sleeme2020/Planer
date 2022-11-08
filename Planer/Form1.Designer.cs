namespace Planer
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Mon = new System.Windows.Forms.ColumnHeader();
            this.Tue = new System.Windows.Forms.ColumnHeader();
            this.Wed = new System.Windows.Forms.ColumnHeader();
            this.Th = new System.Windows.Forms.ColumnHeader();
            this.Fr = new System.Windows.Forms.ColumnHeader();
            this.Sat = new System.Windows.Forms.ColumnHeader();
            this.Sun = new System.Windows.Forms.ColumnHeader();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Mon,
            this.Tue,
            this.Wed,
            this.Th,
            this.Fr,
            this.Sat,
            this.Sun});
            this.listView1.Location = new System.Drawing.Point(12, 185);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1057, 348);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Mon
            // 
            this.Mon.Text = "Понедельник";
            this.Mon.Width = 151;
            // 
            // Tue
            // 
            this.Tue.Text = "Вторник";
            this.Tue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tue.Width = 151;
            // 
            // Wed
            // 
            this.Wed.Text = "Среда";
            this.Wed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Wed.Width = 151;
            // 
            // Th
            // 
            this.Th.Text = "Четверг";
            this.Th.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Th.Width = 151;
            // 
            // Fr
            // 
            this.Fr.Text = "Пятница";
            this.Fr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Fr.Width = 151;
            // 
            // Sat
            // 
            this.Sat.Text = "Суббота";
            this.Sat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sat.Width = 151;
            // 
            // Sun
            // 
            this.Sun.Text = "Воскресение";
            this.Sun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sun.Width = 151;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(3, 1);
            this.monthCalendar1.MaxSelectionCount = 30;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ScrollChange = 1;
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.Red;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(336, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(733, 148);
            this.checkedListBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать Событие";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 51);
            this.button2.TabIndex = 7;
            this.button2.Text = "Добавить чек поинт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 578);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader Mon;
        private ColumnHeader Tue;
        private ColumnHeader Wed;
        private ColumnHeader Th;
        private ColumnHeader Fr;
        private ColumnHeader Sat;
        private ColumnHeader Sun;
        private MonthCalendar monthCalendar1;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Button button2;
    }
}