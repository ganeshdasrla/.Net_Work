using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class OCP
    {
    }

    //OCP: Open Closed Principle
    //Def: A class shpuld be open for extension but closed for modifcations.
    //This means you can add new features without altering existing code

    //Once class is written it should be closed for modifactions but open for extensions

    //Your smatphone, you didn't open it up to add features, you just download apps to extend its capabilities

    //Before OCP:
    public class Rectangle_Volates_OCP
    {
        public double width { get; set; }
        public double height { get; set; }
    }

    public class AreaCalculator
    {
        public double CalculateArea(Rectangle_Volates_OCP rectangle)
        {
            return rectangle.width * rectangle.height; //Calcluates only area of rectangle, this violates OCP,
                                                       //when new shape(Cirle) area is required
        }
    }
    //This design may become problemtaic when adding new shapes. Need to modifiy AreaCalculator for each new shape, whcih viloates OCP

    //After Applying OCP:
    public interface IShape
    {
        double CalculateArea();
    }

    public class Rectangle : IShape
    {
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    public class Circle : IShape
    {
        public double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }
    //By introducing Interface(IShape) new shape like Circle can be added without modifying existing code, adthering to OCP

    //According to OCP, the class should be open for extension but closed for modifications. So when you introduce new shape then just implement it from the interface IShape.
    //IShape is open for extesnion but closed for further modifcations
}
