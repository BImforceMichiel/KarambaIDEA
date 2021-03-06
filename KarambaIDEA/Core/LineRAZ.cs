﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarambaIDEA.Core
{
    public class LineRAZ
    {
        public int id;
        public PointRAZ Start;
        public PointRAZ End;
        //public VectorRAZ vectorq;
        public VectorRAZ vector
        {
            get
            {
                return new VectorRAZ(Start, End);
            }
        }


        public LineRAZ()
        {

        }

        public LineRAZ(int _id, PointRAZ _Start, PointRAZ _End)
        {
            this.id = _id;
            this.Start = _Start;
            this.End = _End;

        }

        public static LineRAZ TranslateLineWithVector(Project _project, LineRAZ line, VectorRAZ translation)
        {
            PointRAZ newStart = PointRAZ.CreateNewOrExisting(_project,line.Start.X + translation.X, line.Start.Y + translation.Y, line.Start.Z + translation.Z);
            PointRAZ newEnd = PointRAZ.CreateNewOrExisting(_project,line.End.X + translation.X, line.End.Y + translation.Y, line.End.Z + translation.Z);
            LineRAZ result = new LineRAZ(line.id, newStart, newEnd);
            return result;
        }

        /// <summary>
        /// In this method the startpoint of the line is compared to the point. IF ther are equal the original line is returned. 
        /// If not the line will be flipped. Where startpoint and endpoint
        /// </summary>
        /// <param name="tol"></param>
        /// <param name="point"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public static LineRAZ FlipLineIfPointNotEqualStartPoint(double tol, PointRAZ point, LineRAZ line)
        {
            if (PointRAZ.ArePointsEqual(tol, point, line.Start) == true)
            {
                return line;
            }
            else
            {
                return new LineRAZ(line.id, line.End, line.Start);
            }
        }

        public static LineRAZ FlipLine(LineRAZ line)
        {
            return new LineRAZ(line.id, line.End, line.Start);
        }


        public static int ShouldEccentricityBeAssumedPOSOrNEG(double tol, PointRAZ point, LineRAZ line)
        {
            if (PointRAZ.ArePointsEqual(tol, point, line.End) == true)
            {
                LineRAZ lijn2 = LineRAZ.FlipLineIfPointNotEqualStartPoint(tol, point, line);
                if (lijn2.vector.Z > 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }
            else
            {
                if (line.vector.Z > 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
