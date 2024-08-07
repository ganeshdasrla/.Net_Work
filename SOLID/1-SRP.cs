using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    internal class SRP
    {
    }

    //SOLID
    //SOLID Principles are useful to write easily extendable code and avoid common coding errors
    //Adhering to these principles can lead to more modular, flexible and maintainable code.


    //1. SRP -- Single Responsibility Principle
    //A class should have only one reaso to change, menas it should have only one responsibility
    //this promotes code modularization and makes the code easier to understand and maintain
    //A class should do only onething, and it should do it well

    //Think of chef who only focuses on cooking, not managing the resturant or delivering the food

    //Before SRP:
    //This Report class two responsibilites 1. generating report 2. svaing it file -- This voilate SRP
    public class Report_Voilating_SRP
    {
        public void GenerateReport() { } //which generates report
        public void SaveToFile() { } //Save generated report to file

    }

    //After SRP:
    //Now: This Report class is only reponsible for generating the report
    public class Report
    {
        public void GenerateReport() { }
    }

    //This ReportSaver class is responsible for saving the reports
    public class ReportSaver
    {
        public void SaveToFile() { }
    }

    //This way, if you make any changes to Report class will not affect the ReportSaver class.
}
