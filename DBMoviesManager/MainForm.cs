using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        const int LOWER_YEAR = 1888;
        const int UPPER_YEAR = 2020;
        const int LOWER_RATING = 1;
        const int UPPER_RATING = 5;

        //  Declare Lists for each of the following: movie
        List<Movie> movieList = new List<Movie>();

        //Create a new Movie object
        Movie currentMovie = new Movie();

        public MainForm()
        {
            InitializeComponent();

            MakeGenreInvisible();
            MakeMemberInvisible();
            MakeMovieInvisible();
            showGenreComboBox.Text = "All";

            //This method sets up a connection to a Postgres database
            SetDBConnection("localhost", "postgres", "bmc", "moviedb");

            checkPostgresVersion();

            GetMoviesFromDB();
        }
        /// <summary>
        /// This method will search through every movie in moviList
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
        /// <summary>
        /// This method setsup a db connection to a postgreSQL db. The connection is stored in the global variable 'dbConnection'
        /// </summary>
        /// <param name="serverAddress">The server name or IP address</param>
        /// <param name="username">The username having the right to manipulate the db</param>
        /// <param name="password">The corresponding password of the user</param>
        /// <param name="dbName">The db to connect to</param>
        /// <returns></returns>
        private void SetDBConnection(string serverAddress, string username, string password, string dbName)
        {
            //string conectionString = "Host=localhost;Username=postgres;Password=gmq715;Database=test_db";
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + password + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);
        }

        
        /// <summary>
        /// This methods displays the version of the Postgres server to which the program connects to
        /// </summary>
        private void checkPostgresVersion()
        {
            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();

            //This is a string representing the SQL query to execute in the db
            string sqlQuery = "SELECT version()";


            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            string postgresVersion = dbCommand.ExecuteScalar().ToString();

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();
        }

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

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new Movie and setup its info
                currentMovie = new Movie(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetTimeSpan(3).ToString(), dataReader.GetDouble(4), dataReader.GetString(5));

                movieList.Add(currentMovie);

                movieListView.View = View.Details;          //Set the view to show details.
                movieListView.FullRowSelect = true;         //Select the item and subitems when selection is made.

                movieListView.Columns.Add("Title");         //Add column Title
                movieListView.Columns.Add("Year");         //Add column Year
                movieListView.Columns.Add("Length");         //Add column Length

                movieListView.Items.Add(new ListViewItem(new string[] { currentMovie.Title, currentMovie.Year.ToString(), currentMovie.Length.ToString() }));
                //Resize the headers so we will see al the content without having to resize it
                movieListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                movieListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            //After executing the query(ies) in the db, the connection must be closed
            dbConnection.Close();

            return movieList;
        }
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
        public void MakeMovieInvisible()
        {
            genreLabel.Visible = false;
            genreComboBox.Visible = false;
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
        }
        public void MakeMovieVisible()
        {
            genreLabel.Visible = true;
            genreComboBox.Visible = true;
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
        }
        /*private void ShowGenreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the movieListView to only show the movies of the appropriate genre
            movieListView.Items.Clear();

            MakeMemberInvisible();
            MakeGenreInvisible();
            MakeMovieInvisible();
            addLabel.Visible = false;
            addComboBox.Visible = false;

            //This foreach loop will look at every single movie in the movieList
            foreach (Movie currentMovie in movieList)
            {
                //If the movie has the same genre as the selected genre in the genreComboBox, it go through the if statement
                if (genreComboBox.SelectedItem.ToString() == currentMovie.Genre)
                {
                    //This add the current object to the movieListView
                    movieListView.Items.Add(new ListViewItem(new string[] { currentMovie.Title, currentMovie.Year.ToString() }));

                    //Clear the textboxes
                    genreComboBox.Text = "";
                    titleTextBox.Text = "";
                    yearTextBox.Text = "";
                    lengthTextBox.Text = "";
                    ratingTextBox.Text = "";
                    imageTextBox.Text = "";
                    pictureBox.Visible = false;
                    searchLabel.Visible = true;
                    searchTextBox.Text = "";
                }
                //If the selected genre is all it will display all the movies no matter the genre
                else if (genreComboBox.Text == "All")
                {
                    //This will add every single movie to the movieListView
                    movieListView.Items.Add(new ListViewItem(new string[] { currentMovie.Title, currentMovie.Year.ToString() }));

                    //Clear the textboxes
                    genreComboBox.Text = "";
                    titleTextBox.Text = "";
                    yearTextBox.Text = "";
                    lengthTextBox.Text = "";
                    ratingTextBox.Text = "";
                    imageTextBox.Text = "";
                    searchTextBox.Text = "";
                }
            }
        }*/

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            //If the input is in a correct format and in the boundaries, it will pass through the if statement
            if (CheckIfMovieIsOk() == true && checkIfIntervalYearOK(int.Parse(yearTextBox.Text), LOWER_YEAR, UPPER_YEAR) && checkIfIntervalRatingOK(decimal.Parse(ratingTextBox.Text), LOWER_RATING, UPPER_RATING))
            {
                //This will create a new Movie object
                Movie currentMovie = new Movie();
                //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                if (imageTextBox.Text.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    //This assigns the values of the current Movie
                    //currentMovie.Genre = genreComboBox.Text;
                    currentMovie.Title = titleTextBox.Text;
                    currentMovie.Year = int.Parse(yearTextBox.Text);
                    currentMovie.Length = lengthTextBox.Text;
                    currentMovie.Rating = double.Parse(ratingTextBox.Text);
                    currentMovie.Image = imageTextBox.Text;

                    //Add the current Movie to the movieList
                    movieList.Add(currentMovie);

                    //Add the current Movie to the movieListView
                    movieListView.Items.Add(new ListViewItem(new string[] { currentMovie.Title, currentMovie.Year.ToString() }));

                    //Clear the textboxes
                    genreComboBox.Text = "";
                    titleTextBox.Text = "";
                    yearTextBox.Text = "";
                    lengthTextBox.Text = "";
                    ratingTextBox.Text = "";
                    imageTextBox.Text = "";
                    pictureBox.Visible = false;
                    searchLabel.Visible = true;
                    searchTextBox.Text = "";
                }
                //The user will be notified if they did not entere the correct image format
                else
                {
                    MessageBox.Show("The image must be in a jpg, jpeg or a png format, the image was not saved, if you want to add the correct image, please select the movie to modify it");
                }
            }
        }
        private bool CheckIfMovieIsOk()
        {
            bool formOK = true;

            formOK = formOK && CheckIfInputOk(genreComboBox.Text, "string");
            formOK = formOK && CheckIfInputOk(titleTextBox.Text, "string");
            formOK = formOK && CheckIfInputOk(yearTextBox.Text, "int");
            formOK = formOK && CheckIfInputOk(lengthTextBox.Text, "string");
            formOK = formOK && CheckIfInputOk(ratingTextBox.Text, "decimal");
            formOK = formOK && CheckIfInputOk(imageTextBox.Text, "string");

            return formOK;
        }
        //This method will be used to make sure the user input is in the correct format
        private bool CheckIfInputOk(string field, string fieldType)
        {
            int intVariable;
            double doubleVariable;

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
                case "string":
                    //Nothing to do
                    break;
            }

            return true;
        }
        /// <summary>
        /// This method will make sure the user entered a valid year in the boundaries
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
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
        /// <param name="value"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
        private bool checkIfIntervalRatingOK(decimal value, int lowerLimit, int upperLimit)
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

        private void ModifyMovieButton_Click(object sender, EventArgs e)
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

                //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                if (imageTextBox.Text.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || imageTextBox.Text.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Assigns the values to the object
                    //aMovie.Genre = genreComboBox.Text;
                    aMovie.Title = titleTextBox.Text;
                    aMovie.Year = int.Parse(yearTextBox.Text);
                    aMovie.Length = lengthTextBox.Text;
                    aMovie.Rating = double.Parse(ratingTextBox.Text);
                    pictureBox.Visible = false;
                    aMovie.Image = imageTextBox.Text;
                    searchLabel.Visible = true;

                    //Removes the object at the selected index in the movieListView
                    movieListView.Items.RemoveAt(selectedIndex);
                    //Inserts the modified object at the selected index in the movieListView
                    movieListView.Items.Insert(selectedIndex, new ListViewItem(new string[] { aMovie.Title, aMovie.Year.ToString() }));

                    //Removes the object at the selected index in the movieList
                    movieList.RemoveAt(indexInMovieList);
                    //Inserts the modified object at the selected index in the movieList
                    movieList.Insert(indexInMovieList, aMovie);

                    //Clear the textboxes
                    genreComboBox.Text = "";
                    titleTextBox.Text = "";
                    yearTextBox.Text = "";
                    lengthTextBox.Text = "";
                    ratingTextBox.Text = "";
                    imageTextBox.Text = "";
                    searchTextBox.Text = "";
                }
                //The user will be notified if they did not entere the correct image format
                else
                {
                    MessageBox.Show("The image must be in a jpg, jpeg or a png format, the image was not saved, if you want to add the correct image, please select the movie to modify it");
                }
            }
            //If no movie is selected, it will notify the user to select a movie to modify it
            else
            {
                MessageBox.Show("You need to select a movie to modify");
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
                genreComboBox.Text = "";
                titleTextBox.Text = "";
                yearTextBox.Text = "";
                lengthTextBox.Text = "";
                ratingTextBox.Text = "";
                imageTextBox.Text = "";
                pictureBox.Visible = false;
            }
            //If no movie is selected, it will notify the user to select a movie to delete it
            else
            {
                MessageBox.Show("You need to select a movie to delete");
            }
        }

        private void MovieListView_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                //If there is no image, it will go through the if statement
                string movieImage = movieList[indexInMovieList].Image.ToString();
                //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                if (movieList[indexInMovieList].Image.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || movieList[indexInMovieList].Image.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase) || movieList[indexInMovieList].Image.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Assigns the values from the object to the textboxes
                    //genreComboBox.Text = movieList[indexInMovieList].Genre;
                    titleTextBox.Text = movieList[indexInMovieList].Title;
                    yearTextBox.Text = movieList[indexInMovieList].Year.ToString();
                    lengthTextBox.Text = movieList[indexInMovieList].Length.ToString();
                    ratingTextBox.Text = movieList[indexInMovieList].Rating.ToString();
                    searchLabel.Visible = true;
                    searchTextBox.Text = "";
                    genreComboBox.Text = "";
                    imageTextBox.Text = movieList[indexInMovieList].Image;
                    pictureBox.Visible = true;
                    pictureBox.Image = Image.FromFile(imageTextBox.Text);
                    MakeGenreInvisible();
                    MakeMemberInvisible();
                }
                //Makes sure the imageTextBox is indeed a picture in either the jpg, jepg or the png format
                if (movieList[indexInMovieList].Image.ToString() == "")
                {
                    //Assigns the values from the object to the textboxes
                    //genreComboBox.Text = movieList[indexInMovieList].Genre;
                    titleTextBox.Text = movieList[indexInMovieList].Title;
                    yearTextBox.Text = movieList[indexInMovieList].Year.ToString();
                    lengthTextBox.Text = movieList[indexInMovieList].Length.ToString();
                    ratingTextBox.Text = movieList[indexInMovieList].Rating.ToString();
                    searchLabel.Visible = true;
                    searchTextBox.Text = "";
                    genreComboBox.Text = "";
                    imageTextBox.Text = movieList[indexInMovieList].Image;
                }
                //The user will be notified if they did not entere the correct image format
                else
                {
                    MessageBox.Show("The image must be in a jpg, jpeg or a png format, the image was not saved, if you want to add the correct image, please select the movie to modify it");
                }
            }
        }

        private void AddComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the movie has the same genre as the selected genre in the genreComboBox, it go through the if statement
            if (addComboBox.Text == "Movie")
            {
                MakeMovieVisible();
                MakeMemberInvisible();
                MakeGenreInvisible();
            }
            //If the selected genre is all it will display all the movies no matter the genre
            else if (addComboBox.Text == "Member")
            {
                MakeMovieInvisible();
                MakeMemberVisible();
                MakeGenreInvisible();
            }
            //If the selected genre is all it will display all the movies no matter the genre
            else if (addComboBox.Text == "Genre")
            {
                MakeMovieInvisible();
                MakeMemberInvisible();
                MakeGenreVisible();
            }
        }
    }
}
