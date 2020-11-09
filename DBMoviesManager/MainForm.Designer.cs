namespace DBMoviesManager
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
            this.movieListView = new System.Windows.Forms.ListView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.showGenreComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deleteMovieButton = new System.Windows.Forms.Button();
            this.modifyMovieButton = new System.Windows.Forms.Button();
            this.addMovieButton = new System.Windows.Forms.Button();
            this.showMemberComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.ratingTextBox = new System.Windows.Forms.TextBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imageTextBox = new System.Windows.Forms.TextBox();
            this.addMemberButton = new System.Windows.Forms.Button();
            this.modifyMemberButton = new System.Windows.Forms.Button();
            this.deleteMemberButton = new System.Windows.Forms.Button();
            this.memberNameLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.memberNameTextBox = new System.Windows.Forms.TextBox();
            this.dobTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.addLabel = new System.Windows.Forms.Label();
            this.addComboBox = new System.Windows.Forms.ComboBox();
            this.genreNameTextBox = new System.Windows.Forms.TextBox();
            this.genreNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.deleteGenreButton = new System.Windows.Forms.Button();
            this.modifyGenreButton = new System.Windows.Forms.Button();
            this.addGenreButton = new System.Windows.Forms.Button();
            this.genreListBox = new System.Windows.Forms.ListBox();
            this.memberListBox = new System.Windows.Forms.ListBox();
            this.memberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // movieListView
            // 
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(491, 54);
            this.movieListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(433, 400);
            this.movieListView.TabIndex = 76;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            this.movieListView.SelectedIndexChanged += new System.EventHandler(this.MovieListView_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(757, 476);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 31);
            this.searchButton.TabIndex = 75;
            this.searchButton.Text = "Search movie";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(491, 480);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(263, 22);
            this.searchTextBox.TabIndex = 74;
            this.searchTextBox.Text = "Search movie by name";
            this.searchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            // 
            // showGenreComboBox
            // 
            this.showGenreComboBox.FormattingEnabled = true;
            this.showGenreComboBox.Location = new System.Drawing.Point(779, 15);
            this.showGenreComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showGenreComboBox.Name = "showGenreComboBox";
            this.showGenreComboBox.Size = new System.Drawing.Size(145, 24);
            this.showGenreComboBox.TabIndex = 63;
            this.showGenreComboBox.SelectedIndexChanged += new System.EventHandler(this.showGenreComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(720, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Genre:";
            // 
            // deleteMovieButton
            // 
            this.deleteMovieButton.Location = new System.Drawing.Point(89, 453);
            this.deleteMovieButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteMovieButton.Name = "deleteMovieButton";
            this.deleteMovieButton.Size = new System.Drawing.Size(147, 33);
            this.deleteMovieButton.TabIndex = 55;
            this.deleteMovieButton.Text = "Delete";
            this.deleteMovieButton.UseVisualStyleBackColor = true;
            this.deleteMovieButton.Click += new System.EventHandler(this.DeleteMovieButton_Click);
            // 
            // modifyMovieButton
            // 
            this.modifyMovieButton.Location = new System.Drawing.Point(89, 414);
            this.modifyMovieButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modifyMovieButton.Name = "modifyMovieButton";
            this.modifyMovieButton.Size = new System.Drawing.Size(147, 34);
            this.modifyMovieButton.TabIndex = 54;
            this.modifyMovieButton.Text = "Modify";
            this.modifyMovieButton.UseVisualStyleBackColor = true;
            this.modifyMovieButton.Click += new System.EventHandler(this.ModifyMovieButton_Click);
            // 
            // addMovieButton
            // 
            this.addMovieButton.Location = new System.Drawing.Point(89, 374);
            this.addMovieButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addMovieButton.Name = "addMovieButton";
            this.addMovieButton.Size = new System.Drawing.Size(147, 33);
            this.addMovieButton.TabIndex = 53;
            this.addMovieButton.Text = "Add new movie";
            this.addMovieButton.UseVisualStyleBackColor = true;
            this.addMovieButton.Click += new System.EventHandler(this.AddMovieButton_Click);
            // 
            // showMemberComboBox
            // 
            this.showMemberComboBox.FormattingEnabled = true;
            this.showMemberComboBox.Location = new System.Drawing.Point(555, 15);
            this.showMemberComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showMemberComboBox.Name = "showMemberComboBox";
            this.showMemberComboBox.Size = new System.Drawing.Size(145, 24);
            this.showMemberComboBox.TabIndex = 99;
            this.showMemberComboBox.SelectedIndexChanged += new System.EventHandler(this.ShowMemberComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 98;
            this.label4.Text = "Member:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(13, 118);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(39, 17);
            this.titleLabel.TabIndex = 57;
            this.titleLabel.Text = "Title:";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(13, 153);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(42, 17);
            this.yearLabel.TabIndex = 58;
            this.yearLabel.Text = "Year:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(5, 190);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(67, 34);
            this.lengthLabel.TabIndex = 59;
            this.lengthLabel.Text = "Length:\r\n(minutes)";
            this.lengthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(13, 229);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(53, 17);
            this.ratingLabel.TabIndex = 61;
            this.ratingLabel.Text = "Rating:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(89, 116);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(147, 22);
            this.titleTextBox.TabIndex = 64;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(89, 153);
            this.yearTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(147, 22);
            this.yearTextBox.TabIndex = 65;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(89, 190);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(147, 22);
            this.lengthTextBox.TabIndex = 66;
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new System.Drawing.Point(89, 227);
            this.ratingTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new System.Drawing.Size(147, 22);
            this.ratingTextBox.TabIndex = 68;
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(13, 265);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(50, 17);
            this.imageLabel.TabIndex = 70;
            this.imageLabel.Text = "Image:\r";
            this.imageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageTextBox
            // 
            this.imageTextBox.Location = new System.Drawing.Point(89, 263);
            this.imageTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageTextBox.Name = "imageTextBox";
            this.imageTextBox.Size = new System.Drawing.Size(147, 22);
            this.imageTextBox.TabIndex = 71;
            // 
            // addMemberButton
            // 
            this.addMemberButton.Location = new System.Drawing.Point(328, 158);
            this.addMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(147, 33);
            this.addMemberButton.TabIndex = 78;
            this.addMemberButton.Text = "Add new member";
            this.addMemberButton.UseVisualStyleBackColor = true;
            this.addMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // modifyMemberButton
            // 
            this.modifyMemberButton.Location = new System.Drawing.Point(328, 196);
            this.modifyMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modifyMemberButton.Name = "modifyMemberButton";
            this.modifyMemberButton.Size = new System.Drawing.Size(147, 34);
            this.modifyMemberButton.TabIndex = 79;
            this.modifyMemberButton.Text = "Modify";
            this.modifyMemberButton.UseVisualStyleBackColor = true;
            this.modifyMemberButton.Click += new System.EventHandler(this.ModifyMemberButton_Click);
            // 
            // deleteMemberButton
            // 
            this.deleteMemberButton.Location = new System.Drawing.Point(328, 236);
            this.deleteMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteMemberButton.Name = "deleteMemberButton";
            this.deleteMemberButton.Size = new System.Drawing.Size(147, 33);
            this.deleteMemberButton.TabIndex = 80;
            this.deleteMemberButton.Text = "Delete";
            this.deleteMemberButton.UseVisualStyleBackColor = true;
            this.deleteMemberButton.Click += new System.EventHandler(this.DeleteMemberButton_Click);
            // 
            // memberNameLabel
            // 
            this.memberNameLabel.AutoSize = true;
            this.memberNameLabel.Location = new System.Drawing.Point(251, 57);
            this.memberNameLabel.Name = "memberNameLabel";
            this.memberNameLabel.Size = new System.Drawing.Size(49, 17);
            this.memberNameLabel.TabIndex = 82;
            this.memberNameLabel.Text = "Name:";
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Location = new System.Drawing.Point(247, 89);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(56, 34);
            this.dobLabel.TabIndex = 83;
            this.dobLabel.Text = "Date\r\nof birth:";
            this.dobLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // memberNameTextBox
            // 
            this.memberNameTextBox.Location = new System.Drawing.Point(328, 54);
            this.memberNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memberNameTextBox.Name = "memberNameTextBox";
            this.memberNameTextBox.Size = new System.Drawing.Size(145, 22);
            this.memberNameTextBox.TabIndex = 87;
            // 
            // dobTextBox
            // 
            this.dobTextBox.Location = new System.Drawing.Point(328, 92);
            this.dobTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dobTextBox.Name = "dobTextBox";
            this.dobTextBox.Size = new System.Drawing.Size(145, 22);
            this.dobTextBox.TabIndex = 88;
            this.dobTextBox.Text = "mm/dd/yyyy";
            this.dobTextBox.Click += new System.EventHandler(this.DobTextBox_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(251, 129);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(44, 17);
            this.typeLabel.TabIndex = 94;
            this.typeLabel.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Actor",
            "Director",
            "Producer",
            "Director of photography"});
            this.typeComboBox.Location = new System.Drawing.Point(328, 126);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(145, 24);
            this.typeComboBox.TabIndex = 95;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(13, 45);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(52, 17);
            this.genreLabel.TabIndex = 96;
            this.genreLabel.Text = "Genre:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(948, 54);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 102;
            this.pictureBox.TabStop = false;
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(13, 18);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(37, 17);
            this.addLabel.TabIndex = 72;
            this.addLabel.Text = "Add:";
            // 
            // addComboBox
            // 
            this.addComboBox.FormattingEnabled = true;
            this.addComboBox.Items.AddRange(new object[] {
            "Movie",
            "Member",
            "Genre"});
            this.addComboBox.Location = new System.Drawing.Point(89, 15);
            this.addComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addComboBox.Name = "addComboBox";
            this.addComboBox.Size = new System.Drawing.Size(147, 24);
            this.addComboBox.TabIndex = 73;
            this.addComboBox.SelectedIndexChanged += new System.EventHandler(this.AddComboBox_SelectedIndexChanged);
            // 
            // genreNameTextBox
            // 
            this.genreNameTextBox.Location = new System.Drawing.Point(328, 277);
            this.genreNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.genreNameTextBox.Name = "genreNameTextBox";
            this.genreNameTextBox.Size = new System.Drawing.Size(145, 22);
            this.genreNameTextBox.TabIndex = 105;
            // 
            // genreNameLabel
            // 
            this.genreNameLabel.AutoSize = true;
            this.genreNameLabel.Location = new System.Drawing.Point(251, 281);
            this.genreNameLabel.Name = "genreNameLabel";
            this.genreNameLabel.Size = new System.Drawing.Size(49, 17);
            this.genreNameLabel.TabIndex = 103;
            this.genreNameLabel.Text = "Name:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(239, 318);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(83, 17);
            this.descriptionLabel.TabIndex = 104;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(328, 315);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(145, 22);
            this.descriptionTextBox.TabIndex = 106;
            // 
            // deleteGenreButton
            // 
            this.deleteGenreButton.Location = new System.Drawing.Point(328, 428);
            this.deleteGenreButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteGenreButton.Name = "deleteGenreButton";
            this.deleteGenreButton.Size = new System.Drawing.Size(147, 33);
            this.deleteGenreButton.TabIndex = 109;
            this.deleteGenreButton.Text = "Delete";
            this.deleteGenreButton.UseVisualStyleBackColor = true;
            this.deleteGenreButton.Click += new System.EventHandler(this.deleteGenreButton_Click);
            // 
            // modifyGenreButton
            // 
            this.modifyGenreButton.Location = new System.Drawing.Point(328, 388);
            this.modifyGenreButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modifyGenreButton.Name = "modifyGenreButton";
            this.modifyGenreButton.Size = new System.Drawing.Size(147, 34);
            this.modifyGenreButton.TabIndex = 108;
            this.modifyGenreButton.Text = "Modify";
            this.modifyGenreButton.UseVisualStyleBackColor = true;
            this.modifyGenreButton.Click += new System.EventHandler(this.modifyGenreButton_Click);
            // 
            // addGenreButton
            // 
            this.addGenreButton.Location = new System.Drawing.Point(328, 350);
            this.addGenreButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addGenreButton.Name = "addGenreButton";
            this.addGenreButton.Size = new System.Drawing.Size(147, 33);
            this.addGenreButton.TabIndex = 107;
            this.addGenreButton.Text = "Add new genre";
            this.addGenreButton.UseVisualStyleBackColor = true;
            this.addGenreButton.Click += new System.EventHandler(this.addGenreButton_Click);
            // 
            // genreListBox
            // 
            this.genreListBox.FormattingEnabled = true;
            this.genreListBox.ItemHeight = 16;
            this.genreListBox.Location = new System.Drawing.Point(89, 54);
            this.genreListBox.Margin = new System.Windows.Forms.Padding(4);
            this.genreListBox.Name = "genreListBox";
            this.genreListBox.Size = new System.Drawing.Size(147, 52);
            this.genreListBox.TabIndex = 111;
            this.genreListBox.Click += new System.EventHandler(this.genreListBox_Click);
            // 
            // memberListBox
            // 
            this.memberListBox.FormattingEnabled = true;
            this.memberListBox.ItemHeight = 16;
            this.memberListBox.Location = new System.Drawing.Point(89, 303);
            this.memberListBox.Margin = new System.Windows.Forms.Padding(4);
            this.memberListBox.Name = "memberListBox";
            this.memberListBox.Size = new System.Drawing.Size(147, 52);
            this.memberListBox.TabIndex = 112;
            this.memberListBox.Click += new System.EventHandler(this.MemberListBox_Click);
            // 
            // memberLabel
            // 
            this.memberLabel.AutoSize = true;
            this.memberLabel.Location = new System.Drawing.Point(11, 306);
            this.memberLabel.Name = "memberLabel";
            this.memberLabel.Size = new System.Drawing.Size(63, 17);
            this.memberLabel.TabIndex = 113;
            this.memberLabel.Text = "Member:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 513);
            this.Controls.Add(this.memberLabel);
            this.Controls.Add(this.memberListBox);
            this.Controls.Add(this.genreListBox);
            this.Controls.Add(this.deleteGenreButton);
            this.Controls.Add(this.modifyGenreButton);
            this.Controls.Add(this.addGenreButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.genreNameTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.genreNameLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.showMemberComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.dobTextBox);
            this.Controls.Add(this.memberNameTextBox);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.memberNameLabel);
            this.Controls.Add(this.deleteMemberButton);
            this.Controls.Add(this.modifyMemberButton);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.movieListView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.addComboBox);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.imageTextBox);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.ratingTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.showGenreComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.deleteMovieButton);
            this.Controls.Add(this.modifyMovieButton);
            this.Controls.Add(this.addMovieButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox showGenreComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button deleteMovieButton;
        private System.Windows.Forms.Button modifyMovieButton;
        private System.Windows.Forms.Button addMovieButton;
        private System.Windows.Forms.ComboBox showMemberComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox ratingTextBox;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.TextBox imageTextBox;
        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.Button modifyMemberButton;
        private System.Windows.Forms.Button deleteMemberButton;
        private System.Windows.Forms.Label memberNameLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.TextBox memberNameTextBox;
        private System.Windows.Forms.TextBox dobTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.ComboBox addComboBox;
        private System.Windows.Forms.TextBox genreNameTextBox;
        private System.Windows.Forms.Label genreNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button deleteGenreButton;
        private System.Windows.Forms.Button modifyGenreButton;
        private System.Windows.Forms.Button addGenreButton;
        private System.Windows.Forms.ListBox genreListBox;
        private System.Windows.Forms.ListBox memberListBox;
        private System.Windows.Forms.Label memberLabel;
    }
}

