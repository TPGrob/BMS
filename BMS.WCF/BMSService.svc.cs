using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BMS.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BMSService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BMSService.svc or BMSService.svc.cs at the Solution Explorer and start debugging.
    public class BMSService : IBMSService
    {
        public Bierkroegen DoWork()
        {
           // string connectString = "SQLEXPRESS; Initial Catalog = BMS; Integrated Security = True;";

           // BMSClassesDataContext db = new BMSClassesDataContext(connectString);
            return new Bierkroegen() ;
        }
    }


}
