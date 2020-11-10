using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class GameObjectPlace
    {
        public int XCordinate { get; set; }
        public int YCordinat { get; set; }

        public override bool Equals(object obj)
        {
            GameObjectPlace newObj = obj as GameObjectPlace;

            if (newObj != null && this.XCordinate == newObj.XCordinate && this.YCordinat == newObj.YCordinat)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
