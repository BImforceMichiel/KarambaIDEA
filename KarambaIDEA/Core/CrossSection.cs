﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace KarambaIDEA.Core
{
    public class CrossSection
    {

        public int id
        {
            get
            {
                return this.project.crossSections.IndexOf(this)+1;//IDEA count from one
            }
        }

        public string name;
        //public string shape;
        public MaterialSteel material;
        public double height;
        public double width;
        public double thicknessFlange;
        public double thicknessWeb;
        public double radius;
        public Project project;
        public Shape shape;


        public CrossSection()
        {

        }

        public CrossSection(Project _project,string _name, Shape _shape, MaterialSteel _material, double _height, double _width, double _thicknessFlange, double _thicknessWeb, double _radius)
        {
            this.name = _name;
            this.shape = _shape;
            this.material = _material;
            
            this.height = _height;
            this.width = _width;
            this.thicknessFlange = _thicknessFlange;
            this.thicknessWeb = _thicknessWeb;
            this.radius = _radius;

            this.project = _project;
            _project.crossSections.Add(this);

#warning: DOORSNEDES ALLEEN AANMAKEN ALS DEZE NOG NIET BESTAAT!
        }

        public static CrossSection CreateNewOrExisting(Project _project, string _name, Shape _shape, MaterialSteel _material, double _height, double _width, double _thicknessFlange, double _thicknessWeb, double _radius)
        {
            
            double tol = Project.tolerance;
            CrossSection p = _project.crossSections.Where(a => a.name == _name  && a.material == _material).FirstOrDefault();
            if (p == null)
                p = new CrossSection(_project, _name, _shape, _material, _height, _width, _thicknessFlange, _thicknessWeb, _radius);
            return p;
        }

        public enum Shape
        {
            ISection,
            HollowSection
        }


        //public double CrosssectionProperties(string name)
        //{
        //    _Application excel = new _Excel.Application();
        //    Workbook wb;
        //    Worksheet ws;

        //    wb = excel.Workbooks.Open(@"C:\Users\raz\Google Drive\C#Grasshopper\TotalRayaan06-09\Translate3\CrossSectionValues.xlsx");
        //    ws = wb.Worksheets[1];
        //    for (int i=1; i < 7031; i++)
        //    {
        //        if (ws.Cells[i,4].Value2.Tostring()==name)
        //        {
        //            return ws.Cells[i, 6].Value2.Todouble();

        //        }

        //    }


        //}


    }
}