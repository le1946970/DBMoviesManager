﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBMoviesManager
{
    public partial class MainForm : Form
    {
        NpgsqlConnection dbConnection;

        //Create constants for the lowest and highest possible year and rating
        const int LowerYear = 1888;
        const int UpperYear = 2020;
        const int LowerRating = 1;
        const int UpperRating = 5;
        //Constants for the database
        private const string DatabaseHost = "localhost";
        private const string DatabaseUser = "postgres";
        private const string DatabasePassword = "bmc";
        private const string DatabaseName = "moviedb";

        //  Declare Lists for each of the following
        List<Movie> movieList = new List<Movie>();
        List<Genre> genreList = new List<Genre>();
        List<Member> memberList = new List<Member>();


        //Create a new Movie object
        Movie currentMovie = new Movie();


        public MainForm()
        {
            InitializeComponent();

            MakeGenreInvisible();
            MakeMemberInvisible();
            MakeMovieInvisible();
            showGenreComboBox.Text = "All";

            //This method sets up a connection to a Postgres database and recieves information
            CreateDBConnection(DatabaseHost, DatabaseUser, DatabasePassword, DatabaseName);
            GetMoviesFromDB();
            GetGenresFromDB();
            GetMembersFromDB();

        }

        /// <summary>
        /// This method setsup a db connection to a postgreSQL db. The connection is stored in the global variable 'dbConnection'
        /// </summary>
        /// <param name="serverAddress">The server name or IP address</param>
        /// <param name="username">The username having the right to manipulate the db</param>
        /// <param name="password">The corresponding password of the user</param>
        /// <param name="dbName">The db to connect to</param>
        /// <returns></returns>
        private NpgsqlConnection CreateDBConnection(string serverAddress, string username, string password, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + password + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);

            return dbConnection;
        }

        /// <summary>
        /// Method to recieve all of the movies and their corresponding information within the database.
        /// </summary>
        /// <returns>Returns a list of total movies</returns>
        private List<Movie> GetMoviesFromDB()
        {
            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();


            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM moviedbschema.movie;";
            Console.WriteLine("SQL Query: " + sqlQuery);


            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            movieListView.View = View.Details;          //Set the view to show details.
            movieListView.FullRowSelect = true;         //Select the item and subitems when selection is made.

            movieListView.Columns.Add("Title");         //Add column Title
            movieListView.Columns.Add("Year");         //Add column Year
            movieListView.Columns.Add("Length");         //Add column Length

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new Movie and setup its info
                currentMovie = new Movie();

                currentMovie.ID = dataReader.GetInt32(0);
                currentMovie.Title = dataReader.GetString(1);
                currentMovie.Year = dataReader.GetInt32(2);
                currentMovie.Length = dataReader.GetTimeSpan(3).ToString();
                currentMovie.Rating = dataReader.GetDouble(4);
                currentMovie.Image = dataReader.GetString(5);

                currentMovie.Genre = AssignGenresFromDB(currentMovie.ID);
                currentMovie.Member = AssignMemberFromDB(currentMovie.ID);

                movieList.Add(currentMovie);

                movieListView.Items.Add(new ListViewItem(new string[] { currentMovie.Title, currentMovie.Year.ToString(), currentMovie.Length.ToString() }));
                //Resize the headers so we will see al the content without having to resize it
                movieListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                movieListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return movieList;
        }

        /// <summary>
        /// Grabs all of the genres available within the database.
        /// </summary>
        /// <returns>Returns a list of the different genres that are present within movies.</returns>
        private List<Genre> GetGenresFromDB()
        {
            List<Genre> currentGenreList = new List<Genre>();
            Genre currentGenre;
            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM moviedbschema.genre;";
            Console.WriteLine("SQL Query: " + sqlQuery);


            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new Movie and setup its info
                currentGenre = new Genre();

                currentGenre.Code = dataReader.GetString(0);
                currentGenre.Name = dataReader.GetString(1);
                if (dataReader.ToString() == "")
                    currentGenre.Description = dataReader.GetString(2);

                currentGenreList.Add(currentGenre);
                genreList.Add(currentGenre);
                showGenreComboBox.Items.Add(currentGenre.Name);
            }

            showGenreComboBox.Items.Add("All");
            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return currentGenreList;
        }

        /// <summary>
        /// Assigns genres to movies via a join table within the database. Multiple movies can have multiple genres, and vise versa.
        /// </summary>
        /// <param name="currentMovieID"></param>
        /// <returns></returns>
        private List<Genre> AssignGenresFromDB(int currentMovieID)
        {
            List<Genre> currentGenreList = new List<Genre>();

            //Access the jt_genre_movie table
            NpgsqlConnection dbConnection2 = CreateDBConnection(DatabaseHost, DatabaseUser, DatabasePassword, DatabaseName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            //Access the genre table
            NpgsqlConnection dbConnection3 = CreateDBConnection(DatabaseHost, DatabaseUser, DatabasePassword, DatabaseName);
            NpgsqlCommand dbCommand3;
            NpgsqlDataReader dataReader3;

            string genreCode;
            Genre currentGenre;

            dbConnection2.Open();


            string sqlQuery = "SELECT genrecode FROM moviedbschema.jt_genre_movie WHERE movieid = " + currentMovieID + ";";

            dbCommand2 = new NpgsqlCommand(sqlQuery, dbConnection2);
            dataReader2 = dbCommand2.ExecuteReader();

            while (dataReader2.Read())
            {
                currentGenre = new Genre();

                genreCode = dataReader2.GetString(0);

                //Open a connection to get the genre table
                dbConnection3.Open();

                sqlQuery = "SELECT * FROM moviedbschema.genre WHERE genrecode = '" + genreCode + "';";

                Console.WriteLine("sqlQuery = " + sqlQuery);

                dbCommand3 = new NpgsqlCommand(sqlQuery, dbConnection3);

                dataReader3 = dbCommand3.ExecuteReader();
                dataReader3.Read();

                currentGenre.Code = dataReader3.GetString(0);
                currentGenre.Name = dataReader3.GetString(1);
                currentGenre.Description = dataReader3.GetString(2);

                //Add to genreList
                currentGenreList.Add(currentGenre);
                //Close the connection
                dbConnection3.Close();
            }

            dbConnection2.Close();

            return currentGenreList;
        }
        /// <summary>
        /// Grabs all of the genres available within the database.
        /// </summary>
        /// <returns>Returns a list of the different genres that are present within movies.</returns>
        private List<Member> GetMembersFromDB()
        {
            List<Member> currentMemberList = new List<Member>();
            Member currentMember;
            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM moviedbschema.member;";
            Console.WriteLine("SQL Query: " + sqlQuery);


            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new Movie and setup its info
                currentMember = new Member();

                currentMember.ID = dataReader.GetInt32(0);
                currentMember.Name = dataReader.GetString(1);
                currentMember.Dob = dataReader.GetDateTime(2);
                currentMember.MemberType = dataReader.GetInt32(3);

                currentMemberList.Add(currentMember);
                memberList.Add(currentMember);
                showMemberComboBox.Items.Add(currentMember.Name);
            }
            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return currentMemberList;
        }

        private List<Member> AssignMemberFromDB(int currentMovieID)
        {
            List<Member> currentMemberList = new List<Member>();

            //Access the jt_genre_movie table
            NpgsqlConnection dbConnection4 = CreateDBConnection(DatabaseHost, DatabaseUser, DatabasePassword, DatabaseName);
            NpgsqlCommand dbCommand4;
            NpgsqlDataReader dataReader4;

            //Access the member table
            NpgsqlConnection dbConnection5 = CreateDBConnection(DatabaseHost, DatabaseUser, DatabasePassword, DatabaseName);
            NpgsqlCommand dbCommand5;
            NpgsqlDataReader dataReader5;

            int memberCode;
            Member currentMember;

            dbConnection4.Open();


            string sqlQuery = "SELECT memberid FROM moviedbschema.jt_movie_member WHERE movieid = " + currentMovieID + ";";

            dbCommand4 = new NpgsqlCommand(sqlQuery, dbConnection4);
            dataReader4 = dbCommand4.ExecuteReader();

            while (dataReader4.Read())
            {
                currentMember = new Member();

                memberCode = dataReader4.GetInt32(0);

                //Open a connection to get the member table
                dbConnection5.Open();

                sqlQuery = "SELECT * FROM moviedbschema.member WHERE memberid = '" + memberCode + "';";

                Console.WriteLine("sqlQuery = " + sqlQuery);

                dbCommand5 = new NpgsqlCommand(sqlQuery, dbConnection5);

                dataReader5 = dbCommand5.ExecuteReader();
                dataReader5.Read();

                currentMember.ID = dataReader5.GetInt32(0);
                currentMember.Name = dataReader5.GetString(1);
                currentMember.Dob = dataReader5.GetDateTime(2);
                currentMember.MemberType = dataReader5.GetInt32(3);

                currentMemberList.Add(currentMember);

                //Close the connection
                dbConnection5.Close();
            }

            dbConnection4.Close();

            return currentMemberList;
        }
        /// <summary>
        /// This method adds a new 'movie' record in the 'movie' table of the db.        
        /// </summary>
        /// <param name="movie">The object containing the 'movie' info</param>
        /// <returns></returns>
        private int InsertMovieInDB(Movie movie)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "INSERT INTO moviedbschema.movie VALUES(" + movie.ID + ", '" + movie.Title + "', '" + movie.Year + ", '" + movie.Length + ", '" + movie.Rating + ", '" + movie.Image + "');";
            
            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }

        /// <summary>
        /// This method updates an 'movie' record in the 'movie' table of the db.
        /// </summary>
        /// <param name="movie">The object containing the new 'movie' info</param>
        /// <returns></returns>
        private int UpdateMovieInDB(Movie movie)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "UPDATE moviedbschema.movie SET movieid = '" + movie.ID + "', title = '" + movie.Title + "', year = '" + movie.Year + "', length = '" + movie.Length + "', audience_rating = '" + movie.Rating + "', imagepath = '" + movie.Image + "' WHERE movieid = " + movie.ID + ";";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            dbCommand.Dispose();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }
        private int DeleteJTMovieMemberFromDB(int movieID, int memberID)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            string sqlQuery = "DELETE ";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            dbCommand.Dispose();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }
        /// <summary>
        /// This method adds a new 'member' record in the 'member' table of the db.        
        /// </summary>
        /// <param name="member">The object containing the 'member' info</param>
        /// <returns></returns>
        private int InsertMemberInDB(Member member)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "INSERT INTO moviedbschema.member VALUES(" + member.ID + ", '" + member.Name + "', '" + member.Dob + ", '" + member.MemberType + "');";

            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }

        /// <summary>
        /// This method updates an 'member' record in the 'member' table of the db.
        /// </summary>
        /// <param name="member">The object containing the new 'member' info</param>
        /// <returns></returns>
        private int UpdateMemberInDB(Member member)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "UPDATE moviedbschema.member SET memberid = '" + member.ID + "', name = '" + member.Name + "', dateofbirth = '" + member.Dob + "', type = '" + member.MemberType + "' WHERE memberid = " + member.ID + ";";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }
        /// <summary>
        /// This method adds a new 'genre' record in the 'genre' table of the db.        
        /// </summary>
        /// <param name="genre">The object containing the 'genre' info</param>
        /// <returns></returns>
        private int InsertGenreInDB(Genre genre)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "INSERT INTO moviedbschema.genre VALUES(" + genre.Code + ", '" + genre.Name + "', '" + genre.Description + "');";

            Console.WriteLine("SQL Query: " + sqlQuery);

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }

        /// <summary>
        /// This method updates an 'genre' record in the 'genre' table of the db.
        /// </summary>
        /// <param name="genre">The object containing the new 'genre' info</param>
        /// <returns></returns>
        private int UpdateGenreInDB(Genre genre)
        {
            //This variable will store the number of affecter rows by the INSERT query
            int queryResult;

            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "UPDATE moviedbschema.genre SET genrecode = '" + genre.Code + "', name = '" + genre.Name + "', description = '" + genre.Description + "' WHERE genrecode = " + genre.Code + ";";

            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            queryResult = dbCommand.ExecuteNonQuery();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return queryResult;
        }
        private void ClearTheTextBoxes()
        {
            genreListBox.Items.Clear();
            titleTextBox.Text = "";
            yearTextBox.Text = "";
            lengthTextBox.Text = "";
            ratingTextBox.Text = "";
            imageTextBox.Text = "";
            memberListBox.Items.Clear();
            memberNameTextBox.Text = "";
            dobTextBox.Text = "";
            typeComboBox.Text = "";
            genreNameTextBox.Text = "";
            descriptionTextBox.Text = "";
            pictureBox.Visible = false;
            searchTextBox.Text = "Search movie by name";
            dobTextBox.Text = "dd/mm/yyyy";
            addComboBox.Text = "";
            showGenreComboBox.Text = "";
            showMemberComboBox.Text = "";
        }

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            //If the input is in a correct format and in the boundaries, it will pass through the if statement
            if (CheckIfMovieIsOk() == true && checkIfIntervalYearOK(int.Parse(yearTextBox.Text), LowerYear, UpperYear) && checkIfIntervalRatingOK(double.Parse(ratingTextBox.Text), LowerRating, UpperRating))
            {
                String stripped = lengthTextBox.Text.Replace(":", "");
                if (stripped.All(char.IsDigit))
                {
                    //This will create a new Movie object
                    Movie currentMovie = new Movie();
                    if (imageTextBox.Text == "")
                    {
                        //This assigns the values of the current Movie
                        currentMovie.Title = titleTextBox.Text;
                        currentMovie.Year = int.Parse(yearTextBox.Text);
                        currentMovie.Length = lengthTextBox.Text;
                        currentMovie.Rating = double.Parse(ratingTextBox.Text);
                        currentMovie.Image = "No image";
                        //Add the current Movie to the movieList
                        movieList.Add(currentMovie);

                        //Insert the movie in the db
                        //InsertMovieInDB(currentMovie);

                        ClearTheTextBoxes();
                    }
                    //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                    else if (imageTextBox.Text.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            //This assigns the values of the current Movie
                            currentMovie.Title = titleTextBox.Text;
                            currentMovie.Year = int.Parse(yearTextBox.Text);
                            currentMovie.Length = lengthTextBox.Text;
                            currentMovie.Rating = double.Parse(ratingTextBox.Text);
                            pictureBox.Image = Image.FromFile(imageTextBox.Text);
                            currentMovie.Image = imageTextBox.Text;

                            //Add the current Movie to the movieList
                            movieList.Add(currentMovie);

                            //Insert the movie in the db
                            //InsertMovieInDB(currentMovie);

                            ClearTheTextBoxes();
                        }
                        catch
                        {
                            //Error message
                            MessageBox.Show("The image could not be found");
                        }
                    }
                    //The user will be notified if they did not enter the correct image format
                    else
                    {
                        MessageBox.Show("The image must be in a jpg, jpeg or a png format");
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("The length of the movie must be only digits");
                }
            }
        }

        private void ModifyMovieButton_Click(object sender, EventArgs e)
        {
            //If the input is in a correct format and in the boundaries, it will pass through the if statement
            if (CheckIfMovieIsOk() == true && checkIfIntervalYearOK(int.Parse(yearTextBox.Text), LowerYear, UpperYear) && checkIfIntervalRatingOK(double.Parse(ratingTextBox.Text), LowerRating, UpperRating))
            {
                String stripped = lengthTextBox.Text.Replace(":", "");
                if (stripped.All(char.IsDigit))
                {
                    //If the selectedIndex is not 0, it will go through the if statement
                    if (movieListView.SelectedIndices.Count >= 0)
                    {
                        //To avoid an error
                        if (movieListView.SelectedIndices.Count <= 0)
                        {
                            return;
                        }
                        //selectedIndex is the index in the movieListView
                        int selectedIndex = movieListView.SelectedIndices[0];
                        //selectedMovieName is a string of the name of the selectedIndex
                        string selectedMovieName = movieListView.Items[selectedIndex].Text;
                        //indexInMovieList is the index in the movieList, it executes the SearchMoviesByName method to search through the movieList
                        //to find the selected movie
                        int indexInMovieList = SearchMoviesByName(selectedMovieName);

                        //Created a new instance for the selected object from the movieList
                        Movie aMovie;
                        aMovie = (Movie)movieList[indexInMovieList];
                        if (imageTextBox.Text == "No image" || imageTextBox.Text == "")
                        {
                            //Assigns the values to the object
                            aMovie.Title = titleTextBox.Text;
                            aMovie.Year = int.Parse(yearTextBox.Text);
                            aMovie.Length = lengthTextBox.Text;
                            aMovie.Rating = double.Parse(ratingTextBox.Text);
                            pictureBox.Visible = false;
                            searchTextBox.Text = "Search movie by name";
                            aMovie.Image = imageTextBox.Text;

                            //Removes the object at the selected index in the movieListView
                            movieListView.Items.RemoveAt(selectedIndex);
                            //Inserts the modified object at the selected index in the movieListView
                            movieListView.Items.Insert(selectedIndex, new ListViewItem(new string[] { aMovie.Title, aMovie.Year.ToString(), aMovie.Length.ToString() }));

                            //Removes the object at the selected index in the movieList
                            movieList.RemoveAt(indexInMovieList);
                            //Inserts the modified object at the selected index in the movieList
                            movieList.Insert(indexInMovieList, aMovie);

                            //Update the movie in the db
                            //UpdateMovieInDB(aMovie);

                            //Clear the textboxes
                            ClearTheTextBoxes();
                        }
                        else if (imageTextBox.Text.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                        {
                            try
                            {
                                //Assigns the values to the object
                                aMovie.Title = titleTextBox.Text;
                                aMovie.Year = int.Parse(yearTextBox.Text);
                                aMovie.Length = lengthTextBox.Text;
                                aMovie.Rating = double.Parse(ratingTextBox.Text);
                                pictureBox.Visible = false;
                                aMovie.Image = imageTextBox.Text;
                                searchTextBox.Text = "Search movie by name";

                                //Removes the object at the selected index in the movieListView
                                movieListView.Items.RemoveAt(selectedIndex);
                                //Inserts the modified object at the selected index in the movieListView
                                movieListView.Items.Insert(selectedIndex, new ListViewItem(new string[] { aMovie.Title, aMovie.Year.ToString(), aMovie.Length.ToString() }));

                                //Removes the object at the selected index in the movieList
                                movieList.RemoveAt(indexInMovieList);
                                //Inserts the modified object at the selected index in the movieList
                                movieList.Insert(indexInMovieList, aMovie);

                                //Update the movie in the db
                                //UpdateMovieInDB(aMovie);

                                //Clear the textboxes
                                ClearTheTextBoxes();
                            }
                            catch
                            {
                                //Error message
                                MessageBox.Show("The image could not be found");
                            }
                        }
                        //The user will be notified if they did not entere the correct image format
                        else
                        {
                            MessageBox.Show("The image must be in a jpg, jpeg or a png format");
                        }
                    }
                    //If no movie is selected, it will notify the user to select a movie to modify it
                    else
                    {
                        MessageBox.Show("You need to select a movie to modify");
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("The length of the movie must be only digits");
                }
            }
        }

        private void DeleteMovieButton_Click(object sender, EventArgs e)
        {
            //If the user selected a movie, if will go through the if statement
            if (movieListView.SelectedIndices.Count >= 0)
            {
                //Avoids an error
                if (movieListView.SelectedIndices.Count <= 0)
                {
                    return;
                }
                //The selected int is the index of the object in the movieListView
                int selected = movieListView.SelectedIndices[0];

                //This will remove the object from the movieListView as well as the movieList
                movieListView.Items.RemoveAt(selected);
                movieList.RemoveAt(selected);

                //Clear the textboxes
                ClearTheTextBoxes();
            }
            //If no movie is selected, it will notify the user to select a movie to delete it
            else
            {
                MessageBox.Show("You need to select a movie to delete");
            }
        }

        private void MovieListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfo(); //Update the info in the form's controls
            MakeGenreInvisible();
            MakeMemberInvisible();
            MakeMovieVisible();
            addMovieButton.Visible = false;
        }

        private void AddComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the movie has the same genre as the selected genre in the genreComboBox, it go through the if statement
            if (addComboBox.Text == "Movie")
            {
                MakeMovieVisible();
                genreLabel.Visible = false;
                genreListBox.Visible = false;
                memberLabel.Visible = false;
                memberListBox.Visible = false;
                MakeMemberInvisible();
                MakeGenreInvisible();
                modifyMovieButton.Visible = false;
                deleteMovieButton.Visible = false;
                //Clear the textboxes
                ClearTheTextBoxes();
                movieListView.Items.Clear();
            }
            //If the selected genre is all it will display all the movies no matter the genre
            else if (addComboBox.Text == "Member")
            {
                MakeMovieInvisible();
                MakeMemberVisible();
                MakeGenreInvisible();
                modifyMemberButton.Visible = false;
                deleteMemberButton.Visible = false;
                //Clear the textboxes
                ClearTheTextBoxes();
                movieListView.Items.Clear();
            }
            //If the selected genre is all it will display all the movies no matter the genre
            else if (addComboBox.Text == "Genre")
            {
                MakeMovieInvisible();
                MakeMemberInvisible();
                MakeGenreVisible();
                modifyGenreButton.Visible = false;
                deleteGenreButton.Visible = false;
                //Clear the textboxes
                ClearTheTextBoxes();
                movieListView.Items.Clear();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //This will create a List will all the movies containing what the user entered in the searchTextBox
            var searchMovieName = movieList.FindAll(x => x.Title.ToLower().Contains(searchTextBox.Text.ToLower()));

            //If the string input is empty
            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Please enter a movie name");
            }
            //If the searchMovieName list isn't empty, it will go through the if statement
            else if (searchMovieName.Count > 0)
            {
                //Clear the movieListView
                movieListView.Items.Clear();
                //Foreach object in the searchMovieName list, it will add the object to the movieListView
                searchMovieName.ForEach(x => { movieListView.Items.Add(new ListViewItem(new string[] { x.Title, x.Year.ToString() })); });

                //Clear the textboxes
                ClearTheTextBoxes();
            }
            //If the searchMovieName list is empty it will notify the user the movie he is looking for could not be found
            else
            {
                MessageBox.Show("We cannot find the movie you are searching for");
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = ""; //Remove the placeholder text within the box
        }

        private void showGenreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the approporiate boxes
            movieListView.Items.Clear();
            ClearTheTextBoxes();

            //Retrieve the selected genre from the combo box
            string selectedGenre = showGenreComboBox.SelectedItem.ToString();

            //If "all" is selected,
            if (selectedGenre == "All")
            {
                foreach (Movie m in movieList) //Loop through the movieList
                {
                    movieListView.Items.Add(new ListViewItem(new string[] { m.Title, m.Year.ToString(), m.Length.ToString() })); //Add every movie in the list to the listView
                    MakeGenreInvisible();
                    MakeMemberInvisible();
                    MakeMovieInvisible();
                }
            }
            else //If something else is selected
            {
                var searchGenreName = genreList.FindAll(x => x.Name.ToLower().Contains(selectedGenre.ToLower()));
                //This adds the genre's information in the appropriate textboxes
                if (searchGenreName.Count > 0)
                {
                    foreach (Genre g in searchGenreName)
                    {
                        if (searchGenreName.Exists(x => x.Code == g.Code))
                        {
                            if (!movieList.Exists(x => x.Genre.Exists(y => y.Name == selectedGenre)))
                            {
                                //Display the genre's information
                                genreNameTextBox.Text = g.Name;
                                descriptionTextBox.Text = g.Description;

                                //Allow the user to modify or delete the genre
                                MakeGenreVisible();
                                addGenreButton.Visible = false;
                                MakeMemberInvisible();
                                MakeMovieInvisible();
                            }
                            else
                            {
                                foreach (Movie m in movieList) //Loop through movieList
                                {
                                    for (int i = 0; i < m.Genre.Count; i++) //Loop through the genres of each movie
                                    {
                                        if (m.Genre[i].Name == selectedGenre) //If the genre matches the one the user is searching for,
                                        {
                                            movieListView.Items.Add(new ListViewItem(new string[] { m.Title, m.Year.ToString(), m.Length.ToString() })); //Add it to the list box

                                            //Allow the user to modify or delete the genre
                                            MakeGenreVisible();
                                            addGenreButton.Visible = false;
                                            MakeMemberInvisible();
                                            MakeMovieInvisible();

                                            //Display the genre's information
                                            genreNameTextBox.Text = m.Genre[i].Name;
                                            descriptionTextBox.Text = m.Genre[i].Description;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void genreListBox_Click(object sender, EventArgs e)
        {
            //Make the genre controls visible within the form
            genreNameTextBox.Visible = true;
            genreNameLabel.Visible = true;
            addGenreButton.Visible = true;
            deleteGenreButton.Visible = true;
            MakeMemberInvisible();
            //Clear the selected item from the memberListBox to avoid confusion for the user
            memberListBox.ClearSelected();
            genreNameTextBox.Text = "";
        }

        private void modifyGenreButton_Click(object sender, EventArgs e)
        {
            //If the input is in a correct format and in the boundaries, it will pass through the if statement
            if (CheckIfGenreIsOk() == true)
            {
                if (genreNameTextBox.TextLength >= 3)
                {
                    string desc = descriptionTextBox.Text;
                    string oldName = showGenreComboBox.Text;
                    string name = genreNameTextBox.Text;
                    name = char.ToUpper(name[0]) + name.Substring(1);

                    //selectedIndex is the index in the movieListView
                    int selectedIndex = showGenreComboBox.SelectedIndex;
                    //selectedMovieName is a string of the name of the selectedIndex
                    string selectedGenreName = showGenreComboBox.Items[selectedIndex].ToString();
                    //indexInMovieList is the index in the movieList, it executes the SearchMoviesByName method to search through the movieList
                    //to find the selected movie
                    int indexInGenreList = SearchByGenre(selectedGenreName);

                    //This will create a List will all the movies containing what the user entered in the searchTextBox
                    var searchGenreName = genreList.FindAll(x => x.Name.ToLower().Contains(showGenreComboBox.Text.ToLower()));

                    //If the genre isn't in a movie, this if statement will modify the information for the genre only
                    if (!movieList.Exists(x => x.Genre.Exists(y => y.Name == oldName)))
                    {
                        searchGenreName.ForEach(x => { x.Name = name; x.Description = descriptionTextBox.Text; x.Code = name.Substring(0, 3).ToUpper(); });

                        //Modify the genre object in the showGenreComboBox
                        showGenreComboBox.Items.Clear();
                        foreach (Genre g in genreList)
                        {
                            showGenreComboBox.Items.Add(g.Name);
                        }
                        showGenreComboBox.Items.Add("All");

                        //Update the genre in the db
                        //UpdateGenreInDB(searchGenreName);

                        //Clear the appropriate textbox
                        ClearTheTextBoxes();
                        movieListView.Items.Clear();
                    }
                    else
                    {
                        foreach (Movie m in movieList)
                        {
                            for (int i = 0; i < m.Genre.Count; i++)
                            {
                                if (searchGenreName.Exists(x => x.Code == m.Genre[i].Code))
                                {
                                    m.Genre[i].Name = name;
                                    m.Genre[i].Description = desc;
                                    m.Genre[i].Code = name.Substring(0, 3).ToUpper();

                                    //Modify the member object in the emberList
                                    genreList.RemoveAt(indexInGenreList);
                                    genreList.Insert(indexInGenreList, m.Genre[i]);

                                    //Modify the genre object in the movie
                                    m.Genre.Insert(i, m.Genre[i]);
                                    m.Genre.RemoveAt(i + 1);

                                    //Modify the genre object in the showGenreComboBox
                                    showGenreComboBox.Items.Clear();
                                    foreach (Genre g in genreList)
                                    {
                                        showGenreComboBox.Items.Add(g.Name);
                                    }
                                    showGenreComboBox.Items.Add("All");

                                    //Update the movie in the db
                                    //UpdateMovieInDB(m);
                                    //Update the genre in the db
                                    //UpdateGenreInDB(searchGenreName);

                                    //Clear the appropriate textbox
                                    ClearTheTextBoxes();
                                    movieListView.Items.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter at least 3 letters");
                }
            }
        }


        private void deleteGenreButton_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedIndices.Count > 0)
            {
                //Clear the text boxes accordingly
                genreNameTextBox.Clear();
                descriptionTextBox.Clear();

                //Get the selected indexes for movies and genre
                int selectedGenre = genreListBox.SelectedIndex;
                int selectedMovie = movieListView.SelectedIndices[0];

                //If an item is selected,
                if (selectedGenre > -1)
                {
                    //Delete the item in question from movieList
                    movieList[selectedMovie].Genre.RemoveAt(selectedGenre);
                    
                    //Update the movie in the db
                    //UpdateMovieInDB(movieList[selectedMovie]);

                    //Update the form information
                    UpdateInfo();
                }
                else
                {
                    MessageBox.Show("Please select a genre to remove");
                }
            }
            else
            {
                //Get the selected index for genre
                int selectedGenre = showGenreComboBox.SelectedIndex;
                string selectedGenreName = showGenreComboBox.Items[selectedGenre].ToString();
                int indexInGenreList = SearchByGenre(selectedGenreName);

                //This will create a List will all the movies containing what the user entered in the searchTextBox
                var searchGenreName = genreList.Find(x => x.Name.ToLower().Contains(showGenreComboBox.Text.ToLower()));

                if (!movieList.Exists(x => x.Genre.Exists(y => y.Name == searchGenreName.Name)))
                {
                    if (showGenreComboBox.Items.Contains(searchGenreName.Name))
                    {
                        showGenreComboBox.Items.RemoveAt(selectedGenre);
                    }
                    genreList.RemoveAt(indexInGenreList);
                    //Clear the appropriate textbox
                    ClearTheTextBoxes();
                    movieListView.Items.Clear();
                }
                else
                {
                    foreach (Movie m in movieList)
                    {
                        for (int i = 0; i < m.Genre.Count; i++)
                        {
                            if (searchGenreName.Name == m.Genre[i].Name)
                            {
                                if (showGenreComboBox.Items.Contains(m.Genre[i].Name))
                                {
                                    showGenreComboBox.Items.RemoveAt(selectedGenre);
                                }
                                m.Genre.RemoveAt(i);
                                genreList.RemoveAt(indexInGenreList);
                                //Clear the appropriate textbox
                                ClearTheTextBoxes();
                                movieListView.Items.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void addGenreButton_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedIndices.Count > 0)
            {
                if (movieListView.SelectedIndices.Count <= 0)
                {
                    return;
                }

                //selectedIndex is the index in the movieListView
                int selectedIndex = movieListView.SelectedIndices[0];
                //selectedMovieName is a string of the name of the selectedIndex
                string selectedMovieName = movieListView.Items[selectedIndex].Text;
                //indexInMovieList is the index in the movieList, it executes the SearchMoviesByName method to search through the movieList
                //to find the selected movie
                int indexInMovieList = SearchMoviesByName(selectedMovieName);

                var searchGenreName = genreList.FindAll(x => x.Name.ToLower().Contains(genreNameTextBox.Text.ToLower()));
                if (genreNameTextBox.Text == "")
                {
                    MessageBox.Show("Please enter a genre name");
                }
                else if (genreNameTextBox.TextLength >= 3)
                {
                    if (searchGenreName.Count > 0)
                    {
                        foreach (Genre g in searchGenreName)
                        {
                            if (searchGenreName.Exists(x => x.Code == g.Code))
                            {
                                if (!genreListBox.Items.Contains(g.Name))
                                {
                                    //Add the genre to the movie
                                    movieList[indexInMovieList].Genre.Add(g);

                                    //Update the movie in the db
                                    //UpdateMovieInDB(movieList[indexInMovieList]);

                                    UpdateInfo(); //Update the info in the form's controls

                                    //Clear the appropriate textboxe
                                    genreNameTextBox.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("This genre is already a part of this movie");
                                }
                            }
                        }
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Please enter an existing genre");
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter at least 3 letters");
                }
            }
            else
            {
                //If the input is in a correct format and in the boundaries, it will pass through the if statement
                if (CheckIfGenreIsOk() == true)
                {
                    string name = genreNameTextBox.Text;
                    name = char.ToUpper(name[0]) + name.Substring(1);
                    if (genreNameTextBox.TextLength >= 3)
                    {
                        if (!genreList.Exists(x => x.Name == name))
                        {
                            //Create a new genre item
                            Genre genre = new Genre();

                            //Get the genre's information
                            genre.Name = name;
                            genre.Description = descriptionTextBox.Text;
                            genre.Code = genreNameTextBox.Text.Substring(0, 3).ToUpper();
                            genreList.Add(genre);

                            showGenreComboBox.Items.Clear(); //Clear the showGenreComboBox
                            foreach (Genre g in genreList)
                            {
                                showGenreComboBox.Items.Add(g.Name);
                            }
                            showGenreComboBox.Items.Add("All");

                            //Insert the genre in the db
                            //InsertGenreInDB(genre);

                            //Clear the textboxes
                            ClearTheTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("This genre already exists");
                        }
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Please enter at least 3 letters");
                    }
                }
            }
        }

        /// <summary>
        /// This method will search through every movie in movieList
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns></returns>
        private int SearchMoviesByName(string movieName)
        {
            int i = 0;
            foreach (Movie movies in movieList)
            {
                if (movieName != movieList[i].Title)
                {
                    i++;
                }
            }
            return i;
        }
        private int SearchByGenre(string movieGenre)
        {
            int i = 0;
            foreach (Genre genres in genreList)
            {
                if (movieGenre != genreList[i].Name)
                {
                    i++;
                }
            }
            return i;
        }
        private int SearchByMember(string movieMember)
        {
            int i = 0;
            foreach (Member members in memberList)
            {
                if (movieMember != memberList[i].Name)
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Makes all member-related controls invisible
        /// </summary>
        public void MakeMemberInvisible()
        {
            memberNameLabel.Visible = false;
            memberNameTextBox.Visible = false;
            dobLabel.Visible = false;
            dobTextBox.Visible = false;
            typeComboBox.Visible = false;
            typeLabel.Visible = false;
            addMemberButton.Visible = false;
            modifyMemberButton.Visible = false;
            deleteMemberButton.Visible = false;
        }

        /// <summary>
        /// Makes all genre-related controls invisible
        /// </summary>
        public void MakeGenreInvisible()
        {
            genreNameLabel.Visible = false;
            genreNameTextBox.Visible = false;
            descriptionLabel.Visible = false;
            descriptionTextBox.Visible = false;
            addGenreButton.Visible = false;
            modifyGenreButton.Visible = false;
            deleteGenreButton.Visible = false;
        }

        /// <summary>
        /// Makes all member-related controls visible
        /// </summary>
        public void MakeMemberVisible()
        {
            memberNameLabel.Visible = true;
            memberNameTextBox.Visible = true;
            dobLabel.Visible = true;
            dobTextBox.Visible = true;
            typeComboBox.Visible = true;
            typeLabel.Visible = true;
            addMemberButton.Visible = true;
            modifyMemberButton.Visible = true;
            deleteMemberButton.Visible = true;
        }

        /// <summary>
        /// Makes all genre-related controls invisible
        /// </summary>
        public void MakeGenreVisible()
        {
            genreNameLabel.Visible = true;
            genreNameTextBox.Visible = true;
            descriptionLabel.Visible = true;
            descriptionTextBox.Visible = true;
            addGenreButton.Visible = true;
            modifyGenreButton.Visible = true;
            deleteGenreButton.Visible = true;
        }

        /// <summary>
        /// Makes all movie-related controls invisible
        /// </summary>
        public void MakeMovieInvisible()
        {
            genreLabel.Visible = false;
            genreListBox.Visible = false;
            titleLabel.Visible = false;
            titleTextBox.Visible = false;
            yearLabel.Visible = false;
            yearTextBox.Visible = false;
            lengthLabel.Visible = false;
            lengthTextBox.Visible = false;
            ratingLabel.Visible = false;
            ratingTextBox.Visible = false;
            imageLabel.Visible = false;
            imageTextBox.Visible = false;
            addMovieButton.Visible = false;
            modifyMovieButton.Visible = false;
            deleteMovieButton.Visible = false;
            memberLabel.Visible = false;
            memberListBox.Visible = false;
        }

        /// <summary>
        /// Makes all movie-related controls visible
        /// </summary>
        public void MakeMovieVisible()
        {
            genreLabel.Visible = true;
            genreListBox.Visible = true;
            titleLabel.Visible = true;
            titleTextBox.Visible = true;
            yearLabel.Visible = true;
            yearTextBox.Visible = true;
            lengthLabel.Visible = true;
            lengthTextBox.Visible = true;
            ratingLabel.Visible = true;
            ratingTextBox.Visible = true;
            imageLabel.Visible = true;
            imageTextBox.Visible = true;
            addMovieButton.Visible = true;
            modifyMovieButton.Visible = true;
            deleteMovieButton.Visible = true;
            memberLabel.Visible = true;
            memberListBox.Visible = true;
        }

        /// <summary>
        /// Checks to make sure the movie in question fits a certain criteria.
        /// </summary>
        /// <returns>Returns the movie and dictates if it is usable.</returns>
        private bool CheckIfMovieIsOk()
        {
            bool formOK = true;

            formOK = formOK && CheckIfInputOk(titleTextBox.Text, "string");
            formOK = formOK && CheckIfInputOk(yearTextBox.Text, "int");
            formOK = formOK && CheckIfInputOk(lengthTextBox.Text, "string");
            formOK = formOK && CheckIfInputOk(ratingTextBox.Text, "double");

            return formOK;
        }
        private bool CheckIfMemberIsOk()
        {
            bool formOK = true;

            formOK = formOK && CheckIfInputOk(memberNameTextBox.Text, "string");
            formOK = formOK && CheckIfInputOk(typeComboBox.Text, "string");

            return formOK;
        }
        private bool CheckIfGenreIsOk()
        {
            bool formOK = true;

            formOK = formOK && CheckIfInputOk(genreNameTextBox.Text, "string");

            return formOK;
        }

        /// <summary>
        /// Method used to make sure user input is in the correct format.
        /// </summary>
        /// <param name="field">To describe a control in a given context.</param>
        /// <param name="fieldType">To describe what type set control can work with.</param>
        /// <returns>Returns user input and dictates if it is usable.</returns>
        private bool CheckIfInputOk(string field, string fieldType)
        {
            int intVariable;
            double doubleVariable;
            DateTime dateTimeVariable;

            if (String.IsNullOrEmpty(field))
            {
                MessageBox.Show("At least one required field is empty");
                return false;
            }

            switch (fieldType)
            {
                case "int":  //Checks if the data type is 'int'
                    if (int.TryParse(field, out intVariable) == false)
                    {
                        MessageBox.Show("The value: " + field + " must be a(n) " + fieldType + " value");
                        return false;
                    }
                    break;
                case "double":  //Checks if the data type is 'double'
                    if (double.TryParse(field, out doubleVariable) == false)
                    {
                        MessageBox.Show("The value: " + field + " must be a(n) " + fieldType + " value");
                        return false;
                    }
                    break;
                case "dateTime": //Checks if the data type is 'DateTime'
                    if (DateTime.TryParse(field, out dateTimeVariable) == false)
                    {
                        MessageBox.Show("The value: " + field + " must be a(n) " + fieldType + " value");
                        return false;
                    }
                    break;
                case "string":
                    //Nothing to do
                    break;
            }

            return true;
        }

        /// <summary>
        /// This method will make sure the user entered a valid year in the boundaries
        /// </summary>
        /// <param name="value">The value in question</param>
        /// <param name="lowerLimit">The value's minimum</param>
        /// <param name="upperLimit">The value's maximum</param>
        /// <returns>Returns a boolean value dictating if the interval year is usable or not.</returns>
        private bool checkIfIntervalYearOK(int value, int lowerLimit, int upperLimit)
        {
            //If the year is in the boundaries, the code will keep running
            if (value <= upperLimit && value >= lowerLimit)
            {
                return true;
            }
            //If the year is not in the oundaries, a messageBox will inform the user the year is out of boundaries
            else
            {
                MessageBox.Show("The year should be between 1888 and 2020");
                return false;
            }
        }

        /// <summary>
        /// This method will make sure the user entered a valid rating in the boundaries
        /// </summary>
        /// <param name="value">The value in question</param>
        /// <param name="lowerLimit">The value's minimum</param>
        /// <param name="upperLimit">The value's maximum</param>
        /// <returns>Returns a boolean value dictating if the interval year is usable or not.</returns>
        private bool checkIfIntervalRatingOK(double value, int lowerLimit, int upperLimit)
        {
            //If the rating is in the boundaries, the code will keep running
            if (value <= upperLimit && value >= lowerLimit)
            {
                return true;
            }
            //If the rating is not in the oundaries, a messageBox will inform the user the rating is out of boundaries
            else
            {
                MessageBox.Show("The rating should be between 1 and 5");
                return false;
            }
        }

        /// <summary>
        /// Updates the movie/genre/member info within the form's controls.
        /// </summary>
        private void UpdateInfo()
        {
            genreListBox.Items.Clear(); //Clear the genre list box
            memberListBox.Items.Clear(); //Clear the member list box
            showGenreComboBox.Items.Clear(); //Clear the showGenreComboBox
            showMemberComboBox.Items.Clear(); //Clear the showMemberComboBox

            //If the user selected a movie, it will go through the if statement
            if (movieListView.SelectedIndices.Count >= 0)
            {
                if (movieListView.SelectedIndices.Count <= 0)
                {
                    return;
                }
                //selectedIndex is the index in the movieListView
                int selectedIndex = movieListView.SelectedIndices[0];
                //selectedMovieName is a string of the name of the selectedIndex
                string selectedMovieName = movieListView.Items[selectedIndex].Text;
                //indexInMovieList is the index in the movieList, it executes the SearchMoviesByName method to search through the movieList
                //to find the selected movie
                int indexInMovieList = SearchMoviesByName(selectedMovieName);

                //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                if (movieList[indexInMovieList].Image.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || movieList[indexInMovieList].Image.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || movieList[indexInMovieList].Image.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        MakeMovieVisible();
                        //Assigns the values from the object to the textboxes
                        //genreComboBox.Text = movieList[indexInMovieList].Genre;
                        titleTextBox.Text = movieList[indexInMovieList].Title;
                        yearTextBox.Text = movieList[indexInMovieList].Year.ToString();
                        lengthTextBox.Text = movieList[indexInMovieList].Length.ToString();
                        ratingTextBox.Text = movieList[indexInMovieList].Rating.ToString();
                        searchTextBox.Text = "Search movie by name";
                        imageTextBox.Text = movieList[indexInMovieList].Image;
                        pictureBox.Visible = true;
                        pictureBox.Image = Image.FromFile(imageTextBox.Text);
                        
                        //Genre distribution
                        foreach (Genre g in movieList[indexInMovieList].Genre)
                        {
                            genreListBox.Items.Add(g.Name);
                        }
                        //Member distribution
                        foreach (Member m in movieList[indexInMovieList].Member)
                        {
                            memberListBox.Items.Add(m.Name);
                        }
                        foreach (Genre g in genreList)
                        {
                            showGenreComboBox.Items.Add(g.Name);
                        }
                        showGenreComboBox.Items.Add("All");
                        foreach (Member m in memberList)
                        {
                            showMemberComboBox.Items.Add(m.Name);
                        }
                        MakeGenreInvisible();
                        MakeMemberInvisible();
                        addMovieButton.Visible = false;
                    }
                    catch
                    {
                        //Error message
                        MessageBox.Show("The image could not be found");
                    }
                }
                //It will go through this else if statement if there is no image
                else if (movieList[indexInMovieList].Image.ToString() == "No image" || movieList[indexInMovieList].Image.ToString() == "")
                {
                    MakeMovieVisible();
                    MakeGenreInvisible();
                    MakeMemberInvisible();
                    addMovieButton.Visible = false;

                    //Assigns the values from the object to the textboxes
                    //genreComboBox.Text = movieList[indexInMovieList].Genre;
                    titleTextBox.Text = movieList[indexInMovieList].Title;
                    yearTextBox.Text = movieList[indexInMovieList].Year.ToString();
                    lengthTextBox.Text = movieList[indexInMovieList].Length.ToString();
                    ratingTextBox.Text = movieList[indexInMovieList].Rating.ToString();
                    searchTextBox.Text = "Search movie by name";
                    pictureBox.Image = null;
                    imageTextBox.Text = "";
                    //Genre distribution
                    foreach (Genre g in movieList[indexInMovieList].Genre)
                    {
                        genreListBox.Items.Add(g.Name);
                    }
                    //Member distribution
                    foreach (Member m in movieList[indexInMovieList].Member)
                    {
                        memberListBox.Items.Add(m.Name);
                    }
                    foreach (Genre g in genreList)
                    {
                        showGenreComboBox.Items.Add(g.Name);
                    }
                    showGenreComboBox.Items.Add("All");
                    foreach (Member m in memberList)
                    {
                        showMemberComboBox.Items.Add(m.Name);
                    }
                }
                //The user will be notified if they did not entere the correct image format
                else
                {
                    MessageBox.Show("The image must be in a jpg, jpeg or a png format");
                }
            }

        }

        private void ShowMemberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the approporiate boxes
            movieListView.Items.Clear();
            ClearTheTextBoxes();
            MakeGenreInvisible();
            MakeMemberVisible();
            MakeMovieInvisible();
            addMemberButton.Visible = false;

            //Retrieve the selected member from the combo box
            string selectedMember = showMemberComboBox.SelectedItem.ToString();

            var searchMemberName = memberList.FindAll(x => x.Name.ToLower().Contains(selectedMember.ToLower()));
            //This adds the member's information in the right place
            if (searchMemberName.Count > 0)
            {
                foreach (Member m in searchMemberName)
                {
                    if (searchMemberName.Exists(x => x.ID == m.ID))
                    {
                        if (!movieList.Exists(x => x.Member.Exists(y => y.Name == selectedMember)))
                        {
                            //Display the member's information
                            memberNameTextBox.Text = m.Name;
                            dobTextBox.Text = m.Dob.ToString();
                            if (m.MemberType.ToString() == "1")
                            {
                                typeComboBox.Text = "Actor";
                            }
                            else if (m.MemberType.ToString() == "2")
                            {
                                typeComboBox.Text = "Director";
                            }
                            else if (m.MemberType.ToString() == "3")
                            {
                                typeComboBox.Text = "Producer";
                            }
                            else if (m.MemberType.ToString() == "4")
                            {
                                typeComboBox.Text = "Director of photography";
                            }
                        }
                        else
                        {
                            foreach (Movie mo in movieList)
                            {
                                for (int i = 0; i < mo.Member.Count; i++) //Loop through the members of each movie
                                {
                                    if (mo.Member[i].Name == selectedMember) //If the member matches the one the user is searching for,
                                    {
                                        movieListView.Items.Add(new ListViewItem(new string[] { mo.Title, mo.Year.ToString(), mo.Length.ToString() })); //Add it to the list box

                                        //Display the member's information
                                        memberNameTextBox.Text = m.Name;
                                        dobTextBox.Text = m.Dob.ToString();
                                        if (m.MemberType.ToString() == "1")
                                        {
                                            typeComboBox.Text = "Actor";
                                        }
                                        else if (m.MemberType.ToString() == "2")
                                        {
                                            typeComboBox.Text = "Director";
                                        }
                                        else if (m.MemberType.ToString() == "3")
                                        {
                                            typeComboBox.Text = "Producer";
                                        }
                                        else if (m.MemberType.ToString() == "4")
                                        {
                                            typeComboBox.Text = "Director of photography";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedIndices.Count > 0)
            {
                if (movieListView.SelectedIndices.Count <= 0)
                {
                    return;
                }
                //selectedIndex is the index in the movieListView
                int selectedIndex = movieListView.SelectedIndices[0];
                //selectedMovieName is a string of the name of the selectedIndex
                string selectedMovieName = movieListView.Items[selectedIndex].Text;
                //indexInMovieList is the index in the movieList, it executes the SearchMoviesByName method to search through the movieList
                //to find the selected movie
                int indexInMovieList = SearchMoviesByName(selectedMovieName);

                var searchMemberName = memberList.FindAll(x => x.Name.ToLower().Contains(memberNameTextBox.Text.ToLower()));
                if (memberNameTextBox.Text == "")
                {
                    MessageBox.Show("Please enter a member name");
                }
                else if (memberNameTextBox.TextLength >= 3)
                {
                    if (searchMemberName.Count > 0)
                    {
                        foreach (Member m in searchMemberName)
                        {
                            if (searchMemberName.Exists(x => x.ID == m.ID))
                            {
                                if (!memberListBox.Items.Contains(m.Name))
                                {
                                    //Add the member to the movie
                                    movieList[indexInMovieList].Member.Add(m);

                                    //Update the movie in the db
                                    //UpdateMovieInDB(movieList[indexInMovieList]);

                                    UpdateInfo(); //Update the info in the form's controls

                                    //Clear the appropriate textbox
                                    memberNameTextBox.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("This member is already a part of this movie");
                                }
                            }
                        }
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Please enter an existing member");
                    }

                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter at least 3 letters");
                }
            }
            else
            {
                //If the input is in a correct format and in the boundaries, it will pass through the if statement
                if (CheckIfMemberIsOk() == true)
                {
                    string dob = dobTextBox.Text;
                    string name = memberNameTextBox.Text;
                    // Creates a TextInfo based on the "en-US" culture.
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    name = myTI.ToTitleCase(name);

                    if (memberNameTextBox.TextLength >= 3)
                    {
                        if (!memberList.Exists(x => x.Name == name))
                        {
                            Member newMember = new Member();
                            int memberCount = memberList.Count;
                            memberCount = memberCount + 2;
                            for (int i = 0; i < memberCount; i++)
                            {
                                int id = memberCount;
                                id = id + 10123;
                                if (!memberList.Exists(x => x.ID == id))
                                {
                                    if (id != 10126)
                                    {
                                        if (DateTime.TryParse(dob, out DateTime DateValue))
                                        {
                                            if (typeComboBox.Text == "Actor")
                                            {
                                                newMember.ID = id;
                                                newMember.Name = name;
                                                newMember.Dob = DateValue;
                                                newMember.MemberType = 1;
                                                memberList.Add(newMember);
                                                showMemberComboBox.Items.Add(newMember.Name);

                                                //Insert the member in the db
                                                //InsertMemberInDB(newMember);

                                                //Clear the textboxes
                                                ClearTheTextBoxes();
                                            }
                                            else if (typeComboBox.Text == "Director")
                                            {
                                                newMember.ID = id;
                                                newMember.Name = name;
                                                newMember.Dob = DateValue;
                                                newMember.MemberType = 2;
                                                memberList.Add(newMember);
                                                showMemberComboBox.Items.Add(newMember.Name);

                                                //Insert the member in the db
                                                //InsertMemberInDB(newMember);

                                                //Clear the textboxes
                                                ClearTheTextBoxes();
                                            }
                                            else if (typeComboBox.Text == "Producer")
                                            {
                                                newMember.ID = id;
                                                newMember.Name = name;
                                                newMember.Dob = DateValue;
                                                newMember.MemberType = 3;
                                                memberList.Add(newMember);
                                                showMemberComboBox.Items.Add(newMember.Name);

                                                //Insert the member in the db
                                                //InsertMemberInDB(newMember);

                                                //Clear the textboxes
                                                ClearTheTextBoxes();
                                            }
                                            else if (typeComboBox.Text == "Director of photography")
                                            {
                                                newMember.ID = id;
                                                newMember.Name = name;
                                                newMember.Dob = DateValue;
                                                newMember.MemberType = 4;
                                                memberList.Add(newMember);
                                                showMemberComboBox.Items.Add(newMember.Name);

                                                //Insert the member in the db
                                                //InsertMemberInDB(newMember);

                                                //Clear the textboxes
                                                ClearTheTextBoxes();
                                            }
                                            else
                                            {
                                                //Error message
                                                MessageBox.Show("Please enter a valid member type");
                                            }
                                        }
                                        else
                                        {
                                            //Error message
                                            MessageBox.Show("The Date of birth was not in the correct format");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Error message
                            MessageBox.Show("This member already exists");
                        }
                    }
                    else
                    {
                        //Error message
                        MessageBox.Show("Please enter at least 3 letters");
                    }
                }
            }
        }

        private void ModifyMemberButton_Click(object sender, EventArgs e)
        {
            //If the input is in a correct format and in the boundaries, it will pass through the if statement
            if (CheckIfMemberIsOk() == true)
            {
                if (memberNameTextBox.TextLength >= 3)
                {
                    //Get the selected index for member
                    string name = showMemberComboBox.Text;
                    string dob = dobTextBox.Text;
                    int selectedMember = showMemberComboBox.SelectedIndex;
                    string selectedMemberName = showMemberComboBox.Items[selectedMember].ToString();
                    int indexInMemberList = SearchByMember(selectedMemberName);

                    string newName = memberNameTextBox.Text;
                    // Creates a TextInfo based on the "en-US" culture.
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    newName = myTI.ToTitleCase(newName);

                    //This will create a List will all the movies containing what the user entered in the searchTextBox
                    var searchMemberName = memberList.FindAll(x => x.Name.ToLower().Contains(showMemberComboBox.Text.ToLower()));
                    //If the member isn't in a movie, this if statement will modify the information for the member only
                    if (!movieList.Exists(z => z.Member.Exists(y => y.Name == name)))
                    {
                        searchMemberName.ForEach(x => { x.Name = newName; x.Dob = DateTime.Parse(dobTextBox.Text);
                        if (typeComboBox.Text == "Actor")
                        {
                                x.MemberType = 1;
                        }
                        else if (typeComboBox.Text == "Director")
                        {
                                x.MemberType = 2;
                        }
                        else if (typeComboBox.Text == "Producer")
                        {
                                x.MemberType = 3;
                        }
                        else if (typeComboBox.Text == "Director of photography")
                        {
                                x.MemberType = 4;
                        }
                        });
                        //Modify the member object in the showMemberComboBox
                        showMemberComboBox.Items.Clear();
                        foreach (Member m in memberList)
                        {
                            showMemberComboBox.Items.Add(m.Name);
                        }

                        //Update the member in the db
                        //UpdateMemberInDB(searchMemberName);

                        //Clear the appropriate textbox
                        ClearTheTextBoxes();
                        movieListView.Items.Clear();
                    }
                    else
                    {
                        foreach (Movie m in movieList)
                        {
                            for (int i = 0; i < m.Member.Count; i++)
                            {
                                if (searchMemberName.Exists(x => x.ID == m.Member[i].ID))
                                {
                                    if (DateTime.TryParse(dob, out DateTime DateValue))
                                    {
                                        m.Member[i].Name = newName;
                                        m.Member[i].Dob = DateValue;

                                        if (typeComboBox.Text == "Actor")
                                        {
                                            m.Member[i].MemberType = 1;
                                        }
                                        else if (typeComboBox.Text == "Director")
                                        {
                                            m.Member[i].MemberType = 2;
                                        }
                                        else if (typeComboBox.Text == "Producer")
                                        {
                                            m.Member[i].MemberType = 3;
                                        }
                                        else if (typeComboBox.Text == "Director of photography")
                                        {
                                            m.Member[i].MemberType = 4;
                                        }

                                        //Modify the member object in the emberList
                                        memberList.RemoveAt(indexInMemberList);
                                        memberList.Insert(indexInMemberList, m.Member[i]);

                                        //Modify the member object in the movie
                                        m.Member.Insert(i, m.Member[i]);
                                        m.Member.RemoveAt(i + 1);

                                        //Modify the member object in the showMemberComboBox
                                        showMemberComboBox.Items.Insert(selectedMember, m.Member[i].Name);
                                        showMemberComboBox.Items.RemoveAt(selectedMember + 1);

                                        //Update the movie in the db
                                        //UpdateMovieInDB(m);
                                        //Update the member in the db
                                        //UpdateMemberInDB(searchMemberName);

                                        //Clear the appropriate textbox
                                        ClearTheTextBoxes();
                                        movieListView.Items.Clear();
                                    }
                                    else
                                    {
                                        //Error message
                                        MessageBox.Show("The Date of birth was not in the correct format");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter at least 3 letters");
                }
            }
        }

        private void DeleteMemberButton_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedIndices.Count > 0)
            {
                if (movieListView.SelectedIndices.Count > 0)
                {
                    //Clear the text boxes accordingly
                    memberNameTextBox.Clear();
                    dobTextBox.Clear();
                    typeComboBox.Text = "";

                    //Get the selected indexes for movies and member
                    int selectedMember = memberListBox.SelectedIndex;
                    int selectedMovie = movieListView.SelectedIndices[0];

                    string selectedMemberName = memberListBox.Items[selectedMember].ToString();
                    string memberNameLabel = memberNameTextBox.Text;

                    //If an item is selected,
                    if (selectedMember > -1)
                    {
                        //Delete the item in question from movieList
                        movieList[selectedMovie].Member.RemoveAt(selectedMember);

                        MessageBox.Show(selectedMemberName + " has been deleted from this movie");

                        //Update the form information
                        UpdateInfo();
                        /*
                        //Update the movie in the db
                        if (DeleteJTMovieMemberFromDB(movieList[selectedMovie].ID, movieList[selectedMovie].Member[selectedMember].ID) != 0)
                        {
                            //Delete the item in question from movieList
                            movieList[selectedMovie].Member.RemoveAt(selectedMember);

                            MessageBox.Show(selectedMemberName + " has been deleted from this movie");

                            //Update the form information
                            UpdateInfo();
                        }
                        else
                        {
                            MessageBox.Show("The member was not deleted from the movie");
                        }*/
                    }

                    else
                    {
                        MessageBox.Show("Please select a member to remove");
                    }
                }
            }
            else
            {
                //Get the selected index for member
                int selectedMember = showMemberComboBox.SelectedIndex;
                string selectedMemberName = showMemberComboBox.Items[selectedMember].ToString();
                int indexInMemberList = SearchByMember(selectedMemberName);

                //This will create a List will all the movies containing what the user entered in the searchTextBox
                var searchMemberName = memberList.Find(x => x.Name.ToLower().Contains(showMemberComboBox.Text.ToLower()));

                if (!movieList.Exists(x => x.Member.Exists(y => y.Name == searchMemberName.Name)))
                {
                    showMemberComboBox.Items.RemoveAt(selectedMember);
                    memberList.RemoveAt(indexInMemberList);

                    //Clear the appropriate textbox
                    ClearTheTextBoxes();
                    movieListView.Items.Clear();
                }
                else
                {
                    foreach (Movie m in movieList)
                    {
                        for (int i = 0; i < m.Member.Count; i++)
                        {
                            if (searchMemberName.ID == m.Member[i].ID)
                            {

                                m.Member.RemoveAt(i);
                                showMemberComboBox.Items.RemoveAt(selectedMember);
                                memberList.RemoveAt(indexInMemberList);
                                //Clear the appropriate textbox
                                ClearTheTextBoxes();
                                movieListView.Items.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void MemberListBox_Click(object sender, EventArgs e)
        {
            //Make the member controls visible within the form
            memberNameLabel.Visible = true;
            memberNameTextBox.Visible = true;
            addMemberButton.Visible = true;
            deleteMemberButton.Visible = true;
            MakeGenreInvisible();
            //Clear the selected item from the genreListBox to avoid confusion for the user
            genreListBox.ClearSelected();
            memberNameTextBox.Text = "";
        }

        private void DobTextBox_Click(object sender, EventArgs e)
        {
            dobTextBox.Text = "";
        }
    }
}
