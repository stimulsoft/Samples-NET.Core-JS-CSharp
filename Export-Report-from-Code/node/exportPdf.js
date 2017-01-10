module.exports = function (callback, reportPath) {
    // Prepare engine module
    var Stimulsoft = require('stimulsoft-reports-js');
    Stimulsoft.Base.StiFontCollection.addOpentypeFontFile("node/Roboto-Black.ttf");

    // Load and render the report template
    var report = new Stimulsoft.Report.StiReport();
    report.loadFile(reportPath);
    report.render();

    // Export report to PDF bytes
    var settings = new Stimulsoft.Report.Export.StiPdfExportSettings();
    var service = new Stimulsoft.Report.Export.StiPdfExportService();
    var stream = new Stimulsoft.System.IO.MemoryStream();
    service.exportTo(report, stream, settings);
    var data = stream.toArray();

    callback(/* error */null, data);
};