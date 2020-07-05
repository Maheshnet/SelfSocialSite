using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace SUtilities
{
    public class SentryLogger
    {
        private static readonly Exception _exception = null;
        private static readonly String _message = String.Empty;
        public string SerializeObjecttoJSON(object obj)
        {
            string output = JsonConvert.SerializeObject(obj);
            return output;
        }

        public static string SerializeObjecttoXML(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                LogtoSentry("Exception at SerializeObjecttoXML", LogEventLevel.Error, ex);
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
        public static Object XMLtoObject(string xml, Type objectType)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            Object obj = null;
            try
            {
                strReader = new StringReader(xml);
                XmlSerializer serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception exp)
            {
                LogtoSentry("Exception at XMLtoObject", LogEventLevel.Error, exp);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
                if (strReader != null)
                {
                    strReader.Close();
                }
            }
            return obj;
        }
        public static void LogtoSentry(string message,
                                       LogEventLevel LogLevel,
                                      [Optional] Exception exception)

        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .MinimumLevel.Debug()
                    // Other overloads exist, for example, configure the SDK with only the DSN or no parameters at all.
                    .WriteTo.Sentry(o =>
                    {
                        o.MinimumBreadcrumbLevel = LogEventLevel.Debug; // Debug and higher are stored as breadcrumbs (default os Information)
                        o.MinimumEventLevel = LogEventLevel.Warning; // Error and higher is sent as event (default is Error)
                                                                     // If DSN is not set, the SDK will look for an environment variable called SENTRY_DSN. If nothing is found, SDK is disabled.
                        o.Dsn = new Sentry.Dsn("https://b3ea36055dcf4b79bc7ee046fd224ec5@o407788.ingest.sentry.io/5277439");
                        o.AttachStacktrace = true;
                        o.SendDefaultPii = true;
                        o.AttachStacktrace = true;
                        o.Debug = true;
                        o.DiagnosticsLevel = (Sentry.Protocol.SentryLevel)LogEventLevel.Error;
                        // send PII like the username of the user logged in to the device
                        // Other configuration
                    })
                    .CreateLogger();

                switch (LogLevel)
                {
                    case LogEventLevel.Information:
                        Log.Information(message);
                        break;
                    case LogEventLevel.Warning:
                        Log.Warning(message);
                        break;
                    case LogEventLevel.Error:
                        Log.Error(exception, message);
                        break;
                    case LogEventLevel.Debug:
                        if (exception == null)
                        {
                            Log.Debug(message);
                            break;
                        }
                        else
                        {
                            Log.Debug(exception, message);
                            break;
                        }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Exception At Logger", Ex);

            }
           
        }
    }
}
