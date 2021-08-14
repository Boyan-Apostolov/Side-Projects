using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AspNetCoreTemplate.Data;
using AspNetCoreTemplate.Data.HospitalModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Diagnostics;

    using AspNetCoreTemplate.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private HospitalContext dbContext = new HospitalContext();

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult AdminIndex()
        {
            return this.View();
        }

        public IActionResult PatientIndex()
        {
            return this.View();
        }

        public IActionResult DoctorIndex()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            return this.View();
        }

        public IActionResult AddMedicament(string name)
        {
            bool isValid = false;
            ViewBag.Name = name;
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    isValid = false;
                    throw new InvalidOperationException("Emplty Medicament Name");
                }

                var medicament = new Medicament { Name = name };
                dbContext.Medicaments.Add(medicament);
                isValid = true;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                isValid = false;
            }

            ViewBag.IsValid = isValid;
            return this.View();
        }

        public IActionResult AddPatient(string firstName, string lastName, string address, string email, int? isInsured)
        {
            bool isValid = false;
            bool hasInsurance = false;
            if (isInsured == 1)
            {
                hasInsurance = true;
            }
            else
            {
                hasInsurance = false;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(email))
                {
                    isValid = false;
                    throw new InvalidOperationException("Emplty Info");
                }

                ViewBag.FistName = firstName;
                ViewBag.LastName = lastName;

                var patient = new Patient
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    Email = email,
                    HasInsurance = hasInsurance
                };

                dbContext.Patients.Add(patient);
                dbContext.SaveChanges();
                isValid = true;
            }
            catch (Exception e)
            {
                isValid = false;
            }

            ViewBag.IsValid = isValid;
            return this.View();
        }

        public IActionResult AddDoctor(string name, string specialty)
        {
            bool isValid = false;
            try
            {

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(specialty))
                {
                    isValid = false;
                    throw new InvalidOperationException("Invalid Doctor info!");
                }

                var doctor = new Doctor
                {
                    Name = name,
                    Specialty = specialty
                };
                dbContext.Doctors.Add(doctor);
                dbContext.SaveChanges();
                isValid = true;
            }
            catch (Exception e)
            {
                isValid = false;
            }
            ViewBag.IsValid = isValid;
            ViewBag.specialty = specialty;
            return this.View();
        }

        public IActionResult AddDiagnose(string name, string comments, int patientId)
        {
            List<Patient> patients = this.dbContext.Patients.ToList();

            bool isValid = false;
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(comments))
                {
                    isValid = false;
                    throw new InvalidOperationException("Invalid Diagnose info!");
                }

                if (dbContext.Patients.Find(patientId) == null)
                {
                    isValid = false;
                    throw new InvalidOperationException("Invalid PatientId!");
                }

                var diagnose = new Diagnose
                {
                    Name = name,
                    Comments = comments,
                    PatientId = patientId
                };

                var patient = dbContext.Patients.Find(patientId);

                if (patient != null)
                {
                    ViewBag.Patient = patient.FirstName + " " + patient.LastName;
                }

                ViewBag.Name = name;
                ViewBag.Comments = comments;

                dbContext.Diagnoses.Add(diagnose);
                dbContext.SaveChanges();
                isValid = true;
            }
            catch (Exception e)
            {
            }

            ViewBag.Patients = patients;
            ViewBag.IsValid = isValid;

            return this.View(patients);
        }

        public IActionResult AddVisitation(DateTime date, string comments, int patientId, int doctorId)
        {
            bool isValid = false;
            try
            {
                if (string.IsNullOrWhiteSpace(comments))
                {
                    isValid = false;
                    throw new Exception();
                }

                if (dbContext.Patients.Find(patientId) == null)
                {
                    isValid = false;
                }
                if (dbContext.Doctors.Find(doctorId) == null)
                {
                    isValid = false;
                }


                var visitation = new Visitation
                {
                    Date = date,
                    Comments = comments,
                    PatientId = patientId,
                    DoctorId = doctorId
                };
                dbContext.Visitations.Add(visitation);
                dbContext.SaveChanges();
                isValid = true;
            }
            catch (Exception e)
            {
            }
            var patients = dbContext.Patients.ToList();
            var doctors = dbContext.Doctors.ToList();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;

            ViewBag.Date = date;
            ViewBag.Comments = comments;

            var patient = dbContext.Patients.Find(patientId);
            var doctor = dbContext.Doctors.Find(doctorId);

            if (patient != null)
            {
                ViewBag.Patient = patient.FirstName + " " + patient.LastName;
                ViewBag.Doctor = doctor.Name;
            }

            ViewBag.IsValid = isValid;

            return this.View();
        }

        public IActionResult LinkPatientWithMedicament(int patientId, int medicamentId)
        {
            bool isValid = false;

            try
            {
                if (dbContext.Patients.Find(patientId) == null || dbContext.Medicaments.Find(medicamentId) == null)
                {
                    isValid = false;
                    throw new ArgumentException("Invalid");
                }

                var patientMedicament = new PatientMedicament
                {
                    PatientId = patientId,
                    MedicamentId = medicamentId
                };
                dbContext.PatientMedicaments.Add(patientMedicament);
                dbContext.SaveChanges();
                isValid = true;
            }
            catch (Exception e)
            {
            }
            var patients = dbContext.Patients.ToList();
            var medicaments = dbContext.Medicaments.ToList();

            ViewBag.Patients = patients;
            ViewBag.Medicaments = medicaments;

            var medicament = dbContext.Medicaments.Find(medicamentId);
            var patient = dbContext.Patients.Find(patientId);

            if (patient != null)
            {
                ViewBag.Medicament = medicament.Name;
                ViewBag.Patient = patient.FirstName + " " + patient.LastName;
            }


            ViewBag.IsValid = isValid;
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
