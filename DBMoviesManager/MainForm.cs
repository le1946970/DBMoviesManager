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

            //This method sets up a connection to a Postgres database
            SetDBConnection("localhost", "postgres", "gmq715", "test_db");

            checkPostgresVersion();

            GetMoviesFromDB();
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
            
            MessageBox.Show("PostgreSQL version: " + postgresVersion);
        }
        private List<Movie> GetMoviesFromDB()
        {
            //Before sending commands to the database, the connection must be opened
            dbConnection.Open();


            //This is a string representing the SQL query to execute in the db            
            string sqlQuery = "SELECT * FROM employee;";
            Console.WriteLine("SQL Query: " + sqlQuery);


            //This is the actual SQL containing the query to be executed
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            //This variable stores the result of the SQL query sent to the db
            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            //Read each line present in the dataReader
            while (dataReader.Read())
            {
                //Create a new Movie and setup its info
                currentMovie = new Movie(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetInt32(3), dataReader.GetInt32(4), dataReader.GetString(5), dataReader.GetString(6));

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
    }
}
