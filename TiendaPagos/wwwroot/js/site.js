// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// ----------------------------
// Funciones VentasUpdateModel
// ----------------------------

 
    function ActualizarDatosVenta(pendientePagar) {
        var valorAbono = parseInt($('#abonarId').val());
    console.log(valorAbono);

    var totalPendiente = pendientePagar;
    var nuevoPendiente = (totalPendiente - valorAbono).toLocaleString();
    $('#pendientePagarId').html("$" + nuevoPendiente);
};

