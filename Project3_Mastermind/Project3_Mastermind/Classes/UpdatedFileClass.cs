using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*
Will Oughton & Drew Watson
3309
Freidman
Project 3: Mastermind
Spring 18
*/

namespace Project3_Mastermind
{
    //This class will be used to update Player file for the leaderboard
    //I do not know how to add the file to the debugger though
    class UpdatedFileClass
    {
        private string updatedFilePath;
        private StreamWriter updatedFileSW;   // Reference variable of type SW
        private int recordWriteCount;

        // Constructor with file path input
        // Create instance of StreamWriter class (type) and store reference
        public UpdatedFileClass(string filePath)
        {
            recordWriteCount = 0;
            updatedFilePath = filePath;
            try
            {
                updatedFileSW = new StreamWriter(updatedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "Cannot open file " + updatedFilePath + " Terminate Program.",
                                "Output File Connection Error.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } // end Try
        } // end currentFileClass Constructor 



        // Write a record from the current file
        public void writeNextRecord(string record)
        {
            try
            {
                
                updatedFileSW.WriteLine(record);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex + "IO error in file write. Terminate program.",
                                "File Write Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } // end try and catch

            recordWriteCount++; // increment the record written count
            
        } // end putNextRecord()


        // Get value of number of records written
        public int getRecordsWrittenCount()
        {
            return recordWriteCount;
        } // end getRecordsWrittenCount



        // Close the output file
        public void closeFile()
        {
            updatedFileSW.Close();
        }  // end closeFile


        // Rewind the output file
        public void rewindFile()
        {
            recordWriteCount = 0;
            updatedFileSW = new StreamWriter(updatedFilePath);
            updatedFileSW.Flush();
            updatedFileSW.BaseStream.Seek(0, SeekOrigin.Begin);
        }  // end rewindFile

    }//end updateClass
}
