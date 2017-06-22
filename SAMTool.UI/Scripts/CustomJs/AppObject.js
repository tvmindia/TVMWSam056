var DataTables = {};
//---------------------------------------Docuement Ready--------------------------------------------------//
$(document).ready(function () {
    try {
        //var UserViewModel = new Object();
        DataTables.ObjectTable = $('#tblAppObjects').DataTable(
         {
             dom: '<"pull-right"f>rt<"bottom"ip><"clear">',
             order: [],
             searching: true,
             paging: true,
             data: null,
             columns: [
               { "data": "ID" },
               { "data": "ObjectName" },
               { "data": "AppName" },
               { "data": "commonDetails.CreatedDatestr", "defaultContent": "<i>-</i>" },
               { "data": null, "orderable": false, "defaultContent": '<a href="#" onclick="Edit(this)"<i class="glyphicon glyphicon-share-alt" aria-hidden="true"></i></a>' }
             ],
             columnDefs: [{ "targets": [0], "visible": false, "searchable": false }
             ]
         });
    }
    catch (e) {
        notyAlert('error', e.message);

    }
});
function ChangeObjectData(this_obj)
{
    debugger;
    $('#hdnAppID').val(this_obj.value);
    DataTables.ObjectTable.clear().rows.add(GetAllAppObjects(this_obj.value)).draw(false);
}
function GetAllAppObjects(id) {
    try {
        debugger;
        var data = { "ID": id };
        var ds = {};
        ds = GetDataFromServer("AppObject/GetAllAppObjects/", data);
        if (ds != '') {
            ds = JSON.parse(ds);
        }
        if (ds.Result == "OK") {
            return ds.Records;
        }
        if (ds.Result == "ERROR") {
            alert(ds.Message);
        }
    }
    catch (e) {
        notyAlert('error', e.message);
    }
}