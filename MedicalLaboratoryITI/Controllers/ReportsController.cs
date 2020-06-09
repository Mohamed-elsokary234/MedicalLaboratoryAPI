using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.WebApi;

namespace MedicalLaboratoryITI.Controllers
{
    //[EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ReportsController : ReportsControllerBase
    {
        //To configure the Telerik Reporting REST service from the application configuration file,
        //set the value of the ReportServiceConfiguration property to an instance of the ConfigSectionReportServiceConfiguration class.
        //static Telerik.Reporting.Services.ConfigSectionReportServiceConfiguration configSectionConfigurationInstance =
       // new Telerik.Reporting.Services.ConfigSectionReportServiceConfiguration();


        static readonly ReportServiceConfiguration configurationInstance =
        new ReportServiceConfiguration
        {
            HostAppId = "Application1",
            ReportSourceResolver = new UriReportSourceResolver(HttpContext.Current.Server.MapPath("~/Reports"))
                .AddFallbackResolver(new TypeReportSourceResolver()),
            Storage = new Telerik.Reporting.Cache.File.FileStorage(),
        };

    public ReportsController()
    {
        this.ReportServiceConfiguration = configurationInstance;

        //this.ReportServiceConfiguration = configSectionConfigurationInstance;
    }

     #region SendMailMessage_Implementation
     protected override HttpStatusCode SendMailMessage(MailMessage mailMessage)
     {
         using (var smtpClient = new SmtpClient("smtp.companyname.com", 25))
         {
             smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
             smtpClient.EnableSsl = true;
             smtpClient.Send(mailMessage);
         }
 
         return HttpStatusCode.OK;
     }
     #endregion
    }
}
