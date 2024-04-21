document.addEventListener('DOMContentLoaded', function () {
    const inputs = document.querySelectorAll('.input-field');

    inputs.forEach(function (input) {
        input.addEventListener('input', function () {
            if (input.value !== '') {
                input.classList.add('filled');
            } else {
                input.classList.remove('filled');
            }
        });
    });
});
