using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace QSharpContests.Tests
{
    public class Modules
    {
        static public string GetTempFilepath([CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "")
        {
            return System.IO.Path.GetFileName(filePath) + "_" + memberName + ".dump";
        }

        static public double EPS = 1e-5;
    }
}
