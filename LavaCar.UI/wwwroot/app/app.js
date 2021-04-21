/*######################################################## Funciones y variables globales ###################################################################################################*/
//constante con tiempo de espera en los mensajes con timer
const timer = 2500;

//funcion que muestra error de conexion en un mensaje.
function ErrorDeConexion() {
    swal({
        title: "Error, no se pudo hacer conexión con el servidor",
        text: "Verifique su conexión a la red",
        icon: "error",
        buttons: {
            confirm: {
                text: "Confirmar",
            },
        },
    });
}//fin ErrorDeConexion

//funcion que muestra mensajes al usuario por un tiempo definido
function MostrarMensaje(titulo, mensaje, tipo) {
    swal({
        title: titulo,
        text: mensaje,
        buttons: false,
        icon: tipo,
        closeOnClickOutside: false,
        closeOnEsc: false, 
        timer: timer,
    });
}//fin MostrarMensaje

//funcion que muestra mensajes al usuario este debe confirmar el mensaje
function MostrarMensajeDeConfirmarcion(titulo, mensaje, tipo) {
    swal({
        title: titulo,
        content: {
            element: 'p',
            attributes: {
                innerHTML: "<h4>" + mensaje + "</h4>",
            },
        },
        icon: tipo,
        buttons: {
            confirm: {
                text: "Confirmar",
            },
        },
        closeOnClickOutside: false,
        closeOnEsc: false
    });
}

//funcion que permite hacer solicitud de datos al servidor por medio de ajax
function Get(url) {
    return new Promise(function (resolve, reject) {
        $.get(url).done(function (data) {
            resolve(data)
        }).fail(function (err) {
            reject(err)
        });
    });
}

//funcion que valida los formularios por medio de plugin de jquery y muestra errores si los hay.
function Validar(idForm) {
    $.validator.unobtrusive.parse($("#" + idForm));
    $(".text-danger").show(); //Muestra los mensajes de error en caso de que existan 
}// fin Validar

//funcion que valida que el formulario sea valido es decir no tenga errores para enviar.
function EsFormularioValido(idForm) {
    return $("#" + idForm).valid() && $("#" + idForm).validate().pendingRequest === 0;
}

//funcion que muestra un mensaje con un gif de cargando en las peticiones
function Cargando() {
    swal({
        title: "Cargando...",
        text: "Espere por favor",
        icon: "/Img/cargando.gif",
        button: false,
        closeOnClickOutside: false,
        closeOnEsc: false
    });
}//fin MostrarCargando

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

/*######################################################## Fin Funciones y variables globales ###################################################################################################*/
