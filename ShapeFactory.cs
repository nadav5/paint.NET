using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(ShapeType type)
        {
            return type switch
            {
                ShapeType.Circle => new Circle(0),
                ShapeType.Rectangle => new Rectangle(0, 0),
                ShapeType.Line => new Line(0, 0, 0, 0),
                _ => throw new NotSupportedException($"Unknown shape type: {type}")
            };
        }
    }
}