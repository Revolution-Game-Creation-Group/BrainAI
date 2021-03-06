﻿namespace BrainAI.InfluenceMap.Fading
{
    using System;

    using BrainAI.Pathfinding;

    public class NPowDistanceFading : IFading
    {
        private readonly float pow;

        public NPowDistanceFading(float pow)
        {
            this.pow = pow;
        }

        public Point GetForce(Point vector, float chargeValue)
        {
            var vectorX = vector.X;
            var vectorY = vector.Y;

            var quadDist = vectorX * vectorX + vectorY * vectorY;
            var dist = Math.Sqrt(quadDist);
            var affectPower = chargeValue / Math.Pow(quadDist, this.pow / 2);

            return new Point(
                (int)(vectorX / dist * affectPower),
                (int)(vectorY / dist * affectPower));
        }
    }
}