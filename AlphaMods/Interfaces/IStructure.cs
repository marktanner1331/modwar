using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMods.Interfaces
{
    public abstract class IStructure
    {
        public string Owner;

        public byte Health { get; }

        public abstract bool HitTest(float x, float y);
    }
}
