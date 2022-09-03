using PlacementManagement.Models;
using PlacementManagement.Web.Repository;
using PlacementManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    public class StudentQualificationsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IStudentAcademicRepository<StudentQualification, QualificationType> _qualRepo;

        public StudentQualificationsController(
            IStudentRepository studentRepo, IStudentAcademicRepository<StudentQualification, QualificationType> qualRepo)
        {
            _studentRepo = studentRepo;
            _qualRepo = qualRepo;
        }

        // GET: StudentQualifications?studentId=1
        public async Task<ActionResult> Index(int? studentId)
        {
            if (studentId == null)
                return View();

            try
            {
                var student = await _studentRepo.GetStudent((int)studentId);
                var qualifications = await _qualRepo.GetAll((int)studentId);

                var model = new StudentDetailViewModel
                {
                    Student = student,
                    StudentQualifications = qualifications
                };

                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "No such student exists - " + studentId.ToString();
                return View();
            }
        }

        // GET: StudentQualifications/Create
        public async Task<ActionResult> Create(int studentId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var model = new StudentQualificationViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName()
                };

                List<QualificationType> qualTypes = await _qualRepo.GetAll();
                ViewData["Qualifications"] = new SelectList(qualTypes, "Id", "Name");
                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to add qualification";
                return View();
            }
        }

        // POST: StudentQualifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(StudentQualificationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var qualification = new StudentQualification
                    {
                        StudentId = model.StudentId,
                        QualificationTypeId = model.QualificationTypeId,
                        Percentage = model.Percentage,
                        PassingYear = model.PassingYear
                    };

                    await _qualRepo.Add(qualification);
                }
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to add qualification";

                List<QualificationType> qualTypes = await _qualRepo.GetAll();
                ViewData["Qualifications"] = new SelectList(qualTypes, "Id", "Name");

                return View(model);
            }
        }

        // GET: StudentQualifications/Edit/5
        public async Task<ActionResult> Edit(int studentId, int qualificationTypeId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var stdQualfications = await _qualRepo.GetAll(studentId);

                StudentQualification selectedQual = stdQualfications.Find(
                    (qual) => qual.QualificationTypeId == qualificationTypeId);

                if (selectedQual == null)
                {
                    return HttpNotFound("Qualification not exists");
                }

                var model = new StudentQualificationViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName(),
                    QualificationTypeId = selectedQual.QualificationTypeId,
                    PassingYear = selectedQual.PassingYear,
                    Percentage = selectedQual.Percentage
                };

                List<QualificationType> qualTypes = await _qualRepo.GetAll();
                ViewData["Qualifications"] = new SelectList(qualTypes, "Id", "Name", qualificationTypeId);

                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to update qualification";
                return View();
            }
        }

        // POST: StudentQualifications/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(StudentQualificationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var qualification = new StudentQualification
                    {
                        StudentId = model.StudentId,
                        QualificationTypeId = model.QualificationTypeId,
                        Percentage = model.Percentage,
                        PassingYear = model.PassingYear
                    };

                    await _qualRepo.Update(qualification);
                }
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to update qualification";
                
                List<QualificationType> qualTypes = await _qualRepo.GetAll();
                ViewData["Qualifications"] = new SelectList(qualTypes, "Id", "Name", model.QualificationTypeId);

                return View(model);
            }
        }

        // GET: StudentQualifications/Delete/5
        public async Task<ActionResult> Delete(int studentId, int qualificationTypeId)
        {
            return View();
        }

        // POST: StudentQualifications/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int studentId, int qualificationTypeId, FormCollection collection)
        {
            try
            {
                await _qualRepo.Remove(studentId, qualificationTypeId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
