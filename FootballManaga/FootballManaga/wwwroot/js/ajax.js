    $(document).ready(function () {
        $("#search").keyup(function () {
            $.ajax({
                url: "Index",
                data: { type: $("#searh").val() },
                type: "POST",
                success: function (data) {
                    $("#table").html(data);
                }
            });
        });

    });
