import {
  toggleOverflowClass,
  debounce,
  detectBodyClass,
  closeBlockIfClickOutside,
} from "./_helpers";
import "./sliders";
import "./filters";
import "./business-segments-animation";
import "./load-more";

document.addEventListener("DOMContentLoaded", function (event) {
  //global variables
  const langBtn = document.querySelector(".app-header__lang-control-btn");
  const langDropdown = document.querySelector(".app-header__lang-control");
  const langLinks = document.querySelectorAll(".app-header__lang-link");
  let activeLang = "en";
  let isMobileView = false;
  const headerBurgerBtn = document.querySelector(".app-header__burger-btn");
  const headerMobileDropdown = document.querySelector(
    ".app-header__mobile-nav"
  );
  const appHeader = document.querySelector(".app-header");

  function setActiveLang() {
    langBtn.querySelector(".current-lang").innerHTML = activeLang;
    langLinks.forEach((item) => {
      if (item.lang === activeLang) {
        item.classList.add("accent-active-item");
      } else {
        item.classList.remove("accent-active-item");
      }  
    });
  }

  function makeStickyHeader() {
    const header = document.querySelector(".app-header");
    let sticky = header.offsetTop;

    const toggleStickyView = () => {
      if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
      } else {
        header.classList.remove("sticky");
      }
    };

    toggleStickyView();
    window.addEventListener("scroll", () => toggleStickyView());
  }

  function toggleMobileView() {
    headerBurgerBtn.addEventListener("click", () => {
      if (isMobileView) {
        isMobileView = false;
      } else {
        isMobileView = true;
      }

      detectMobileView();
    });
  }

  function detectMobileView() {
    headerMobileDropdown.classList.toggle("shown");
    toggleOverflowClass(document.body);
    appHeader.classList.toggle("mobile-mode");
    headerBurgerBtn.innerHTML = `${
      isMobileView
        ? '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36"><g id="Icon/navigation/cross" fill-rule="evenodd" stroke="none" stroke-width="1"><path id="Path" d="M30 27.08l-9.18-9.1 9.09-9.17L27.08 6l-9.1 9.18-9.17-9.09L6 8.9l9.19 9.1-9.1 9.19L8.9 30l9.11-9.2 9.18 9.1z" transform="rotate(90 18 18)"/></g></svg>'
        : '<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36"><g id="Icon/navigation/burger" fill-rule="evenodd" stroke="none" stroke-width="1"><path id="Shape" d="M30 12H6V8h24v4zm0 4H6v4h24v-4zm0 8H6v4h24v-4z"/></g></svg>'
    }`;
  }

  function removeMobileViewOnResolutionChange() {
    if (isMobileView) {
      isMobileView = false;
      detectMobileView();
    }
  }

  function toggleSearchOverlay() {
    const searchOverlay = document.getElementById("search-overlay");
    const openBtn = document.querySelectorAll(".tags-navigation__search-btn");
    const closeBtn = document.querySelector(
      "#search-overlay .search-overlay__close-btn"
    );

    openBtn.forEach((item) =>
      item.addEventListener("click", () => {
        searchOverlay.classList.add("shown");
        toggleOverflowClass(document.body);
      })
    );

    closeBtn.addEventListener("click", () => {
      searchOverlay.classList.remove("shown");
      toggleOverflowClass(document.body);
    });

    document.addEventListener("keyup", (e) => {
      if (e.key === "Escape") {
        searchOverlay.classList.remove("shown");
        toggleOverflowClass(document.body);
      }
    });
  }

  function toggleLangDropdown() {
    setActiveLang();

    langBtn.addEventListener("click", () => {
      langDropdown.classList.toggle("shown");
    });

    langLinks.forEach((item) =>
      item.addEventListener("click", () => {
        document.querySelector("html").setAttribute("lang", item.lang);
        activeLang = item.lang;
        setActiveLang();
      })
    );

    closeBlockIfClickOutside(
      langDropdown,
      ".app-header__lang-control-btn-cover"
    );
  }

  function copyToClipboard() {
    const cb = navigator.clipboard;
    cb.writeText(window.location.href).then(() => console.log("Text copied"));
  }

  function backNavigation() {
    const backBtn = document.querySelector(".back-btn");
    if (backBtn) {
      backBtn.addEventListener("click", () => window.history.back());
    }
  }

  function controlSearchButtonVisibility() {
    const tagNav = document.querySelector(".tags-navigation");
    const searchBtn = document.querySelector(
      ".app-header__mobile-menu .tags-navigation__search-btn"
    );
    if (window.innerWidth < 641 && !tagNav) {
      searchBtn.style.display = "none";
    }
  }

  function toggleAccordion(accordionBtnClass) {
    const acc = document.querySelectorAll(accordionBtnClass);
    if (acc) {
      let i;

      for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
          this.classList.toggle("active");

          const panel = this.nextElementSibling;
          panel.classList.toggle("shown");
        });
      }
    }
  }

  function showMoreBtn(listClass, btnClass) {
    const btn = document.querySelector(btnClass);
    const list = document.querySelector(listClass);

    if (btn) {
      btn.addEventListener("click", () => {
        Array.from(list.children).forEach((node) =>
          node.classList.toggle("shown")
        );
      });
    }
  }

  function toggleSearchHeader() {
    const searchHeader = document.querySelector(".search-overlay__top");
    const overlay = document.querySelector(".search-overlay");
    let searchHeaderOffset = window.innerWidth > 640 ? 80 : 12;

    if (searchHeader) {
      const toggleStickyView = () => {
        if (overlay.scrollTop > searchHeaderOffset) {
          overlay.classList.add("fixed");
        } else {
          overlay.classList.remove("fixed");
        }
      };

      toggleStickyView();
      overlay.addEventListener("scroll", () => toggleStickyView());
    }
  }

  function adjustJobLinkStyles() {
    const links = document.querySelectorAll(".job-link");

    if (links.length !== 0) {
      links.forEach((item, index) => {
        item.addEventListener("focus", () => {
          if (index != 0) {
            const indexToReduce = window.innerWidth > 640 ? 3 : 1;
            links[index - indexToReduce].classList.add("focused-class");
          }
        });

        item.addEventListener("blur", () => {
          links.forEach((el) => el.classList.remove("focused-class"));
        });
      });
    }
  }

  adjustJobLinkStyles();
  // the list of function calls
  showMoreBtn(".faq__list", ".faq__cta");
  showMoreBtn(".all-jobs__list", ".all-jobs__cta");
  toggleAccordion(".faq__btn");
  toggleLangDropdown();
  makeStickyHeader();
  toggleMobileView();

  if (document.querySelector("#copy-post-url-btn")) {
    document
      .querySelector("#copy-post-url-btn")
      .addEventListener("click", () => copyToClipboard());
  }
  if (document.querySelector("#search-overlay .search-overlay__close-btn")) {
    toggleSearchOverlay();
  }

  backNavigation();
  controlSearchButtonVisibility();

  detectBodyClass("transparent-header", ".media-header");
  detectBodyClass("jobs-overview", ".faq");

  toggleSearchHeader();

  // the list of functions detection on resize
  window.addEventListener("resize", () => {
    debounce(controlSearchButtonVisibility());
    if (window.innerWidth > 640) {
      debounce(removeMobileViewOnResolutionChange());
    }
  });
});
