//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClone.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Following
    {
        public int Rowid { get; set; }
        public string User_id { get; set; }
        public string Following_id { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
    }
}
