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
    
    public partial class User
    {
        public User()
        {
            this.Post = new HashSet<Post>();
            this.Comment = new HashSet<Comment>();
            this.Log = new HashSet<Log>();
            this.Payment = new HashSet<Payment>();
            this.Project = new HashSet<Project>();
            this.ProjectAccess = new HashSet<ProjectAccess>();
        }
    
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<ProjectAccess> ProjectAccess { get; set; }
    }
}
