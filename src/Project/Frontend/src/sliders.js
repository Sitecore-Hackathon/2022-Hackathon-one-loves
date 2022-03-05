import { initializeSlider } from "./_helpers";

document.addEventListener("DOMContentLoaded", function () {
  function setYearTimeline(data, slideIndex) {
    document.querySelector(
      ".year-slider__timeline-year.year-slider__timeline-year--prev"
    ).innerHTML = slideIndex === 0 ? "" : data[slideIndex - 1];
    document.querySelector(
      ".year-slider__timeline-year.year-slider__timeline-year--current"
    ).innerHTML = data[slideIndex === 0 ? 0 : slideIndex];
    document.querySelector(
      ".year-slider__timeline-year.year-slider__timeline-year--next"
    ).innerHTML = slideIndex === data.length - 1 ? "" : data[slideIndex + 1];
  }

  function initializeYearSlider() {
    const YEARS = [];

    if (document.querySelector("#year-swiper")) {
      if (document.querySelector(".isEditorMode")) {
        const swiper = document.querySelectorAll(".swiper-container");
        const swiperWrapper = document.querySelectorAll(".swiper-wrapper");

        if (swiper) {
          swiper.forEach((item) => (item.style.overflow = "visible"));
          swiperWrapper.forEach((item) => {
            item.style.display = "flex";
            item.style.flexDirection = "column";
          });
        }
      } else {
        document
          .querySelectorAll(".year-slider__year")
          .forEach((item) => YEARS.push(item.getAttribute("value")));

        const swiper = new Swiper("#year-swiper", {
          slidesPerView: 1,
          grabCursor: true,
          centeredSlides: true,
        });
        swiper.on("realIndexChange", () =>
          setYearTimeline(YEARS, swiper.realIndex)
        );
        const prev = document.querySelector(".year-slider__slider-btn.prev");
        const next = document.querySelector(".year-slider__slider-btn.next");

        prev.addEventListener("click", () => {
          swiper.slidePrev();
          setYearTimeline(YEARS, swiper.realIndex);
        });

        next.addEventListener("click", () => {
          swiper.slideNext();
          setYearTimeline(YEARS, swiper.realIndex);
        });

        setYearTimeline(YEARS, swiper.realIndex);
      }
    }
  }

  if (document.querySelector("#swiper")) {
    initializeSlider(
      "#swiper",
      {
        slidesPerView: 1,
        grabCursor: true,
        freeMode: true,
        mousewheel: true,
        centeredSlides: true,
        loop: true,
      },
      ".techtalk__slider-btn.prev",
      ".techtalk__slider-btn.next"
    );
  }

  if (document.querySelector("#gallery-swiper")) {
    initializeSlider(
      "#gallery-swiper",
      {
        slidesPerView: "auto",
        centeredSlides: true,
        grabCursor: true,
        loop: true,
        mousewheel: true,
        spaceBetween: 15,
      },
      ".gallery-slider__slider-btn.prev",
      ".gallery-slider__slider-btn.next"
    );
  }

  initializeYearSlider();

  if (document.querySelector("#social-gallery-swiper")) {
    initializeSlider(
      "#social-gallery-swiper",
      {
        slidesPerView: 2,
        grabCursor: true,
        loop: true,
        spaceBetween: 20,
        centeredSlides: true,
        effect: "coverflow",
        mousewheel: true,
        coverflowEffect: {
          rotate: 0,
          stretch: 0,
          depth: 100,
          modifier: 1,
          slideShadows: false,
        },
        breakpoints: {
          // when window width is >= 640px
          640: {
            slidesPerView: 3,
            centeredSlides: true,
            spaceBetween: 48,
          },
        },
      },
      ".social-gallery__slider-btn.prev",
      ".social-gallery__slider-btn.next"
    );
  }
});
