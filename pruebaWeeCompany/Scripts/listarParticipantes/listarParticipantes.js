

$(document).ready(function () {

	
	$.get('/api/ParticipantesAPI', function (response) {
		console.log(response);

        var dataTable = $('#tablaParticipantes').DataTable({
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },
            data: response, // Asignar los datos de respuesta al DataTable
            columns: [
                { data: 'nombreCompania' },
                { data: 'cedula' },
                { data: 'nombreContacto' },
                { data: 'titulo' },
                { data: 'correoElectronico' },
                { data: 'telefono' },
            ]
        });
	});


})
