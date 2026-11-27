const API = '/api/categorias';
let categorias = [];

async function cargar() {
    const res = await fetch(API);
    categorias = await res.json();
    mostrar(categorias);
}

function mostrar(datos) {
    const tabla = document.getElementById('tablaCategorias');
    tabla.innerHTML = datos.map(c => `
        <tr>
            <td>${c.nombre}</td>
            <td>${c.descripcion}</td>
            <td><span class="${c.activa ? 'badge-activo' : 'badge-inactivo'}">${c.activa ? 'Activa' : 'Inactiva'}</span></td>
            <td>
                <button onclick="editar('${c.id}')" class="btn-texto-azul">Editar</button>
                <button onclick="eliminar('${c.id}')" class="btn-texto-rojo">Eliminar</button>
            </td>
        </tr>
    `).join('');
}

function buscar() {
    const texto = document.getElementById('buscar').value.toLowerCase();
    const filtrados = categorias.filter(c => c.nombre.toLowerCase().includes(texto));
    mostrar(filtrados);
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

function confirmar(mensaje) {
    return new Promise((resolve) => {
        document.getElementById('modalMensaje').textContent = mensaje;
        document.getElementById('modal').classList.remove('hidden');
        document.getElementById('modalConfirmar').onclick = () => {
            document.getElementById('modal').classList.add('hidden');
            resolve(true);
        };
        document.getElementById('modalCancelar').onclick = () => {
            document.getElementById('modal').classList.add('hidden');
            resolve(false);
        };
    });
}

async function editar(id) {
    const c = categorias.find(x => x.id === id);
    document.getElementById('categoriaId').value = c.id;
    document.getElementById('nombre').value = c.nombre;
    document.getElementById('descripcion').value = c.descripcion;
    document.getElementById('formTitulo').textContent = 'Editar Categoria';
    document.getElementById('btnCancelar').classList.remove('hidden');
}

function limpiar() {
    document.getElementById('categoriaId').value = '';
    document.getElementById('nombre').value = '';
    document.getElementById('descripcion').value = '';
    document.getElementById('formTitulo').textContent = 'Nueva Categoria';
    document.getElementById('btnCancelar').classList.add('hidden');
}

async function eliminar(id) {
    const ok = await confirmar('¿Eliminar esta categoria?');
    if (!ok) return;
    await fetch(`${API}/${id}`, { method: 'DELETE' });
    mostrarExito('Categoria eliminada');
    cargar();
}

document.getElementById('btnCancelar').addEventListener('click', limpiar);

document.getElementById('formCategoria').addEventListener('submit', async (e) => {
    e.preventDefault();
    const id = document.getElementById('categoriaId').value;
    const datos = {
        nombre: document.getElementById('nombre').value,
        descripcion: document.getElementById('descripcion').value
    };

    if (id) {
        const res = await fetch(`${API}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(datos)
        });
        if (res.ok) {
            mostrarExito('Categoria actualizada');
        } else {
            const error = await res.text();
            mostrarError(error);
        }
    } else {
        const res = await fetch(API, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(datos)
        });
        if (res.ok) {
            mostrarExito('Categoria creada');
        } else {
            const error = await res.text();
            mostrarError(error);
        }
    }

    limpiar();
    cargar();
});

cargar();