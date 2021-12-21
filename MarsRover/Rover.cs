using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Mars Rover class
    /// </summary>
    internal class Rover
    {
        internal int XLocation { get; set; }
        internal int YLocation { get; set; }
        internal DirectionEnum CurrentDirection { get; set; }
        internal string MoveOrder { get; set; }
        internal int XMax { get; set; }
        internal int YMax { get; set; }

        /// <summary>
        /// Executes the move order of the rover
        /// </summary>
        internal void Move()
        {
            var ordersArray = MoveOrder.ToCharArray(); 
            foreach (var order in ordersArray)
            {
                switch (order)
                {
                    //L is to move 90 degrees to left from rovers current direction.
                    case 'L':
                        //Check if direction value smaller than zero, if it is then change it to proper direction value.
                        CurrentDirection = (DirectionEnum)(Convert.ToInt32(CurrentDirection) - 1 < 0 ? 4 + (Convert.ToInt32(CurrentDirection) - 1) : Convert.ToInt32(CurrentDirection) - 1);
                        break;
                    //R is to move 90 degrees to rigth from rovers current direction.
                    case 'R':
                        //Check if direction value bigger than four, if it is then change it to proper direction value.
                        CurrentDirection = (DirectionEnum)(Convert.ToInt32(CurrentDirection) + 1 >= 4 ? (Convert.ToInt32(CurrentDirection) + 1) % 4 : Convert.ToInt32(CurrentDirection) + 1);
                        break;
                    //Move rover according to direction
                    case 'M':
                        switch (CurrentDirection)
                        {
                            case DirectionEnum.North:
                                YLocation++;
                                break;
                            case DirectionEnum.East:
                                XLocation++;
                                break;
                            case DirectionEnum.South:
                                YLocation--;
                                break;
                            case DirectionEnum.West:
                                XLocation--;
                                break;
                            default:
                                break;
                        }
                        if (YLocation > YMax || XLocation > XMax || YLocation < 0 || XLocation < 0)
                        {
                            throw new ArgumentException("Exceeded plane limits");
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
