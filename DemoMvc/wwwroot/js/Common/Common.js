var j = jQuery.noConflict();
//j(document).ready(function () {
//    $('table').hide();
//});

//j(document).ready(function () {
//    j('tbody tr:gt(90)').hide();
//});
function addNewRow(id) {
    var tr = "<tr>" +
        "<th scope='row'>1</th>" +
        "<td><input type='text' name='FirstName[]' placeholder='FirstName'/></td>" +
        "<td><input type='text' name='LastName[]' placeholder='LastName' /></td>" +
        "<td><input type='text' name='HandlerName[]' placeholder='HandlerName' /></td>" +
        "<td><button type='button' class='btn btn-danger deleteRow'>-</button></td>" +
        "</tr >"

    $('tbody').append(tr);
}

//function hideRow(id, table) {
//    $(table).find(id).closest('tr').hide();
//}

function hideRow(id) {
    if (id == 1) {
        alert("First Cannot be Deleted");
    }
    else {
        j(document).on('click', '.hideRow', function (id) {
            id = this;
            j(id).closest('tr').hide();
        });
    }
}