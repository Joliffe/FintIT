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