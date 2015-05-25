using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTNDAL;

using CTNDb;
using CTNDb.Properties;

namespace testDB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*using (var con = new CTNContext(Resources.ConnectionString))
            {
                var atsType1 = new ATSType()
                {
                    Type = "Very Big"
                };
                var atsType2 = new ATSType()
                {
                    Type = "Very Small"
                };
                var atsTypeService = new ATSTypeService(con);
                atsTypeService.Create(atsType1);
                atsTypeService.Create(atsType2);
            }*/
            /* var serv = new CTNService(context);
                List<CTN> list = new List<CTN>(serv.GetAll());

                foreach (var ctn in list)
                {
                    serv.Delete(ctn);
                }*/
        }
    }


}
