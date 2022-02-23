using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace N01520224_Hari_Assignment2.Controllers
{
    
    public class J1Controller : ApiController
    {
        /// <summary>
        /// computes the total calorie count based on your choice of food 
        /// </summary>
        /// <param name="burger">integer input</param>
        /// <param name="drink">integer input</param>
        /// <param name="side">integer input</param>
        /// <param name="dessert">integer input</param>
        /// <returns>returns a string "Your total calorie count is {totalcalorie} based on the the food choice input</returns>
        /// Eg: GET ../api/J1/Menu/1/2/3/4  ---> "Your total calorie count is 691"
        
        [HttpGet]
        [Route("api/j1/menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            int[] burgerCal = {461, 431, 420, 0};
            int[] drinkCal = {130, 160, 118, 0};
            int[] sideCal = {100, 57, 70, 0};
            int[] dessertCal = {167, 266, 75, 0};
            int[] validChoices = { 1, 2, 3, 4 };
            int totalCalories = 0;

            if (validChoices.Contains(burger) && validChoices.Contains(drink) && validChoices.Contains(side) && validChoices.Contains(dessert))
            {
                totalCalories = burgerCal[burger - 1] + drinkCal[drink - 1] + sideCal[side - 1] + dessertCal[dessert - 1];
                return $"Your total calorie count is {totalCalories}";
            }
            else
            {
                return "Invalid food code. please check your input";
            }

           
        }


        /// <summary>
        /// computes the number combinations that result a total of 10 from the 2 dices
        /// </summary>
        /// <param name="m">dice1 integer input</param>
        /// <param name="n">dice2 integer input</param>
        /// <returns>returns the string "There are {count} total ways to get the sum 10"</returns>
        /// Eg: GET ../api/J2/DiceGame/6/8 ---> "There are 5 total ways to get the sum 10."

        [HttpGet]
        [Route("api/j2/dicegame/{m}/{n}")]
        public string Dicegame(int m, int n)
        {
            int count = 0;
            
            if(m > 0 && n > 0)
            {
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (i + j == 10)
                        {
                            count = count + 1;
                        }
                    }
                }
                return $"There are {count} total ways to get the sum 10";
            }

            else
            {
                return "Invalid number of dice sides";
            }

        }

        /// <summary>
        /// Returns a distance table that indicates the distance between any two of the cities
        /// </summary>
        /// <param name="cd2">integer input - distance between city1 and city2</param>
        /// <param name="cd3">integer input - distance between city2 and city3</param>
        /// <param name="cd4">integer input - distance between city3 and city4</param>
        /// <param name="cd5">integer input - distance between city4 and city5</param>
        /// <returns>returns a 5 line string output showing the relative distances between respective cities</returns>
        
        /// Eg: api/j3/arewethereyet/{3}/{10}/{12}/{5} --> below output
        /// 0 3 13 25 30
        /// 3 0 10 22 27
        /// 13 10 0 12 17
        /// 25 22 12 0 5
        /// 30 27 17 5 0

        [HttpGet]
        [Route("api/j3/arewethereyet/{cd2}/{cd3}/{cd4}/{cd5}")]
        public string[] AreWeThereYet(int cd2, int cd3, int cd4, int cd5)
        {
            int[] cityDistance = { cd2, cd3, cd4, cd5 };
            int[] city = new int[5];
            
            string[] resultArray = new string[5];

            for(int i = 0; i < 5; i++)
            {
                if (i == 0)
                    city[i] = 0;
                else
                    city[i] = city[i - 1] + cityDistance[i - 1];
            }

            for(int i = 0; i<5; i++)
            {
                string result = string.Empty;
                for (int j = 0; j < 5; j++)
                {
                    int relativeDistance = city[j] - city[i];
                    if (relativeDistance < 0) relativeDistance = (relativeDistance * -1);
                    result = result + $"{relativeDistance} ";
                }
                resultArray[i] = result;
            }

            return resultArray;
            
        }

    }
}
