// Check form validation
function formValidate(form) {
    form.removeData("validator");
    form.removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
    if (!form.valid())
        return false;
    else
        return true;
}