var DataTables = {};
//---------------------------------------Docuement Ready--------------------------------------------------//
$(document).ready(function ()
{
    try {
        var UserViewModel = new Object();
        DataTables.userTable = $('#tblUsersList').DataTable(
         {
             dom: '<"pull-left"f>rt<"bottom"ip><"clear">',
             order: [],
             searching: true,
             paging: true,
             data: GetAllUsers(UserViewModel),
             columns: [
               { "data": "ID" },
               { "data": "UserName" },
               { "data": "LoginName" },
               { "data": "Email", "defaultContent": "<i>-</i>" },
               { "data": "RolesCSV", "defaultContent": "<i>-</i>" },//simple,configurable
               { "data": "Active", "defaultContent": "<i>-</i>" },
               { "data": "CreatedDate", "defaultContent": "<i>-</i>" }, 
               { "data": null, "orderable": false, "defaultContent": '<a href="#" onclick="Edit(this)"<i class="glyphicon glyphicon-share-alt" aria-hidden="true"></i></a>' }
             ]              
         });
    }
    catch (e) {
        notyAlert('error', e.message);

    }    
});

function GetAllUsers() {

    try {
        debugger;
        var data = {};
        var ds = {};
        ds = GetDataFromServer("User/GetAllUsers/", data);
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