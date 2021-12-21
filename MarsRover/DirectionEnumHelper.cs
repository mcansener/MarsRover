using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal static class DirectionEnumHelper
    {
        internal static DirectionEnum GetDirectionEnumReference(char directionCharacter)
        {
            switch (directionCharacter)
            {
                case 'N': 
                    return DirectionEnum.North;
                case 'S':
                    return DirectionEnum.South;
                case 'E':
                    return DirectionEnum.East;
                case 'W':
                    return DirectionEnum.West;
                default:
                    throw new ArgumentException("Invalid direction");
            }
        }
    }
}
