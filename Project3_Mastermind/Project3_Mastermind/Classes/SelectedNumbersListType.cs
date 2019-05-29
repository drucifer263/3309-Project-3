using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Will Oughton & Drew Watson
3309
Freidman
Project 3: Mastermind
Spring 18
*/

namespace Project3_Mastermind
{
    //This class gets the current column or number of turns the player is on
    //and checks to make sure the current column is available and if not
    //it will move to the next available one, then set that column as used
     class SelectedNumbersListType
    {
        TrackUsedNumbers numbersTracked;

        //Default constructor
        public SelectedNumbersListType()
        {

            ///Initializes tracked numbers obj
            numbersTracked = new TrackUsedNumbers();

        }

        //Checks to see if number has been used and returns true or false
        public bool isNumberUsed(int rn)
        {
            bool numberUsed = false;

            //Checks to see if the number has been used within tracked number
            if (numbersTracked.checkIfCellUsed(rn))
            {
                numberUsed = true;
            }

            return numberUsed;
        }

        //Sets the number as used within tracked number
        public void setUsedNumber(int rn)
        {

            numbersTracked.markCellUsed(rn);
        }

        //Resets tracked numbers
        public void reset()
        {
            TrackUsedNumbers numbersTracked = new TrackUsedNumbers();
            //numbersTracked.initilizeTrackedNumbersArray();
        }
    }
}
