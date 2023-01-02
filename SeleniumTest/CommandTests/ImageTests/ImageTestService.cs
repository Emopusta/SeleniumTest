using SeleniumTest.ResultTestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.CommandTests.ImageTests
{
    public interface ImageTestService
    {
        ResultTest POSTAddImageTest(int vehicleId, string filePath);

    }
}
