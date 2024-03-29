﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_STUDENT> T_STUDENT { get; set; }
    
        public virtual int usp_DeleteStudent(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeleteStudent", idParameter);
        }
    
        public virtual ObjectResult<usp_GetAllStudentData_Result> usp_GetAllStudentData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetAllStudentData_Result>("usp_GetAllStudentData");
        }
    
        public virtual int usp_SaveStudent(string firstName, string lastName, string email, string address, Nullable<System.DateTime> enrollDate, Nullable<int> departmentId)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var enrollDateParameter = enrollDate.HasValue ?
                new ObjectParameter("enrollDate", enrollDate) :
                new ObjectParameter("enrollDate", typeof(System.DateTime));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SaveStudent", firstNameParameter, lastNameParameter, emailParameter, addressParameter, enrollDateParameter, departmentIdParameter);
        }
    
        public virtual int usp_SaveStudentListFromDataTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SaveStudentListFromDataTable");
        }
    
        public virtual int usp_SaveStudentListFromXml(string xmlData)
        {
            var xmlDataParameter = xmlData != null ?
                new ObjectParameter("xmlData", xmlData) :
                new ObjectParameter("xmlData", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SaveStudentListFromXml", xmlDataParameter);
        }
    
        public virtual int usp_UpdateStudent(Nullable<int> id, string firstName, string lastName, string email, string adress, Nullable<System.DateTime> enrollDate, Nullable<int> departmentId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var adressParameter = adress != null ?
                new ObjectParameter("adress", adress) :
                new ObjectParameter("adress", typeof(string));
    
            var enrollDateParameter = enrollDate.HasValue ?
                new ObjectParameter("enrollDate", enrollDate) :
                new ObjectParameter("enrollDate", typeof(System.DateTime));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_UpdateStudent", idParameter, firstNameParameter, lastNameParameter, emailParameter, adressParameter, enrollDateParameter, departmentIdParameter);
        }
    
        public virtual int usp_SaveStudent1(string firstName, string lastName, string email, string address, Nullable<System.DateTime> enrollDate, Nullable<int> departmentId)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var enrollDateParameter = enrollDate.HasValue ?
                new ObjectParameter("enrollDate", enrollDate) :
                new ObjectParameter("enrollDate", typeof(System.DateTime));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SaveStudent1", firstNameParameter, lastNameParameter, emailParameter, addressParameter, enrollDateParameter, departmentIdParameter);
        }
    }
}
