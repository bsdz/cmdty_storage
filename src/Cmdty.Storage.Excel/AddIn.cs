﻿#region License
// Copyright (c) 2019 Jake Fowler
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without 
// restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following 
// conditions:
//
// The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using ExcelDna.ComInterop;
using ExcelDna.Integration;

namespace Cmdty.Storage.Excel
{
    public enum CalcMode
    {
        Blocking,
        Async
    }

    internal class AddIn : IExcelAddIn
    {
        public const string ExcelFunctionNamePrefix = "cmdty.";
        public const string ExcelFunctionCategory = "Cmdty.Storage";
        public void AutoOpen()
        {
            //dynamic app = (Application)ExcelDnaUtil.Application;
            //dynamic calcMode = app.Calculation;
            //CalcMode = app.Calculation == XlCalculation.xlCalculationManual ? CalcMode.Blocking : CalcMode.Async;
            //if (app.Calculation == XlCalculation.xlCalculationManual)
            //    CalcMode = CalcMode.Blocking;
            //else
            //    CalcMode = CalcMode.Async;
            ComServer.DllRegisterServer();
        }

        public void AutoClose()
        {
            ComServer.DllUnregisterServer();
        }

        public static CalcMode CalcMode { get; set; }
    }
}
