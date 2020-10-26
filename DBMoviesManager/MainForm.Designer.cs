﻿namespace DBMoviesManager
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
            this.searchLabel = new System.Windows.Forms.Label();
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveExitButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.dobTextBox = new System.Windows.Forms.TextBox();
            this.ypeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.memberLabel = new System.Windows.Forms.Label();
            this.memberComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.addLabel = new System.Windows.Forms.Label();
            this.addComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchLabel.Location = new System.Drawing.Point(544, 483);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(152, 17);
            this.searchLabel.TabIndex = 77;
            this.searchLabel.Text = "Search movie by name";
            // 
            // movieListView
            // 
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(538, 54);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(434, 400);
            this.movieListView.TabIndex = 76;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(806, 476);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 31);
            this.searchButton.TabIndex = 75;
            this.searchButton.Text = "Search movie";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(538, 480);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(262, 22);
            this.searchTextBox.TabIndex = 74;
            // 
            // showGenreComboBox
            // 
            this.showGenreComboBox.FormattingEnabled = true;
            this.showGenreComboBox.Items.AddRange(new object[] {
            "All",
            "Drama",
            "Action",
            "Camedy",
            "Family",
            "Animation",
            "History",
            "Adventure"});
            this.showGenreComboBox.Location = new System.Drawing.Point(826, 15);
            this.showGenreComboBox.Name = "showGenreComboBox";
            this.showGenreComboBox.Size = new System.Drawing.Size(146, 24);
            this.showGenreComboBox.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(768, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Genre:";
            // 
            // deleteMovieButton
            // 
            this.deleteMovieButton.Location = new System.Drawing.Point(105, 388);
            this.deleteMovieButton.Name = "deleteMovieButton";
            this.deleteMovieButton.Size = new System.Drawing.Size(146, 33);
            this.deleteMovieButton.TabIndex = 55;
            this.deleteMovieButton.Text = "Delete";
            this.deleteMovieButton.UseVisualStyleBackColor = true;
            // 
            // modifyMovieButton
            // 
            this.modifyMovieButton.Location = new System.Drawing.Point(105, 348);
            this.modifyMovieButton.Name = "modifyMovieButton";
            this.modifyMovieButton.Size = new System.Drawing.Size(146, 34);
            this.modifyMovieButton.TabIndex = 54;
            this.modifyMovieButton.Text = "Modify";
            this.modifyMovieButton.UseVisualStyleBackColor = true;
            // 
            // addMovieButton
            // 
            this.addMovieButton.Location = new System.Drawing.Point(105, 309);
            this.addMovieButton.Name = "addMovieButton";
            this.addMovieButton.Size = new System.Drawing.Size(146, 33);
            this.addMovieButton.TabIndex = 53;
            this.addMovieButton.Text = "Add new movie";
            this.addMovieButton.UseVisualStyleBackColor = true;
            // 
            // showMemberComboBox
            // 
            this.showMemberComboBox.FormattingEnabled = true;
            this.showMemberComboBox.Items.AddRange(new object[] {
            "Drama",
            "Action",
            "Comedy",
            "Family",
            "Horror",
            "All"});
            this.showMemberComboBox.Location = new System.Drawing.Point(602, 15);
            this.showMemberComboBox.Name = "showMemberComboBox";
            this.showMemberComboBox.Size = new System.Drawing.Size(146, 24);
            this.showMemberComboBox.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 98;
            this.label4.Text = "Member:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(28, 96);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(39, 17);
            this.titleLabel.TabIndex = 57;
            this.titleLabel.Text = "Title:";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(28, 131);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(42, 17);
            this.yearLabel.TabIndex = 58;
            this.yearLabel.Text = "Year:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(19, 168);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(67, 34);
            this.lengthLabel.TabIndex = 59;
            this.lengthLabel.Text = "Length:\r\n(minutes)";
            this.lengthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(27, 207);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(53, 17);
            this.ratingLabel.TabIndex = 61;
            this.ratingLabel.Text = "Rating:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(105, 93);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(146, 22);
            this.titleTextBox.TabIndex = 64;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(105, 131);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(146, 22);
            this.yearTextBox.TabIndex = 65;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(105, 168);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(146, 22);
            this.lengthTextBox.TabIndex = 66;
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.Location = new System.Drawing.Point(105, 204);
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.Size = new System.Drawing.Size(146, 22);
            this.ratingTextBox.TabIndex = 68;
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(27, 243);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(50, 17);
            this.imageLabel.TabIndex = 70;
            this.imageLabel.Text = "Image:\r";
            this.imageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageTextBox
            // 
            this.imageTextBox.Location = new System.Drawing.Point(105, 241);
            this.imageTextBox.Name = "imageTextBox";
            this.imageTextBox.Size = new System.Drawing.Size(146, 22);
            this.imageTextBox.TabIndex = 71;
            // 
            // addMemberButton
            // 
            this.addMemberButton.Location = new System.Drawing.Point(357, 309);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(146, 33);
            this.addMemberButton.TabIndex = 78;
            this.addMemberButton.Text = "Add new member";
            this.addMemberButton.UseVisualStyleBackColor = true;
            // 
            // modifyMemberButton
            // 
            this.modifyMemberButton.Location = new System.Drawing.Point(357, 348);
            this.modifyMemberButton.Name = "modifyMemberButton";
            this.modifyMemberButton.Size = new System.Drawing.Size(146, 34);
            this.modifyMemberButton.TabIndex = 79;
            this.modifyMemberButton.Text = "Modify";
            this.modifyMemberButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(357, 388);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(146, 33);
            this.deleteButton.TabIndex = 80;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveExitButton
            // 
            this.saveExitButton.Location = new System.Drawing.Point(1149, 469);
            this.saveExitButton.Name = "saveExitButton";
            this.saveExitButton.Size = new System.Drawing.Size(146, 31);
            this.saveExitButton.TabIndex = 81;
            this.saveExitButton.Text = "Save and exit";
            this.saveExitButton.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(280, 96);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 82;
            this.nameLabel.Text = "Name:";
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Location = new System.Drawing.Point(276, 127);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(56, 34);
            this.dobLabel.TabIndex = 83;
            this.dobLabel.Text = "Date\r\nof birth:";
            this.dobLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(357, 93);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(146, 22);
            this.nameTextBox.TabIndex = 87;
            // 
            // dobTextBox
            // 
            this.dobTextBox.Location = new System.Drawing.Point(357, 131);
            this.dobTextBox.Name = "dobTextBox";
            this.dobTextBox.Size = new System.Drawing.Size(146, 22);
            this.dobTextBox.TabIndex = 88;
            // 
            // ypeLabel
            // 
            this.ypeLabel.AutoSize = true;
            this.ypeLabel.Location = new System.Drawing.Point(280, 168);
            this.ypeLabel.Name = "ypeLabel";
            this.ypeLabel.Size = new System.Drawing.Size(44, 17);
            this.ypeLabel.TabIndex = 94;
            this.ypeLabel.Text = "Type:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Actor",
            "Director",
            "Producer",
            "Director of photography"});
            this.typeComboBox.Location = new System.Drawing.Point(357, 165);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(146, 24);
            this.typeComboBox.TabIndex = 95;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(28, 57);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(52, 17);
            this.genreLabel.TabIndex = 96;
            this.genreLabel.Text = "Genre:";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Items.AddRange(new object[] {
            "Drama",
            "Action",
            "Comedy",
            "Family",
            "Animation",
            "History",
            "Adventure"});
            this.genreComboBox.Location = new System.Drawing.Point(105, 54);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(146, 24);
            this.genreComboBox.TabIndex = 97;
            // 
            // memberLabel
            // 
            this.memberLabel.AutoSize = true;
            this.memberLabel.Location = new System.Drawing.Point(28, 277);
            this.memberLabel.Name = "memberLabel";
            this.memberLabel.Size = new System.Drawing.Size(63, 17);
            this.memberLabel.TabIndex = 100;
            this.memberLabel.Text = "Member:";
            // 
            // memberComboBox
            // 
            this.memberComboBox.FormattingEnabled = true;
            this.memberComboBox.Items.AddRange(new object[] {
            "Drama",
            "Action",
            "Comedy",
            "Family",
            "Horror",
            "All"});
            this.memberComboBox.Location = new System.Drawing.Point(105, 274);
            this.memberComboBox.Name = "memberComboBox";
            this.memberComboBox.Size = new System.Drawing.Size(146, 24);
            this.memberComboBox.TabIndex = 101;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(995, 54);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 102;
            this.pictureBox.TabStop = false;
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(28, 18);
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
            "Member"});
            this.addComboBox.Location = new System.Drawing.Point(105, 15);
            this.addComboBox.Name = "addComboBox";
            this.addComboBox.Size = new System.Drawing.Size(146, 24);
            this.addComboBox.TabIndex = 73;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 513);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.memberComboBox);
            this.Controls.Add(this.memberLabel);
            this.Controls.Add(this.showMemberComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.ypeLabel);
            this.Controls.Add(this.dobTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.saveExitButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.modifyMemberButton);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.searchLabel);
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
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchLabel;
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
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveExitButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox dobTextBox;
        private System.Windows.Forms.Label ypeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label memberLabel;
        private System.Windows.Forms.ComboBox memberComboBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.ComboBox addComboBox;
    }
}
