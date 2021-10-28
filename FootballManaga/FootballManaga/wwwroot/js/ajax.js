    $(document).ready(function () {
        $("#search").keyup(function () {
            $.ajax({
                url: "Search",
                data: { name: $("#searh").val() },
                type: "POST",
                success: function (data) {
                    $("#table").html(data);
                }
            });
        });

    });
