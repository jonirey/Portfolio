// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function mostrarFormulario(boton) {
    /*  var id = boton.getAttribute('data-id');*/
    var url = boton.getAttribute('data-url');
    $.ajax({
        url: url,
        type: 'GET',
        success: function (resultado) {
            $('#miModal .modal-body').html(resultado);
            $('#miModal').modal({
                backdrop: 'static',
                keyboard: false
            });
            $('#miModal').modal('show');
            $('#miModal').data('url', url);
        }
    });
}

document.querySelector("input[type=number]").addEventListener("wheel", function (e) {
    e.preventDefault();
});

function validateRecaptcha() {
    if (grecaptcha.getResponse() == "") {
        alert("Por favor complete el reCAPTCHA");
        return false;
    }
    return true;
}


