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
    //The purpose of the solution class is to generate the hidden solution the player is trying to guess. Once
    //the player makes a guess, it will take their guess and compare it to the solution. If the player has guessed
    //any of the right colors and or the right place it will generate the proper number of black and cyan hint pegs.
    class GameSolutionClass
    {
        private const int MAX = 4;
        private ColorPaletteClass myColor = new ColorPaletteClass();
        private int[] solutionArray = new int[MAX];
        private string difficulty = "";
        private string solutionMessage = "";
        

        //Constructor
        public GameSolutionClass()
        {
            initilizeSolutionArray();
        }

        //Initilizes solution array
        private void initilizeSolutionArray()
        {
            for (int i = 0; i < MAX; i++)
            {
                solutionArray[i] = 0;
                
            }
        }

        //Generates solution
        public void generateSolution()
        {
            RNGClass solutionRNG = new RNGClass();
 
            for (int i = 0; i < MAX; i++)
            {
                solutionArray[i] = solutionRNG.getRandomNum(difficulty);
                solutionMessage += solutionArray[i]+" ";
            }

            //MessageBox.Show("Solution is: "+solutionMessage);
        }

        //Checks for win condition
        public bool isWinner(/*int [] guessArray*/ GuessAreaClass myGuess, SolutionReportClass myReport/**/)
        {
            bool win = false;

            //Just testing HInt class/Solution report class not how we should check for winner I dont think but ill leave it for now
            compareArray(myGuess.GuessArray, myReport);

            if (myReport.BlackPeg == 4)
            {
                //MessageBox.Show("Guess: "+ myGuess.getArraytoDisplay()+"\r\n"+"Solution: "+ solutionMessage);
                win = true;
            }

            return win;
        }

        //Compares guess array to the solution array and then states the proper number of pegs
        private void compareArray(int[] guessArray, SolutionReportClass myReport)
        {
            myReport.BlackPeg = 0;
            myReport.WhitePeg = 0;
            myReport.EmptyPeg = 4;
            
            int[] tempSolution = new int[4];
            int[] tempGuess = new int[4];

            solutionArray.CopyTo(tempSolution,0);
            guessArray.CopyTo(tempGuess, 0);

            for (int i = 0; i < MAX; i++)
            {

                if ( tempSolution[i] != -1 && tempGuess[i] !=-1 && solutionArray[i] == guessArray[i])
                {
                    tempSolution[i] = -1;
                    tempGuess[i] = -1;

                    myReport.BlackPeg++;
                    myReport.EmptyPeg--;
                }
            }
            for (int k = 0; k < MAX; k++)
            {
                for (int j = 0; j < MAX; j++)
                {
                    if (tempSolution[k] != -1 && tempGuess[j] != -1  && solutionArray[k] == guessArray[j])
                    {
                        tempSolution[k] = -1;
                        tempGuess[j] = -1;

                        myReport.WhitePeg++;
                        myReport.EmptyPeg--;
                    }

                }
            }

            //MessageBox.Show("Number of correct buttons and colors "+myReport.BlackPeg+" ");
            //MessageBox.Show("Number of correct colors " + myReport.WhitePeg + " ");
        }

        //Sets the colors of the solution buttons
        public Button[] setColors()
        {
            Button[] solutionButtons = new Button[MAX];

            for (int i = 0; i < MAX; i++)
            {
                solutionButtons[i] = new Button();
                myColor.getColor(solutionArray[i], solutionButtons[i]);
            }

            return solutionButtons;
        }

        //Sets the difficulty for RNG
        public void setDifficulty(string difficultyLevel)
        {
            difficulty = difficultyLevel;
        }
    }
}
