// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function() {

    $('.done-checkbox').on('click', function(e) {
        toPay(e.target);
    });

});

function toPay(checkbox) {

    checkbox.disabled = true;    

    var form = checkbox.closest('form');
    form.submit();   
}