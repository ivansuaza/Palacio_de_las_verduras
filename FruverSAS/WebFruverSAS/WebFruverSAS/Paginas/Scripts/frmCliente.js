var dir = "http://localhost:51542/api/";
var oTabla = $("#tablaDatos").DataTable();


jQuery(function () {
    //Carga el menú
    $("#dvMenu").load("../Paginas/Menu.html");

    //Registrar los botones para responder al evento click
    $("#btnAgre").on("click", function () {
        alert("Agregar");
        $("#txtCodigo").val(0)
        let nroD = $("#txtNroDoc").val();
        let name = $("#txtNombre").val();

        alert("nroDoc:" + nroD + "Nombre :" + name)
        if (name.trim() == "" || nroD.trim() == "" || parseInt(nroD, 10) <= 0) {
            mensajeInfo("Falta Informacion del Cliente")
            $("#txtNroDoc").focus();
            return;
        }
        else {
            let rpta = window.confirm("Estas Seguro de Crear el Cliente: " + name + " Con Numero Doc : " + nroD);
            if (rpta == true) {
                ejecutarComando("POST")
            } else {
                window.alert("Cancelada la Accion de Modificacion")
                mensajeInfo("No se Agrego ningun Cliente")
            }
        }

    });
    $("#btnModi").on("click", function () {
        alert("Modificar");
        let nroD = $("#txtNroDoc").val();
        let name = $("#txtNombre").val();
        alert("nroDoc " + nroD + "nombre" + name);
        if (name.trim() == "" || nroD.trim() == "" || parseInt(nroD, 10) <= 0 || nroD.trim() == "" || parseInt(nroD, 10) <= 0) {
            mensajeError("Debe Buscar 1ro. un artista");
            $("#txtNroDoc").focus();
            return;
        }
        else {

            let rpta = window.confirm("Estas seguro de modificar datos de: " + name + ", con nro. Doc. " + nroD);
            if (rpta == true) {
                ejecutarComando("PUT");
            } else {
                mensajeInfo("Cancelada acción de Modificar al Cliente");
            }
        }
        
    });
    $("#btnBusc").on("click", function () {
        alert("Buscar");
        Consultar();
    });
    $("#btnCanc").on("click", function () {
        alert("Cancelar");
        //Cancelar();
    });
    $("#btnImpr").on("click", function () {
        alert("Impresión");
        //Imprimir();
    });
    $("#tablaDatos tbody").on("click", 'tr', function (evento) {
        evento.preventDefault(); // Evita el comportamiento predeterminado del evento

        // Verifica si la fila ya está seleccionada
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected'); // Quita la selección si ya estaba seleccionada
        }
        // Elimina la clase 'selected' de cualquier otra fila seleccionada en la tabla
        $('#tablaDatos tbody tr.selected').removeClass('selected');

        // Añade la clase 'selected' a la fila actual
        $(this).addClass('selected');

        editarFila($(this).closest('tr'));

    });
        
    llenarComboGenero();
    llenarComboDpto();
    llenarComboTipDoc();
    llenarTabla();
});  //Del: jQuery


function mensajeError(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-danger");
    $("#dvMensaje").html(texto);
}
function mensajeInfo(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-info");
    $("#dvMensaje").html(texto);
}
function mensajeOk(texto) {
    $("#dvMensaje").removeClass("alert alert-success");
    $("#dvMensaje").addClass("alert alert-success");
    $("#dvMensaje").html(texto);
}

function editarFila(datosFila) {

    // Obtener y asignar valores a los controles del formulario.
    let idTD = datosFila.find('td:eq(4)').text(); // Tipo de documento
    $("#cboTipDoc").val(idTD);

    let idGe = datosFila.find('td:eq(6)').text(); // Género
    console.log("Genero: "  + idGe)
    $("#cboGenero").val(idGe);

    let idDe = datosFila.find('td:eq(8)').text(); // Departamento
    console.log("Departamento :" + idDe)
    $("#cboDpto").val(idDe);

    let idCi = datosFila.find('td:eq(7)').text(); // Ciudad
    llenarComboCuidad(idCi); // Función para llenar el combo de ciudades basado en el departamento

    // Asignar datos básicos al formulario
    $("#txtCodigo").val(datosFila.find('td:eq(1)').text()); // Código del cliente
    $("#txtNombre").val(datosFila.find('td:eq(2)').text()); // Nombre del cliente
    $("#txtApellido").val(datosFila.find('td:eq(3)').text()); // Apellido del cliente
    $("#txtNroDoc").val(datosFila.find('td:eq(5)').text()); // Número de documento

    // Mensaje de confirmación
    mensajeOk("Ok");
}


async function llenarTabla() {
    let rpta = await llenarTablaGral(dir + "cliente?dato=0&comando=1", "#tablaDatos");
}


async function llenarComboGenero() {
    let url = dir + "genero";
    let rpta = await llenarComboGral(url, "#cboGenero")
}

async function llenarComboTipDoc() {
    let url = dir + "tipoDoc";
    let rpta = await llenarComboGral(url, "#cboTipDoc");
}

async function llenarComboDpto() {
    let url = dir + "dpto";
    let rpta = await llenarComboGral(url, "#cboDpto");
    if (rpta == "Termino") {
        llenarComboCuidad();
    }
}

async function llenarComboCuidad(idCiu) { ///Id de la cuidad dependiendo del Departamento
    let idDpto = $("#cboDpto").val();
    let url = dir + "cuidad?idDpto=" + idDpto;
    let rpta = await llenarComboGral(url, "#cboCuidad");
    if (idCiu != undefined && rpta == "Termino")
        $("#cboCuidad").val(idCiu);
}

async function Consultar() {
    mensajeInfo(""); // Limpiar mensajes previos

    try {
        // Validar número de documento
        let nroDoc = $("#txtNroDoc").val();
        if (nroDoc == undefined || nroDoc.trim() == "" || parseInt(nroDoc, 10) <= 0) {
            mensajeError("Error, el nro. del documento no es valido");
            $("#txtNroDoc").focus();
            return;
        }

        const datosOut = await fetch(dir + "cliente?dato=" + nroDoc + "&comando=2",
            {
                method: "GET",
                mode: "cors",
                headers: {
                    "content-type": "application/json",

                }

            }
        );

        const datosIn = await datosOut.json();
        console.log(datosIn)
        if (datosIn == "") {
            mensajeInfo("No se encontró artista con nro. doc. : " + nroDoc);
            return;
        }
        $("#txtCodigo").val(datosIn[0].Codigo);
        $("#txtNombre").val(datosIn[0].Nombre);
        $("#txtApellido").val(datosIn[0].Apellido);
        $("#cboGenero").val(datosIn[0].idGen);
        $("#cboTipDoc").val(datosIn[0].idTD);
        $("#txtNroDoc").val(datosIn[0].nroD)
       // llenarComboCiudad(datosIn[0].idCiu);

    } catch (error) {
        mensajeError(`Error al consultar cliente: ${error.message}`);
    }
}


async function ejecutarComando(accion) {
    // Capturar los datos de entrada
    let Codi = $("#txtCodigo").val();
    let Nomb = $("#txtNombre").val();
    let Apel = $("#txtApellido").val();
    let idTD = $("#cboTipDoc").val();
    let nroD = $("#txtNroDoc").val();
    let idGen = $("#cboGenero").val()
    
    alert("CODI" + Codi + " Nombre : " + Nomb + " Apellido: " + Apel + " Num Doc : " + nroD)


    let datosOut = {
        Codigo: Codi,
        Nombre: Nomb,
        Apellido: Apel,
        idtipoDoc: idTD,
        nroDoc: nroD,
        idGenero: idGen
    };

    console.log(datosOut)

    try {
        const response = await fetch(dir + "cliente", {
            method: accion,
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(datosOut),
        });

        const Respuesta = await response.json();
        Consultar(); 
        mensajeOk(Respuesta);
        llenarTabla();
    } catch (error) {
        mensajeError(`Error al ejecutar comando: ${error.message}`);
    }
}

