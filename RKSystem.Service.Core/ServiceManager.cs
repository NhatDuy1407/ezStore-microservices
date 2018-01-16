namespace RKSystem.Service.Core
{
    public abstract class ServiceManager
    {
        public void ConfigureLogger()
        {
//            const string logConfig = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
//<log4net>
//  <appender name=""RollingFile"" type=""log4net.Appender.RollingFileAppender"">
//    <file type=""log4net.Util.PatternString"" value=""Logs/FnF-%date{yyyyMMdd}.txt""/>
//    <appendToFile value=""true""/>
//    <rollingStyle value=""Size"" />
//    <maxSizeRollBackups value=""10"" />
//    <maximumFileSize value=""10MB"" />
//    <!--Ensure the file name is unchanged-->
//    <staticLogFileName value=""true"" />
//    <lockingModel type=""log4net.Appender.FileAppender+MinimalLock"" />
//    <layout type=""log4net.Layout.PatternLayout"">
//      <conversionPattern value=""%date [%thread] %-5level %logger - %message%newline""/>
//    </layout>
//  </appender>

//  <root>
//    <level value=""ALL""/>
//    <appender-ref ref=""RollingFile""/>
//  </root>
//</log4net>";

//            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(logConfig)))
//            {
//                XmlConfigurator.Configure(,stream);
//            }
        }

        public void UseLog4Net()
        {
            //// Topshelf to use Log4Net
            //Log4NetLogWriterFactory.Use();

            //// MassTransit to use Log4Net
            //Log4NetLogger.Use();
        }

        public abstract int Start();
    }
}
