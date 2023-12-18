using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinFletchersArrows
{
    internal class Arrow
    {
        private ArrowHead _arrowHead { get; set; }
        private float _shaftLength { get; set; }
        private Fletching _fletching { get; set; }

        public Arrow(ArrowHead head, float shaft, Fletching fletching)
        {
            _arrowHead = head;
            _shaftLength = shaft;
            _fletching = fletching;
        }

        public static Arrow CreateEliteArrow()
        {
            return new Arrow(ArrowHead.Steel, 95.0f, Fletching.Plastic);
        }

        public static Arrow CreateBeginnerArrow()
        {
            return new Arrow(ArrowHead.Wood, 75f, Fletching.GooseFeathers);
        }

        public static Arrow CreateMarksmanArrow()
        {
            return new Arrow(ArrowHead.Steel, 65.0f, Fletching.GooseFeathers);
        }

        public float GetCost()
        {
            float arrowHeadCost = _arrowHead switch
            {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5
            };

            float shaftCost = _shaftLength * 0.05f;

            float fletchingCost = _fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            var totalPrice = arrowHeadCost + shaftCost + fletchingCost;

            return totalPrice;

        }
    }
}
