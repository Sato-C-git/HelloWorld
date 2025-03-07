using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic;

namespace SimpleCalc
{
    /// <summary>
    /// 
    /// </summary>
    public class CalculationHistory
    {
        public string FirstNum { get; set; }
        public string SecondNum { get; set; }
        public string FourArithmeticOpts { get; set; }
        public int ResultNum { get; set; }
        [Ignore]
        public DateTime CalcDateTime { get; set; }

        //public string CalcDateTimeString => this.CalcDateTime.ToString("yyyy/MM/dd HH:mm:ss");

        public string CalcDateTimeString
        {
            get => this.CalcDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            set
            {
                DateTime.TryParse(value, out var parseResult);
                this.CalcDateTime = parseResult;
            }
        }

    }
    //public void CalcResult(string FirstNum, string SecondNum, string FourArithmeticOpts, int ResultNum,
    //    DateAndTime CalcDateTime)
    //{

    //}
}