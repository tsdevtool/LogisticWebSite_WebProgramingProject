// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const $dropdown = $(".dropdown");
const $dropdownToggle = $(".dropdown-toggle");
const $dropdownMenu = $(".dropdown-menu");
const showClass = "show";

$(window).on("load resize", function () {
    if (this.matchMedia("(min-width: 768px)").matches) {
        $dropdown.hover(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
        );
    } else {
        $dropdown.off("mouseenter mouseleave");
    }
});

$(window).on("load resize", function () {
    if (this.matchMedia("(max-width: 991px)").matches) {
        $dropdown.click(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
        );
    }

});

// bottom to top btn start //
var btn = $('#button');

$(window).scroll(function () {
    if ($(window).scrollTop() > 300) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});
btn.on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({
        scrollTop: 0
    }, '300');
});
// bottom to top btn end //
// preloader start //
$(window).on('load', function () {
    // Preloader
    $('.loader').fadeOut();
    $('.loader-mask').delay(350).fadeOut('slow');
});
// preloader end //
// skill bar start //
$(document).ready(function () {
    startAnimation();
    function startAnimation() {
        jQuery('.skills').each(function () {
            jQuery(this).find('.skillbar').animate({
                width: jQuery(this).attr('data-percent')
            }, 6000);
        });
    }
});
// skill bar end //

// owl carousel start //
$('#owl-carousel-testimonials4').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2,
            margin: 15
        },
        1000: {
            items: 2,
            margin: 30
        }
    }
})
$('#owl-carousel-testimonial2').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2,
            margin: 15
        },
        1000: {
            items: 2,
            margin: 30
        }
    }
})

$('#owl-carousel-two').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        },
        1000: {
            items: 2
        }
    }
})
var owl = $("#owl-carousel-two");
owl.owlCarousel();
$(".next-btn").click(function () {
    owl.trigger("next.owl.carousel");
});
$(".prev-btn").click(function () {
    owl.trigger("prev.owl.carousel");
});
$(".prev-btn").addClass("disabled");
$(owl).on("translated.owl.carousel", function (event) {
    if ($(".owl-prev").hasClass("disabled")) {
        $(".prev-btn").addClass("disabled");
    } else {
        $(".prev-btn").removeClass("disabled");
    }
    if ($(".owl-next").hasClass("disabled")) {
        $(".next-btn").addClass("disabled");
    } else {
        $(".next-btn").removeClass("disabled");
    }
});
// 


$(document).ready(function () {
    $('#owl-carousel-one').owlCarousel({
        loop: true,
        margin: 30,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    });
});

$('#owl-carouseltestimonial').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})
var owl = $("#owl-carouseltestimonial");
owl.owlCarousel();
$(".next-btn").click(function () {
    owl.trigger("next.owl.carousel");
});
$(".prev-btn").click(function () {
    owl.trigger("prev.owl.carousel");
});
$(".prev-btn").addClass("disabled");
$(owl).on("translated.owl.carousel", function (event) {
    if ($(".owl-prev").hasClass("disabled")) {
        $(".prev-btn").addClass("disabled");
    } else {
        $(".prev-btn").removeClass("disabled");
    }
    if ($(".owl-next").hasClass("disabled")) {
        $(".next-btn").addClass("disabled");
    } else {
        $(".next-btn").removeClass("disabled");
    }
});

$('#owl-carousel-portfolio').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 3,
            margin: 15
        },
        1000: {
            items: 3
        }
    }
})
$('#owl-carousel-services').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2,
            margin: 15
        },
        1000: {
            items: 3
        }
    }
})
$('#owl-carousel-customers').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2,
            margin: 20
        },
        1000: {
            items: 3,
            margin: 20
        },
        1100: {
            items: 3
        }
    }
})
$('#owl-carousel-latest-portfolio').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        420: {
            items: 2,
            margin: 10
        },
        768: {
            items: 3,
            margin: 15
        },
        1000: {
            items: 3,
            margin: 20
        },
        1100: {
            items: 4,
            margin: 40
        }
    }
})
$('#owl-carousel-portfolio3').owlCarousel({
    loop: true,
    margin: 30,
    nav: true,
    responsive: {
        0: {
            items: 1
        },
        430: {
            items: 2,
            margin: 15
        },
        768: {
            items: 3,
            margin: 15
        },
        1000: {
            items: 4,
            margin: 30
        }
    }
})
// owl carousels end //
// video script start //
window.document.onkeydown = function (e) {
    if (!e) {
        e = event;
    }
    if (e.keyCode == 27) {
        lightbox_close();
    }
}
function lightbox_open() {
    var lightBoxVideo = document.getElementById("VisaChipCardVideo");
    document.getElementById('light').style.display = 'block';
    document.getElementById('fade').style.display = 'block';
    lightBoxVideo.play();
}
function lightbox_close() {
    var lightBoxVideo = document.getElementById("VisaChipCardVideo");
    document.getElementById('light').style.display = 'none';
    document.getElementById('fade').style.display = 'none';
    lightBoxVideo.pause();
}
// video script end
// counter script start
$(document).ready(function () {

    var counters = $(".count");
    var countersQuantity = counters.length;
    var counter = [];

    for (i = 0; i < countersQuantity; i++) {
        counter[i] = parseInt(counters[i].innerHTML);
    }

    var count = function (start, value, id) {
        var localStart = start;
        setInterval(function () {
            if (localStart < value) {
                localStart++;
                counters[id].innerHTML = localStart;
            }
        }, 40);
    }

    for (j = 0; j < countersQuantity; j++) {
        count(0, counter[j], j);
    }
});



$('.count').each(function () {
    $(this).prop('Counter', 0).animate({
        Counter: $(this).text()
    }, {
        duration: 6000,
        easing: 'swing',
        step: function (now) {
            $(this).text(Math.ceil(now));
        }
    });
});
// counter script end
// search bar script 
$(document).ready(function () {
    $('a[href="#search"]').on('click', function (event) {
        $('#search').addClass('open');
        $('#search > form > input[type="search"]').focus();
    });
    $('#search, #search button.close').on('click keyup', function (event) {
        if (event.target == this || event.target.className == 'close' || event.keyCode == 27) {
            $(this).removeClass('open');
        }
    });
});
// //
// animation start //
AOS.init();
// animation end //