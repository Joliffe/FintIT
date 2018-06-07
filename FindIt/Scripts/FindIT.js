$('#menu-toggle').click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

function LoadImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#Image')
                .attr('src', e.target.result)
                .width(150)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function ShowPopUp(enterpriseID) {
    var url = "Enterprise/GetEnterpriseByID?enterpriceID=" + enterpriseID

    $("#ModalTile").html("Descripcion de la empresa!");
    $("#mymodal").appendTo("body").modal("show");

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            var obj = JSON.parse(data);

        }
    })
}