using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Election
{
    public partial class FormsBasedUI : Form, IUserInterface
    {
        /// <summary>
        /// object of class IConstituencyFileReader
        /// </summary>
        public IConstituencyFileReader IOhandler { get; set; }
        /// <summary>
        /// object of ConfigData for passing in the user selected files
        /// </summary>
        private ConfigData configData = new ConfigData();
        /// <summary>
        /// object of class ConstituencyList for accessing properties and methods of this class
        /// </summary>
        private ConstituencyList constituencyList;
        /// <summary>
        /// Open file browser window for user to select XML files
        /// </summary>
        OpenFileDialog ofd = new OpenFileDialog();
        Boolean bool1;
        
        int num = 0;
        //create array for saving filenames in
        String[] files = new String[5];
        /// <summary>
        /// variable for passing in slected report type, LINQ Query case name in ConstituencyList
        /// </summary>
        private String selectedReportType;

        public FormsBasedUI(IConstituencyFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        private void FormsBasedUI_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Class for holding file name and root of XML file to be loaded
        /// </summary>
        public void SetupConfigData()
        {            
            //filter out everything except xml files
            ofd.Filter = "XML|*.xml";
            //open file dialog to search for xml files
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files[num] = ofd.SafeFileName;                
            }
                // Generate configuration data (filename and required vote report for each constituency)
                configData.configRecords.Add(new ConfigRecord(files[num]));
                num++;
        }
        /// <summary>
        /// Load all the selected XML files into the program
        /// </summary>
        public void RunProducerConsumer()
        {
            //Create constituency list to hold individual constituency objects read from datasets
            constituencyList = new ConstituencyList();

            // Create progress manager with number of files to process
            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            // Output message to indicate that the program has started
            lblProgress.Text = "Creating and starting all producers and consumers";

            // Create a PCQueue instance, give it a capacity of 4
            var pcQueue = new PCQueue(4);

            // Create 2 Producer instances and 2 Consumer instances, these will begin executing on
            // their respective threads as soon as they are instantiated
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler)
                //,new Producer("P2", pcQueue, configData, IOhandler) 
            };

            Consumer[] consumers = { new Consumer("C1", pcQueue, constituencyList, progManager),
                                     new Consumer("C2", pcQueue, constituencyList, progManager) };

            // Keep producing and consuming until all work items are completed
            while (progManager.ItemsRemaining > 0) ;

            // Output message to indicate that the program is shutting down
            lblProgress.Text = "Shutting down all producers and consumers";

            // Deactivate the PCQueue so it does not prevent waiting producer and/or consumer threads
            // from completing
            pcQueue.Active = false;

            // Iterate through producers and signal them to finish
            foreach (var p in producers)
            {
                p.Finished = true;
            }

            // Iterate through consumers and signal them to finish
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            // We need to ensure that no thread waiting on Monitor.Wait() is stranded with
            // no Monitor.Pulse() now possible since all producer and consumer threads have
            // been signalled to stop, in the worse case all such threads could be stranded
            // so pulse that many times to ensure enough pulses are made available (or the
            // program can halt erroneously), wasted pulse are simply ignored 
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    // Pulse the PCQueue to signal any waiting threads
                    Monitor.Pulse(pcQueue);

                    // Give a short break to the main thread so the pulses have time to be
                    // detected by any potentially waiting producer and/or consumer threads
                    Thread.Sleep(100);
                }
            }

            // Once all producer and consumer threads have finally finished we can gracefully
            // shutdown the main thread, this is achieved by spinning on a while() loop until
            // there are no running threads, in this case we do not mind the main thread
            // spinning as we are about to shutdown the program
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ; // Wait by spinning

            Console.WriteLine();
            lblProgress.Text = "All producers and consumers shut down";
        }
        /// <summary>
        /// Display the results of the requested LINQ Query by the user based on the button selection
        /// </summary>
        public void DisplayResults()
        {          
            // Clear any items in listbox
            lstRelevant.Items.Clear();
            constituencyList.data(selectedReportType);
            

            if (selectedReportType == "ElectionWinner")
            {
                foreach (var con in constituencyList.dataCand(selectedReportType))
                    lstRelevant.Items.Add(con);
            }

            else if(selectedReportType =="Votes")
            {
                foreach (var con in constituencyList.data(selectedReportType))
                    lstRelevant.Items.Add(con);
            }
            else if(selectedReportType =="Candidates")
            {
                foreach (var con in constituencyList.dataCand(selectedReportType))
                    lstRelevant.Items.Add(con);
            }
            else if (selectedReportType == "PartyWinner")
            {
                foreach (var con in constituencyList.data(selectedReportType))
                    lstRelevant.Items.Add(con);
            }
            else if (selectedReportType == "ConstituencyWinner")
            {
                foreach (var con in constituencyList.dataCon(selectedReportType, cboCons.SelectedItem.ToString()))
                    lstRelevant.Items.Add(con);
            }
            else if (selectedReportType == "ConstituencyCandidates")
            {
                foreach (var con in constituencyList.dataCon(selectedReportType, cboCons.SelectedItem.ToString()))
                    lstRelevant.Items.Add(con);
            }
            else if (selectedReportType == "ElectedCandidates")
            {
                foreach (var con in constituencyList.dataCon(selectedReportType))
                    lstRelevant.Items.Add(con);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            SetupConfigData();
            btnLoad.Enabled = true;
            lblProgress.Text = "Config data loaded. Waiting for user to press load";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "Loading data. Please wait.";
            lblProgress.Refresh();
            RunProducerConsumer();
            //btnOpen.Enabled = false;
            btnCandidates.Enabled = true;
            btnConstituency.Enabled = true;
            btnParty.Enabled = true;
            btnWinner.Enabled = true;
            btnPartyWin.Enabled = true;
            btnConCan.Enabled = true;
            btnElectedCandidates.Enabled = true;
            btnLoad.Enabled = false;
            btnOpen.Enabled = false;
            lblProgress.Text = "All data files loaded.";
            foreach (Constituency con in constituencyList.constituency)
            { cboCons.Items.Add(con.constituencyName); }
        }
        //give the variable, selectedReportType a name to pass as a case to ConstituencyList via DisplayResults()
        private void btnParty_Click(object sender, EventArgs e)
        {
            selectedReportType = "Votes";
            DisplayResults();
        }

        private void btnWinner_Click(object sender, EventArgs e)
        {
            selectedReportType = "ElectionWinner";
            DisplayResults();
        }

        private void btnCandidates_Click(object sender, EventArgs e)
        {
            selectedReportType = "Candidates";
            DisplayResults();
        }

        private void btnPartyWin_Click(object sender, EventArgs e)
        {
            selectedReportType = "PartyWinner";
            DisplayResults();
        }
        //make sure their is a constituency selected to avoid crashing the program
        private void btnConstituency_Click(object sender, EventArgs e)
        {
            bool1 = false;
            while (bool1 == false)
            {
                try
                {
                    if (cboCons.SelectedItem.ToString() == " ")
                    {
                        MissingInformationException missing = new MissingInformationException();
                        throw (missing);
                    }
                    else
                    {
                        selectedReportType = "ConstituencyWinner";
                        DisplayResults();
                        bool1 = true;
                    }
                    bool1 = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");
                    bool1 = true;
                }
            }
        }
        //try and catch an exception to prevent the program for unexpextingly close 
        private void btnConCan_Click(object sender, EventArgs e)
        {
            bool1 = false;
            while (bool1 == false)
            {
                try
                {
                    if (cboCons.SelectedItem.ToString() == " ")
                    {
                        MissingInformationException missing = new MissingInformationException();
                        throw (missing);
                    }
                    else
                    {
                        selectedReportType = "ConstituencyCandidates";
                        DisplayResults();
                        bool1 = true;
                    }
                    bool1 = true;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");
                    bool1 = true;
                }
            }
        }

        private void btnElectedCandidates_Click(object sender, EventArgs e)
        {
            selectedReportType = "ElectedCandidates";
            DisplayResults();
        }
        //close program down properly
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
