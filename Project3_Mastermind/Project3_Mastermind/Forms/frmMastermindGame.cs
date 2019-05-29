using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class frmMastermind : Form
    {
        //Objects
        private RNGClass myRNG = new RNGClass();
        private ColorPaletteClass myColor = new ColorPaletteClass();
        private GuessAreaClass myGuess = new GuessAreaClass();
        private GameSolutionClass mySolution = new GameSolutionClass();
        private SolutionReportClass myReport = new SolutionReportClass();
        private PlayerClass playerOne = new PlayerClass();
        private LeaderBoardClass myLeaderBoard = new LeaderBoardClass();

        private TimeSpan playerTime = new TimeSpan();
        private DateTime playerStart = new DateTime();
        private DateTime playerStop = new DateTime();
        
        //Arrays
        private Button[,] newGuessButton;
        private Button[,] newHintButton;
        private Button[,] newPlayerGuessButton = new Button[4, 4];
        private Button[] solutionButtons = new Button[4];
        private int[] guessNumber = new int[4];
        private int[] guessArray = new int[4];

        //Variables
        private string difficulty = "";
        private int guessCount = 0;
        private static int numberOfGuessDueToDifficulty = 0;
        private int scoreOfPlayer = 0;


        public frmMastermind()
        {
            InitializeComponent();
        }

        private void frmMastermind_Load(object sender, EventArgs e)
        {
            setUpControls();

            //Inilize leaderBoard
            myLeaderBoard.inilializeEnitreList();

            //Write entirelist of leader board
            myLeaderBoard.writeEntireList();

            //Display leaderboard
            myLeaderBoard.displayLeaderBoard();

            //Sets focus to name txtbox
            txtName.Focus();

            myLeaderBoard.rewindFiles();

            myLeaderBoard.closeFiles();

        }
        
        

        //Name button click event
        private void btnNameOk_Click(object sender, EventArgs e)
        {
            try
            {
                //Validates name txtbox
                if(validateName(txtName))
                {
                    playerOne.PlayerName = txtName.Text.Trim();

                    //Modifies board so some controls are disabled while other are enabled
                    startGame();

                    lblDisplayName.Text = playerOne.displayName();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + "Please try again." + "\n\n" + "Type of error encountered: " + ex.GetType().ToString(), "Error: Exception found.");
            }
        }

        //This will set up the board for an easy game
        private void btnEasy_Click(object sender, EventArgs e)
        {
            //Sets up guess area
            setUpGameBoard();
      
            //Sets up number of attempts
            numberOfGuessDueToDifficulty = 12;
            MessageBox.Show("You have " + numberOfGuessDueToDifficulty + " guesses!");

            //Gets difficulty from button
            difficulty = btnEasy.Text;

            //Gives score for difficulty
            scoreOfPlayer = 1000;

            //Sets the players objects difficulty
            playerOne.PlayerDifficulty = difficulty;

            //Sets difficulty
            mySolution.setDifficulty(difficulty); 

            //Generates random number
            mySolution.generateSolution();

            //creates the easy board
            setUpGuessArea();
            
        }


        //This will set up the board for the medium game
        private void btnMedium_Click(object sender, EventArgs e)
        {
            //Sets up guessArea controls
            setUpGameBoard();

            numberOfGuessDueToDifficulty = 10;
            MessageBox.Show("You have " + numberOfGuessDueToDifficulty + " guesses!");

            //Gets difficulty from button
            difficulty = btnMedium.Text;

            //Gives score for difficulty
            scoreOfPlayer = 2000;

            //Sets the players objects difficulty
            playerOne.PlayerDifficulty = difficulty;

            //Sets difficulty level for RNG
            mySolution.setDifficulty(difficulty);

            //Generates solution
            mySolution.generateSolution();

            //creates the medium board
            setUpGuessArea();
        }

        //Sets up the board for a hard game
        private void btnHard_Click(object sender, EventArgs e)
        {
            //Sets up guess area
            setUpGameBoard();

            //Sets number of guesses
            numberOfGuessDueToDifficulty = 8;
            MessageBox.Show("You have " + numberOfGuessDueToDifficulty + " guesses!");

            //Gets difficulty from button
            difficulty = btnHard.Text;

            //Gives score for difficulty
            scoreOfPlayer = 3000;

            //Sets the players objects difficulty
            playerOne.PlayerDifficulty = difficulty;

            //Sets difficulty level for RNG
            mySolution.setDifficulty(difficulty);

            //Generates random number
            mySolution.generateSolution();

            //creates hard board
            setUpGuessArea();

        }

        //This is the code that will copy the player guesses and store them into a guess
        //area. It will also display the hints to the player as well. 
        private void btnChoiceConfirm_Click(object sender, EventArgs e)
        {

            bool winner = false;
            string loseMessage = "Congrats! You managed to lose the game! Better luck next time!";
            string continueMessage = "Do you want to play again?";
            string winMessage = "Congrats! You win!";
            DialogResult button;

            // Gets a number from the colors that are picked and places them into an array
            for (int i = 0; i < 4; i++)
            {
                guessArray[i] = myColor.getCode(newPlayerGuessButton[0, i]);
            }

            //Copies array into Guess Area Class array
            myGuess.GuessArray = guessArray;


            //Shows players guess in message box
            MessageBox.Show("Guess is: " + myGuess.getArraytoDisplay());

            //Fills in buttons from player guess area to guess board
            for (int i = 0; i < 4; i++)
            {
                newGuessButton[i, guessCount].BackColor = newPlayerGuessButton[0, i].BackColor;
            }

                    //Gets true or false for win condition
                    winner = mySolution.isWinner(myGuess, myReport);

                    //Sets up pegs to transfer colors
                    int[] pegNumber = new int[4];
                    Button[] pegButtons = new Button[4];

                    for (int i = 0; i < 4; i++)
                    {
                        pegNumber[i] = 0;
                        pegButtons[i] = new Button();
                    }

                    //Paints pegs on guess board
                    setPegOnBoard(pegNumber);

                    //Calls color palette and matches the peg number to peg button
                    for (int i = 0; i < 4; i++)
                    {
                        myColor.setPegColor(pegNumber[i], pegButtons[i]);
                    }

                    //Paints the back color of peg buttons to the gameboard pegs
                    for (int i = 0; i < 4; i++)
                    {
                        newHintButton[i, guessCount].BackColor = pegButtons[i].BackColor;
                    }

                    //Increments count
                    guessCount++;

                    //Tests to see if there is a winner
                    if (winner == true)
                    {
                        setPlayerWinConditions();

                        button = MessageBox.Show(winMessage + "\r\n" + continueMessage, "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        //This gives the player the choice to play a new game or quit
                        if (button == DialogResult.Yes)
                        {
                            TrackUsedNumbers.initilizeTrackedNumbersArray();
                            newGamePlus();
                           
                        }

                        else
                        {
                            this.Close();
                        }

                    }

                    //This compares the number of guess given from the difficulty to the number of guesses taken. If no winning matches
                    //this loser message displays.
                    if (guessCount == numberOfGuessDueToDifficulty && winner == false)
                    {
                        pnlSolutionBoard.Visible = true;

                        button = MessageBox.Show(loseMessage + "\r\n" + continueMessage, "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (button == DialogResult.Yes)
                        {
                            newGamePlus();
                        }

                        else
                        {
                            this.Close();
                        }

                    }
                }

        //Button click event for each button in guess area
        private void Button_Click(object sender, EventArgs e)
        {
            int colID = convertCharToInt(((Button)sender).Name[4]);

            //Displays the name of the button that is clicked
            //MessageBox.Show("btn: "+((Button)sender).Name[4]);

            //sets the player guesses to the board below to store all of their guesses
            if (difficulty.Equals("Easy"))
            {
                if (guessNumber[colID] < 6)
                {
                    guessNumber[colID]++;

                    myColor.getColor(guessNumber[colID], ((Button)sender));
                }

                else
                {
                    guessNumber[colID] = 0;
                }
            }

            else if (difficulty.Equals("Medium"))
            {
                if (guessNumber[colID] < 8)
                {
                    guessNumber[colID]++;
                    myColor.getColor(guessNumber[colID], ((Button)sender));
                }

                else
                {
                    guessNumber[colID] = 0;
                }
            }

            else
            {
                if (guessNumber[colID] < 10)
                {
                    guessNumber[colID]++;
                    myColor.getColor(guessNumber[colID], ((Button)sender));
                }

                else
                {
                    guessNumber[colID] = 0;
                }
            }
        }

        //Rules 
        private void btnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rules To The Game\n\n\n"
                +"Mastermind is a code breaker game. The rules are simple really. The computer"
                +"will generate a random solution that the user must try and guess. Each difficulty will"
                +"give the user a different amount of tries and a different amount of colors to guess from."
                +"The player will choose 4 colors (no duplicates in solution) and then the they will be given a hint."
                +"The Black Peg means you have the correct color in the correct spot, and the Cyan Peg means that"
                +"you have the correct color but in the wrong spot. Your goal is to guess the right solution before"
                +"running out of guesses."
                +"\n\nTo place on the leader board you must have one of the top 5 high scores. The leader board is both"
                +"displayed in the beginning and an updated one at the end."
                +"\n\nGOOD LUCK AND HAVE FUN!!!!!!!");
        }


        //Exit button, will close all open forms as well. This is needed since every
        //new game makes a new form and hides the old one.
        private void btnExit_Click(object sender, EventArgs e)
        {
            for(int i = Application.OpenForms.Count - 1; i >=0; i--)
            {
                if(Application.OpenForms[i].Name != "Menu")
                {
                    Application.OpenForms[i].Close();
                }
            }
        }


        //Creates guess card
        public void createGuessCard()
        {

            newGuessButton = new Button[4, numberOfGuessDueToDifficulty];

            Size guessAreaSize = new Size(60, 60);
            Point loc = new Point(0, 0);
            int topMargin = 10;
            int padding = 5;
            int barWidth = 6;

            for (int row = 0; row < 4; row++)
            {
                loc.Y = topMargin + row * (guessAreaSize.Height + padding);
                int extraLeftPadding = 5;
                for(int col = 0; col < numberOfGuessDueToDifficulty; col++)
                {
                    newGuessButton[row, col] = new Button();
                    newGuessButton[row, col].Location = new Point(extraLeftPadding + col * (guessAreaSize.Width + padding) + barWidth, loc.Y);
                    newGuessButton[row, col].Size = guessAreaSize;

                    newGuessButton[row, col].Enabled = false;
                    if(col == 0)
                    {
                        newGuessButton[row, col].Enabled = false;
                        newGuessButton[row, col].BackColor = Color.White;
                    }
                    newGuessButton[row, col].Name = "btn" + row.ToString() + col.ToString();

                    //Associates the same event handler with each of the buttons generated
                    newGuessButton[row, col].Click += new EventHandler(Button_Click);

                    //add buttons to the form/panel
                    pnlGuessBoard.Controls.Add(newGuessButton[row, col]);
                }
            }
        }

        //Creates hint card
        public void createHintCard()
        {

            newHintButton = new Button[4, numberOfGuessDueToDifficulty];

            Size hintAreaSize = new Size(60, 20);
            Point loc = new Point(0, 0);
            int topMargin = 0;
            int padding = 5;
            int barWidth = 6;

            for (int row = 0; row < 4; row++)
            {
                loc.Y = topMargin + row * (hintAreaSize.Height + padding);
                int extraLeftPadding = 5;
                for (int col = 0; col < numberOfGuessDueToDifficulty; col++)
                {
                    newHintButton[row, col] = new Button();
                    newHintButton[row, col].Location = new Point(extraLeftPadding + col * (hintAreaSize.Width + padding) + barWidth, loc.Y);
                    newHintButton[row, col].Size = hintAreaSize;

                    newHintButton[row, col].Enabled = false;
                    newHintButton[row, col].BackColor = Color.White;

                    newHintButton[row, col].Name = "btn" + row.ToString() + col.ToString();

                    //Associates the same event handler with each of the buttons generated
                    newHintButton[row, col].Click += new EventHandler(Button_Click);

                    //add buttons to the form/panel
                    pnlHintBoard.Controls.Add(newHintButton[row, col]);
                }
            }
        }

        //Creates solution card
        public void createSolutionCard()
        {
            //sets the amount of columns for the difficulty
            Button[] newSolutionButton = new Button[4];

            Size solutionHintArea = new Size(60, 60);
            Point loc = new Point(0,0 );
            int topMargin = 10;
            int padding = 3;
            int barWidth = 6;

            for (int i = 0; i < 4; i++)
            {
                solutionButtons[i] = new Button();
            }

            solutionButtons = mySolution.setColors();

            for (int row = 0; row < 4; row++)
            {
                loc.Y = topMargin + row * (solutionHintArea.Height + padding);
                //int extraLeftPadding = 5;
                for (int col = 0; col < 1; col++)
                {
                    newSolutionButton[row] = new Button();
                    newSolutionButton[row].Location = new Point((solutionHintArea.Width + padding) + barWidth, loc.Y);
                    newSolutionButton[row].Size = solutionHintArea;

                    newSolutionButton[row].Enabled = false;
                    newSolutionButton[row].BackColor = Color.White;

                    newSolutionButton[row].Name = "btn" + row.ToString();

                    //Associates the same event handler with each of the buttons generated
                    newSolutionButton[row].Click += new EventHandler(Button_Click);

                    newSolutionButton[row].BackColor = solutionButtons[row].BackColor;

                    //add buttons to the form/panel
                    pnlSolutionBoard.Controls.Add(newSolutionButton[row]);

                   
                }
            }
        }

        //Creates the guess area
        public void createGuessArea()
        {
            Size playerGuessArea = new Size(60, 60);
            Point loc = new Point(0, 0);
            int topMargin = 20;
            int padding = 5;
            int barWidth = 6;

            for (int row = 0; row < 1; row++)
            {
                loc.Y = topMargin + row * (playerGuessArea.Height + padding);
                int extraLeftPadding = 5;
                for (int col = 0; col < 4; col++)
                {
                    newPlayerGuessButton[row,col] = new Button();
                    newPlayerGuessButton[row,col].Location = new Point(extraLeftPadding + col * (playerGuessArea.Width + padding) + barWidth, loc.Y);
                    newPlayerGuessButton[row,col].Size = playerGuessArea;

                    newPlayerGuessButton[row,col].Enabled = true;
                    newPlayerGuessButton[row,col].BackColor = Color.Red;

                    newPlayerGuessButton[row,col].Name = "btn" + row.ToString() + col.ToString();

                    //Associates the same event handler with each of the buttons generated
                    newPlayerGuessButton[row,col].Click += new EventHandler(Button_Click);

                    //add buttons to the form/panel
                    pnlPlayerGuessArea.Controls.Add(newPlayerGuessButton[row,col]);


                }
            }
        }

       
        
        //Sets up the controls for the intro
        private void setUpControls()
        {
            lblDisplayName.Visible = false;
            lblCurrentPlayer.Visible = false;
            pnlGameControls.Visible = false;
            grpDifficulty.Visible = false;
            pnlPlayerGuessArea.Visible = false;
            txtName.Focus();
        }

        //Calls a new game form
        private void newGamePlus()
        {
            this.Visible = false;
            resetGame();
            frmMastermind newGamePlus = new frmMastermind();
            newGamePlus.Show();
        }

        //Resets variables
        private void resetGame()
        {
            difficulty = "";

            guessCount = 0;
            numberOfGuessDueToDifficulty = 0;

            Button[,] newGuessButton = new Button[12, 12];
            Button[,] newHintButton = new Button[12, 12];
            Button[,] newPlayerGuessButton = new Button[4, 4];

            

            guessNumber = new int[4];
            Button[] solutionButtons = new Button[4];
            int[] guessArray = new int[4];
        }

        //Makes buttons and name visible
        private void startGame()
        {
            grpDifficulty.Visible = true;
            pnlIntro.Visible = false;
            lblCurrentPlayer.Visible = true;
            lblDisplayName.Visible = true;
        }

        //Sets up game board makes game board visible
        private void setUpGameBoard()
        {
            grpDifficulty.Visible = false;
            pnlGameControls.Visible = true;
            pnlPlayerGuessArea.Visible = true;
            initilizeGuessArray();
        }

        //Creates the cards and play area for the player
        private void setUpGuessArea()
        {
            createGuessArea();
            createGuessCard();
            createHintCard();
            createSolutionCard();
            pnlSolutionBoard.Visible = false;
            playerStart = DateTime.Now;
        }

        //Initilizes guessAreaArray
        private void initilizeGuessArray()
        {
            for (int i = 0; i < 4; i++)
            {
                guessArray[i] = 0;
            }
        }

        //Calculates players score
        private void calculateScore()
        {
            int score = 0;

            if (playerOne.PlayerTryCount < 2)
            {
                score = 3000;
            }

            else if(playerOne.PlayerTryCount <4)
            {
                score = 2500;
            }

            else if (playerOne.PlayerTryCount < 6)
            {
                score = 2000;
            }

            else if (playerOne.PlayerTryCount < 8)
            {
                score = 1500;
            }

            else if (playerOne.PlayerTryCount < 10)
            {
                score = 1000;
            }

            else
            {
                score = 500;
            }

            playerOne.PlayerScore += score;
        }

        //Converts a character to an int for button naming
        private int convertCharToInt(char c)
        {
            return ((int)(c) - (int)('0'));
        }

        //Validates name txtbox
        private bool validateName(TextBox txtbox)
        {
            bool validName = false;
            string name = "";

            name = txtbox.Text;
            name = name.Trim();

            //Checks to see if name txtbox is empty
            if (string.IsNullOrWhiteSpace(name))
            {
                //Displays a message and sets validname to false
                MessageBox.Show("Name is a manditory field, Please try again.", "Entry Error!");
                validName = false;
                txtName.Clear();
                txtName.Focus();
            }

            else
            {
                validName = true;
            }

            //Returns validname
            return validName;
        }

        //Sets conditions after winning
        private void setPlayerWinConditions()
        {
            pnlSolutionBoard.Visible = true;
            playerStop = DateTime.Now;

            playerTime = playerStop.Subtract(playerStart);


            playerOne.PlayerScore = scoreOfPlayer;

            calculateScore();

            MessageBox.Show("time taken in seconds: " + playerTime.TotalSeconds);
            MessageBox.Show("Number of guesses: " + guessCount);
            MessageBox.Show("Player score for Difficulty: " + scoreOfPlayer);

            playerOne.PlayerTryCount = guessCount;

            //Consider making player time an int
            playerOne.PlayerTime = playerTime;

            //MessageBox.Show("Player object looks like: " + playerOne.createPlayerWriteLeaderBoard());

            myLeaderBoard.addPlayerObjToList(playerOne);

            myLeaderBoard.sortList();
            
            //Display leaderboard
            myLeaderBoard.displayLeaderBoard();

            myLeaderBoard.deleteLastElement();

            //Display leaderboard
            myLeaderBoard.displayLeaderBoard();

            //Rewinds files
            myLeaderBoard.rewindFiles();
            
            myLeaderBoard.writeEntireList();

            myLeaderBoard.closeFiles();

            myLeaderBoard.copyFile();

            myLeaderBoard.rewindFiles();

        }

        //Displays and correctly paints hints on board
        private void setPegOnBoard(int[] pegNumber)
        {
            //Sets the numbers for the pegs and the color index for color palette
            if (myReport.BlackPeg == 1)
            {
                pegNumber[0] = 41;

                if (myReport.WhitePeg == 1)
                {
                    pegNumber[1] = 42;
                   

                }

                else if (myReport.WhitePeg == 2)
                {
                    pegNumber[1] = 42;
                    pegNumber[2] = 42;

                }

               

                else if (myReport.WhitePeg == 3)
                {
                    pegNumber[1] = 42;
                    pegNumber[2] = 42;
                    pegNumber[3] = 42;
                }

            }

            else if (myReport.BlackPeg == 2)
            {
                pegNumber[0] = 41;
                pegNumber[1] = 41;

                if (myReport.WhitePeg == 1)
                {
                    pegNumber[2] = 42;
                    
                }

                else if (myReport.WhitePeg == 2)
                {
                    pegNumber[2] = 42;
                    pegNumber[3] = 42;
                }
            }

            else if (myReport.BlackPeg == 3)
            {
                pegNumber[0] = 41;
                pegNumber[1] = 41;
                pegNumber[2] = 41;

                if(myReport.WhitePeg == 1)
                {
                    pegNumber[3] = 42;
                }

            }

            else if (myReport.BlackPeg == 4)
            {
                pegNumber[0] = 41;
                pegNumber[1] = 41;
                pegNumber[2] = 41;
                pegNumber[3] = 41;
            }


            else if (myReport.WhitePeg == 1 && pegNumber[0] == 0)
            {
                pegNumber[0] = 42;
            }
            else if (myReport.WhitePeg == 2 && pegNumber[0] == 0 && pegNumber[1] == 0)
            {
                pegNumber[0] = 42;
                pegNumber[1] = 42;
            }

            else if (myReport.WhitePeg == 3 && pegNumber[0] == 0 && pegNumber[1] == 0 && pegNumber[2] == 0)
            {
                pegNumber[0] = 42;
                pegNumber[1] = 42;
                pegNumber[2] = 42;
            }

            else if (myReport.WhitePeg == 4 && pegNumber[0] == 0 && pegNumber[1] == 0 && pegNumber[2] == 0 && pegNumber[3] == 0)
            {
                pegNumber[0] = 42;
                pegNumber[1] = 42;
                pegNumber[2] = 42;
                pegNumber[3] = 42;
            }

            
        }
    }
}
