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
    //RNG class that will create a number from 1-8 depending on the number of balls/colors
    //Each number will be sent to the color palette class where they will be asigned a color
    //Simple class similar to the one in bingo, could probably repurpose the one from bingo lol
    class RNGClass
    {
        
        private Random RandomObj;      // Type random object

        public RNGClass()
        {
            RandomObj = new Random(); // Creates and seeds (using current time) random object 

        }

        // Get Random Value
        // Gets next random value and ensures it is in the correct range for the column
        //    involved
        // Returns a valid random number

        //Gets a unique random number
        public int  getRandomNum(string difficulty)
        {
            int randomNum = 0;
            const int MIN = 1;
            int max = 0;

            max = getDifficultyLevel(difficulty);
            randomNum = getUnique(MIN,max);
            return randomNum;

        }

        //Retruns a unique number
        public int getUnique(int min, int max)
        {
            int value = 0;
            bool unique = false;

            while (unique == false)
            {
                value = RandomObj.Next(min, max);
                if (!Globals.selectedNumbersListObj.isNumberUsed(value))
                {
                    unique = true;
                    Globals.selectedNumbersListObj.setUsedNumber(value);
                   
                }
            }

            return value;
        }
    
        //Gets the max number for the RNG
        private int getDifficultyLevel(string difficulty)
        {
            
            int numberOfColors = 0;

            if (difficulty.Equals("Easy"))
            {
                numberOfColors = 6;
            }

            else if (difficulty.Equals("Medium"))
            {
                numberOfColors = 8;
            }

            else if (difficulty.Equals("Hard"))
            {
                numberOfColors = 10;
            }

            else
            {
                MessageBox.Show("Not within range!");
            }

            return numberOfColors;
        }


    }
}
