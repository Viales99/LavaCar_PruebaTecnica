$(document).ready(function () {

    //Llamada de las funciones con los identificadores únicos.
    iniciarDataTable('DataTableGeneral');

});

//Configuración del idioma utilizada en todos los DataTable
let idioma = {
    "emptyTable": "No hay datos disponibles en la tabla.",
    "info": "Mostrando del _START_ al _END_ de _TOTAL_ registros ",
    "infoEmpty": "Mostrando 0 registros de un total de 0.",
    "infoFiltered": "(filtrados de un total de _MAX_ registros)",
    "infoPostFix": "",
    "lengthMenu": "Mostrar _MENU_ registros",
    "loadingRecords": "Cargando...",
    "processing": "Procesando...",
    "search": "Buscar:",
    "searchPlaceholder": "Dato para buscar",
    "zeroRecords": "No se han encontrado coincidencias.",
    "paginate": {
        "first": "Primera",
        "last": "Última",
        "next": "Siguiente",
        "previous": "Anterior"
    },
    "aria": {
        "sortAscending": "Ordenación ascendente",
        "sortDescending": "Ordenación descendente"
    }
};

//Función que inicializa el DataTable general (Características básicas)
function iniciarDataTable(id) {

    var table = $('#' + id).DataTable({
        "language": idioma,
        "bJQueryUI": false,
        lengthMenu: [[5, 10, 20, 25, 50, -1], [5, 10, 20, 25, 50, "Todos"]],
        iDisplayLength: 5
    });

    return table;
}
