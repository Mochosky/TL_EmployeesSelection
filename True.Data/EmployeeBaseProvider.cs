using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;

using True.Infrastructure;
using System.ComponentModel.Composition;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace True.Data
{
    [Export(typeof(IEmployeeBaseProvider))]
    public class EmployeeBaseProvider : IEmployeeBaseProvider
    {
        private IConfiguration configurationApi { get; }

        public EmployeeBaseProvider(IConfiguration configuration)
        {
            configurationApi = configuration;
        }

        private static EmployeeBase[] allEmployees;
        static EmployeeBaseProvider()
        {
            try
            {
                GetData();
            }
            catch
            {
                allEmployees = new EmployeeBase[0];
            }
        }
        public IEnumerable<IEmployeeBase> GetEmployeeBaseList(int? id = null)
        {
            if (id.HasValue)
            {
                var rslt = allEmployees.FirstOrDefault(e => e.id == id);
                if (rslt == null)
                    return new EmployeeBase[0];

                return new EmployeeBase[] { rslt };
            }

            return allEmployees;
        }
        private static void GetData()
        {
            var request = HttpWebRequest.Create(configurationApi.GetConnectionString("apiUrl")) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var source = reader.ReadToEnd();
                allEmployees = serializer.Deserialize<EmployeeBase[]>(source);
            }
        }
    }
}
