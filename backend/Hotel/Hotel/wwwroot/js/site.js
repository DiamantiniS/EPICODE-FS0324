// Camera functions
function loadEditCameraModal(numero) {
    $.get('/Admin/Camere/Edit/' + numero, function (data) {
        $('#editNumero').val(data.numero);
        $('#editDescrizione').val(data.descrizione);
        $('#editTipologia').val(data.tipologia);
        $('#editTariffaBase').val(data.tariffaBase);
    }).fail(function (xhr) {
        alert("Errore nel caricamento dei dati della camera: " + xhr.responseText);
    });
}

function loadDeleteCameraModal(numero) {
    $('#deleteNumero').val(numero);
}

function submitCreateCamera() {
    var form = $('#createCameraForm');
    console.log(form.serialize());
    $.post('/Admin/Camere/Create', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la creazione della camera: " + xhr.responseText);
    });
}

function submitEditCamera() {
    var form = $('#editCameraForm');
    console.log(form.serialize());
    $.post('/Admin/Camere/Edit', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la modifica della camera: " + xhr.responseText);
    });
}

function submitDeleteCamera() {
    var form = $('#deleteCameraForm');
    console.log(form.serialize());
    $.post('/Admin/Camere/Delete', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante l'eliminazione della camera: " + xhr.responseText);
    });
}


// Cliente functions
function loadEditClienteModal(codiceFiscale) {
    $.get('/Admin/Clienti/Edit/' + codiceFiscale, function (data) {
        $('#editCodiceFiscale').val(data.codiceFiscale);
        $('#editCognome').val(data.cognome);
        $('#editNome').val(data.nome);
        $('#editCitta').val(data.citta);
        $('#editProvincia').val(data.provincia);
        $('#editEmail').val(data.email);
        $('#editTelefono').val(data.telefono);
        $('#editCellulare').val(data.cellulare);
    }).fail(function (xhr) {
        alert("Errore nel caricamento dei dati del cliente: " + xhr.responseText);
    });
}

function loadDeleteClienteModal(codiceFiscale) {
    $('#deleteCodiceFiscale').val(codiceFiscale);
}

function submitCreateCliente() {
    var form = $('#createClienteForm');
    console.log(form.serialize());
    $.post('/Admin/Clienti/Create', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la creazione del cliente: " + xhr.responseText);
    });
}

function submitEditCliente() {
    var form = $('#editClienteForm');
    console.log(form.serialize());
    $.post('/Admin/Clienti/Edit', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la modifica del cliente: " + xhr.responseText);
    });
}

function submitDeleteCliente() {
    var form = $('#deleteClienteForm');
    console.log(form.serialize());
    $.post('/Admin/Clienti/Delete', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante l'eliminazione del cliente: " + xhr.responseText);
    });
}

// Prenotazione functions
function loadEditPrenotazioneModal(id) {
    $.get('/Admin/Prenotazioni/Edit/' + id, function (data) {
        $('#editId').val(data.id);
        $('#editCodiceFiscaleCliente').val(data.codiceFiscaleCliente);
        $('#editNumeroCamera').val(data.numeroCamera);
        $('#editDataPrenotazione').val(data.dataPrenotazione.substring(0, 10));
        $('#editNumeroProgressivoAnno').val(data.numeroProgressivoAnno);
        $('#editAnno').val(data.anno);
        $('#editDal').val(data.dal.substring(0, 10));
        $('#editAl').val(data.al.substring(0, 10));
        $('#editCaparraConfirmatoria').val(data.caparraConfirmatoria);
        $('#editTariffaApplicata').val(data.tariffaApplicata);
        $('#editTrattamentoId').val(data.trattamentoId);
    }).fail(function (xhr) {
        alert("Errore nel caricamento dei dati della prenotazione: " + xhr.responseText);
    });
}

function loadDeletePrenotazioneModal(id) {
    $('#deleteId').val(id);
}

function submitCreatePrenotazione() {
    var form = $('#createPrenotazioneForm');
    console.log(form.serialize());
    $.post('/Admin/Prenotazioni/Create', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la creazione della prenotazione: " + xhr.responseText);
    });
}

function submitEditPrenotazione() {
    var form = $('#editPrenotazioneForm');
    console.log(form.serialize());
    $.post('/Admin/Prenotazioni/Edit', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante la modifica della prenotazione: " + xhr.responseText);
    });
}

function submitDeletePrenotazione() {
    var form = $('#deletePrenotazioneForm');
    console.log(form.serialize());
    $.post('/Admin/Prenotazioni/Delete', form.serialize(), function (response) {
        location.reload();
    }).fail(function (xhr) {
        console.log(xhr.responseText);
        alert("Errore durante l'eliminazione della prenotazione: " + xhr.responseText);
    });
}
