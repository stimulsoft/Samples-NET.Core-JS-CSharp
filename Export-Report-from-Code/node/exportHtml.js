module.exports = function (callback, reportPath) {
    // Prepare engine module
    var Stimulsoft = require('stimulsoft-reports-js');
    Stimulsoft.Base.StiFontCollection.addOpentypeFontFile("node/Roboto-Black.ttf");

    // Load and render the report template
    var report = new Stimulsoft.Report.StiReport();
    report.loadFile(reportPath);
    report.renderAsync(function () {
        // Export report to HTML string
        var settings = new Stimulsoft.Report.Export.StiHtmlExportSettings();
        var service = new Stimulsoft.Report.Export.StiHtmlExportService();
        var textWriter = new Stimulsoft.System.IO.TextWriter();
        var htmlTextWriter = new Stimulsoft.Report.Export.StiHtmlTextWriter(textWriter);
        service.exportTo(report, htmlTextWriter, settings);

        // Return result HTML string
        var resultHtml = textWriter.getStringBuilder().toString();
        callback(/* error */null, resultHtml);
    });
};