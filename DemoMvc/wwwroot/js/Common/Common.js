var j = jQuery.noConflict();
j(document).ready(function () {
    $('table').hide();
});
//j('thead').on('click', '.addRow', function () {
//    var tr = "<tr>" +
//        "<th scope='row'>1</th>" +
//        "<td><input type='text' name='FirstName[]' placeholder='FirstName'/></td>" +
//        "<td><input type='text' name='LastName[]' placeholder='LastName' /></td>" +
//        "<td><input type='text' name='HandlerName[]' placeholder='HandlerName' /></td>" +
//        "<td><button type='button' class='btn btn-danger deleteRow'>-</button></td>" +
//        "</tr >"

//    j('tbody').append(tr);
//});

//j('tbody').on('click', '.deleteRow', function () {
//    j(this).parent().parent().remove();
//});