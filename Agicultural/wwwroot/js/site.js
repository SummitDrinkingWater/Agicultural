// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#btn").click(function () {
        var dd = {};
        dd.qrmod = $("#qr").val();
        $.ajax({
            url: "/Home/Jav",
            type: "post",
            contentType: 'application/json',
            data: JSON.stringify(dd)
        }).done(function (b64) {
            $("#qrs").attr("src", "data:image/jpeg;base64," + b64)

        })
    });
});



