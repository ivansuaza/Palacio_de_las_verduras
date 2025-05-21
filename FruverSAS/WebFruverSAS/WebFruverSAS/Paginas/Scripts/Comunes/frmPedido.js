var dir = "http://localhost:51542/api/";  // url de la Api 




// Obtener la fecha y hora actual
const now = new Date();
const formattedDate = new Intl.DateTimeFormat("en-US", {
    year: "numeric",
    month: "2-digit",
    day: "2-digit"
}).format(now);

// Obtener las horas, minutos y segundos
const hours = now.getHours().toString().padStart(2, '0');
const minutes = now.getMinutes().toString().padStart(2, '0');
const seconds = now.getSeconds().toString().padStart(2, '0');

// Combina la fecha y la hora en un solo string
const formattedDateTime = `${formattedDate} ${hours}:${minutes}:${seconds}`;

// Asigna la fecha y hora al input
document.getElementById("lbFechaAct").value = formattedDateTime;

// Función para llenar los combos con datos obtenidos de la API
async function llenarComboGral(url, combo) {
    try {
        let res = await fetch(url);  // Realiza la petición a la API
        let data = await res.json(); // Convierte la respuesta en formato JSON

        let select = document.querySelector(combo);
        select.innerHTML = ""; // Limpiar las opciones previas

        // Si hay datos, agregar una opción vacía por defecto
        if (data.length > 0) {
            let optionDefault = document.createElement('option');
            optionDefault.value = "";  // Valor vacío por defecto
            optionDefault.textContent = "Seleccione una opción";
            select.appendChild(optionDefault);

            // Agregar las opciones dinámicas
            data.forEach(item => {
                let option = document.createElement('option');
                option.value = item.Id; // Cambia 'Id' si es diferente en tu respuesta
                option.textContent = item.Nombre; // Cambia 'Nombre' si es diferente
                select.appendChild(option); // Agregar la opción al select
            });
        } else {
            let optionEmpty = document.createElement('option');
            optionEmpty.value = "";
            optionEmpty.textContent = "No hay opciones disponibles";
            select.appendChild(optionEmpty);
        }
    } catch (error) {
        console.error("Error al llenar el combo:", error);
    }
}

// Función para obtener las direcciones de la API
async function obtenerDirecciones(clienteId) {
    const url = `http://localhost:51542/api/Direcciones/${clienteId}`; // URL de la API
    try {
        const response = await fetch(url);
        if (response.ok) {
            const direcciones = await response.json();
            return direcciones; // Suponiendo que la respuesta es un array de direcciones
        } else {
            console.error('Error al obtener las direcciones');
            return [];
        }
    } catch (error) {
        console.error('Error de conexión', error);
        return [];
    }
}

async function obtenerPedidos() {
    const clienteId = document.getElementById("txtCodigoCliente").value;
    if (!clienteId) return; // Validar que el campo no esté vacío

    try {
        const url = `${dir}Pedidos/${clienteId}`; // Cambiar según tu endpoint
        const response = await fetch(url);
        if (response.ok) {
            const pedidos = await response.json();
            llenarTablaPedidos(pedidos); // Llenar la tabla con los pedidos obtenidos
        } else {
            console.error('Error al obtener pedidos del cliente');
            limpiarTablaPedidos(); // Limpiar la tabla si hay error
        }
    } catch (error) {
        console.error('Error de conexión:', error);
    }
}

// Función para llenar la tabla con los pedidos obtenidos
function llenarTablaPedidos(pedidos) {
    const tbody = document.querySelector("#tablaPedidos tbody");
    tbody.innerHTML = ""; // Limpiar la tabla antes de llenarla

    if (pedidos.length > 0) {
        pedidos.forEach(pedido => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${pedido.Codigo}</td>
                <td>${pedido.Cantidad}</td>
                <td>${pedido.PrecioUnitario}</td>
                <td>${pedido.Total}</td>
            `;
            tbody.appendChild(row);
        });
    } else {
        // Si no hay pedidos, agregar un mensaje en la tabla
        const row = document.createElement("tr");
        row.innerHTML = `<td colspan="4" class="text-center">No hay pedidos disponibles</td>`;
        tbody.appendChild(row);
    }
}




// Función para llenar el select de direcciones
function llenarDirecciones(direcciones) {
    const select = document.getElementById("cboDirecciones");
    select.innerHTML = ""; // Limpiar cualquier opción anterior

    // Crear un primer item de selección
    const option = document.createElement("option");
    option.value = "";
    option.textContent = "Seleccione una dirección";
    select.appendChild(option);

    // Crear las opciones para cada dirección
    direcciones.forEach(direccion => {
        const option = document.createElement("option");
        option.value = direccion.id; // Asumiendo que la dirección tiene un campo "id"
        option.textContent = direccion.direccion; // Asumiendo que la dirección tiene un campo "direccion"
        select.appendChild(option);
    });
}

function limpiarTablaPedidos() {
    const tbody = document.querySelector("#tablaPedidos tbody");
    tbody.innerHTML = ""; // Vaciar el contenido de la tabla
}

// Evento para manejar el checkbox
document.getElementById("chkDomicilio").addEventListener("change", async function () {
    const container = document.getElementById("direccionesContainer");

    if (this.checked) {
        // Mostrar el select de direcciones
        container.style.display = "block";

        const clienteId = 123; // Este sería el ID del cliente, por ejemplo
        const direcciones = await obtenerDirecciones(clienteId);

        // Llenar el select con las direcciones obtenidas
        llenarDirecciones(direcciones);
    } else {
        // Ocultar el select de direcciones
        container.style.display = "none";
    }
});



// Función para llenar las opciones de las formas de pago
async function llenarFormaPg() {
    let url = dir + 'FormaPago';
    await llenarComboGral(url, '#cboFormaPg');
}

// Función para llenar las opciones de los tipos de venta
async function llenarTipoVenta() {
    let url = dir + 'TipoVenta';
    await llenarComboGral(url, '#cboTipoVenta');
}

// Llamada inicial para llenar los combos al cargar la página
document.addEventListener('DOMContentLoaded', function () {
    llenarFormaPg();   // Llenar las formas de pago
    llenarTipoVenta(); // Llenar los tipos de venta
});
