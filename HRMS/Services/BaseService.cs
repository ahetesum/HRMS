using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Services
{
    public class BaseService
    {
                  #region Declaration
        public ApplicationDbContext db { get; set; }
        public BaseService()
        {
            //LogHelper.LogInfo("Init");
        }
        #endregion

        ~BaseService()
        {
            //db.Dispose();
            //db = null;
            //LogHelper.LogInfo("Disposed here ...................... !");
            
        }

    }
    }
