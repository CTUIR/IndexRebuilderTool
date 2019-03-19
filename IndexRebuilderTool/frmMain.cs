using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IndexRebuilderTool
{
    public partial class frmMain : Form
    {
        private string strSourcePath = "";
        private string strMasterCopyPath = "";
        private string strSourceWithoutExtention = "";
        private string strMasterCopyWithoutExtention = "";
        private string strSourcPathAndName = "";
        private string strMasterCopyPathAndName = "";
        private string strRebuildIndexesScriptFileName = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            rtxStep1.Text = "Step1:  Use SQL Server Management Studio and run SQL script to dynamically " +
                "pull a list of all the tables/indexes in CDMS.  The script is in file " + 
                "./DbScripts/GetListOfTablesAndIndexes.sql and must be run manually.  " +
                "Save the results in a csv file called TableIndexList.csv.";

            rtxStep2.Text = "Step2:  Review the TableIndexThresholds.csv file, to verify the % fragmentation " +
                "thresholds are what they should be.  Add a 4th column to TableIndexList.csv, " +
                "containing the threshold.";

            rtxStep3.Text = "Step3:  \"Build SQL File\" reads the file TableIndexList.csv, and creates " +
                "the SQL code file containing the commands to programatically rebuild the indexes.";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Source File";

            // Show the Dialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSourcPathAndName = openFileDialog1.FileName;
                if (!verifyFile(strSourcPathAndName))
                {
                    txtSoureFile.Text = strSourcPathAndName;
                    strSourcePath = Path.GetDirectoryName(openFileDialog1.FileName);
                    strSourceWithoutExtention = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                }

            }
        }

        private bool verifyFile(string aFileName)
        {
            bool blnIsFileGood = String.IsNullOrEmpty(aFileName);

            return blnIsFileGood;
        }
        private void btnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            List<string> strIndexList = new List<string>();

            StreamReader reader = new StreamReader(strSourcPathAndName);

            string strLineIn = reader.ReadLine();
            while (strLineIn != null)
            {
                strIndexList.Add(strLineIn);

                strLineIn = reader.ReadLine();
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(strSourcPathAndName, false); //append = false
            IndexInfoLine holdRecord = new IndexInfoLine();
            foreach (var item in strIndexList)
            {
                var strItemList = item.Split(',').ToList<string>();

                if ((strItemList[0] == "Fields") && (strItemList[0] == "PK_dbo.Fields"))
                {
                    int intX = 0;
                }

                if (holdRecord.strTableName == "")
                {
                    holdRecord.strTableName = strItemList[0];
                    holdRecord.strIndexName = strItemList[1];

                    writer.WriteLine(item);
                }
                else if ((holdRecord.strTableName == strItemList[0]) &&
                        (holdRecord.strIndexName == strItemList[1])
                    )
                {
                    // Do nothing - skip the record.
                }
                else
                {
                    holdRecord.strTableName = strItemList[0];
                    holdRecord.strIndexName = strItemList[1];

                    writer.WriteLine(item);
                }
            }
            writer.Close();
        }

        private void btnBrowseForMasterCopy_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Source File";

            // Show the Dialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strMasterCopyPathAndName = openFileDialog1.FileName;
                if (!verifyFile(strMasterCopyPathAndName))
                {
                    txtMasterCopy.Text = strMasterCopyPathAndName;
                    strMasterCopyPath = Path.GetDirectoryName(openFileDialog1.FileName);
                    strMasterCopyWithoutExtention = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                }

            }
        }

        private void btnCopyInThresholds_Click(object sender, EventArgs e)
        {
            List<IndexInfoLine> lstMasterInfoList = new List<IndexInfoLine>();
            List<IndexInfoLine> lstIndexInfoList = new List<IndexInfoLine>();
            List<string> strIndexList = new List<string>();

            // First, read the master index list
            StreamReader reader = new StreamReader(strMasterCopyPathAndName);

            int intCommaLoc = -1;
            int intLastCommaLoc = -1;

            string strLineIn = reader.ReadLine();
            while (strLineIn != null)
            {
                IndexInfoLine indexInfoLine = new IndexInfoLine();

                string [] aryLineIn = strLineIn.Split(',');

                indexInfoLine.strTableName = aryLineIn[0];
                indexInfoLine.strIndexName = aryLineIn[1];
                indexInfoLine.dblThreshold = Convert.ToDouble(aryLineIn[3]);

                lstMasterInfoList.Add(indexInfoLine);

                strLineIn = reader.ReadLine();
            }
            reader.Close();

            // Next, load the index list
            //StreamReader reader = new StreamReader(strSourcPathAndName);
            reader = new StreamReader(strSourcPathAndName);

            //string strLineIn = reader.ReadLine();
            strLineIn = reader.ReadLine();
            while (strLineIn != null)
            {
                IndexInfoLine indexInfoLine = new IndexInfoLine();

                string[] aryLineIn = strLineIn.Split(',');

                indexInfoLine.strTableName = aryLineIn[0];
                indexInfoLine.strIndexName = aryLineIn[1];
                indexInfoLine.dblFragmentation = Convert.ToDouble(aryLineIn[2]);

                lstIndexInfoList.Add(indexInfoLine);

                strLineIn = reader.ReadLine();
            }

            reader.Close();

            // If table name and index name match, copy in the threshold
            foreach (var item in lstIndexInfoList)
            {
                for (int i = 0; i < lstMasterInfoList.Count; i++)
                {
                    if ((item.strTableName == lstMasterInfoList[i].strTableName) &&
                        (item.strIndexName == lstMasterInfoList[i].strIndexName)
                    )
                    {
                        item.dblThreshold = lstMasterInfoList[i].dblThreshold;
                        i = lstMasterInfoList.Count;
                    }
                }
            }

            // Now write out the final list.
            StreamWriter writer = new StreamWriter(strSourcPathAndName, false); //append = false

            string strOutLine = "";
            foreach (var item in lstIndexInfoList)
            {
                strOutLine = item.strTableName + "," + item.strIndexName + "," + item.dblFragmentation + "," + item.dblThreshold;
                writer.WriteLine(strOutLine);
            }

            writer.Close();

            if (lstIndexInfoList.Count != lstMasterInfoList.Count)
                MessageBox.Show("The record counts for the source file, and the master file are different.  Please review.");
                
        }

        private int LocatedSecondComma(string strText)
        {
            int intLocation = -1;

            intLocation = strText.LastIndexOf(",");

            return intLocation;
        }

        private void btnSelectScriptFileLocation_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Select Location";



            saveFileDialog1.FileName = "RebuildIndexesScriptFile" + BuildDateTimeStamp() + ".sql";
            saveFileDialog1.DefaultExt = "txt";

            // Show the Dialog.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strRebuildIndexesScriptFileName = saveFileDialog1.FileName;
            }
        }

        private void btnBuildSqlScript_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(strSourcPathAndName);
            StreamWriter writer = new StreamWriter(strRebuildIndexesScriptFileName, false); // append = false
            string strLineOut = "";

            // Write the initialization stuff
            strLineOut = "use CDMS_DEV462\n";
            strLineOut += "go\n";
            strLineOut += "\n";
            strLineOut += "declare @fragmentation as decimal(7, 2);\n";
            strLineOut += "declare @buildCount as int;\n";
            strLineOut += "set @buildCount = 0;";
            strLineOut += "\n";
            strLineOut += "RAISERROR ('Starting to review the indexes...', 0, 1) with NOWAIT\n";
            strLineOut += "\n";

            IndexInfoLine indexInfoLine = new IndexInfoLine();

            string strLineIn = reader.ReadLine();
            while (strLineIn != null)
            {
                string[] aryLineIn = strLineIn.Split(',');

                indexInfoLine.strTableName = aryLineIn[0];
                indexInfoLine.strIndexName = aryLineIn[1];
                indexInfoLine.dblFragmentation = Convert.ToDouble(aryLineIn[2]);
                indexInfoLine.dblThreshold = Convert.ToDouble(aryLineIn[3]);

                strLineOut += "--" + indexInfoLine.strTableName + ", " + indexInfoLine.strIndexName + "\n";
                strLineOut += "set @fragmentation = (\n";
                strLineOut += "\tselect avg_fragmentation_in_percent\n";
                strLineOut += "\tfrom sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) indexstats\n";
                strLineOut += "\tINNER JOIN sys.indexes ind\n";
                strLineOut += "\tON ind.object_id = indexstats.object_id\n";
                strLineOut += "\tAND ind.index_id = indexstats.index_id\n";
                strLineOut += "\twhere OBJECT_NAME(ind.OBJECT_ID) = '" + indexInfoLine.strTableName + "' and ind.name = '" + indexInfoLine.strIndexName + "' and indexstats.alloc_unit_type_desc != 'LOB_DATA'\n";
                strLineOut += ")\n";
                strLineOut += "\n";
                strLineOut += "if (@fragmentation = 0)\n";
                strLineOut += "\tRAISERROR ('" + indexInfoLine.strTableName + " " + indexInfoLine.strIndexName + ":  OK...', 0, 1) with NOWAIT\n";
                strLineOut += "else\n";
                strLineOut += "\tbegin\n";
                strLineOut += "\t\twhile @fragmentation > " + indexInfoLine.dblThreshold + " AND @buildCount < 20\n";
                strLineOut += "\t\tbegin\n";
                strLineOut += "\t\t\talter index [" + indexInfoLine.strIndexName + "] on dbo." + indexInfoLine.strTableName + " rebuild\n";
                strLineOut += "\n";
                strLineOut += "\t\t\tset @buildCount = @buildCount + 1;";
                strLineOut += "\n";
                strLineOut += "\t\t\tset @fragmentation = (\n";
                strLineOut += "\t\t\t\tselect avg_fragmentation_in_percent\n";
                strLineOut += "\t\t\t\tfrom sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) indexstats\n";
                strLineOut += "\t\t\t\tINNER JOIN sys.indexes ind\n";
                strLineOut += "\t\t\t\tON ind.object_id = indexstats.object_id\n";
                strLineOut += "\t\t\t\tAND ind.index_id = indexstats.index_id\n";
                strLineOut += "\t\t\t\twhere OBJECT_NAME(ind.OBJECT_ID) = '" + indexInfoLine.strTableName + "' and ind.name = '" + indexInfoLine.strIndexName + "' and indexstats.alloc_unit_type_desc != 'LOB_DATA'\n";
                strLineOut += "\t\t\t)\n";
                strLineOut += "\t\tend\n";
                strLineOut += "\t\tif (@buildCount = 20)\n";
                strLineOut += "\t\t\tRAISERROR ('" + indexInfoLine.strTableName + " " + indexInfoLine.strIndexName + " still exceed threshold after 20 tries...', 0, 1) with NOWAIT;\n";
                strLineOut += "\t\telse\n";
                strLineOut += "\t\t\tRAISERROR ('" + indexInfoLine.strTableName + " " + indexInfoLine.strIndexName + " rebuilt...', 0, 1) with NOWAIT;\n";
                strLineOut += "\n";
                strLineOut += "\t\tset @buildCount = 0;\n";
                strLineOut += "\tend\n";
                strLineOut += "\n";
                strLineOut += "\n";

                strLineIn = reader.ReadLine();
            }
            reader.Close();

            strLineOut += "RAISERROR ('Done reviewing the indexes...', 0, 1) with NOWAIT\n";

            writer.WriteLine(strLineOut);

            writer.Close();
        }

        private string BuildDateTimeStamp()
        {
            DateTime dt = DateTime.Now;
            string strYear = dt.Year.ToString();

            string strMonth = dt.Month.ToString();
            if (strMonth.Length < 2)
                strMonth = Pad2DigitNumber(strMonth);

            string strDay = dt.Day.ToString();
            if (strDay.Length < 2)
                strDay = Pad2DigitNumber(strDay);

            string strHour = dt.Hour.ToString();
            if (strHour.Length < 2)
                strHour = Pad2DigitNumber(strHour);

            string strMinute = dt.Minute.ToString();
            if (strMinute.Length < 2)
                strMinute = Pad2DigitNumber(strMinute);

            string strSecond = dt.Second.ToString();
            if (strSecond.Length < 2)
                strSecond = Pad2DigitNumber(strSecond);

            return (strYear + strMonth + strDay + "_" + strHour + strMinute + strSecond);
        }

        private string Pad2DigitNumber(string strNum)
        {
            if (strNum.Length < 2)
                strNum = "0" + strNum;

            return strNum;
        }

        private void InitializeSqlScriptFile()
        {

        }
    }

    public class IndexInfoLine
    {
        public string strTableName = "";
        public string strIndexName = "";
        public double dblFragmentation = 0.0;
        public double dblThreshold = 0.0;
    }
}
