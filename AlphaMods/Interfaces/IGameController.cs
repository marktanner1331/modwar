using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMods.Interfaces
{
    public abstract class IGameController
    {
        public IEnumerable<IPlayer> Players { get; }

        public IMap Map { get; }

        public abstract void AddPlayer(IPlayer player);

        public abstract void SetMap(IMap map);

        public abstract void Start();
    }
}
