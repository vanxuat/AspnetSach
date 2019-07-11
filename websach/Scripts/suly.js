$(document).ready(function () {
    $("#target").submit(function (event) {
        event.preventDefault();
        var employee = new Object();
        employee.nguoidung = $('#IDNguiDung').val()
        employee.matkhau = $('#IDMatKhau').val()
       
            $.ajax({
                type: "POST",
                url: "/LoginUser/DangNhap",
                data: JSON.stringify(employee),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response == true) {

                        window.location.assign('/Home/Index')

                    }
                    else {

                        $("#canhbao").removeClass("d-none")
                    }
                }
            });
       
    });

});