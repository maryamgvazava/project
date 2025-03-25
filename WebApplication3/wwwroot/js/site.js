// Seat selection handling
document.addEventListener('DOMContentLoaded', function () {
    // Initialize seat selection
    const seatButtons = document.querySelectorAll('.seat:not(.disabled)');
    seatButtons.forEach(button => {
        button.addEventListener('click', function () {
            const seatId = this.dataset.seatId;
            document.getElementById('selectedSeatId').value = seatId;

            // Update UI to show selected seat
            seatButtons.forEach(btn => btn.classList.remove('btn-primary'));
            this.classList.add('btn-primary');
        });
    });

    // Form validation
    const forms = document.querySelectorAll('.needs-validation');
    forms.forEach(form => {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
            form.classList.add('was-validated');
        }, false);
    });
});