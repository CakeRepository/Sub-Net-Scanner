using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Host_Subnet_Scan
{
    class Worker
    {
        public string findMacAddress(string ipAddress)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                string macAddress = " ";
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript("arp -a " + ipAddress);
                
                // invoke execution on the pipeline (ignore output)
                
                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                // check the other output streams (for example, the error stream)
                if (PowerShellInstance.Streams.Error.Count > 0)
                {
                    // error records were written to the error stream.
                    // do something with the items found.
                }
                int i = 0;
                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    i++;
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        //TODO: do something with the output item 
                        //Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                        
                        if (i == 4)
                        {
                            macAddress = outputItem.BaseObject.ToString().Substring(24, 17);
                            //Console.WriteLine(outputItem.BaseObject.ToString().Substring(24,17));
                        }
                    }
                }
                return macAddress;
            }
        }
        
    }
}
