﻿using MachineTest.Models;

namespace MachineTest.Interfaces
{
    public interface IAttendenceServices
    {
        bool AddAttendence(Attendence att);
        //Attendence CheckForExist(Attendence att);
    }
}
