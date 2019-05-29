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
     * Once the solution class has finished the comparison of the player guess to the solution
     * it then sends the number of hint pegs to the solution report class. The purpose
     * of this class is to recieve the number and type of pegs that should be displayed
     * and then sets that pegs color to the proper hint buttons.
     */ 
    class SolutionReportClass
    {
        //Variables
        private int blackPeg = 0;
        private int whitePeg = 0;
        private int emptyPeg = 0;

        //Objects
        ColorPaletteClass pegColor = new ColorPaletteClass();

        //Constructor
        public SolutionReportClass()
        {

        }

        //Properties
        public int BlackPeg
        {
                
            get
            {
                return blackPeg;
            }

            set
            {
                blackPeg = value;
            }
        }

        public int WhitePeg
        {
            get
            {
                return whitePeg;
            }

            set
            {
                whitePeg = value;
            }
        }

        public int EmptyPeg
        {
            get
            {
                return emptyPeg;
            }

            set
            {
                emptyPeg = value;
            }
        }

        //Sets peg color (not used)
        public void  setPegs(int pegNumber, Button peg)
        {
            pegColor.setPegColor(pegNumber, peg);
        }

    }
}
