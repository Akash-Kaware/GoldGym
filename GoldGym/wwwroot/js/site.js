// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Image Upload Preview
function ShowImagePreview(input) {
    var validExtensions = ['jpeg', 'jpg', 'png'];
    if (input.files && input.files[0]) {
        var fileName = input.files[0].name;
        var fileNameExt = fileName.substr(fileName.lastIndexOf('.') + 1);
        if ($.inArray(fileNameExt, validExtensions) == -1) {
            alert("Please select valid profile photo.");
            input.value = null;
            $('#imagePreview').prop('src', '/images/default-avatar.png');
        }
        else {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imagePreview').prop('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0]);
        }
    }
}