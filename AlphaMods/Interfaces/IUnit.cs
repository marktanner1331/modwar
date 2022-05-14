using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMods.Interfaces
{
    public abstract class IUnit : IStructure
    {
        public float CenterX { get; }
        public float CenterY { get; }

        public float Speed { get; }

        public abstract void Move(float x, float y);
    }
}
