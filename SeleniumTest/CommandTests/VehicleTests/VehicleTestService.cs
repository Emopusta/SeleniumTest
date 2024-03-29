﻿using SeleniumTest.ResultTestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.CommandTests.VehicleTests
{
    public interface VehicleTestService
    {
        ResultTest POSTAddVehicleTest(string name);
        ResultTest PUTUpdateVehicleTest(string name, int velocity, int batteryPercentage, int statusId);


    }
}
