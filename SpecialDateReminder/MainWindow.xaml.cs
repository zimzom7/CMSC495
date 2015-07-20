/********************************************REVISION HISTORY********************************************
2015-07-11  Jana    Added code to initialize dataset from database and save back to database at closing.




********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpecialDateReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        SDRDataSet SDRDataSet { get; set; }
        Calendar Calendar { get; set; }
        SqlConnection Connection { get; set; }
        SqlCommand PersonCommand { get; set; }
        SqlDataAdapter PersonDataAdapter { get; set; }
        SqlCommandBuilder PersonCommandBuilder { get; set; }
        SqlCommand EventCommand { get; set; }
        SqlDataAdapter EventDataAdapter { get; set; }
        SqlCommandBuilder EventCommandBuilder { get; set; }
        SqlCommand Wish_ListCommand { get; set; }
        SqlDataAdapter Wish_ListDataAdapter { get; set; }
        SqlCommandBuilder Wish_ListCommandBuilder { get; set; }
        SqlCommand Wish_List_ItemCommand { get; set; }
        SqlDataAdapter Wish_List_ItemDataAdapter { get; set; }
        SqlCommandBuilder Wish_List_ItemCommandBuilder { get; set; }
        bool Exiting { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            SDRDataSet = new SDRDataSet();

            this.DataContext = SDRDataSet; // Use this for data binding?

            Connection = new SqlConnection(SpecialDateReminder.Properties.Settings.Default.SDRConnectionString);
            Connection.Open();

            // Populate dataset with data from database.
            PersonCommand = new SqlCommand("SELECT * FROM Person", Connection);
            PersonDataAdapter = new SqlDataAdapter(PersonCommand);
            PersonCommandBuilder = new SqlCommandBuilder(PersonDataAdapter);
            PersonDataAdapter.Fill(SDRDataSet, "Person");

            EventCommand = new SqlCommand("SELECT * FROM Event", Connection);
            EventDataAdapter = new SqlDataAdapter(EventCommand);
            EventCommandBuilder = new SqlCommandBuilder(EventDataAdapter);
            EventDataAdapter.Fill(SDRDataSet, "Event");

            Wish_ListCommand = new SqlCommand("SELECT * FROM Wish_List", Connection);
            Wish_ListDataAdapter = new SqlDataAdapter(Wish_ListCommand);
            Wish_ListCommandBuilder = new SqlCommandBuilder(Wish_ListDataAdapter);
            Wish_ListDataAdapter.Fill(SDRDataSet, "Wish_List");

            Wish_List_ItemCommand = new SqlCommand("SELECT * FROM Wish_List_Item", Connection);
            Wish_List_ItemDataAdapter = new SqlDataAdapter(Wish_List_ItemCommand);
            Wish_List_ItemCommandBuilder = new SqlCommandBuilder(Wish_List_ItemDataAdapter);
            Wish_List_ItemDataAdapter.Fill(SDRDataSet, "Wish_List_Item");

            Calendar = new Calendar(SDRDataSet);

            Thread alertThread = new Thread(new ThreadStart(Monitor_Events));
            alertThread.Start();

            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Exiting = true;
            // Update database with any changes and then close connection.
            PersonDataAdapter.Update(SDRDataSet.Person);
            EventDataAdapter.Update(SDRDataSet.Event);
            Wish_ListDataAdapter.Update(SDRDataSet.Wish_List);
            Wish_List_ItemDataAdapter.Update(SDRDataSet.Wish_List_Item);
            Connection.Dispose();
        }

        public void Monitor_Events()
        {
            while (!Exiting)
            {
                //monitor events to see if anything is in the near future
                //if found, alert user
                //allow user to dismiss alert and record this state so it doesn't happen again while program is running

                //Calendar.Alert();

                Thread.Sleep(10000); //check every 10 seconds
            }
        }

    }
}