function moveToBody(element) {
    if (!element) return;
    document.body.appendChild(element);
}


function showModal(element) {
    const modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.show();
}

function hideModal(element) {
    const modal = bootstrap.Modal.getOrCreateInstance(element);
    modal.hide();
}