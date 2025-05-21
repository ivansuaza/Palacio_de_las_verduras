
const form = document.getElementById('loginForm');
const message = document.getElementById('message');
form.addEventListener('submit', function (event) {
    event.preventDefault();

    const username = form.username.value;
    const password = form.password.value;

    // Validación básica
    if (username === "juanperez" && password === "12345") {
        message.textContent = "Inicio de sesión exitoso.";
        message.className = "message success";
        window.location.href = "frmInicio.html";
    } else {
        message.textContent = "Usuario o contraseña incorrectos.";
        message.className = "message error";
    }
});