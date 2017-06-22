var DataTables = {};
var EmptyGuid = "00000000-0000-0000-0000-000000000000";
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
               { "data": null, "orderable": false, "defaultContent": '<a href="#" onclick="EditObject(this)"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a><span> | </span><a href="#" onclick="DeleteObject(this)"><i class="fa fa-trash-o" aria-hidden="true"></i></a>' }
             ],
             columnDefs: [{ "targets": [0], "visible": false, "searchable": false }
             ]
         });
        $('#hdnID').val(EmptyGuid);
        $('#hdnAppID').val(EmptyGuid);
    }
    catch (e) {
        notyAlert('error', e.message);

    }
});
function ChangeObjectData(this_obj)
{
    debugger;
    $('#hdnAppID').val(this_obj.value);
    ChangeButtonPatchView("AppObject", "btnAppObjectPatch", "select");
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
function AddNewObject()
{
    ChangeButtonPatchView("AppObject", "btnAppObjectPatch", "Edit");
    $('#ObjectName').val('');
    $('#hdnID').val(EmptyGuid);
    $('#formEdit').show(500);

}
function EditObject(this_obj)
{
    debugger;
    ChangeButtonPatchView("AppObject", "btnAppObjectPatch", "Edit");
    $('#formEdit').show(500);
    var rowData = DataTables.ObjectTable.row($(this_obj).parents('tr')).data();
    $('#ObjectName').val(rowData.ObjectName);
    $('#hdnID').val(rowData.ID);
}
function SaveSuccess(data, status, xhr)
{
    debugger;
    var i = JSON.parse(data)
    switch (i.Result) {
        case "OK":
            notyAlert('success', i.Message);
            $('#hdnID').val(i.Records.ID);
            DataTables.ObjectTable.clear().rows.add(GetAllAppObjects( $('#hdnAppID').val())).draw(false);
            break;
        case "Error":
            notyAlert('error', i.Message);
            break;
        case "ERROR":
            notyAlert('error', i.Message);
            break;
        default:
            break;
    }
}
function DeleteObject(this_obj)
{
    var rowData = DataTables.ObjectTable.row($(this_obj).parents('tr')).data();

}