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
    //This takes the users guesses and converts the colors to numbers
    //then it stores that info into an array to be sent to the solution class
    //to compare it to the randomly generated solution
    class GuessAreaClass
    {
       //Variables
        private int[] guessArray = new int[4];
        private string guessArrayMessage = "";
         

        //Constructor
        public GuessAreaClass()
        {
            initilizeGuessArray();
        }

        //Properties
        public int[] GuessArray
        {
            get
            {
                return guessArray;
            }
            set
            {
                guessArray = value;
            }
            
        }

        public string GuessArrayMessage
        {
            get
            {
                return guessArrayMessage;
            }
            set
            {
                guessArrayMessage = value;
            }

        }
 

        //Initilizes guess array
        private void initilizeGuessArray()
        {
            for (int i = 0; i < 4; i++)
            {
                guessArray[i] = 0;
            }
        }

        //Sets guess array to a number
        public void setGuessArray(int playerNumber)
        {
            for(int i=0;i<4;i++)
            {
                guessArray[i] = playerNumber;
            }
        }

        //Returns guess array
        public string getArraytoDisplay()
        {
            guessArrayMessage = "";

            //Creates a string from the guess array from player's guess
            for (int i = 0; i < 4; i++)
            {
                guessArrayMessage += guessArray[i] + " ";
            }

            return guessArrayMessage;
        }

    }
}
