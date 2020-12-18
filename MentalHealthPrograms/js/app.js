$(document).ready(function () {
    //$('#dataTable').DataTable();
    $('#dataTable').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": PostUrl,
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [
            {
                "targets": [7],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [3],
                "visible": true,
                "searchable": false,
                "orderable": true
            },
            {
                "targets": [2],
                "visible": true,
                "searchable": false,
                "orderable": true
            },
            {
                "targets": [4],
                "visible": true,
                "searchable": false,
                "orderable": true
            },
            {
                "targets": [5],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [6],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [1],
                "visible": false,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [0],
                "visible": true,
                "searchable": true,
                "orderable": true
            }
        ],
        "columns": [
            { "data": "Name_1", "title": "Name", "name": "Name", "autoWidth": true },
            { "data": "Name_2", "title": "Name 2", "name": "Name 2", "autoWidth": true },
            { "data": "Street_1", "title": "Street 1", "name": "Street 1", "autoWidth": true },
            { "data": "Street_2", "title": "Street 2", "name": "Street 2", "autoWidth": true },
            { "data": "City", "title": "City", "name": "City", "autoWidth": true },
            { "data": "Zip", "title": "Zip", "name": "Zip", "autoWidth": true },
            { "data": "Phone", "title": "Phone", "name": "Phone", "autoWidth": true },
            { "data": "Website", "title": "Website", "name": "Website", "autoWidth": true }
        ]
    });
});