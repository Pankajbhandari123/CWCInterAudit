/// <reference path="../Report/DashboardKpiReport.aspx" />
/// <reference path="../Report/DashboardKpiReport.aspx" />
$(document).ready(function () {
    $('#ddlChartType').get(0).selectedIndex = 0;
    $('#ddlDivision').get(0).selectedIndex = 0;
    $('#ddlKpiRange').get(0).selectedIndex = 0;
    var ChartType = $('#ddlChartType option:selected').text();
    var divisionRecno = $('#ddlDivision option:selected').val();
    var kpivalue = $('#ddlKpiRange option:selected').val();

    getStatusForKPI(ChartType, divisionRecno, kpivalue);

});

function ajaxReq(handler, reqType, data, callbackFun, asyc) {
    if (asyc) asyc = true; else asyc = false;
    $.ajax({
        url: handler + "?request=" + reqType,
        type: "post",
        async: asyc,
        data: data,
        error: function () {
            alert("Oops! Something went wrong.");
        }
    }).done(callbackFun);
}

$(document).on('change', '#ddlKpiRange', function (e) {
    e.preventDefault();
    var ChartType = $('#ddlChartType option:selected').text();
    var divisionRecno = $('#ddlDivision option:selected').val();
    var kpivalue = $('#ddlKpiRange option:selected').val();
    
    getStatusForKPI(ChartType,divisionRecno, kpivalue);

});

$(document).on('change', '#ddlChartType', function (e) {
    e.preventDefault();
    var ChartType = $('#ddlChartType option:selected').text();
    var divisionRecno = $('#ddlDivision option:selected').val();
    var kpivalue = $('#ddlKpiRange option:selected').val();

    getStatusForKPI(ChartType, divisionRecno, kpivalue);

});

$(document).on('change', '#ddlDivision', function (e) {
    e.preventDefault();
    var ChartType = $('#ddlChartType option:selected').text();
    var divisionRecno = $('#ddlDivision option:selected').val();
    var kpivalue = $('#ddlKpiRange option:selected').val();

    getStatusForKPI(ChartType, divisionRecno, kpivalue);

});

function getStatusForKPI(ChartType, divisionRecno, kpivalue) {
    ajaxReq('DefaultHandler.ashx',
                       'getStatusForKpi',
                       {
                           "kpivalue": kpivalue,
                           "divisionRecno": divisionRecno
                       },
                       function (resp) {
                           showStatusForKpi(resp, ChartType)
                       }, true);
}


function showStatusForKpi(resp, ChartType) {
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var divisionRecno = $('#ddlDivision option:selected').val();
    // var ChartType = "spline";
    console.log(kpivalue);

    if (resp.status === false) {
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];

        var count = resp.data.length;

        for (i = 0; i < resp.data.length; i++) {

            ActualArray.push({ label: "", y: "" });

            PlanArray.push({ label: "", y: "" });

        }
        console.log(PlanArray);
        console.log(ActualArray);


        var chart = new CanvasJS.Chart("chartContainer", {


            title: {
                fontFamily: "Times New Roman",
                text: "Planned Vs. Actual",
                fontSize: 20
            },
            subtitles: [{
                //   text: "DateWise Production"
            }],

        });
        chart.render();
    }

    else if (resp.status === true) {
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];
        var y2Interval;
        var splitstring = [];
        var splitedValue;
        var count = resp.data.length;

        for (i = 0; i < resp.data.length; i++) {
            splitstring = (resp.data[i].INITIATIVE).split('.');
            console.log(splitstring);
            splitedValue = splitstring[0];

            if (resp.data[i].name == "0") {
                PlanArray.push({ a: (resp.data[i].PLANNED_RECNO), b: (resp.data[i].INITIATIVE), recno: (resp.data[i].INITIATIVE_RECNO), name: "Planned", label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units", indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside" });
                y2Interval = parseInt(resp.data[0].PLANNED_VALUE) * 1.5;
            }
            else if (resp.data[i].name == "1") {
                ActualArray.push({ a: (resp.data[i].PLANNED_RECNO), b: (resp.data[i].INITIATIVE), recno: (resp.data[i].INITIATIVE_RECNO), name: "Actual", label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units", indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside" });
            }
            //if (ActualArray.length == 0) {
            //    ActualArray.push({ name: "", x: "", y: "" });
            //}
            //if (PlanArray.length == 0) {
            //    PlanArray.push({ name: "", x: "", y: "" });
            //}
        }
        console.log(PlanArray);
        console.log(ActualArray);

        $("chartContainer").text("test")
        var chart = new CanvasJS.Chart("chartContainer", {
            exportEnabled: true,
            animationEnabled: true,
            title: {
                fontFamily: "Times New Roman",
                text: "Planned Vs. Actual",
                fontSize: 20
            },
            //subtitles: [{
            //    text: "subtitle"
            //}],
            axisX: {
                title: "Initiative",
                labelMaxWidth: 150,
                labelWrap: true
            },
            axisY: {
                //  logarithmic: true,
                title: "Parameter",
                titleFontColor: "#4F81BC",
                lineColor: "#4F81BC",
                labelFontColor: "#4F81BC",
                tickColor: "#4F81BC"
            },
            //axisY2: {
            //    title: "Actual Parameter",
            //    titleFontColor: "#C0504E",
            //    lineColor: "#C0504E",
            //    labelFontColor: "#C0504E",
            //    tickColor: "#C0504E",
            //    interval: y2Interval
            //},
            toolTip: {
                shared: true,
                //contentFormatter: function (e) {
                //    var content = " ";
                //    for (var i = 0; i < e.entries.length; i++) {
                //        content += e.entries[i].dataSeries.name + " " + "<strong>" + e.entries[i].dataPoint.y + "</strong>";
                //        content += "<br/>";
                       
                //    }
                //    return content;
                //}
            },
            legend: {
                cursor: "pointer",
                itemclick: toggleDataSeries
            },
            data: [{
                //color: "#35933B",
                type: ChartType,
           //     toolTipContent: "Initiative : {b} ",
                name: "Planned",
                showInLegend: true,
                yValueFormatString: "#,##0.# Units",
                click: onClick,
                dataPoints: PlanArray


            },
            {
               // color: "#F04618",
                type: ChartType,
                name: "Actual",
                showInLegend: true,
                yValueFormatString: "#,##0.# Units",
                click: onClick,
                dataPoints: ActualArray
            }]
        });
        chart.render();

        function onClick(e) {
            //var url = "../ManagementDashboard/Report/DashboardKpiReportChanged.aspx?Mode=" + e.dataPoint.name + "&Status=" + e.dataPoint.a + "&kpi="
            var url = "../Report/DashboardKpiReportChanged.aspx?Mode=" + e.dataPoint.name + "&Status=" + e.dataPoint.a + "&kpi="
                + kpivalue + "&division=" + divisionRecno + "&InitRec=" + e.dataPoint.recno;
            window.open(url, '_blank');
        }
        function toggleDataSeries(e) {
            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                e.dataSeries.visible = false;
            } else {
                e.dataSeries.visible = true;
            }
            e.chart.render();
        }
        setTimeout(function () {
            var abc = document.getElementsByClassName("canvasjs-chart-canvas");
            console.log(abc);
            var abcx = abc[0].getContext('2d');
            abcx.fillStyle = 'white';
            abcx.fillRect(0, 300, 60, 250);
        }, 1500);
    }
}



//function showStatusForKpi(resp, ChartType) {
//    var kpivalue = $('#ddlKpiRange option:selected').val();
//    var divisionRecno = $('#ddlDivision option:selected').val();
//    // var ChartType = "spline";
//    console.log(kpivalue);

//    if (resp.status === false) {
//        console.log(resp.data);
//        var i;
//        var PlanArray = [];
//        var ActualArray = [];

//        var count = resp.data.length;

//        for (i = 0; i < resp.data.length; i++) {

//            ActualArray.push({ label: "", y: "" });

//            PlanArray.push({ label: "", y: "" });

//        }
//        console.log(PlanArray);
//        console.log(ActualArray);


//        var chart = new CanvasJS.Chart("chartContainer", {


//            title: {
//                fontFamily: "Times New Roman",
//                text: "Planned Vs. Actual",
//                fontSize: 20
//            },
//            subtitles: [{
//                //   text: "DateWise Production"
//            }],

//        });
//        chart.render();
//    }

//    else if (resp.status === true) {
//        console.log(resp.data);
//        var i;
//        var PlanArray = [];
//        var ActualArray = [];
//        var y2Interval;
//        var splitstring = [];
//        var splitedValue;
//        var count = resp.data.length;

//        for (i = 0; i < resp.data.length; i++) {
//            splitstring = (resp.data[i].INITIATIVE).split('.');
//            console.log(splitstring);
//            splitedValue = splitstring[0];

//            if (resp.data[i].name == "0") {
//                PlanArray.push({ a: (resp.data[i].PLANNED_RECNO), name: "Planned", label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units", indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside" });
//                y2Interval = parseInt(resp.data[0].PLANNED_VALUE) * 1.5;
//            }
//            else if (resp.data[i].name == "1") {
//                ActualArray.push({ a: (resp.data[i].PLANNED_RECNO), name: "Actual", label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units", indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside" });
//            }
//            //if (ActualArray.length == 0) {
//            //    ActualArray.push({ name: "", x: "", y: "" });
//            //}
//            //if (PlanArray.length == 0) {
//            //    PlanArray.push({ name: "", x: "", y: "" });
//            //}
//        }
//        console.log(PlanArray);
//        console.log(ActualArray);

//        $("chartContainer").text("test")
//        var chart = new CanvasJS.Chart("chartContainer", {
//            exportEnabled: true,
//            animationEnabled: true,
//            title: {
//                fontFamily: "Times New Roman",
//                text: "Planned Vs. Actual",
//                fontSize: 20
//            },
//            //subtitles: [{
//            //    text: "subtitle"
//            //}],
//            axisX: {
//                title: "Initiative",
//                labelMaxWidth: 150,
//                labelWrap: true
//            },
//            axisY: {
//              //  logarithmic: true,
//                title: "Planned Parameter",
//                titleFontColor: "#4F81BC",
//                lineColor: "#4F81BC",
//                labelFontColor: "#4F81BC",
//                tickColor: "#4F81BC"
//            },
//            axisY2: {
//                title: "Actual Parameter",
//                titleFontColor: "#C0504E",
//                lineColor: "#C0504E",
//                labelFontColor: "#C0504E",
//                tickColor: "#C0504E",
//                interval: y2Interval
//            },
//            toolTip: {
//                shared: true
//            },
//            legend: {
//                cursor: "pointer",
//                itemclick: toggleDataSeries
//            },
//            data: [{
//                type: ChartType,
//                name: "Planned",
//                showInLegend: true,
//                yValueFormatString: "#,##0.# Units",
//                click: onClick,
//                dataPoints: PlanArray


//            },
//            {
//                type: ChartType,
//                name: "Actual",
//                axisYType: "secondary",
//                showInLegend: true,
//                yValueFormatString: "#,##0.# Units",
//                click: onClick,
//                dataPoints: ActualArray
//            }]
//        });
//        chart.render();

//        function onClick(e) {
//            var url = "../ManagementDashboard/Report/DashboardKpiReport.aspx?Mode=" + e.dataPoint.name + "&Status=" + e.dataPoint.a;
//            window.open(url, '_blank');
//        }
//        function toggleDataSeries(e) {
//            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
//                e.dataSeries.visible = false;
//            } else {
//                e.dataSeries.visible = true;
//            }
//            e.chart.render();
//        }
//        setTimeout(function () {
//            var abc = document.getElementsByClassName("canvasjs-chart-canvas");
//            console.log(abc);
//            var abcx = abc[0].getContext('2d');
//            abcx.fillStyle = 'white';
//            abcx.fillRect(0, 300, 60, 250);
//        }, 1500);
//    }
//}



