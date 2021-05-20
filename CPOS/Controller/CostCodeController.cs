using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class CostCodeController
    {
        public static char[] CostCode = SettingsController.Settings.CostCode.ToUpper().ToCharArray();
        

        public static string CostToCode(decimal cost)
        {
            string xcost = cost.ToString();
            xcost = xcost.Replace('0', CostCode[0]);
            xcost = xcost.Replace('1', CostCode[1]);
            xcost = xcost.Replace('2', CostCode[2]);
            xcost = xcost.Replace('3', CostCode[3]);
            xcost = xcost.Replace('4', CostCode[4]);
            xcost = xcost.Replace('5', CostCode[5]);
            xcost = xcost.Replace('6', CostCode[6]);
            xcost = xcost.Replace('7', CostCode[7]);
            xcost = xcost.Replace('8', CostCode[8]);
            xcost = xcost.Replace('9', CostCode[9]);
            xcost = xcost.Replace('.', CostCode[10]);
            return xcost;
        }

        public static decimal CodeToCost(string Code)
        {
            try
            {
                string xcode = Code.ToUpper();
                xcode = xcode.Replace(CostCode[0], '0');
                xcode = xcode.Replace(CostCode[1], '1');
                xcode = xcode.Replace(CostCode[2], '2');
                xcode = xcode.Replace(CostCode[3], '3');
                xcode = xcode.Replace(CostCode[4], '4');
                xcode = xcode.Replace(CostCode[5], '5');
                xcode = xcode.Replace(CostCode[6], '6');
                xcode = xcode.Replace(CostCode[7], '7');
                xcode = xcode.Replace(CostCode[8], '8');
                xcode = xcode.Replace(CostCode[9], '9');
                xcode = xcode.Replace(CostCode[10],'.');
                return decimal.Parse(xcode);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
