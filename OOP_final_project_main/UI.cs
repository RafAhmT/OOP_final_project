using OOP_Assigment_classlib;
using OOP_final_project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_final_project
{
    public class UI
    {
        void init_controller()
        {
            AdminController adminCtrl = new AdminController();
            NurseController nurseCtrl = new NurseController();
            DoctorController docCtrl = new DoctorController();
            PatientController patCtrl = new PatientController();

        }
        void mainscreen()
        {
            init_controller();
            bool isrun = true;
            while (isrun)
            {

            }
        }
    }
}
