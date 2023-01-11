
namespace WebApp_CrystalReport
{
    public class CrystalReportConnection
    {
        public static CrystalDecisions.Shared.ConnectionInfo GetConnection()
        {
            CrystalDecisions.Shared.ConnectionInfo connectionInfo = new CrystalDecisions.Shared.ConnectionInfo();

            connectionInfo.ServerName = @"DESKTOP-5ESG0V0\SQLEXPRESS";
            connectionInfo.DatabaseName = "AdventureWorks2019";
            connectionInfo.IntegratedSecurity = true;

            return connectionInfo;
        }
    }
}