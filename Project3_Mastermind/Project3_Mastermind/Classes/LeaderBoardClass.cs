using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
Will Oughton & Drew Watson
3309
Freidman
Project 3: Mastermind
Spring 18
*/

namespace Project3_Mastermind
{
    //Reads in a Player text file of the top 5 scores
    //Places them into objects and filters records into Player objects
    //Places Objects into a list of Player objects
    //Outputs objects attributes into a string of records
    //Records are output to a file
    class LeaderBoardClass
    {
        List<PlayerClass> leaderBoardList = new List<PlayerClass>();

        //The file path needs to be changed for whatever computer you are using unless you know how to add it to the debugger
        //Otherwise the application won't know where to read the file etc etc

        private static string currentPlayerFilePath = "currentPlayerFile.txt"; //for when I was working at home
        private static string updatedPlayerFilePath = "updatedPlayerFile.txt"; //for when I was working at home
        private static string updatedPlayerFilePath2 = "updatedPlayerFile2.txt";
        public static CurrentFileClass currentPlayerFile = new
            CurrentFileClass(currentPlayerFilePath);

        public static UpdatedFileClass updatedPlayerFile = new
            UpdatedFileClass(updatedPlayerFilePath);

        //public static CurrentFileClass copyUpdatedPlayerFile = new CurrentFileClass(updatedPlayerFilePath);
        //public static UpdatedFileClass copyCurrentPlayerFile = new UpdatedFileClass(currentPlayerFilePath);

        //Constructor
        public LeaderBoardClass()
        {
            initilizeList();
        }

        //Initilizes playerclass list
        public static void initilizeList()
        {
            List<PlayerClass> leaderBoardList = new List<PlayerClass>();
        }

        //Retruns the elements in leader board
        public int getCount()
        {
            return leaderBoardList.Count();
        }

        //Reads properties form file, places them into objects, and places objects within list
        public bool inilializeEnitreList()
        {
            string nextRecord;
            bool isEndOfFile = true;
            bool success;
            int countProcessedRecords = 0;

            nextRecord = currentPlayerFile.getNextRecord(ref isEndOfFile);
            while (!isEndOfFile)
            {
                countProcessedRecords++;
                PlayerClass player = new PlayerClass();
                success = player.createPlayer(nextRecord);
                if (success != true)
                {
                    MessageBox.Show
                       ("Unable to create an Player Object.  Player list not created.",
                        "Employee List Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                leaderBoardList.Add(player);
                nextRecord = currentPlayerFile.getNextRecord(ref isEndOfFile);
            } //end While

            if (countProcessedRecords > 0)
                return true;
            else
                return false;
        }

        //Writes list to updated file
        public void writeEntireList()
        {
            
            foreach (PlayerClass player in leaderBoardList)
            {
                
                updatedPlayerFile.writeNextRecord(player.createPlayerWrite());
                
            }
            
            updatedPlayerFile.closeFile();

          
        }

        //Rewinds both files to allow for them to be read from the start again
        public void rewindFiles()
        {
            updatedPlayerFile.rewindFile();
            currentPlayerFile.rewindFile();
        }

        //Closes both the files
        public void closeFiles()
        {
            updatedPlayerFile.closeFile();
            currentPlayerFile.closeFile();
        }

        //Displays each player object 
        public void displayEntireList()
        {
            foreach (PlayerClass player in leaderBoardList)
            {
                MessageBox.Show(player.displayRecord());
            }
        }

        //Displays leaderboard
        public void displayLeaderBoard()
        {
            string leaderBoard = "";

            foreach (PlayerClass player in leaderBoardList)
            {
                leaderBoard += player.createPlayerWriteLeaderBoard()+"\r\r\n";
            }

            MessageBox.Show("Top Five Players\n\n\n"+leaderBoard);
        }
       
         //Sorts list
        public void sortList()
        {
            int listCount = getCount();
            PlayerClass tempPlayer = new PlayerClass();
            
            for(int i =0;i<listCount;i++)
            {
                for(int j=0;j<listCount-1;j++)
                {
                    if(leaderBoardList[i].PlayerScore > leaderBoardList[j].PlayerScore)
                    {
                        tempPlayer = leaderBoardList[j];
                        leaderBoardList[j] = leaderBoardList[i];
                        leaderBoardList[i] = tempPlayer;
                    }
                }
            }
                

            //leaderBoardList.Sort((x,y) => x.PlayerScore.CompareTo(y.PlayerScore));
        }
        //Adds current player object,
        public void addPlayerObjToList(PlayerClass currentPlayer)
        {
            leaderBoardList.Add(currentPlayer);
        }

        //Deletes the last element so it removes the lowest ranking person off the leader boards
        public void deleteLastElement()
        {
            int listCount = getCount();

            if(listCount == 6)
            {
                leaderBoardList.RemoveAt(listCount-1);
            }
        }

        //This will copy the updatedPlayerFile contents to the currentPlayerFile and overrides the data
        //that is store inside of the currentPlayer
        public void copyFile()
        {

            try
            {
                File.Copy("updatedPlayerFile.txt", "currentPlayerFile.txt", true);
            }
            catch
            {
                MessageBox.Show("Failed to copy");
            }
            
        }
    }
}
