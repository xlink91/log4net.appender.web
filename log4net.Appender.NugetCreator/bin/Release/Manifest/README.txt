<appender name="Web" type="log4net.Appender.Web.WebService, log4net.Appender.Web">
	<Uri value="http://localhost:63232/api/log/initializer" />
	<Headers value="" />
	<layout type="log4net.Layout.PatternLayout">
		<!-- Pattern to output the caller's file name and line number -->
		<conversionPattern value="%date [%thread] %-5level %logger [%ndc] - %message%newline" />
	</layout>
</appender>
