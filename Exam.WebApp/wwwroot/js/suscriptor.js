var msgOk = '<div class="alert alert-success alert-dismissible"> ';
msgOk = msgOk + ' <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> ';
msgOk = msgOk + ' <strong>Registro guardado correctamente.!</strong></div>';

var msgFail = ' <div class="alert alert-danger alert-dismissible"> ';
msgFail = msgFail + ' <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> ';
msgFail = msgFail + ' <strong>Ocurrio un error, por favor intentalo mas tarde. !</strong></div> ';

var msgWarning = ' <div class="alert alert-warning alert-dismissible"> ';
msgWarning = msgWarning + ' <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> ';
msgWarning = msgWarning + ' <strong>El registro ya existe. !</strong></div> ';

var msgWarn = ' <div class="alert alert-danger alert-dismissible"> ';
msgWarn = msgWarn + ' <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> ';
msgWarn = msgWarn + ' <strong>No se encontro informacion relacionada. !</strong></div> ';


function fnBuscaSuscriptor() {

    var miUrl = '/Suscriptor/BuscaSuscriptor/")'
    var formContainer = $("#fmrData");

    $.ajax({
        type: 'GET',
        url: miUrl,
        dataType: 'json',
        data: formContainer.serialize(),
        success: function (response) {
            if (response != null) {
                fnmuestraDatos(response);
    //            limpiar(false);
            }
            else {
                document.getElementById("msg").innerHTML = msgWarn;
            }
        },
        error: function (response) {
            console.log(response);
            document.getElementById("msg").innerHTML = msgFail;
        },
        async: true
    });
}

function fnGuardaSuscriptor() {
    var miUrl = '/Suscriptor/GuardaSuscriptor/")'
    var formContainer = $("#fmrData");

    if (!valida('N')) {
        alert('Debe capturar la informacion faltante');
        return false;
    }

    $.ajax({
        type: 'POST',
        url: miUrl,
        dataType: 'json',
        data: formContainer.serialize(),
        success: function (response) {
            if (response == true) {
                document.getElementById("msg").innerHTML = msgOk;
                fnNuevo();
            }
            else {
                document.getElementById("msg").innerHTML = msgWarning;
            }
        },
        error: function (response) {
            console.log(response);
            document.getElementById("msg").innerHTML = msgFail;
        },
        async: true
    });
}


function fnEditarSuscriptor() {
    var miUrl = '/Suscriptor/EditarSuscriptor/")'
    var formContainer = $("#fmrData");

    if (!valida('M')) {
        alert('Debe capturar la informacion faltante');
        return false;
    }

    $.ajax({
        type: 'POST',
        url: miUrl,
        dataType: 'json',
        data: formContainer.serialize(),
        success: function (response) {
            if (response == true) {
                document.getElementById("msg").innerHTML = msgOk;
                fnNuevo();
            }
            else { document.getElementById("msg").innerHTML = msgFail; }
        },
        error: function (response) {
            console.log(response);
            document.getElementById("msg").innerHTML = msgFail;
        },
        async: true
    });
}


function fnEliminarSuscriptor() {
    var miUrl = '/Suscriptor/EliminarSuscriptor/")'
    var formContainer = $("#fmrData");

    $.ajax({
        type: 'POST',
        url: miUrl,
        dataType: 'json',
        data: formContainer.serialize(),
        success: function (response) {
            if (response == true) {
                document.getElementById("msg").innerHTML = msgOk;
                //            fnmuestraDatos();
                //            limpiar(false);
                alert('todo bien');
            }
            else { document.getElementById("msg").innerHTML = msgFail; }
        },
        error: function (response) {
            console.log(response);
            document.getElementById("msg").innerHTML = msgFail;
        },
        async: true
    });
}

function fnNuevo() {
    document.getElementById("TipoDocumento").value = 0;
    document.getElementById("NumeroDocumento").value = "";
    document.getElementById("IdSuscriptor").value = 0;
    document.getElementById("Nombre").value = "";
    document.getElementById("Apellido").value = "";
    document.getElementById("Direccion").value = "";
    document.getElementById("Telefono").value = "";
    document.getElementById("Email").value = "";
    document.getElementById("Estado").value = 0;
    document.getElementById("Username").value = "";
    document.getElementById("Pwd").value = "";

    document.getElementById("Username").setAttribute("readonly", false);
}

function fnmuestraDatos(response) {
    document.getElementById("IdSuscriptor").value = response.idSuscriptor;
    document.getElementById("Nombre").value = response.nombre;
    document.getElementById("Apellido").value = response.apellido;
    document.getElementById("Direccion").value = response.direccion;
    document.getElementById("Telefono").value = response.telefono;
    document.getElementById("Email").value = response.email;
    document.getElementById("Estado").value = response.estado;
    document.getElementById("Username").value = response.username;
    document.getElementById("Pwd").value = "**********";

    var btn_1 = document.getElementById('btnRegister');

    if (response.estado == 0) btn_1.style.display = 'block';
    else btn_1.style.display = 'none';

    document.getElementById("Username").setAttribute("readonly", true);
}


function fnGuardaSuscripcion() {
    var miUrl = '/Suscriptor/GuardaSuscripcion/")'
    var formContainer = $("#fmrData");

    if (!valida('N')) {
        alert('Debe capturar la informacion faltante');
        return false;
    }

    $.ajax({
        type: 'POST',
        url: miUrl,
        dataType: 'json',
        data: formContainer.serialize(),
        success: function (response) {
            if (response == true) {
                document.getElementById("msg").innerHTML = msgOk;
                //            fnmuestraDatos();
                //            limpiar(false);
            }
            else { document.getElementById("msg").innerHTML = msgFail; }
        },
        error: function (response) {
            console.log(response);
            document.getElementById("msg").innerHTML = msgFail;
        },
        async: true
    });
}

function cerrar() {
    var div = document.getElementById("msg");
    div.innerHTML = '';
    document.getElementById("msgAdd").innerHTML = "";
}


function valida(isNew) {
    let nombre = document.getElementById("Nombre").value;
    let apellido = document.getElementById("Apellido").value;
    let direccion = document.getElementById("Direccion").value;
    let telefono = document.getElementById("Telefono").value;
    let email = document.getElementById("Email").value;
    let estado = document.getElementById("Estado").value;
    let username = document.getElementById("Username").value;
    let pwd = document.getElementById("Pwd").value;

    if (nombre == '') {
        alert("Debe capturar el nombre");
        return false;
    }

    if (apellido == '') {
        alert("Debe capturar el añpelldio");
        return false;
    }

    if (direccion == '') {
        alert("Debe capturar la direccion");
        return false;
    }

    if (telefono == '') {
        alert("Debe capturar el telefono");
        return false;
    }

    if (email == '') {
        alert("Debe capturar el email");
        return false;
    }

    if (estado == '') {
        alert("Debe capturar el estado");
        return false;
    }

    if (pwd == '') {
        alert("Debe capturar el password");
        return false;
    }

    if (isNew == 'N') {
        if (username == '') {
            alert("Debe capturar el nombre de usuario");
            return false;
        }
    }

    return true;
}