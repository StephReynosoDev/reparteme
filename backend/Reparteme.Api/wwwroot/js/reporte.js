async function cargar() {
    const res = await fetch('/api/reporte/consumo');
    const datos = await res.json();
    const tabla = document.getElementById('tablaReporte');
    tabla.innerHTML = datos.map(r => `
        <tr>
            <td>${r.nombre}</td>
            <td style="color:#16a34a;">${r.entradas}</td>
            <td style="color:#dc2626;">${r.salidas}</td>
            <td class="${r.cantidadActual < 0 ? 'stock-negativo' : ''}" style="font-weight:700;">${r.cantidadActual}</td>
        </tr>
    `).join('');
}

cargar();