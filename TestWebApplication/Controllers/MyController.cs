using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TestWebApplication;
using TestWebApplication.Models;

namespace StoredProcedureMvc.Controllers
{
    public class MyController : Controller
    {
        readonly Entities _db = new Entities();
        //readonly Sudent _db = new Student();
        public ActionResult Index()
        {
            var list = _db.usp_GetAllStudentData().ToList();
            return View();
        }
        public ActionResult ListObject()
        {
            return View();
        }
        public JsonResult GetStudentList()
        {

            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveStudent(T_STUDENT student)
        {
            _db.usp_SaveStudent(student.FIRST_NAME, student.LAST_NAME, student.EMAIL,
                student.ADRESS, student.ENROLMENT_DATE, student.DEPARTMENT_ID);
            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateStudent(T_STUDENT student)
        {
            _db.usp_UpdateStudent(student.ID, student.FIRST_NAME, student.LAST_NAME, student.EMAIL,
                student.ADRESS, student.ENROLMENT_DATE, student.DEPARTMENT_ID);
            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteStudent(T_STUDENT student)
        {
            _db.usp_DeleteStudent(student.ID);
            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveStudentAsXml(List<T_STUDENT> students)
        {
            var doc = new XElement("STUDENTS");
            foreach (var item in students)
            {
                var doc1 = new XElement("STUDENT");
                doc1.Add(new XElement("FIRST_NAME", item.FIRST_NAME),
                            new XElement("LAST_NAME", item.LAST_NAME),
                            new XElement("EMAIL", item.EMAIL),
                            new XElement("ADRESS", item.ADRESS),
                            new XElement("ENROLMENT_DATE", item.ENROLMENT_DATE),
                            new XElement("DEPARTMENT_ID", item.DEPARTMENT_ID)
                        );
                doc.Add(doc1);
            }
            _db.usp_SaveStudentListFromXml(doc.ToString());
            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveStudentAsTable(List<T_STUDENT> students)
        {
            var stdDt = new DataTable();
            stdDt.Columns.Add("FIRST_NAME", typeof(string));
            stdDt.Columns.Add("LAST_NAME", typeof(string));
            stdDt.Columns.Add("EMAIL", typeof(string));
            stdDt.Columns.Add("Adress", typeof(string));
            stdDt.Columns.Add("ENROLMENT_DATE", typeof(DateTime));
            stdDt.Columns.Add("DEPARTMENT_ID", typeof(int));
            foreach (var item in students)
            {
                stdDt.Rows.Add(item.FIRST_NAME, item.LAST_NAME, item.EMAIL, item.ADRESS,
                    item.ENROLMENT_DATE, item.DEPARTMENT_ID);
            }
            var parameter = new SqlParameter("@studentList", SqlDbType.Structured);
            parameter.Value = stdDt;
            parameter.TypeName = "dbo.StudentType";
            _db.Database.ExecuteSqlCommand("exec dbo.usp_SaveStudentListFromDataTable @studentList", parameter);
            var list = _db.usp_GetAllStudentData().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}