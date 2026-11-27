const API = '/api/movimientos';

async function cargarProductos() {
    const res = await fetch('/api/productos');
    const datos = await res.json();
    const select = document.getElementById('productoId');
    select.innerHTML = datos.map(p => `<option value="${p.id}">${p.nombre}</option>`).join('');
}

async function cargar() {
    const res = await fetch(API);
    const datos = await res.json();
    const tabla = document.getElementById('tablaMovimientos');
    tabla.innerHTML = datos.map(m => `
        <tr>
            <td>${m.productoNombre}</td>
            <td>${m.tipo}</td>
            <td>${m.cantidad}</td>
            <td>${m.motivo}</td>
            <td>${new Date(m.fechaCreacion).toLocaleString()}</td>
        </tr>
    `).join('');
}

function mostrarExito(mensaje) {
    const noti = document.createElement('div');
    noti.className = 'notificacion';
    noti.innerHTML = `✔ ${mensaje}`;
    document.body.appendChild(noti);
    setTimeout(() => noti.remove(), 3000);
}

function mostrarError(mensaje) {
    const noti = document.createElement('div');
    noti.className = 'notificacion-error';
    noti.innerHTML = `✘ ${mensaje}`;
    document.body.appendChild(noti);
    setTimeout(() => noti.remove(), 4000);
}

document.getElementById('formMovimiento').addEventListener('submit', async (e) => {
    e.preventDefault();

    const cantidad = parseInt(document.getElementById('cantidad').value);
    if (cantidad < 1 || cantidad > 999999) {
        mostrarError('La cantidad debe ser entre 1 y 999,999');
        return;
    }

    const datos = {
        productoId: document.getElementById('productoId').value,
        cantidad: cantidad,
        tipo: parseInt(document.getElementById('tipo').value),
        motivo: document.getElementById('motivo').value
    };

    const res = await fetch(API, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(datos)
    });

    if (res.ok) {
        mostrarExito('Movimiento registrado');
        document.getElementById('formMovimiento').reset();
        cargar();
    } else {
        const error = await res.text();
        mostrarError(error);
    }
});

cargarProductos();
cargar();