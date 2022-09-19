using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GISGeometryCompressor
{
    public partial class frmMain : Form
    {
        //Declare global variables
        string database;
        string table;
        string primaryKey;
        string column;
        int passes;
        bool toCompressOrNot;
        string id;
        List<int> rowIDs = new List<int>();
        int progress = 0;
        string success;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //Show console window
            AllocConsole();

            //Populate database selection list
            cboSelectDatabase.DataSource = GetDatabaseList();

        }

        //start boilerplate code to display console window to user
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        //end boilerplate code

        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();
            // Open connection to the database
            string conString = "Server= localhost; Database= GIS; Integrated Security=True;";
            //string conString = "Server= localhost; Database= GIS; Integrated Security=True;";


            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }

        public List<string> GetTableList()
        {
            List<string> list = new List<string>();
            string conString = "Server= localhost; Database= " + cboSelectDatabase.Text + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name FROM sysobjects WHERE xtype = 'U'", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }

        private void cboSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("#######################");
            Console.WriteLine("Database: " + cboSelectDatabase.Text);
            Console.WriteLine("#######################");

            //Output list of tables to the console
            GetTableList().ForEach(i => Console.WriteLine("{0}\t", i));

            cboSelectTable.DataSource = GetTableList();

            //Writes a line break to the consolve
            Console.WriteLine("");
        }

        public List<string> GetColumnList()
        {
            List<string> list = new List<string>();
            string conString = "Server= localhost; Database= " + cboSelectDatabase.Text + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = " + "'" + cboSelectTable.Text + "' and t.type = 'U'", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }

        private void cboSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Table: " + cboSelectTable.Text);
            Console.WriteLine("-----------------------");

            //Output list of tables to the console
            GetColumnList().ForEach(i => Console.WriteLine("{0}\t", i));

            cboSelectPKEY.DataSource = GetColumnList();
            cboSelectColumn.DataSource = GetColumnList();

            //Writes a line break to the consolve
            Console.WriteLine("");
        }

        //This doesn't work yet
        public List<string> GetPrimaryKey()
        {
            List<string> list = new List<string>();
            string conString = "Server= localhost; Database= " + cboSelectDatabase.Text + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT a.COLUMN_NAME FROM all_cons_columns a INNER JOIN all_constraints c ON a.constraint_name = c.constraint_name WHERE c.table_name = '" + table + "' AND c.constraint_type = 'P';", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }

        public Tuple<int, string> GetGeometryData(int rowID)
        {
            String tableName = table;

            string result = "No result";
            string conString = "Server= localhost; Database= " + database + "; Integrated Security=True;";
            //int rowID = 0;

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT " + primaryKey + ", " + column + ".STAsText() FROM " + table + " WHERE " + primaryKey + " = " + rowID.ToString(), con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rowID = Convert.ToInt16(dr[0]);
                            //rowID = Convert.ToInt32(dr[1]);
                            result = (dr[1].ToString());
                        }
                    }
                }
            }

            return Tuple.Create(rowID, result);

        }

        public Tuple<int, string> GenerateSimplifiedPolygonText(int rowID)
        {
            List<int> rowIDs = new List<int>();

            rowIDs = GetRowIDs();

            Tuple<int, string> polygon = GetGeometryData(rowID);


            string query;

            if (polygon.Item2.Contains("MULTI") == false)
            {
                //checks if the polygon is a multipolygon or a regular polygon
                query = drawPoly(polygon.Item2, passes);
            }
            else
            {
                query = drawMultiPoly(polygon.Item2, passes);
            };
            return Tuple.Create(polygon.Item1, query);
        }

        private string drawPoly(string polygon, int passes)
        {
            Console.WriteLine(polygon);

            polygon = polygon.Replace("POLYGON ", "");
            polygon = polygon.Replace("))", "");
            polygon = polygon.Replace("((", "");
            polygon = polygon.Replace(", ", ", ");

            string[] linesCoords = polygon.Split(new string[] { "), (" }, StringSplitOptions.None);

            List<string>[] list = new List<string>[polygon.Count()];

            //Rebuild query after simplification
            //Opening bracket
            string query = "POLYGON (";

            for (int i = 0; i < linesCoords.Count(); i++)
            {

                linesCoords[i] = linesCoords[i].Replace("(", "");
                linesCoords[i] = linesCoords[i].Replace(")", "");

                //Splits each Line of co-ordinates into individual co-ordinates and places them into a list for processing by the simplifier
                string[] lineCoords = linesCoords[i].Split(new string[] { ", " }, StringSplitOptions.None);

                list[i] = lineCoords.ToList();

                Console.WriteLine("Number of rows before: " + list[i].Count());
                Console.WriteLine("Memory consumption before: " + GetObjectSize(list[i]) + " bytes");
                Console.WriteLine();

                query = query + simplifyPolygon(list[i], passes);
                query = query + ",";


            }
            query = query + "'";

            //Remove trailing "," and add closing bracket.
            query = query.Replace("),'", "))'");

            Console.WriteLine();

            return query;
        }

        private string drawMultiPoly(string multipolygon, int passes)
        {
            Console.WriteLine(multipolygon);

            multipolygon = multipolygon.Replace("MULTIPOLYGON ", "");
            multipolygon = multipolygon.Replace("(((", "");
            multipolygon = multipolygon.Replace(")))", "");

            string[] polygon = multipolygon.Split(new string[] { ")), ((" }, StringSplitOptions.None);
            List<string>[] list = new List<string>[polygon.Count()];

            //Rebuild query after simplification
            //Opening bracket
            string query = "MULTIPOLYGON (";
            //Console.WriteLine(list.Count() + " number of polygons");
            //Console.WriteLine(list[1].Count() + " number of sub polygons in index 1");

            for (int i = 0; i < polygon.Count(); i++)
            {

                //Splits each Polygon into "interior rings"
                string[] subPolygon = polygon[i].Split(new string[] { "), (" }, StringSplitOptions.None);

                list[i] = subPolygon.ToList();

                List<string>[] subList = new List<string>[list[i].Count()];

                query = query + "(";
                for (int j = 0; j < list[i].Count(); j++)
                {
                    string[] linesCoords = list[i][j].Split(new string[] { ", " }, StringSplitOptions.None);
                    subList[j] = linesCoords.ToList();

                    query = query + simplifyPolygon(subList[j], passes);

                    if (j != list[i].Count() - 1) //only add comma if not end of the list
                    {
                        query = query + ", ";
                    }
                }
                query = query + ")";

                if (i != list.Count() - 1) //only add comma if not end of the list
                {
                    query = query + ", ";
                }

                Console.WriteLine("Number of rows before: " + list[i].Count());
                Console.WriteLine("Memory consumption before: " + GetObjectSize(list[i]) + " bytes");
                Console.WriteLine();
            }

            query = query + ")'";

            return query; ;
        }

        private string simplifyPolygon(List<string> list, int passes)
        {
            int listSize = list.Count(); //listSize starts at 0

            //Simplifies the polygon as defined by the variable 'passes'
            for (int i = 0; i < passes; i++)
            {
                if (toCompressOrNot == true && listSize > (5 * passes))
                {

                    if (listSize % 2 == 0) //Even number
                    {
                        Console.WriteLine(listSize + " is an even number");

                        for (int j = 0; j < listSize; j++) //Listsize starts at 1 whereas i is an index so it starts at 0, hence less than is used.
                        {
                            if (j == listSize - 2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine(list.ElementAt(j + 1) + " removed ");
                                list.RemoveAt(j + 1); //this offsets the entire loop by one index forward, hence the error
                                listSize = listSize - 1;
                            }
                        }
                    }
                    else //odd number
                    {
                        Console.WriteLine(listSize + " is an odd number");

                        for (int j = 0; j < listSize; j++) //Listsize starts at 1 whereas i is an index so it starts at 0, hence less than is used.
                        {
                            if (j == listSize - 1)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine(list.ElementAt(j + 1) + " removed ");
                                list.RemoveAt(j + 1); //this offsets the entire loop by one index forward, hence the error
                                listSize = listSize - 1;

                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Skipping rows that are too small");
                }
            }



            string partQuery = "(";

            list.ForEach(i => Console.WriteLine("{0}\t", i));

            foreach (string item in list)
            {
                partQuery = partQuery + item + ", ";
            }

            partQuery = partQuery + ")";
            partQuery = partQuery.Replace(", )", ")");

            Console.WriteLine("Number of rows after: " + listSize);
            Console.WriteLine("Memory consumption after: " + GetObjectSize(list) + " bytes");

            return partQuery;
        }

        public List<int> GetRowIDs()
        {
            //Get number of rows in table
            List<int> rowIDs = new List<int>();
            string conString = "Server= localhost; Database= " + database + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT " + primaryKey + " AS [Rows] FROM " + table, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            rowIDs.Add(Convert.ToInt32(dr[0]));
                        }
                    }
                }
            }
            return rowIDs;
        }

        public string updateDatabase(int RowID, string Geometry)
        {

            Console.WriteLine("Now updating the database ...");

            string queryPrefix;

            if (Geometry.Contains("MULTI") == true)
            {
                queryPrefix = " = geometry::STMPolyFromText('";
            }
            else
            {
                queryPrefix = " = geometry::STPolyFromText('";
            }



            string result = "No result";
            string conString = "Server= localhost; Database= " + database + "; Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("UPDATE " + table + " SET " + column + queryPrefix + Geometry + ",0) WHERE " + primaryKey + " = " + RowID, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result = (dr[0].ToString());
                        }
                    }
                }



            }
            return result;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            //Save all frontend values to global variables so background workers thread can be utlized to prevent the interface from freezing.
            database = cboSelectDatabase.Text;
            table = cboSelectTable.Text;
            primaryKey = cboSelectPKEY.Text;
            column = cboSelectColumn.Text;
            passes = Convert.ToInt32(cboSelectPasses.Text);
            toCompressOrNot = chkSkipDataSets.Checked;
            id = cboID.Text;
            progress = 0;
            rowIDs.Clear();
            pbProgress.Value = 0;

            if (btnBegin.Text == "Stop")
            {
                bwProcess.CancelAsync();
                success = "cancelled";
                btnBegin.Text = "Start";
            }
            else
            {
                if (id == "All")
                {
                    rowIDs = GetRowIDs();
                    pbProgress.Maximum = rowIDs.Count();
                }
                else
                {
                    pbProgress.Maximum = 1;
                }

                pbProgress.Minimum = 0;
                bwProcess.RunWorkerAsync(2000);

                btnBegin.Text = "Stop";

            }

        }

        //Gets the memory consumption of a resultset.
        private int GetObjectSize(object TestObject)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, TestObject);
            Array = ms.ToArray();
            return Array.Length;
        }

        private void bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            //delays each iteration
            //    Thread.Sleep(1000);

            if (id == "All")
            {
                //pbProgress.Minimum = 0;
                //pbProgress.Maximum = rowIDs.Count() - 1;

                for (int i = 0; i < rowIDs.Count(); i++)
                {
                    //lblProgressPt1.Text = "Rows " + (i + 1).ToString() + " of " + rowIDs.Count();
                    Tuple<int, string> variables = GenerateSimplifiedPolygonText(rowIDs[i]);
                    updateDatabase(variables.Item1, variables.Item2);
                    bwProcess.ReportProgress(0);

                    if (i == rowIDs.Count() - 1)
                    {
                        success = "true";
                    }

                }

            }
            else
            {
                //pbProgress.Minimum = 0;
                //pbProgress.Maximum = 100;

                Tuple<int, string> variables = GenerateSimplifiedPolygonText(Convert.ToInt32(id));
                updateDatabase(variables.Item1, variables.Item2);
                //pbProgress.Value = 100;
            }




        }

        private void bwProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progress += 1;
            pbProgress.Value += 1;
            lblProgress.Text = "Row " + progress.ToString() + " of " + rowIDs.Count();


        }

        private void bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (success == "true")
            {
                MessageBox.Show("Task completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (success == "false")
            {
                MessageBox.Show("Task failed! This is possibly due to the machine running out of ram. Please limit the max server memory from within SQL Server, to resolve this issue", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine("Process cancelled by user");
            }



            btnBegin.Text = "Start";
        }

        private void cboSelectPKEY_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = cboSelectPKEY.Text;
        }
    }
}
