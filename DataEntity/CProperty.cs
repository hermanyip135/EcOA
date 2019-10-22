using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class CProperty : System.Attribute
    {
         public string Value { get; set; }

         public CProperty(string Value)
        {
            this.Value = Value;
        }
    }
}
