using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /*
     * The player class will both create and record the player attributes
     * The info stored will later be converted to a string so that the file
     * class's and leader board class can compare the information of the player
     * and then write to the updated file, then copy the info and then display it to the
     * leader board.
     */ 
    class PlayerClass
    {
        //Variable
        private string playerName;
        private int playerScore;
        private TimeSpan playerTime;
        private string playerDifficulty;
        private int playerTryCount;
        private string playerRecord;

        //Default constructor
        public PlayerClass()
        {

        }

        //Constructor
        public PlayerClass(string name, int score, TimeSpan time, string difficulty, int tryCount, string record)
        {
            this.PlayerName = name;
            this.PlayerScore = score;
            this.PlayerTime = time;
            this.PlayerDifficulty = difficulty;
            this.PlayerTryCount = tryCount;
            this.PlayerRecord = record;
        }

        //Name Property 
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        //Score Property 
        public int PlayerScore
        {
            get
            {
                return playerScore;
            }
            set
            {
                playerScore = value;
            }
        }

        //Time Property 
        public TimeSpan PlayerTime
        {
            get
            {
                return playerTime;
            }
            set
            {
                playerTime = value;
            }
        }

        //Record Property 
        public string PlayerRecord
        {
            get
            {
                return playerRecord;
            }
            set
            {
                playerRecord = value;
            }
        }

        //Difficulty Property 
        public String PlayerDifficulty
        {
            get
            {
                return playerDifficulty;
            }
            set
            {
                playerDifficulty = value;
            }
        }

        //Try count Property 
        public int PlayerTryCount
        {
            get
            {
                return playerTryCount;
            }
            set
            {
                playerTryCount = value;
            }
        }


        //Displays name for txtbox
        public string displayName()
        {
            return playerName;
        }

        //Creates Player Record
        public void createRecord ()
        {
            playerRecord = playerName + " * " + playerScore + " * " + playerTime + " * " + playerDifficulty + " * " + playerTryCount;
        }

        public string createPlayerWrite()
        {
            createRecord();
            return PlayerRecord;
        }

        //Creates a string of concatenated attributes
        public string createPlayerWriteLeaderBoard()
        {
            string playerString = "";

            playerString = this.playerName + " " + this.playerScore + " " + this.playerTime + " " + this.playerDifficulty + " " + playerTryCount;

            return playerString;
        }

        //Displays Record
        public string displayRecord()
        {
            createRecord();
            return PlayerRecord;
        }

        public string displayPlayerRecord()
        {
            string message = "Name: " + this.playerName
                  + "\nDifficulty: " + this.playerDifficulty
                  + "\nTime: " + this.playerTime
                  + "\nScore: " + playerScore
                  + "\nTries: " + playerTryCount
                  + "\nRecord: " + playerRecord;
            return message;
        }

        //Creates a player oject and places attributes within
        public bool createPlayer(string s)
        {
            PlayerClass thisPlayer = this;
            string[] playerString = s.Split('*');
            int length = playerString.Length;
            int i;

            for (i = 0; i < length; i++)
            {
                playerString[i] = playerString[i].Trim();
            }

            try
            {
                playerName = playerString[0];

                if(playerName == " " || playerName == "")
                    {
                        MessageBox.Show(playerString[0] + ": Name string is empty or Blank. Player File Corrupt. Execution Terminated.",
                        "Name in Player File Invalid",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
            }

            catch
            {
                MessageBox.Show(playerString[0] + ": Name string is not valid. Player File Corrupt. Execution Terminated.",
                        "Name in Player File Invalid",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            try
            {
                playerScore = Convert.ToInt32(playerString[1]);
            }

            catch
            {
                     MessageBox.Show(playerString[1]
                    + ": Score string is empty or Blank. Player File Corrupt.  Execution Terminated.",
                      "Score in Player File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
            }

          
            try
            {
                playerTime = TimeSpan.Parse(playerString[2]);
            }

            catch
            {
                MessageBox.Show(playerString[2]
                    + ": Time of Player string is not a valid date. Player File Corrupt.  Execution Terminated.",
                      "Time inPlayer File Invalid",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            try
            {
                playerDifficulty = playerString[3];

                if (playerDifficulty == " " || playerDifficulty == "")
                {
                    MessageBox.Show(playerString[3] + ": Name string is empty or Blank. Player File Corrupt. Execution Terminated.",
                    "Name in Player File Invalid",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            catch
            {
                MessageBox.Show(playerString[3] + ": Difficulty string is not valid. Player File Corrupt. Execution Terminated.",
                        "Difficulty in Player File Invalid",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            try
            {
                playerTryCount = Convert.ToInt32(playerString[4]);
            }

            catch
            {
                MessageBox.Show(playerString[4]
               + ": Score string is empty or Blank. Player File Corrupt.  Execution Terminated.",
                 "Score in Player File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }// end playerCreate
    }
}
