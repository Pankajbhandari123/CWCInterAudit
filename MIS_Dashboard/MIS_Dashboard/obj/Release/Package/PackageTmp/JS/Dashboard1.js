var divisionRecno = 0;
$(document).ready(function () {

    //var chart = c3.generate({
    //    bindto: '#chartContainer',
    //    data: {
    //        columns: [
    //            ['data1', 30],
    //            ['data2', 120],
    //        ],
    //        type: 'pie'
    //    }
    //});

    //$('#ddlChartType').get(0).selectedIndex = 0;
    //$('#ddlDivision').get(0).selectedIndex = 0;
    $('#ddlKpiRange').get(0).selectedIndex = 2;
    var ChartType = 'pie'; //$('#ddlChartType option:selected').text();
    // var divisionRecno = $('#ddlDivision option:selected').val();
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var name = "% Completed";
    var index = "0";
    
    getCWCStatus(ChartType, kpivalue);
    divisionWiseDataFunction(name, index, kpivalue, divisionRecno);
    getWeekWiseCWCStatus(ChartType);
   // WeekWisedivisionWiseDataFunction(name, index, kpivalue, divisionRecno);

    //  getStatusForKPI(ChartType, divisionRecno, kpivalue);

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

$(document).on('click', '#backButton', function (e) {

    $("#chartsContain").css("display", "block");
    $("#chartsContain2").css("display", "none");
});

$(document).on('change', '#ddlKpiRange', function (e) {
    e.preventDefault();
    
    var ChartType = 'pie';
    var kpivalue = $('#ddlKpiRange option:selected').val();
    getCWCStatus(ChartType, kpivalue);
    var name = "% Completed";
    var index = "0";
    divisionWiseDataFunction(name, index, kpivalue, divisionRecno)
    $("#chartsContain").css("display", "block");
    $("#chartsContain2").css("display", "none");

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

/*OVERALL CWC DASHBOARD Start*/
function getCWCStatus(ChartType, kpivalue) {
    $("#cwcdiv1").text("CWC Consolidated Dashboard").css("font-weight", "Bold");
    ajaxReq('DefaultHandler.ashx',
                       'getStatusCWC',
                       {
                           "kpivalue": kpivalue
                       },
                       function (resp) {
                           showStatusCWC(resp, ChartType)
                       }, true);
}

function showStatusCWC(resp, ChartType) {
    $("#chartContainer").css("class", "col-6")
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var divisionRecno = $('#ddlDivision option:selected').val();
    console.log(kpivalue);
    if (resp.status === false) {
    }

    else if (resp.status === true) {
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];
        var category = [];
        var count = resp.data.length;
        for (i = 0; i < resp.data.length; i++) {
            if (resp.data[i].name == "0") {
                if (PlanArray.length == "0") {
                    PlanArray.push("% Completed");
                }
                PlanArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
            }
            else if (resp.data[i].name == "1") {
                if (ActualArray.length == "0") {
                    ActualArray.push("% Pending");
                }
                ActualArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
            }
        }
        var pl = PlanArray.join(',');
        var act = ActualArray.join(',');
        console.log(PlanArray);
        console.log(ActualArray);
        console.log(pl);
        console.log(act);

        var chart = c3.generate({
            bindto: '#chartContainer',
            data: {
                columns: [
                    PlanArray,
                    ActualArray
                ],
                onclick: function () {
                    divisionWiseDataFunction(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, divisionRecno);
                },
                type: 'pie',
                labels: true
            },
            legend: {
                position: 'right'
            }
        });
    }
}

/*OVERALL CWC DASHBOARD End*/

/*Division Wise Dashboard Start*/
function divisionWiseDataFunction(name, index, kpivalue, divisionRecno) {
    $("#backButton").css("display", "none");
    $("#divisionDiv1").text("Division Wise Dashboard(" + name+")").css("font-weight", "Bold");
    ajaxReq('DefaultHandler.ashx',
                       'getdivisionWiseData',
                       {
                           "kpivalue": kpivalue,
                           "name": name
                       },
                       function (resp) {
                           showdivisionWiseData(resp)
                       }, true);
}

function showdivisionWiseData(resp) {
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var divisionRecno = $('#ddlDivision option:selected').val();
    console.log(kpivalue);
    if (resp.status === false) {
    }

    else if (resp.status === true) {
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];
        var category = [];
        var divname = "";
        var pl = [];
        var po = [];
        var arr1 = [];
        var arr2 = [];
        var arr3 = [];
        var arr4 = [];
        var arr5 = [];
        var arr6 = [];
        var arr7 = [];

        var count = resp.data.length;
        for (i = 0; i < resp.data.length; i++) {
            divname = (resp.data[i].DIVISION_NAME);
            //po.push(PlanArray.push(new Array(divname, parseFloat(resp.data[i].PLANNED_VALUE))));
            //pl = new Array(PlanArray.join(','));
            if (resp.data[i].DIVISION_NAME == 'MIS Division') {
                arr1.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Technical Division') {
                arr2.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Finance Division') {
                arr3.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Engineering Division') {
                arr4.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Commercial Division') {
                arr5.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Personnel Division') {
                arr6.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Purchase Division') {
                arr7.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
        }

        var count12345 = PlanArray.length;
        console.log(count12345);
        for (var j = 0 ; j < count12345; j++) {
            var po = po.push(PlanArray[j]);

            console.log(po);
        }
        //var CompanyName = $.map(resp.data, function (el) { return el; })
        //console.log(CompanyName);
        console.log(PlanArray);

        console.log(pl);


        var chart = c3.generate({
            bindto: '#chartContainer1',
            data: {
                columns: [
                    arr1,
                    arr2,
                    arr3,
                   arr4,
                    arr5,
                   arr6,
                    arr7
                ],
                onclick: function (d, i) {
                    FirstgetStatusForKPIGetDivision(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, this.internal.config.axis_x_categories[d.x]);
                },
                type: 'pie',
                labels: true
            },

            legend: {
                position: 'right'
            }

        });
    }
}

function FirstgetStatusForKPIGetDivision(name, index, kpivalue, DIVISIONName) {
    $("#backButton").css("display", "block");
    $("#divheading").text(name).css("font-weight", "Bold");
    var ChartType = 'bar';
    ajaxReq('DefaultHandler.ashx',
                       'FirstgetStatusForKPIGetDivision',
                       {
                           "DIVISIONName":name // DIVISIONName
                       },
                       function (resp) {
                           console.log(resp);
                           if (resp.status === true) {
                               for (i = 0; i < resp.data.length; i++) {
                                   divisionRecno = resp.data[i].DIVISION_RECNO;
                               }
                               console.log(divisionRecno);
                               getStatusForKPI(ChartType, divisionRecno, kpivalue);
                           }
                       }, true);
}
/*Division Wise Dashboard End*/

/*Status For KPI On Division Basis Start*/
function getStatusForKPI(ChartType, divisionRecno, kpivalue) {
    //  $("#divcharttype").css("display", "block");

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
    $("#chartsContain").css("display", "none");
    $("#chartsContain2").css("display", "block");
    //   var divisionRecno = $('#ddlDivision option:selected').val();
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
        var category = [];
        var y2Interval;
        var splitstring = [];
        var splitedValue;
        var count = resp.data.length;
        for (i = 0; i < resp.data.length; i++) {
            splitstring = (resp.data[i].INITIATIVE).split('.');
            splitedValue = splitstring[0];
            if (resp.data[i].name == "0") {
                if (PlanArray.length == "0") {
                    PlanArray.push("Planned");
                }
                PlanArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
                //PlanArray.push({
                //    a: (resp.data[i].PLANNED_RECNO), b: (resp.data[i].INITIATIVE), recno: (resp.data[i].INITIATIVE_RECNO), name: "Planned",
                //    label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units",
                //    indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside"
                //});
                //y2Interval = parseInt(resp.data[0].PLANNED_VALUE) * 1.5;
                category.push(resp.data[i].INITIATIVE);
            }
            else if (resp.data[i].name == "1") {
                if (ActualArray.length == "0") {
                    ActualArray.push("Actual");
                }
                ActualArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
                //ActualArray.push({
                //    a: (resp.data[i].PLANNED_RECNO), b: (resp.data[i].INITIATIVE), recno: (resp.data[i].INITIATIVE_RECNO), name: "Actual",
                //    label: splitedValue, y: parseFloat(resp.data[i].PLANNED_VALUE), indexLabel: parseFloat(resp.data[i].PLANNED_VALUE).toString() + " Units",
                //    indexLabelFontColor: "black", indexLabelOrientation: "horizontal", indexLabelPlacement: "inside"
                //});
               // category.push(resp.data[i].INITIATIVE);
            }
        }
        var pl = PlanArray.join(',');
        var act = ActualArray.join(',');
        var chart = c3.generate({
            bindto: '#chartContainer2',
            data: {
                columns: [
                ],
                onclick: function (d, i) {
                    myFunction(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, divisionRecno);
                },
                // onclick: function (d, i) { console.log("onclick", d, i, arguments); },
                //  console.log(this.internal.config.axis_x_categories[d.x]);

                //onclick: function (e) {
                //    console.log(String(arguments[0].name));
                //    console.log(parseInt(arguments[0].index));
                //    console.log(kpivalue);
                //    console.log(divisionRecno);
                //    console.log(e.PLANNED_VALUE);
                //  //  myFunction(console.log(String(arguments[0].name)), console.log(parseInt(arguments[0].index)));
                //},
                type: ChartType,
                labels: true
            },
            axis: {
                x: {
                    type: 'category',
                    categories: $.unique(category),
                    show: true
                },
                y: {
                    show: false
                }
            },
            legend: {
                position: 'right'
            },
            zoom: {
                enabled: true
            }
        });

        var plancount = PlanArray.length;
        var actualcount = ActualArray.length;
        console.log(plancount);
        console.log(actualcount);
        console.log(category);
        if (actualcount == 0) {
            if (ActualArray.length == "0") {
                ActualArray.push("Actual");
            }
            ActualArray.push(parseFloat(0));

        }
       

        if (actualcount == 0) {
            chart.load({
                columns: [
                    PlanArray
                ]
            });
        }
        else {
            chart.load({
                columns: [
                    PlanArray,
                    ActualArray
                ]
            });
        }
        // setTimeout(function () {

        // }, 1000);

        console.log(PlanArray);
        console.log(ActualArray);
        console.log(pl);
        console.log(act);
    }
}

function myFunction(name, index, kpivalue, divisionRecno) {
    var url = "../MyDashboard/Report/DashboardKpiReportChanged.aspx?Mode=" + name + "&Status=" + index + "&kpi="
                + kpivalue + "&division=" + divisionRecno;
    window.open(url, '_blank');
}



/*Status For KPI On Division Basis End*/


/*Week Wise Dashboard Start*/

/*OVERALL Week CWC DASHBOARD Start*/
function getWeekWiseCWCStatus(ChartType) {
    
    ajaxReq('DefaultHandler.ashx',
                       'getWeekWiseCWCStatus',
                       {
                           //"kpivalue": kpivalue
                       },
                       function (resp) {
                           showWeekWiseStatusCWC(resp, ChartType)
                       }, true);
}

function showWeekWiseStatusCWC(resp, ChartType) {
    $("#weekChartContainer").css("class", "col-6")
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var divisionRecno = $('#ddlDivision option:selected').val();
    console.log(kpivalue);
    if (resp.status === false) {
    }

    else if (resp.status === true) {
        $("#weekCWC").text("Weekwise CWC Consolidated Dashboard").css("font-weight", "Bold");
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];
        var category = [];
        var progressdate;
        var p = 1;
        var count = resp.data.length;

        for (i = 0; i < resp.data.length; i++) {
            if (resp.data[i].name == "0" && resp.data[i].PLANNED_VALUE == null) {
                $("#divMsg").css("display", "block");
                $("#divMsg").text("No Last Week Update Found").css("font-weight", "Bold");
                $("#weekCWC").text("").css("font-weight", "Bold");
            }
        }
        for (i = 0; i < resp.data.length; i++) {
            if (resp.data[i].name == "0") {
                if (PlanArray.length == "0") {
                    PlanArray.push("% Completed");
                }
                PlanArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
            }
            else if (resp.data[i].name == "1") {
                if (ActualArray.length == "0") {
                    ActualArray.push("% Pending");
                }
                ActualArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
                //if (p == 1) {
                //    PlanArray.push((resp.data[i].PROGRESS_DATE).slice(0,10), parseFloat(resp.data[i].PLANNED_VALUE));
                //}
                //else if (p == 2){
                //    ActualArray.push((resp.data[i].PROGRESS_DATE).slice(0, 10), parseFloat(resp.data[i].PLANNED_VALUE));
                //}

                //p = p + 1;
            }
        }
        var pl = PlanArray.join(',');
        var act = ActualArray.join(',');
        console.log(PlanArray);
        console.log(ActualArray);
        console.log(pl);
        console.log(act);

        var chart = c3.generate({
            bindto: '#weekChartContainer',
            data: {
                columns: [
                    PlanArray,
                    ActualArray
                ],
                onclick: function () {
                    WeekWisedivisionWiseDataFunction(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, divisionRecno);
                },
                type: 'pie',
                labels: true
            },
            legend: {
                position: 'right'
            }
        });
    }
}

/*OVERALL Week CWC DASHBOARD End*/

/*Division Week Wise Dashboard Start*/
function WeekWisedivisionWiseDataFunction(name, index, kpivalue, divisionRecno) {
  //  $("#backButton").css("display", "none");
    $("#weekcwcDivision").text("Weekwise Division Dashboard(" + name + ")").css("font-weight", "Bold");
    ajaxReq('DefaultHandler.ashx',
                       'WeekWisedivisionWiseDataFunction',
                       {
                         //  "kpivalue": kpivalue,
                           "name": name
                       },
                       function (resp) {
                           WeekWiseshowdivisionWiseData(resp)
                       }, true);
}

function WeekWiseshowdivisionWiseData(resp) {
    var kpivalue = $('#ddlKpiRange option:selected').val();
    var divisionRecno = $('#ddlDivision option:selected').val();
    console.log(kpivalue);
    if (resp.status === false) {
    }

    else if (resp.status === true) {
        console.log(resp.data);
        var i;
        var PlanArray = [];
        var ActualArray = [];
        var category = [];
        var divname = "";
        var pl = [];
        var po = [];
        var arr1 = [];
        var arr2 = [];
        var arr3 = [];
        var arr4 = [];
        var arr5 = [];
        var arr6 = [];
        var arr7 = [];

        var count = resp.data.length;
        for (i = 0; i < resp.data.length; i++) {
            divname = (resp.data[i].DIVISION_NAME);
            //po.push(PlanArray.push(new Array(divname, parseFloat(resp.data[i].PLANNED_VALUE))));
            //pl = new Array(PlanArray.join(','));
            if (resp.data[i].DIVISION_NAME == 'MIS Division') {
                arr1.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Technical Division') {
                arr2.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Finance Division') {
                arr3.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Engineering Division') {
                arr4.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Commercial Division') {
                arr5.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Personnel Division') {
                arr6.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
            if (resp.data[i].DIVISION_NAME == 'Purchase Division') {
                arr7.push(divname, parseFloat(resp.data[i].PLANNED_VALUE))
            }
        }

        var count12345 = PlanArray.length;
        console.log(count12345);
        for (var j = 0 ; j < count12345; j++) {
            var po = po.push(PlanArray[j]);

            console.log(po);
        }
        //var CompanyName = $.map(resp.data, function (el) { return el; })
        //console.log(CompanyName);
        console.log(PlanArray);

        console.log(pl);


        var chart = c3.generate({
            bindto: '#weekChartContainer1',
            data: {
                columns: [
                    arr1,
                    arr2,
                    arr3,
                   arr4,
                    arr5,
                   arr6,
                    arr7
                ],
                //onclick: function (d, i) {
                //    FirstgetStatusForKPIGetDivision(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, this.internal.config.axis_x_categories[d.x]);
                //},
                type: 'pie',
                labels: true
            },

            legend: {
                position: 'right'
            }

        });
    }
}

/*Week Wise Dashboard End*/

//function showdivisionWiseData(resp) {
//    var kpivalue = $('#ddlKpiRange option:selected').val();
//    var divisionRecno = $('#ddlDivision option:selected').val();
//    console.log(kpivalue);
//    if (resp.status === false) {
//    }

//    else if (resp.status === true) {
//        console.log(resp.data);
//        var i;
//        var PlanArray = [];
//        var ActualArray = [];
//        var category = [];
//        var count = resp.data.length;
//        for (i = 0; i < resp.data.length; i++) {
//            if (resp.data[i].name == "0") {
//                if (PlanArray.length == "0") {
//                    PlanArray.push("Planned");
//                }
//                PlanArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
//                category.push(resp.data[i].DIVISION_NAME);
//            }
//            else if (resp.data[i].name == "1") {
//                if (ActualArray.length == "0") {
//                    ActualArray.push("Actual");
//                }
//                ActualArray.push(parseFloat(resp.data[i].PLANNED_VALUE));
//                category.push(resp.data[i].DIVISION_NAME);
//            }
//        }
//        var pl = PlanArray.join(',');
//        var act = ActualArray.join(',');
//        console.log(PlanArray);
//        console.log(ActualArray);
//        console.log(category);
//        console.log(pl);
//        console.log(act);

//        var chart = c3.generate({
//            bindto: '#chartContainer1',
//            data: {
//                columns: [
//                    PlanArray,
//                    ActualArray
//                ],
//                onclick: function (d, i) {
//                    FirstgetStatusForKPIGetDivision(String(arguments[0].name), parseInt(arguments[0].index), kpivalue, this.internal.config.axis_x_categories[d.x]);
//                },
//                type: 'bar',
//                labels: true
//            },
//            axis: {
//                x: {
//                    type: 'category',
//                    categories: $.unique(category)
//                }
//            },
//            legend: {
//                position: 'right'
//            },
//            bar: {
//                width: {
//                    ratio: 0.2 // this makes bar width 50% of length between ticks
//                }
//                // or
//                //width: 100 // this makes bar width 100px
//            }
//        });
//    }
//}