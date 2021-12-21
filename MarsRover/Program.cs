using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Program
    {
        static List<Rover> rovers = new List<Rover>();
        static void Main(string[] args)
        {
            string input = @"5 5
                             1 2 N
                             LMLMLMLMM
                             3 3 E
                             MMRMMRMRRM";

            InitializeRovers(input);
            rovers[0].Move();
            rovers[1].Move();
        }

        /// <summary>
        /// Initialize the rovers.
        /// </summary>
        /// <param name="input"></param>
        private static void InitializeRovers(string input)
        {
            string[] strArray = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (strArray.Length == 5)
            {
                GenerateRoverInfo(strArray[0].Trim(), strArray[1].Trim(), strArray[2].Trim());
                GenerateRoverInfo(strArray[0].Trim(), strArray[3].Trim(), strArray[4].Trim());
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }

        /// <summary>
        /// Generate Rover regarding to the given info,order inputs
        /// </summary>
        /// <param name="info"></param>
        /// <param name="moveOrder"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void GenerateRoverInfo(string planeInfo, string info, string moveOrder)
        {
            string[] roverInfo = info.Split(' ');
            if (roverInfo.Length == 3)
            {
                Rover rover = new Rover();
                rover.XLocation = Convert.ToInt32(roverInfo[0]);
                rover.YLocation = Convert.ToInt32(roverInfo[1]);
                rover.CurrentDirection = DirectionEnumHelper.GetDirectionEnumReference(Convert.ToChar(roverInfo[2]));
                rover.MoveOrder = moveOrder;

                var planeArray = planeInfo.Split(' ');
                if (planeArray.Length == 2)
                {
                    rover.XMax = Convert.ToInt32(planeArray[0]);
                    rover.YMax = Convert.ToInt32(planeArray[1]);
                }
                else
                {
                    throw new ArgumentException("Invalid plane input");
                }
                rovers.Add(rover);
            }
            else
            {
                throw new ArgumentException("Invalid rover input");
            }
        }
    }
}
