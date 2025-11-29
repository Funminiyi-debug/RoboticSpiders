using System;
using System.Threading.Tasks;

namespace RoboticSpiders.Domain.Models;

public class Spider(
        IPosition startPosition,
        IWall wall
    ) : Movable(startPosition, wall);
