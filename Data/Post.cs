//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public Post()
        {
            this.Comment = new HashSet<Comment>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
