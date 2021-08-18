

//function btnClose_Click(e) {
//    //var addwindow = $("#btnClose").closest(".k-window-content").data("kendoWindow");
//    var addwindow = window.parent.$("#winAddEmpDetails").data("kendoWindow");
//    if (addwindow !== null) {
//        $("#mainAddEmployeeContainer").empty();
//        addwindow.close();
//        //window.parent.$("#otherCusLogInWindow").data("kendoWindow").close()
//        //e.preventDefault();
//        $("#gridEmployees").data("kendoGrid").dataSource.read();
//    }    
//}

//function window_open() {
//    alert("open add");
//}

function window_close(e) {
    $("#winAddEmpDetails").data("kendoWindow").close();
    $("#gridEmployees").data("kendoGrid").dataSource.read();
}

