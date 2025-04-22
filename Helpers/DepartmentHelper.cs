﻿using AcunMedyaHospitalProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Helpers
{
    public static class DepartmentHelper
    {
        private readonly static AppDbContext db = new AppDbContext();
        public static SelectList GetDepartments()
        {
            var departments = db.Departments.ToList();
            return new SelectList(departments, "ID", "Name");
        }
        public static SelectList GetDepartments(int selectedValue)
        {
            var departments = db.Departments.ToList();
            return new SelectList(departments, "ID", "Name",selectedValue);
        }
    }
}