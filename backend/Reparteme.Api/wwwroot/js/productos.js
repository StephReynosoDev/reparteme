const API = '/api/productos';
let productos = [];

async function cargarCategorias() {
    const res = await fetch('/api/categorias');
    const datos = await res.json();
    const select = document.getElementById('categoriaId');
    select.innerHTML = datos.map(c => `<option value="${c.id}">${c.nombre}</option>`).join('');
}

async function cargar() {
    const res = await fetch(API);
    productos = await res.json();
    mostrar(productos);
}

function mostrar(datos) {
    const tabla = document.getElementById('tablaProductos');
    tabla.innerHTML = datos.map(p => `
        <tr>
            <td>
                ${p.foto ? `<img src="${p.foto}" alt="${p.nombre}" style="width:50px;height:50px;object-fit:cover;border-radius:6px;">` : '<span style="color:#9ca3af;">Sin foto</span>'}
            </td>
            <td>${p.nombre}</td>
            <td>${p.categoriaNombre}</td>
            <td>${p.cantidadActual}</td>
            <td><span class="${p.activo ? 'badge-activo' : 'badge-inactivo'}">${p.activo ? 'Activo' : 'Inactivo'}</span></td>
            <td>
                <button onclick="editar('${p.id}')" class="btn-texto-azul">Editar</button>
                <button onclick="eliminar('${p.id}')" class="btn-texto-rojo">Eliminar</button>
            </td>
        </tr>
    `).join('');
}

function buscar() {
    const texto = document.getElementById('buscar').value.toLowerCase();
    const filtrados = productos.filter(p => p.nombre.toLowerCase().includes(texto));
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
    const p = productos.find(x => x.id === id);
    document.getElementById('productoId').value = p.id;
    document.getElementById('nombre').value = p.nombre;
    document.getElementById('descripcion').value = p.descripcion;
    document.getElementById('foto').value = p.foto || '';
    document.getElementById('cantidad').value = p.cantidadActual;
    document.getElementById('categoriaId').value = p.categoriaId;
    document.getElementById('formTitulo').textContent = 'Editar Producto';
    document.getElementById('btnCancelar').classList.remove('hidden');
}

function limpiar() {
    document.getElementById('productoId').value = '';
    document.getElementById('nombre').value = '';
    document.getElementById('descripcion').value = '';
    document.getElementById('foto').value = '';
    document.getElementById('cantidad').value = '';
    document.getElementById('formTitulo').textContent = 'Nuevo Producto';
    document.getElementById('btnCancelar').classList.add('hidden');
}

async function eliminar(id) {
    const ok = await confirmar('¿Eliminar este producto?');
    if (!ok) return;
    await fetch(`${API}/${id}`, { method: 'DELETE' });
    mostrarExito('Producto eliminado');
    cargar();
}

document.getElementById('btnCancelar').addEventListener('click', limpiar);

document.getElementById('formProducto').addEventListener('submit', async (e) => {
    e.preventDefault();

    const cantidad = parseInt(document.getElementById('cantidad').value);
    if (cantidad < 0 || cantidad > 999999) {
        mostrarError('La cantidad debe ser entre 0 y 999,999');
        return;
    }

    const id = document.getElementById('productoId').value;
    const datos = {
        nombre: document.getElementById('nombre').value,
        descripcion: document.getElementById('descripcion').value,
        foto: document.getElementById('foto').value,
        cantidadActual: cantidad,
        categoriaId: document.getElementById('categoriaId').value
    };

    if (id) {
        const res = await fetch(`${API}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(datos)
        });
        if (res.ok) {
            mostrarExito('Producto actualizado');
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
            mostrarExito('Producto creado');
        } else {
            const error = await res.text();
            mostrarError(error);
        }
    }

    limpiar();
    cargar();
});

cargarCategorias();
cargar();