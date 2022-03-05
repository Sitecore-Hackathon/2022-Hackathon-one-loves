import { initializeSlider } from "./_helpers";

function replaceAnimationToCircleSegments() {
  document.querySelector("body").style.overflow = "auto";
  document.getElementById("circleAnimation").classList.remove("hidden");
  document.getElementById("lottieAnimation").classList.add("hidden");
}

function detectActiveItem(nodes, activeSection) {
  nodes.forEach((item) => {
    if (item.getAttribute("data-section") === activeSection) {
      item.classList.add("active");
    } else {
      item.classList.remove("active");
    }
  });
}

function setAllActiveItems(dots, labels, activeSection) {
  if (activeSection === "all") {
    dots.forEach((item) => {
      item.classList.add("active");
    });

    labels.forEach((item) => {
      item.classList.remove("active");
    });
  }
}

document.addEventListener("DOMContentLoaded", function (event) {
  if (document.querySelector(".business-segments-animation")) {
    const POINTS = document.querySelectorAll(".sections-circle__point");
    const LABELS = document.querySelectorAll(".sections-circle__label");
    const SECTIONS = document.querySelectorAll(
      ".business-segments-animation__box"
    );

    //initialize fadeUp animation for sections
    AOS.init();

    // animation replacement
    document.querySelector("body").style.overflow = "hidden";
    document.getElementById("circleAnimation").classList.add("hidden");
    setTimeout(replaceAnimationToCircleSegments, 6000);

    // detect active section on scroll
    const SECTIONS_OBSERVER = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            const activeSection = entry.target.getAttribute("data-section");

            detectActiveItem(POINTS, activeSection);
            detectActiveItem(LABELS, activeSection);
            detectActiveItem(SECTIONS, activeSection);
            setAllActiveItems(POINTS, LABELS, activeSection);
          }
        });
      },
      { threshold: 0.9 }
    );

    SECTIONS.forEach((div) => SECTIONS_OBSERVER.observe(div));

    initializeSlider("#business-segments-swiper-id", {
      direction: "vertical",
      slidesPerView: 1,
      loop: true,
      mousewheel: true,
      pagination: {
        el: ".swiper-pagination",
        clickable: true
      },
    });
  }
});
