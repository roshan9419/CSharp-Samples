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
    public class StudentProgramsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IStudentAcademicRepository<StudentProgram, Program> _programRepo;

        public StudentProgramsController(
            IStudentRepository studentRepo, IStudentAcademicRepository<StudentProgram, Program> programRepo)
        {
            _studentRepo = studentRepo;
            _programRepo = programRepo;
        }

        // GET: StudentPrograms?studentId=1
        /// <summary>
        /// This will loads the StudentPrograms details page
        /// </summary>
        /// <param name="studentId">StudentId of the student</param>
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
                var programs = await _programRepo.GetAll((int)studentId);

                var model = new StudentDetailViewModel
                {
                    Student = student,
                    StudentPrograms = programs
                };

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StudentPrograms/Create?studentId=1
        public async Task<ActionResult> Create(int studentId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var model = new StudentProgramViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName()
                };

                List<Program> programs = await _programRepo.GetAll();
                ViewData["Programs"] = new SelectList(programs, "ProgramId", "ProgramName");

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
            }
        }

        // POST: StudentPrograms/Create
        /// <summary>
        /// This will add new StudentProgram of a student and redirects back to list page
        /// </summary>
        /// <param name="studentId">StudentId of the student</param>
        [HttpPost]
        public async Task<ActionResult> Create(StudentProgramViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid student program details");

                var program = new StudentProgram
                {
                    StudentId = model.StudentId,
                    ProgramId = model.ProgramId,
                    BatchStartYear = model.BatchStartYear,
                    BatchEndYear = model.BatchEndYear,
                    Backlogs = model.Backlogs,
                    CurrentCGPA = model.CurrentCGPA
                };

                await _programRepo.Add(program);

                TempData["SuccessMessage"] = "Student program added successfully!";
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                List<Program> programs = await _programRepo.GetAll();
                ViewData["Programs"] = new SelectList(programs, "ProgramId", "ProgramName");

                return View(model);
            }
        }

        // GET: StudentPrograms/Edit/5
        public async Task<ActionResult> Edit(int studentId, int programId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var stdPrograms = await _programRepo.GetAll(studentId);

                StudentProgram selectedProgram = stdPrograms.Find((prg) => prg.ProgramId == programId);

                if (selectedProgram == null)
                    throw new Exception("Program not exists");

                var model = new StudentProgramViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName(),
                    ProgramId = selectedProgram.ProgramId,
                    ProgramName = selectedProgram.ProgramName,
                    BatchStartYear = selectedProgram.BatchStartYear,
                    BatchEndYear = selectedProgram.BatchEndYear,
                    Backlogs = selectedProgram.Backlogs,
                    CurrentCGPA = selectedProgram.CurrentCGPA
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
            }
        }

        // POST: StudentPrograms/Edit/5
        /// <summary>
        /// This will update the details of StudentProgram and redirects back to list page
        /// </summary>
        /// <param name="model">StudentProgramViewModel model object</param>
        [HttpPost]
        public async Task<ActionResult> Edit(StudentProgramViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var program = new StudentProgram
                    {
                        StudentId = model.StudentId,
                        ProgramId = model.ProgramId,
                        BatchStartYear = model.BatchStartYear,
                        BatchEndYear = model.BatchEndYear,
                        Backlogs = model.Backlogs,
                        CurrentCGPA = model.CurrentCGPA
                    };

                    await _programRepo.Update(program);

                    TempData["SuccessMessage"] = "Program details updated!";
                }
                return RedirectToAction("Index", new { studentId = model.StudentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: StudentPrograms/Delete/5
        public async Task<ActionResult> Delete(int studentId, int programId)
        {
            try
            {
                var student = await _studentRepo.GetStudent(studentId);
                var stdPrograms = await _programRepo.GetAll(studentId);

                StudentProgram selectedProgram = stdPrograms.Find((prg) => prg.ProgramId == programId);

                if (selectedProgram == null)
                    throw new Exception("Program not exists");

                var model = new StudentProgramViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.GetFullName(),
                    ProgramId = selectedProgram.ProgramId,
                    ProgramName = selectedProgram.ProgramName,
                    BatchStartYear = selectedProgram.BatchStartYear,
                    BatchEndYear = selectedProgram.BatchEndYear,
                    Backlogs = selectedProgram.Backlogs,
                    CurrentCGPA = selectedProgram.CurrentCGPA
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { studentId = studentId });
            }
        }

        // POST: StudentPrograms/Delete/5
        /// <summary>
        /// This will remove the studentProgram from a student and redirects back to the list page
        /// </summary>
        /// <param name="studentId">StudentId of a student (optional)</param>
        /// <param name="programId">ProgramId of a program (optional)</param>
        /// <param name="model">StudentProgramViewModel model object</param>
        [HttpPost]
        public async Task<ActionResult> Delete(int studentId, int programId, StudentProgramViewModel model)
        {
            try
            {
                await _programRepo.Remove(model.StudentId, model.ProgramId);

                TempData["SuccessMessage"] = "Student program has been removed successfully!";
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
