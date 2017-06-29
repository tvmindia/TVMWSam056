var DataTables = {};
var EmptyGuid = "00000000-0000-0000-0000-000000000000";
//---------------------------------------Docuement Ready--------------------------------------------------//
$(document).ready(function () {
    try {
        //var UserViewModel = new Object();
        //DataTables.ObjectTable = $('#tblAppObjects').DataTable(
        // {
        //     dom: '<"pull-right"f>rt<"bottom"ip><"clear">',
        //     order: [],
        //     searching: true,
        //     paging: true,
        //     data: null,
        //     columns: [
        //       { "data": "ID" },
        //       { "data": "ObjectName" },
        //       { "data": "AppName" },
        //       { "data": "commonDetails.CreatedDatestr", "defaultContent": "<i>-</i>" },
        //       { "data": null, "orderable": false, "defaultContent": '<a href="#" onclick="EditObject(this)"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a><span> | </span><a href="#" onclick="DeleteObject(this)"><i class="fa fa-trash-o" aria-hidden="true"></i></a>' }
        //     ],
        //     columnDefs: [{ "targets": [0], "visible": false, "searchable": false }
        //     ]
        // });
        //$('#hdnID').val(EmptyGuid);
        //$('#hdnAppID').val(EmptyGuid);
    }
    catch (e) {
        notyAlert('error', e.message);

    }
});