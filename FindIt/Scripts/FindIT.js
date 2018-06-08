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
            document.getElementById("PopUp").innerHTML = '<div class="gallery_product col-lg-4 col-md-4 col-sm-4 col-xs-6 filter hdpe" style="text-align:center">' +
                '<label class="GalleryImageTitle" for= "wqwerqw" > wqwerqw</label>' +
                '<img src="/Images/descarga.jpg" class="img-responsive" id="gallery-image" onclick="ShowPopUp(402240376)">' +
                '<label for="fdjkyuefdghfgj">fdjkyuefdghfgj</label>' +
                '</div>';
        }
    })
}