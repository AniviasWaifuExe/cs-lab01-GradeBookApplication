using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
     class StandardGradeBook : BaseGradeBook //klasa
    {
        public string name; //pole
        
        public StandardGradeBook(string name, bool isWeighted) : base(name , isWeighted) // const
        {
            Type = GradeBookType.Standard; //"this should set type to gradebooktype.standard" 
        }
    }
}
