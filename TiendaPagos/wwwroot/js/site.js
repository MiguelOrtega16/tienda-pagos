// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// ----------------------------
// Funciones VentasUpdateModel
// ----------------------------


function ActualizarDatosVenta(pendientePagar) {
    var valorAbono = parseInt($('#abonarId').val());
    // console.log(valorAbono);

    var totalPendiente = pendientePagar;
    var nuevoPendiente = (totalPendiente - valorAbono).toLocaleString();
    $('#pendientePagarId').html("$" + nuevoPendiente);
};

function modificarCantidadProductos(tipoMod, cantidadProductoObjeto, precioProducto) {
    var cantidadProducto = parseInt($(cantidadProductoObjeto).val());
    switch (tipoMod) {
        case "sumarProdId":
            var totalCantidad = cantidadProducto + 1;
            break;
        case "restarProdId":
            var totalCantidad = cantidadProducto - 1;
            break;
        case "cantidadProductoId":
            totalCantidad = cantidadProducto;
        default:
            console.log("Error al enviar info: " & tipoMod);
    };

    if (totalCantidad < 1) {
        totalCantidad = 1;
    };
    // console.log(totalCantidad);
    $(cantidadProductoObjeto).val(totalCantidad);
    $('#totalAPagarId').val(precioProducto * totalCantidad);
};

function limiteAbono(totalAPagarObjeto, totalAbonoObjeto) {

    var totalVenta = parseInt($(totalAPagarObjeto).val());

    $(totalAbonoObjeto).attr("max", totalVenta);

};


function usuarioExiste(cedulaCliente) {

    var send = { cedulaId: cedulaCliente };
    $.ajax({
        type: "POST",
        url: "/Catalogo/GetDatosCliente",
        data: send,
        success: function (response) {
            if (response != null) {
                $('#nombreId').val(response.primerNombre);
                $('#apellidoId').val(response.segundoNombre);
                $('#direccionId').val(response.direccion);
                $('#celularId').val(response.celular);
            } else {
                $('#nombreId').val("");
                $('#apellidoId').val("");
                $('#direccionId').val("");
                $('#celularId').val("");
            }
            ;
        },
        failure: function (response) {
            alert(response);
        }
    });
};


