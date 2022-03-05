export const initializeSlider = (sliderId, options, prevBtn, nextBtn) => {
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
    document.querySelectorAll(sliderId).forEach((slider, index) => {
      let newSliderId = `${sliderId}_${index}`;

      slider.setAttribute("id", newSliderId.replace("#", ""));

      const swiper = new Swiper(newSliderId, options);

      if (prevBtn && nextBtn) {
        const prev = slider.parentNode.querySelector(prevBtn);
        const next = slider.parentNode.querySelector(nextBtn);

        prev.addEventListener("click", () => {
          swiper.slidePrev();
        });

        next.addEventListener("click", () => {
          swiper.slideNext();
        });
      }
    });
  }
};

export const toggleOverflowClass = (htmlEl) => {
  htmlEl.classList.toggle("overflow-hidden");
};

export const debounce = (func, timeout = 300) => {
  let timer;
  return (...args) => {
    clearTimeout(timer);
    timer = setTimeout(() => {
      func.apply(this, args);
    }, timeout);
  };
};

export const detectBodyClass = (extraClass, conditionClass) => {
  if (document.querySelector(conditionClass)) {
    document.body.classList.add(extraClass);
  }
};

export const closeBlockIfClickOutside = (closedBlock, controlClass) => {
  // Close the dropdown if the user clicks outside of it
  document.addEventListener("click", function (event) {
    if (!event.target.matches(controlClass)) {
      if (closedBlock.classList.contains("shown")) {
        closedBlock.classList.remove("shown");
      }
    }
  });
};

export const closeParallelBlock = (
  currentBlock,
  parallelBlockClass,
  conditionClass
) => {
  const parallelBlocks = document.querySelectorAll(parallelBlockClass);

  if (currentBlock.classList.contains(conditionClass)) {
    parallelBlocks.forEach((item) => item.classList.add("d-none"));
  } else {
    parallelBlocks.forEach((item) => item.classList.remove("d-none"));
  }

  if (window.innerWidth > 640) {
    parallelBlocks.forEach((item) => item.classList.remove("d-none"));
  }
};

export const removeDuplicates = (array) => {
  array.splice(0, array.length, ...new Set(array));
};
 
