module.exports = function (callback, reportPath) {
    // Prepare engine module
    var Stimulsoft = require('stimulsoft-reports-js');
    Stimulsoft.Base.StiFontCollection.addOpentypeFontFile("node/Roboto-Black.ttf");

    // Load and render the report template
    var report = new Stimulsoft.Report.StiReport();
    report.loadFile(reportPath);
    report.renderAsync(function () {
        // Return JSON report document
        var jsonDocument = report.saveDocumentToJsonString();
        callback(/* error */null, jsonDocument);
    });
};