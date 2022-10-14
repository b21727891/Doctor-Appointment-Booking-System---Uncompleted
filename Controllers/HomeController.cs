using DoctorAppointmentBookingSys.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Text;
namespace DoctorAppointmentBookingSys.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        #region Index method  

        /// <summary>  
        /// GET: Home/Index method.  
        /// </summary>  
        /// <returns>Returns - index view page</returns> 
        public ActionResult Index()
        {
            // Info.  
            return this.View();
        }

        #endregion

        #region Get Calendar data method.  

        /// <summary>  
        /// GET: /Home/GetCalendarData  
        /// </summary>  
        /// <returns>Return data</returns>  
        public ActionResult GetCalendarData()
        {
            // Initialization.  
            JsonResult result = new JsonResult();

            try
            {
                // Loading.  
                List<AptCalendar> data = context.AptCalendar.ToList();
                List<AptCalendarsUI> datas = new List<AptCalendarsUI>();
                foreach (var item in data)
                {
                    datas.Add(new AptCalendarsUI()
                    {
                        AptID = item.AptID,
                        DoctorID= item.DoctorID,
                        Complaint= item.Complaint,
                        StartDate=item.StartDate.ToString("yyyy-MM-dd"),
                        EndDate= item.EndDate.ToString("yyyy-MM-dd"),
                        UserID= item.UserID,
                        DoctorName= item.DoctorName,
                        UserName= item.UserName,
                    });
            }

                // Processing.  
            result = this.Json(datas, JsonRequestBehavior.AllowGet);
        }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Return info.  
            return result;
        }

        #endregion

        #region Helpers  

        #region Load Data  

        /// <summary>  
        /// Load data method.  
        /// </summary>  
        /// <returns>Returns - Data</returns>  
       /* private List<AptCalendar> LoadData()

        {
            // Initialization.  
            List<AptCalendar> lst = new List<AptCalendar>();

            try
            {
                foreach (var d in LoadData())
                {
                    lst.Clear();
                    foreach (var item in lstGetProperties())
                    {
                        lst.Add(item);


                    }

                }
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }*/

        #endregion

        #endregion
    }
}