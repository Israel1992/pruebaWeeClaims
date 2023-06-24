$(document).ready(function () {

	//Validacion fronend de los campos
	
	$("#registroParticipantesForm").validate({
		rules: {
			inputNombreCompania: { required: true, maxlength: 80 },
			inputCedula: { required: true, maxlength: 10 },
			inputNombreContacto: { required: true, maxlength: 80 },
			inputTitutlo: { required: true, maxlength: 80 },
			inputEmail: { required: true, email: true, maxlength: 30},
			inputTelefono: { required: true, number: true, maxlength: 12 }
		},
		messages: {
			inputNombreCompania: {
				required: "Por favor ingresa el nombre de la  compañia.",
				maxlength:"No debe tener mas de 80 caracteres"
			},
			inputCedula: {
				required: "Por favor ingresa el nombre de la cedula.",
				maxlength: "No debe tener mas de 10 caracteres"
			},
			inputNombreContacto: {
				required: "Por favor ingresa el nombre del contacto.",
				maxlength: "No debe tener mas de 80 caracteres"
			},
			inputTitutlo: {
				required: "Por favor ingresa el nombre del titulo.",
				maxlength: "No debe tener mas de 80 caracteres"
			},
			inputEmail: {
				required: "Por favor ingresa el correo electrónico.",
				maxlength: "No debe tener mas de 30 caracteres.",
				email: "Por favor registre un correo electrónico valido."
			},
			inputTelefono: {
				required: "Por favor ingresa un teléfono",
				maxlength: "No debe tener mas de 12 caracteres",
				number: "El campo es de tipo numerico"
			}
		},
		submitHandler: function (form) {
			var isChecked = $('#gridCheck').is(':checked');
			if (isChecked) {
				var formData = $(form).serialize();
				$.post('/api/ParticipantesAPI/', formData, function (response) {
					console.log(response);

					if (response.estatus) {
						$('#resEstatus').show();
						$('#resEstatusError').hide();
						$('#resEstatus').html("Datos guardados correctamente");
						$('#resNombreCompania').html(response.data.nombreCompania);
						$('#resCedula').html(response.data.cedula);
						$('#resNombreContacto').html(response.data.nombreContacto);
						$('#resTitutlo').html(response.data.titulo);
						$('#resEmail').html(response.data.correoElectronico);
						$('#resTelefono').html(response.data.telefono);
						$('#mostrarTabla').show();
						$('#errorBackend').hide();
						$("#Modal").modal("show");
					} else {
						$('#resEstatus').hide();
						$('#resEstatusError').show();
						$('#resEstatusError').html("Error");
						$('#errorBackend').html(response.msg);
						$('#mostrarTabla').hide();
						$('#errorBackend').show();

						$("#Modal").modal("show");
					}
				});
			} else {
				alert("Debe aceptarlos terminos y condiciones");
			}
			
		}
	});
	

	//Metodo para hacer pruebas en el backend
	/*
	$('#registroParticipantesForm').submit(function (event) {
		event.preventDefault();
		var formData = $('#registroParticipantesForm').serialize();
		$.post('/api/ParticipantesAPI/', formData, function (response) {
			console.log(response);

			if (response.estatus) {
				$('#resEstatus').show();
				$('#resEstatusError').hide();
				$('#resEstatus').html("Datos guardados correctamente");
				$('#resNombreCompania').html(response.data.nombreCompania);
				$('#resCedula').html(response.data.cedula);
				$('#resNombreContacto').html(response.data.nombreContacto);
				$('#resTitutlo').html(response.data.titulo);
				$('#resEmail').html(response.data.correoElectronico);
				$('#resTelefono').html(response.data.telefono);
				$('#mostrarTabla').show();
				$('#errorBackend').hide();
				$("#Modal").modal("show");
			} else {
				$('#resEstatus').hide();
				$('#resEstatusError').show();
				$('#resEstatusError').html("Error");
				$('#errorBackend').html(response.msg);
				$('#mostrarTabla').hide();
				$('#errorBackend').show();
				
				$("#Modal").modal("show");
			}
		});
		
	});
	*/

	//Funcion que pemite mostrar los datos cosumidos por el REST cedulaProfecional
	$('#inputCedula').on('blur', function () {
		var cedula = $('#inputCedula').val();
		if (cedula != "") {
			$.get('/api/CedulaProfecionalAPI/'+cedula, function (response) {
				var json = $.parseJSON(response);
				console.log(json);
				if (json.items != undefined) {
					if (json.items.length == 1) {
						var nombre = json.items[0].nombre + " " + json.items[0].paterno + " " + json.items[0].materno;
						var titulo = json.items[0].titulo;

						$('#inputNombreContacto').val(nombre);
						$('#inputTitutlo').val(titulo);
					} else if (json.items.length > 1) {
						//Si tiene mas de 1 registro funcionalidad de tabla para seleccionar elemento

					} else if (json.items.length == 0) {
						$('#inputNombreContacto').val("");
						$('#inputTitutlo').val("");
					}
				} else {
					alert("Hay un error al consumir el WS");
				}
			});
		} else {
			alert("El valor para la cedula no es valido");
		}
	});

	//Redirijimos cuando se quiera listar los registros
	$('#mostrarTabla').click(function () {
		document.location.href = '/weeclaims/Lista';
	});

	//Validamos que todos los campos esten llenos para habilitar submit
	
	$('input[name]').on('input', function () {
		debugger;
		var form = $('#registroParticipantesForm');
		var todosLlenos = true;

		$('input[required]', form).each(function () {
			if ($(this).val() === '') {
				todosLlenos = false;
				return false; // Salir del bucle each
			}
		});
		$('#btnEnviar').prop('disabled', !todosLlenos);
		
	});
	

});