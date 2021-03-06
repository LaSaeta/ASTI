﻿using ASTI_DAL;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_BLL
{
    public class ASTIAdmin
    {
        public long GetNewStaffId(Staff staff)
        {
            long staffId = -1;
            var admin = new ASTIAdminDAL();

            if (string.IsNullOrWhiteSpace(staff.StaffName) || string.IsNullOrWhiteSpace(staff.Password))
                return staffId;

            //Resetting DateOfRegistration as we are not posting its value from view because that does not seem very useful
            staff.DateOfRegistration = DateTime.Today;

            staffId = admin.GetNewStaffId(staff);

            return staffId;
        }

        public List<Citizen> GetAllPendingApplications()
        {
            var admin = new ASTIAdminDAL();
            return admin.GetAllCitizens().Where(app => app.IsPending == "1").ToList();
        }

        public Citizen GetPendingCitizen(int appNum)
        {
            var admin = new ASTIAdminDAL();

            return admin.GetPendingCitizen(appNum);
        }

        public Citizen GetAadharInformation(int appNum)
        {
            var admin = new ASTIAdminDAL();

            return admin.GetAadharInformation(appNum);
        }

        public void AllocateUserId(int appNum)
        {
            var admin = new ASTIAdminDAL();

            admin.AllocateUserId(appNum);
        }

        public int RegisterPinCode(PincodeRegistration pinCode)
        {
            var admin = new ASTIAdminDAL();

            return admin.RegisterPinCode(pinCode);
        }
    }
}
