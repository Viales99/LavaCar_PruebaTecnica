
$(document).ready(function () {

    //################################################# VARIABLES GLOBALES ################################################

    let Accion, url, fila, DataTableVehiculo;

    //################################################# DATATABLE VEHICULOS ################################################

    //Se incializa el Datable que obtiene la lista de vehiculos por Ajax
    DataTableVehiculo = $("#DataTableVehiculos").DataTable({
        "language": idioma,
        "bJQueryUI": false,
        lengthMenu: [[5, 10, 20, 25], [5, 10, 20, 25]],
        iDisplayLength: 5,
        ajax: {
            url: "/Vehiculo/ListarVehiculos",
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
            { data: "marca" },
            {
                render: function (dato, tipo, vehiculo) {
                    return ` <a href="#formVehiculo" class="btnEditarVehiculo btn btn-secondary btn-circle btn-sm m-1" data-toggle="modal" data-id="` + vehiculo.idVehiculo + `">
                                    <span class="fas fa-edit"></span>
                                 </a>
                                 <a class="btnEliminarVehiculo btn btn-danger btn-circle btn-sm m-1" style="color: white;" data-id="` + vehiculo.idVehiculo + `">
                                    <span class="far fa-trash-alt"></span>
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

    //################################################# BOTÓN ACEPTAR MODAL ################################################

    //Evento de acción al presionar el botón de aceptar, dependiendo de la acción (Ingresar o editar)
    // se asigna la url correspondiente y se llama a la función de validar el formulario y realizar la solicitud
    $("#btnAceptar").click(function () {

        const formVehiculo = "formularioVehiculo";
        switch (Accion) {
            case "Agregar":
                Validar(formVehiculo);
                url = "/Vehiculo/AgregarVehiculo/";
                Solicitud(url, "agregado");
                break;
            case "Editar":
                Validar(formVehiculo);
                url = "/Vehiculo/EditarVehiculo/";
                Solicitud(url, "editado");
                break;
            default:
                console.log('No existe caso');
        }

    });

    //Muestra el mensaje de confirmación y en el caso de confirmar llama a la función de IngresarYEditarVehiculoPOST
    function Solicitud(url, accion) {

        if (EsFormularioValido("formularioVehiculo")) {
            swal({
                title: "¿Está seguro?",
                text: "El vehículo será " + accion,
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
                    IngresarYEditarVehiculoPOST(url);
                } else {
                    MostrarMensaje("Acción cancelada", "El vehículo no fue " + accion, "warning");
                }
            });
        } else {
            Validar("formularioVehiculo");
        }
    }

    //Ingresa o Edita el vehiculo y luego llama a la función SolicitudPOST
    function IngresarYEditarVehiculoPOST(url) {

        if ($("#formularioVehiculo").valid()) {

            let token = $('input[name="__RequestVerificationToken"]').val();

            let vehiculo = {
                IdVehiculo: $('#IdVehiculo').val(),
                Placa: $('#Placa').val(),
                Dueno: $('#Dueno').val(),
                Marca: $('#Marca').val(),
                ListaIdServicios: $("#SelectServiciosVehiculo").val()
            };

            let data = {
                __RequestVerificationToken: token, vehiculo
            };

            SolicitudPOST(url, data);

        }

    }

    //Realiza la solicitud Post (de Agregar, Editar o Eliminar), muestra el mensaje y esconde la ventana modal.
    function SolicitudPOST(url, data) {

        Cargando();
        $.post(url, data).done(function (data) {
            console.log(data);
            if (data.ok) {

                RecargarTablaVehiculo();

                $('#formVehiculo').modal('hide');

                MostrarMensaje("Atención", data.mensaje, "success");

            } else {

                MostrarMensajeDeConfirmarcion("Atención", data.mensaje, "warning");
            }
        }).fail(function () {
            ErrorDeConexion();
        });

    }

    //################################################# BOTONES DE ACCIONES ################################################

    //Evento de acción al presionar el botón de agregar vehiculo, restablece los campos del formulario
    $(document).on("click", "#btnAgregarVehiculo", function () {

        Accion = "Agregar"; //AccionIngresar
        $(".text-danger").hide(); //Oculta los mensajes de error (Por si se cerró la ventana estando activados)
        $("#formularioVehiculo").trigger("reset"); //Limpiar campos de texto
        $("#SelectServiciosVehiculo").selectpicker("deselectAll"); //Quita todos los seleccionados
        $("#SelectServiciosVehiculo").selectpicker("refresh"); //Refresca el combobox
        $('#IdVehiculo').val(0) //Ponerle cero al Id (al Html.HiddenFor)(Porque queda guardado el id que se editó antes)
        $("#FormTitulo").text("Agregar vehículo");	//Cambiar el título del formulario

    });

    //Evento de acción al presionar el botón de editar clasificación, obtiene los datos de la fila
    // correspondiente y las asigna al formulario.
    $(document).on("click", ".btnEditarVehiculo", function () {

        Accion = "Editar"; //AccionEditar 
        $(".text-danger").hide();
        $("#formularioVehiculo").trigger("reset");
        $("#FormTitulo").text("Editar vehículo");

        fila = $(this).closest("tr"); //Obtiene la fila seleccionada

        let vehiculo = {
            IdVehiculo: $(this).data("id"),
            Placa: fila.find('td:eq(0)').text(),
            Dueno: fila.find('td:eq(1)').text(),
            Marca: fila.find('td:eq(2)').text(),
        };

        $('#IdVehiculo').val(vehiculo.IdVehiculo);
        $('#Placa').val(vehiculo.Placa);
        $('#Dueno').val(vehiculo.Dueno);
        $('#Marca').val(vehiculo.Marca);

        url = "/Vehiculo/ObtenerIdServiciosDeVehiculo/" + vehiculo.IdVehiculo;

        Get(url).then(function (listaIdServicios) {

            let ListaIdServicios = listaIdServicios;
            console.log(ListaIdServicios);
            $("#SelectServiciosVehiculo").val(ListaIdServicios);
            $("#SelectServiciosVehiculo").selectpicker('render');

        }).catch(() => ErrorDeConexion());

    });

    //Evento de acción al presionar el botón de eliminar clasificación, muestra el mensaje de confirmación y
    // en caso de aceptar llama a la función VerificarExistenciaDeEvento
    $(document).on("click", ".btnEliminarVehiculo", function () {

        fila = $(this).closest("tr"); //Obtiene la fila seleccionada
        let placa = fila.find('td:eq(0)').text();

        swal({
            title: "¿Desea eliminar el vehículo con placa " + placa + "?",
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
                MostrarMensaje("Acción cancelada", "El vehículo no fue eliminado", "warning");
                swal.close();
            } else {
                swal({
                    title: "¿Está seguro?",
                    content: {
                        element: 'p',
                        attributes: {
                            innerHTML: "<h4>El vehículo de placa " + "<strong class='text-danger'>" + placa + "</strong>" + " será eliminado permanentemente.</h4>",
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
                            let idVehiculo = $(this).data("id");
                            url = "/Vehiculo/EliminarVehiculo/";

                            let data = {
                                __RequestVerificationToken: token,
                                id: idVehiculo
                            };

                            SolicitudPOST(url, data);

                        } else {
                            MostrarMensaje("Acción cancelada", "El vehículo no fue eliminado", "warning");
                        }
                    });
            }
        });

    });

     //#################################################  OTROS #################################################################

    //Actualiza la lista de las clasificaciones
    function RecargarTablaVehiculo() {

        DataTableVehiculo.ajax.reload();
    }

    //Inicialización del select de multi opción
    $("#SelectServiciosVehiculo").selectpicker({
        selectAllText: "Seleccionar todos",
        deselectAllText: "Quitar todos",
        actionsBox: true,
        header: "Seleccione una o varios servicios",
        noneSelectedText: "Ninguno seleccionado",
        title: "Seleccione",
        selectedTextFormat: "count",
        width: "100%",
        size: 4,
        style: "form-control",
        styleBase: "form-control",
        countSelectedText: "{0} servicios seleccionados"
    });


    //Se obtienen los servicios y se llama a la función de GestionarSeleccionDeServicios
    Get("/Servicio/ListarServicios").then(function (listaDeServicios) {
         
        GestionarSeleccionDeServicios(listaDeServicios.listaServicios);

    }).catch(() => ErrorDeConexion());

    //Recorre la lista de servicios y las agrega al SelectServiciosVehiculo
    function GestionarSeleccionDeServicios(listaServicios) {

        let opciones = "";

        $.each(listaServicios, function (i) {
            opciones += '<option value=' + listaServicios[i].idServicio + '>' + listaServicios[i].descripcion + '</option>';
        });

        $("#SelectServiciosVehiculo").html(opciones);

        $("#SelectServiciosVehiculo").selectpicker("refresh");

    }

});