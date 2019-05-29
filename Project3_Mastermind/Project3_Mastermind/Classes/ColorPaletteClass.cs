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
    //Cordinates and connects the colors to a specific number sent by the RNG Class
    //Each color has a corresponding number to it which allows for the color to
    //be easily tracked, compared and set.
    class ColorPaletteClass
    {

        //Constructor
        public ColorPaletteClass()
        {

        }

        //Sets peg colors
        public void setPegColor(int number, Button peg)
        {
            switch (number)
            {
                case 41:
                    peg.BackColor = System.Drawing.Color.Black;
                    break;

                case 42:
                    peg.BackColor = System.Drawing.Color.Turquoise;
                    break;

                default:
                    peg.BackColor = System.Drawing.Color.Empty;
                    break;
            }


        }

        //Converts an integer to a color
        public void getColor(int number, Button test)
        {
   
            //MessageBox.Show("random number: " + number);
            switch (number)
            {

                case 1:
                    test.BackColor = System.Drawing.Color.Red;
                    
                    break;

                case 2:
                    test.BackColor = System.Drawing.Color.Blue;
                    
                    break;

                case 3:
                    test.BackColor = System.Drawing.Color.Green;
                    
                    break;

                case 4:
                    test.BackColor = System.Drawing.Color.Orange;
                    
                    break;

                case 5:
                    test.BackColor = System.Drawing.Color.Yellow;
                   
                    break;

                case 6:
                    test.BackColor = System.Drawing.Color.Purple;
                    
                    break;

                case 7:
                    test.BackColor = System.Drawing.Color.Brown;
                    
                    break;

                case 8:
                    test.BackColor = System.Drawing.Color.LightCyan;
                    
                    break;

                case 9:
                    test.BackColor = System.Drawing.Color.DarkBlue;
                    
                    break;

                case 10:
                    test.BackColor = System.Drawing.Color.Gold;
                    
                    break;

                case 11:
                    test.BackColor = System.Drawing.Color.Violet;
                    
                    break;

                case 12:
                    test.BackColor = System.Drawing.Color.HotPink;
                    
                    break;

                case 13:
                    test.BackColor = System.Drawing.Color.Tan;
                    
                    break;

                case 14:
                    test.BackColor = System.Drawing.Color.IndianRed;
                    
                    break;

                default:
                   // test.BackColor = System.Drawing.Color.Silver;
                    
                    break;

                    
            }
        }

        //Converts color to an integer
        public int getCode(Button test)
        {
           
            int code = 0;

            if (test.BackColor.Equals(System.Drawing.Color.Red))
            {
                code = 1;
            }

            else if (test.BackColor.Equals(System.Drawing.Color.Blue))
            {
                code = 2;
            }

            else if (test.BackColor.Equals(System.Drawing.Color.Green))
            {
                code = 3;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Orange))
            {
                code = 4;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Yellow))
            {
                code = 5;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Purple))
            {
                code = 6;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Brown))
            {
                code = 7;
            }

            else if (test.BackColor.Equals(System.Drawing.Color.LightCyan))
            {
                code = 8;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.DarkBlue))
            {
                code = 9;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Gold))
            {
                code = 10;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Violet))
            {
                code = 11;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.HotPink))
            {
                code = 12;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.Tan))
            {
                code = 13;
            }
            else if (test.BackColor.Equals(System.Drawing.Color.IndianRed))
            {
                code = 14;
            }
            else
            {
               // MessageBox.Show("Error, no color selected");
            }

            //MessageBox.Show("color is equal to : " + code);
            return code;
        }

      }     
    }
