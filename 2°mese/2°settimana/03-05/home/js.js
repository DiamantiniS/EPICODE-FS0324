$(document).ready(function () {
  $("#carouselExample").on("slide.bs.carousel", function (e) {
    var windowWidth = $(window).width();
    var itemPerSlide;
    if (windowWidth < 576) {
      // Modalità smartphone
      itemPerSlide = 2;
    } else if (windowWidth < 992) {
      // Modalità tablet
      itemPerSlide = 4;
    } else {
      // Modalità desktop
      itemPerSlide = 6;
    }
    var items = $(".carousel-item").length;
    var totalSlides = Math.ceil(items / itemPerSlide);
    if (e.direction == "left") {
      $(this).carousel("next");
      if ($(this).find(".carousel-item.active").index() == totalSlides - 1) {
        $(this).carousel("pause");
      }
    }
    if (e.direction == "right") {
      $(this).carousel("prev");
      if ($(this).find(".carousel-item.active").index() == 0) {
        $(this).carousel("pause");
      }
    }
  });
});
