﻿using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LiveLarn.Core.Infrastructure.Helper
{
    public static class ReflectionHelper
    {
        public static string WhoseThere([CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            var mth = new StackTrace().GetFrame(1).GetMethod();
            var cls = mth.ReflectedType.FullName;
            return $"{cls}.{memberName}";
        }
    }
}
