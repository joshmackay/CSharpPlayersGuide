using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VinFletchersArrow
{
    internal class Arrow
    {
        public ArrowHead _head;
        public float _shaftLength;
        public Fletching _fletching;

        public Arrow(ArrowHead head, Fletching fletching, float length)
        {
            _head = head;
            _shaftLength = length;
            _fletching = fletching;
        }

        public float GetCost()
        {
            int arrowHeadPrice = _head switch
            {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5,
                _ => throw new NotImplementedException()
            };

            int fletchingPrice = _fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            float shaftPrice = _shaftLength * 0.05f;

            return (float)arrowHeadPrice + (float)fletchingPrice + shaftPrice;
        }
    }

}
