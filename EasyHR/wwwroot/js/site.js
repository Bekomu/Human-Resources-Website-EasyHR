// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.







$(document).ready(function () {
    $(".sadeceHarf").keypress(function (event) {
        var inputValue = event.charCode;
        var trHarf = event.key;
        if (!(inputValue >= 65 && inputValue <= 90)
            && !(inputValue >= 97 && inputValue <= 122)
            && (trHarf != "ü" && trHarf != "Ü")
            && (trHarf != "ö" && trHarf != "Ö")
            && (trHarf != "ç" && trHarf != "Ç")
            && (trHarf != "ş" && trHarf != "Ş")
            && (trHarf != "ğ" && trHarf != "Ğ")
            && (trHarf != "İ" && trHarf != "ı")
            && (inputValue != 32 && inputValue != 0)) {
            event.preventDefault();
        }
    });

    // SADECE TÜRKÇE HARFLER VE BOŞLUK
});

$("#inputUcret").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 3) {
        evt.preventDefault();
    }
});

$("#inputKullaniciSayisi").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 4) {
        evt.preventDefault();
    }
});

$("#inputKullanilmaSuresi").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 3) {
        evt.preventDefault();
    }
});

$(".mersis").keypress( function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 11) {
        evt.preventDefault();
    }
});

$(".vergiNo").keypress( function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 10) {
        evt.preventDefault();
    }
});

$(".tcNo").keypress( function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 11) {
        evt.preventDefault();
    }
});

$(".telefon").keypress( function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 11) {
        evt.preventDefault();
    }
});

$(".maas").keypress( function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 6) {
        evt.preventDefault();
    }
});

$(".harcama").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 5) {
        evt.preventDefault();
    }
});

$(".avans").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 6) {
        evt.preventDefault();
    }
});

$(".para").keypress( function (evt) {
    // 0 for null values
    // 8 for backspace
    // 48-57 for 0-9 numbers

    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57) {
        evt.preventDefault();
    }
});

$(".kkarti").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 16) {
        evt.preventDefault();
    }
});

$(".cvc").keypress(function (evt) {
    if (evt.which != 8 && evt.which != 0 && evt.which < 48 || evt.which > 57 || $(this).val().length === 3) {
        evt.preventDefault();
    }
});



function IzinOnayla(izinId) {
    var baslangic = $(`#baslangic${izinId}`).text();
    var bitis = $(`#bitis${izinId}`).text();
    var gun = $(`#gun${izinId}`).text();
    var tamAd = $(`#tamAd${izinId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${baslangic} - ${bitis} tarihleri arasında almak istediği ${gun} günlük izin talebini onaylıyor musunuz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, onayla!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { izinId: izinId },
                url: '/TalepYonet/IzinOnayla',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep onaylandı, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Izinler';
                },
                error: function () {

                }
            });
        }
    });
}

function IzinReddet(izinId) {
    var baslangic = $(`#baslangic${izinId}`).text();
    var bitis = $(`#bitis${izinId}`).text();
    var gun = $(`#gun${izinId}`).text();
    var tamAd = $(`#tamAd${izinId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${baslangic} - ${bitis} tarihleri arasında almak istediği ${gun} günlük izin talebini reddetmek istediğinize emin misiniz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, reddet!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { izinId: izinId },
                url: '/TalepYonet/IzinReddet',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep onaylandı, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Izinler';
                },
                error: function () {

                }
            });
        }
    });
}

function HarcamaOnayla(harcamaId) {
    var tamAd = $(`#tamAd${harcamaId}`).text();
    var harcamaTutari = $(`#harcamaTutari${harcamaId}`).text();
    var tarih = $(`#tarih${harcamaId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${tarih} tarihli ${harcamaTutari} tutarındaki harcama talebini onaylıyor musunuz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, onayla!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { harcamaId: harcamaId },
                url: '/TalepYonet/HarcamaOnayla',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep onaylandı, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Harcamalar';
                },
                error: function () {

                }
            });
        }
    });
}

function HarcamaReddet(harcamaId) {
    var tamAd = $(`#tamAd${harcamaId}`).text();
    var harcamaTutari = $(`#harcamaTutari${harcamaId}`).text();
    var tarih = $(`#tarih${harcamaId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${tarih} tarihli ${harcamaTutari} tutarındaki harcama talebini reddetmek istediğinize emin misiniz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, reddet!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { harcamaId: harcamaId },
                url: '/TalepYonet/HarcamaReddet',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep onaylandı, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Harcamalar';
                },
                error: function () {

                }
            });
        }
    });
}

function Onayla(avansId) {
    var tamAd = $(`#tamAd${avansId}`).text();
    var avansTutari = $(`#avansTutari${avansId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${avansTutari} tutarındaki avans talebini onaylıyor musunuz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, onayla!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { avansId: avansId },
                url: '/TalepYonet/AvansOnayla',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep onaylandı, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Avanslar';
                },
                error: function () {

                }
            });
        }
    });
}

function Reddet(avansId) {
    var tamAd = $(`#tamAd${avansId}`).text();
    var avansTutari = $(`#avansTutari${avansId}`).text();

    Swal.fire({
        title: 'Emin misiniz?',
        text: `${tamAd} adlı personelin ${avansTutari} tutarındaki avans talebini reddetmek istediğinize emin misiniz?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, reddet!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "post",
                dataType: "html",
                data: { avansId: avansId },
                url: '/TalepYonet/AvansReddet',
                success: function () {
                    Swal.fire({
                        timer: 5000,
                        title: '',
                        text: 'Talep reddedildi, sayfaya yönlendiriliyorsunuz.',
                        icon: 'success',
                    })
                    window.location = '/TalepYonet/Avanslar';
                },
                error: function () {

                }
            });
        }
    });
}

//login ekranı
function password_show_hide() {
    var x = document.getElementById("password");
    var show_eye = document.getElementById("show_eye");
    var hide_eye = document.getElementById("hide_eye");
    hide_eye.classList.remove("d-none");
    if (x.type === "password") {
        x.type = "text";
        show_eye.style.display = "none";
        hide_eye.style.display = "block";
    } else {
        x.type = "password";
        show_eye.style.display = "block";
        hide_eye.style.display = "none";
    }
}


function Onizle(fileName) {
    event.preventDefault();
    $.ajax({
        type: 'POST',
        data: { fileName: fileName },
        url: "/Display/Index",
        success: function (response) {
            if (response == 'Dosya bulunamadı!') {
                alert(response);
            } else {
                window.open("/Display/Show?path=" + response, "_blank");
            }
        },
    });
};

// FOTO YÜKLEME ÖNİZLEME

var preview = document.getElementById("preview");
var def = document.getElementById("def");
var imageName = document.getElementById("imageName");
var imageSize = document.getElementById("imageSize");
var imageType = document.getElementById("imageType");
var input = document.getElementById("imageInput");
var image = document.getElementById("image");

function readFile(file) {
    var reader = new FileReader();

    // when the file is loaded
    reader.onload = function (e) {
        image.src = e.target.result; // base64 string
    }

    // read file as base64 string
    reader.readAsDataURL(file);
}

input.onchange = function (e) {
    if (input.files && input.files[0]) {
        var f = input.files[0];
        readFile(f);
        preview.classList.remove("hide");
        def.classList.add("hide");
    }
    else {
        preview.classList.remove("hide");
        def.classList.remove("hide");
    }
};
// FOTO YÜKLEME ÖNİZLEME

