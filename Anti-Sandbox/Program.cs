using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {

        static void Main(string[] args)
        {
            const string anyrunmac = "52:54:00:4A:04:AF";
            ArrayList ary = new ArrayList();//Anyrun Sandbox mac addresses
            
            ManagementClass manager = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj in manager.GetInstances())
            {
             
                if ((bool)obj["IPEnabled"])
                {
                    ary.Add(obj["MacAddress"].ToString());//We throw mac addresses into the array.
                }
            }

            //Check
            for (int i = 0; i < ary.Count; i++)
            {
                if (anyrunmac != ary[0].ToString())
                {
                    if (i==ary.Count-1)
                    {
                        Console.Write(ary[0].ToString() + ": Mac Address Not Found.");
                        Console.ReadKey();
                    }
                    
                }
                else
                {
                    break;
                }
            }



        }


    }
}
