
$(document).ready(function () {

    //################################################# VARIABLES GLOBALES ################################################

    let Accion, url, fila, DataTableServicio, DataTableModalVehiculo;

    //################################################# DATATABLE SERVICIOS ################################################

    //Se incializa el Datable que obtiene la lista de servicios por Ajax
    DataTableServicio = $("#DataTableServicios").DataTable({
        "language": idioma,
        "bJQueryUI": false,
        lengthMenu: [[5, 10, 20, 25, -1], [5, 10, 20, 25, "Todos"]],
        iDisplayLength: 5,
        ajax: {
            url: "/Servicio/ListarServicios",
            type: "GET",
            dataType: "json",
            dataSrc: "listaServicios",
            error: function (xhr, error, code) {
                ErrorDeConexion();
            }
        },
        columns: [
            { data: "descripcion" },
            { data: "monto" },
            {
                render: function (dato, tipo, servicio) {
                    return ` <a href="#formServicio" class="btnEditarServicio btn btn-secondary btn-circle btn-sm m-1" data-toggle="modal" data-id="` + servicio.idServicio + `">
                                    <span class="fas fa-edit"></span>
                                 </a>
                                 <a class="btnEliminarServicio btn btn-danger btn-circle btn-sm m-1" style="color: white;" data-id="` + servicio.idServicio + `">
                                    <span class="far fa-trash-alt"></span>
                                 </a>
                                 <a href="#modalVehiculos" class="btnVerVehiculos btn btn-info btn-circle btn-sm m-1" title="Ver vehículos" data-toggle="modal" data-id="` + servicio.idServicio + `">
                                    <span class="fas fa-list"></span>
                                </a>`
                },
                orderable: false,
                searchable: false
            }
        ],
        deferRender: true,
        responsive: true,
        autoWidth: false,
        processing: true
    });


    //Se incializa el Datable que obtiene la lista de vehiculos asignados a un servicio
    DataTableModalVehiculo = $("#DataTableModalVehiculos").DataTable({
        "language": idioma,
        "bJQueryUI": false,
        lengthMenu: [[5, 10], [5, 10]],
        iDisplayLength: 5,
        ajax: {
            url: "/Vehiculo/ListarVehiculosPorServicio",
            type: "GET",
            dataType: "json",
            dataSrc: "listaVehiculos",
            error: function (xhr, error, code) {
                ErrorDeConexion();
            }
        },
        columns: [
            { data: "placa" },
            { data: "dueno" },
            { data: "marca" }
        ],
        deferRender: true,
        responsive: true,
        autoWidth: false,
        processing: true
    });


    //################################################# BOTÓN ACEPTAR MODAL ################################################

    //Evento de acción al presionar el botón de aceptar, dependiendo de la acción (Ingresar o editar)
    // se asigna la url correspondiente y se llama a la función de validar el formulario y realizar la solicitud
    $("#btnAceptar").click(function () {

        const formServicio = "formularioServicio";
        switch (Accion) {
            case "Agregar":
                Validar(formServicio);
                url = "/Servicio/AgregarServicio/";
                Solicitud(url, "agregado");
                break;
            case "Editar":
                Validar(formServicio);
                url = "/Servicio/EditarServicio/";
                Solicitud(url, "editado");
                break;
            default:
                console.log('No existe caso');
        }

    });

    //Muestra el mensaje de confirmación y en el caso de confirmar llama a la función de IngresarYEditarServicioPOST
    function Solicitud(url, accion) {

        if (EsFormularioValido("formularioServicio")) {
            swal({
                title: "¿Está seguro?",
                text: "El servicio será " + accion,
                icon: "warning",
                closeOnClickOutside: false,
                closeOnEsc: false,
                buttons: {
                    cancel: {
                        text: "Cancelar",
                        visible: true,
                    },
                    confirm: {
                        text: "Confirmar",
                    },
                },
                dangerMode: true,
            }).then((willDelete) => {
                if (willDelete) {
                    IngresarYEditarServicioPOST(url);
                } else {
                    MostrarMensaje("Acción cancelada", "El servicio no fue " + accion, "warning");
                }
            });
        } else {
            Validar("formularioServicio");
        }
    }

    //Ingresa o Edita el servicio y luego llama a la función SolicitudPOST
    function IngresarYEditarServicioPOST(url) {

        if ($("#formularioServicio").valid()) {

            let token = $('input[name="__RequestVerificationToken"]').val();

            let servicio = {
                IdServicio: $('#IdServicio').val(),
                Descripcion: $('#Descripcion').val(),
                Monto: $('#Monto').val(),
            };

            let data = {
                __RequestVerificationToken: token, servicio
            };

            SolicitudPOST(url, data);

        }

    }

    //Realiza la solicitud Post (de Agregar, Editar o Eliminar), muestra el mensaje y esconde la ventana modal.
    function SolicitudPOST(url, data) {

        Cargando();
        $.post(url, data).done(function (data) {
            
            if (data.ok) {

                RecargarTablaServicio();

                $('#formServicio').modal('hide');

                MostrarMensaje("Atención", data.mensaje, "success");

            } else {

                MostrarMensajeDeConfirmarcion("Atención", data.mensaje, "warning");
            }
        }).fail(function () {
            ErrorDeConexion();
        });

    }

    //################################################# BOTONES DE ACCIONES ################################################

    //Evento de acción al presionar el botón de agregar servicio, restablece los campos del formulario
    $(document).on("click", "#btnAgregarServicio", function () {

        Accion = "Agregar"; //AccionIngresar
        $(".text-danger").hide(); //Oculta los mensajes de error (Por si se cerró la ventana estando activados)
        $("#formularioServicio").trigger("reset"); //Limpiar campos de texto
        $('#IdServicio').val(0) //Ponerle cero al Id (al Html.HiddenFor)(Porque queda guardado el id que se editó antes)
        $("#FormTitulo").text("Agregar servicio");	//Cambiar el título del formulario

    });

    //Evento de acción al presionar el botón de editar clasificación, obtiene los datos de la fila
    // correspondiente y las asigna al formulario.
    $(document).on("click", ".btnEditarServicio", function () {

        Accion = "Editar"; //AccionEditar 
        $(".text-danger").hide();
        $("#formularioServicio").trigger("reset");
        $("#FormTitulo").text("Editar servicio");

        fila = $(this).closest("tr"); //Obtiene la fila seleccionada

        let servicio = {
            IdServicio: $(this).data("id"),
            Descripcion: fila.find('td:eq(0)').text(),
            Monto: fila.find('td:eq(1)').text(),
        };

        $('#IdServicio').val(servicio.IdServicio);
        $('#Descripcion').val(servicio.Descripcion);
        $('#Monto').val(servicio.Monto);

    });

    //Evento de acción al presionar el botón de eliminar clasificación, muestra el mensaje de confirmación y
    // en caso de aceptar llama a la función VerificarExistenciaDeEvento
    $(document).on("click", ".btnEliminarServicio", function () {

        fila = $(this).closest("tr"); //Obtiene la fila seleccionada
        let descripcion = fila.find('td:eq(0)').text();

        swal({
            title: "¿Desea eliminar el servicio " + descripcion + "?",
            icon: "warning",
            closeOnClickOutside: false,
            closeOnEsc: false,
            buttons: {
                cancel: {
                    text: "Cancelar",
                    visible: true,
                },
                confirm: {
                    text: "Confirmar",
                },
            },
        }).then((willDelete) => {
            if (!willDelete) {
                MostrarMensaje("Acción cancelada", "El servicio no fue eliminado", "warning");
                swal.close();
            } else {
                swal({
                    title: "¿Está seguro?",
                    content: {
                        element: 'p',
                        attributes: {
                            innerHTML: "<h4>El servicio " + "<strong class='text-danger'>" + descripcion + "</strong>" + " será eliminado permanentemente.</h4>",
                        },
                    },
                    icon: "warning",
                    closeOnClickOutside: false,
                    closeOnEsc: false,
                    buttons: {
                        cancel: {
                            text: "Cancelar",
                            visible: true,
                        },
                        confirm: {
                            text: "Confirmar",
                        },
                    },
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {

                            let token = $('input[name="__RequestVerificationToken"]').val();
                            let idServicio = $(this).data("id");
                            url = "/Servicio/EliminarServicio/";

                            let data = {
                                __RequestVerificationToken: token,
                                id: idServicio
                            };

                            SolicitudPOST(url, data);

                        } else {
                            MostrarMensaje("Acción cancelada", "El servicio no fue eliminado", "warning");
                        }
                    });
            }
        });

    });

    //Evento de acción al presionar el botón de ver familias, recarga las familias y 
    // abre la modal con la lista de familias
    $(document).on("click", ".btnVerVehiculos", function () {

        const url = "/Vehiculo/ListarVehiculosPorServicio/" + $(this).data("id");

        //Actualiza los servicios del vehiculo seleccionado y luego muestra la lista
        DataTableModalVehiculo.ajax.url(url).load(() => $('#modalVehiculos').modal('show'));

        //Se obtiene la placa del vehiculo seleccionado para el título
        fila = $(this).closest("tr"); //Obtiene la fila seleccionada
        let descripcion = fila.find('td:eq(0)').text();
        $("#VehiculoTitulo").html(descripcion);

    });

     //#################################################  OTROS #################################################################

    //Actualiza la lista de las clasificaciones
    function RecargarTablaServicio() {

        DataTableServicio.ajax.reload();
    }

 

});