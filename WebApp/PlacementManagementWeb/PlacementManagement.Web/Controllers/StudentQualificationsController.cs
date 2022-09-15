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
    [Authorize(Roles = "Admin")]
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

            if (TempData["ErrorMessage"] != null)
                ViewBag.ErrorMessage = TempData["ErrorMessage"];

            if (TempData["SuccessMessage"] != null)
                ViewBag.SuccessMessage = TempData["SuccessMessage"];

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
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
            }
        }

        // POST: StudentQualifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(StudentQualificationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    throw new Exception("Invalid student qualification details");

                var qualification = new StudentQualification
                {
                    StudentId = model.StudentId,
                    QualificationTypeId = model.QualificationTypeId,
                    Percentage = model.Percentage,
                    PassingYear = model.PassingYear
                };

                await _qualRepo.Add(qualification);

                TempData["SuccessMessage"] = "Student qualification added successfully!";
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

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
                    throw new Exception("Qualification not exists");

                var model = new StudentQualificationViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName(),
                    QualificationTypeId = selectedQual.QualificationTypeId,
                    QualificationName = selectedQual.QualificationName,
                    PassingYear = selectedQual.PassingYear,
                    Percentage = selectedQual.Percentage
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
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

                    TempData["SuccessMessage"] = "Qualification details updated!";
                }
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: StudentQualifications/Delete/5
        public async Task<ActionResult> Delete(int studentId, int qualificationTypeId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var stdQualfications = await _qualRepo.GetAll(studentId);

                StudentQualification selectedQual = stdQualfications.Find(
                    (qual) => qual.QualificationTypeId == qualificationTypeId);

                if (selectedQual == null)
                    throw new Exception("Qualification not exists");

                var model = new StudentQualificationViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName(),
                    QualificationTypeId = selectedQual.QualificationTypeId,
                    QualificationName = selectedQual.QualificationName,
                    PassingYear = selectedQual.PassingYear,
                    Percentage = selectedQual.Percentage
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
            }
        }

        // POST: StudentQualifications/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int studentId, int qualificationTypeId, StudentQualificationViewModel model)
        {
            try
            {
                await _qualRepo.Remove(model.StudentId, model.QualificationTypeId);

                TempData["SuccessMessage"] = "Student qualification has been removed successfully!";
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }
    }
}
