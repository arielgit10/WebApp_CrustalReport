using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.IO;
using System.Web.Mvc;

namespace WebApp_CrystalReport.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DownloadReport()
        {
            try
            {
                var report = new ReportClass();
                report.FileName = Server.MapPath("/Reportes/Products.rpt");
                report.Load();
                var connectionInfo = CrystalReportConnection.GetConnection();
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                Tables tables;
                tables = report.Database.Tables;

                foreach (Table table in tables)
                {
                    logOnInfo = table.LogOnInfo;
                    logOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logOnInfo);
                }
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = report.ExportToStream(ExportFormatType.PortableDocFormat);
                report.Dispose();
                report.Close();
                return new FileStreamResult(stream, "application/pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
   
    }
}
