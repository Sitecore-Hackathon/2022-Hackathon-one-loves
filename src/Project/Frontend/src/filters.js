import { closeParallelBlock } from "./_helpers";
import { fetchData } from "./api-service";
import { renderNewTeamMembers, renderNewJobItems } from "./renderNewNodes";
// filters

document.addEventListener("DOMContentLoaded", function () {
  function setFilterWrapperPadding() {
    if (
      window.innerWidth > 640 &&
      document.querySelector(".app-filter.shown .app-filter-result--mob")
    ) {
      document.querySelector(".app-filters-wrapper").style.paddingBottom = `${
        document.querySelector(".app-filter.shown .app-filter-result--mob")
          .offsetHeight
      }px`;
    } else {
      document.querySelector(
        ".app-filters-wrapper"
      ).style.paddingBottom = `0px`;
    }
  }

  function removeFilterWrapperPadding() {
    if (
      document.querySelector(".app-filters-wrapper").style.paddingBottom !==
      "0px"
    ) {
      document.querySelector(
        ".app-filters-wrapper"
      ).style.paddingBottom = `0px`;
    }
  }

  // detect active filters group
  function detectActiveFilters(activeFilter) {
    const activeGroupItems = document.querySelectorAll(`[data-filter-group]`);

    activeGroupItems.forEach((item) => {
      if (item.getAttribute("data-filter-group") === activeFilter) {
        item.classList.add("shown");
      } else {
        item.classList.remove("shown");
      }
    });
  }

  function controlFilters(data) {
    let activeFilter = null;

    const filters = document.querySelectorAll(".app-filter");
    const mobBtn = document.querySelector(".app-filter-btn--mobile");
    const filtersWrapper = document.querySelector(".app-filters-wrapper");
    const controlsWrapper = document.querySelector(".app-filters-wrapper");
    const defaultActiveFilter = !activeFilter && "position";
    const closeBtn = document.querySelector(".app-filter__close-btn");

    const hideFilters = () => {
      mobBtn.classList.remove("shown");
      controlsWrapper.classList.remove("active");
      detectActiveFilters(null);
      filters.forEach((item) => {
        item.classList.remove("d-block");
        item.classList.remove("shown");
      });
      closeParallelBlock(mobBtn, ".app-filter-search", "shown");
      removeFilterWrapperPadding();
    };

    const showFilters = () => {
      mobBtn.classList.add("shown");
      controlsWrapper.classList.add("active");
      filters.forEach((item) => {
        if (
          item.querySelector(".app-filter-btn").getAttribute("name") ===
          defaultActiveFilter
        ) {
          item.classList.add("d-block");
          item.classList.add("shown");
        } else {
          item.classList.add("d-block");
        }
      });

      detectActiveFilters(defaultActiveFilter);
      closeParallelBlock(mobBtn, ".app-filter-search", "shown");
    };

    if (filters) {
      filters.forEach((el) => {
        const btn = el.querySelector(".app-filter-btn");

        btn.addEventListener("click", () => {
          const btnName = btn.getAttribute("name");
          if (btnName !== activeFilter) {
            activeFilter = btnName;
            el.classList.add("shown");
            filtersWrapper.classList.add("active");
            setTimeout(() => setFilterWrapperPadding(), 0);
            detectActiveFilters(activeFilter);
          } else {
            activeFilter = null;
            filtersWrapper.classList.remove("remove");
            detectActiveFilters(activeFilter);
            removeFilterWrapperPadding();
            el.classList.remove("shown");
          }

          filters.forEach(
            (d) =>
              d.querySelector(".app-filter-btn").getAttribute("name") !==
                activeFilter && d.classList.remove("shown")
          );
        });

        document.addEventListener("click", function (event) {
          if (
            !event.target.matches(".app-filter-btn") &&
            !event.target.matches(".app-filter-result-btn") &&
            window.innerWidth > 640
          ) {
            if (el.classList.contains("shown")) {
              el.classList.remove("shown");
              detectActiveFilters(null);
            }
          }

          if (
            !event.target.matches(".app-filter-btn--mobile") &&
            !event.target.matches(".app-filter-result-btn") &&
            !event.target.matches(".app-filter-btn")
          ) {
            hideFilters();
          }
        });
      });

      if (closeBtn) {
        closeBtn.addEventListener("click", () => {
          hideFilters();
        });
      }

      if (mobBtn) {
        mobBtn.addEventListener("click", function () {
          if (this.classList.contains("shown")) {
            hideFilters();
          } else {
            showFilters();
          }
        });
      }
    }
  }

  function controlFilterSearch() {
    const filterSearch = document.querySelectorAll(".app-filter-search");

    if (filterSearch) {
      filterSearch.forEach((el) => {
        const btn = el.querySelector(".app-filter-search__search-mob-btn");
        const closeBtn = el.querySelector(".app-filter-search__close-btn");

        closeBtn.addEventListener("click", () => {
          el.classList.toggle("shown");
          closeParallelBlock(el, ".app-filter__filter-mob-section", "shown");
        });

        btn.addEventListener("click", () => {
          el.classList.toggle("shown");
          closeParallelBlock(el, ".app-filter__filter-mob-section", "shown");
        });
      });
    }
  }

  function controlInput(url, params, renderNewItemsFunc) {
    const input = document.querySelector(".app-filter-search__search-input");

    if (input) {
      input.addEventListener("change", (e) => {
        params.text = e.target.value;
        params.pageNumber = 0;
        localStorage.setItem("pageNumber", 1);
        localStorage.setItem("activeFilter", JSON.stringify(params));

        fetchData(url, params, renderNewItemsFunc);
      });
    }
  }

  function controlFiltersView($filterBlockWidth) {
    const appFilters = document.querySelectorAll(".app-filter");
    const appSearch = document.querySelector(".app-filter-search");

    const filtersWrapper = document.querySelector(".app-filters-wrapper");
    const mobSection = document.querySelector(
      ".app-filter__filter-mob-section"
    );

    if ($filterBlockWidth < 611) {
      if (filtersWrapper.classList.contains("active")) {
        appSearch.classList.add("d-none");
        appFilters.forEach((item) => item.classList.add("d-block"));
      } else {
        appSearch.classList.remove("d-none");
      }
    }

    if ($filterBlockWidth > 610) {
      if (filtersWrapper.classList.contains("active")) {
        appSearch.classList.remove("d-none");
      }

      if (appSearch.classList.contains("shown")) {
        appSearch.classList.remove("shown");
        mobSection.classList.remove("d-none");
        appFilters.forEach((item) => item.classList.remove("d-none"));
      }
    }
  }
  // FILTERS HANDLES
  function controlFilterOptionsBtns(
    resultBlock,
    url,
    params,
    renderNewItemsFunc,
    isSingleFilter
  ) {
    const btns = resultBlock.querySelectorAll(".app-filter-result-btn");
    let activeValue = "";
    const extraParam = resultBlock.getAttribute("data-filter");

    const setActiveItem = () => {
      btns.forEach((item) => {
        if (item.getAttribute("name") === activeValue) {
          item.classList.add("accent-active-item");
        } else {
          item.classList.remove("accent-active-item");
        }
      });
    };

    btns.forEach((item) => {
      item.addEventListener("click", () => {
        activeValue = item.getAttribute("name");
        setActiveItem();
        params[extraParam] = activeValue;
        params.pageNumber = 0;
        localStorage.setItem(extraParam, activeValue);
        localStorage.setItem("pageNumber", 1);

        params = isSingleFilter
          ? {
              ...params,
              [extraParam]: localStorage.getItem(extraParam),
            }
          : {
              ...params,
              location: localStorage.getItem("location"),
              position: localStorage.getItem("position"),
            };
        setParamsToLocalStorage("activeFilter", extraParam, params); 
        delete params.activeFilter;
        fetchData(url, params, renderNewItemsFunc);
      });
    });
  }

  function setParamsToLocalStorage(key, paramKey, value) {
    value.activeFilter = paramKey;
    localStorage.setItem(key, JSON.stringify(value));
  }

  // THE LIST OF FUNCTION CALLS
  if (document.querySelectorAll(".app-filter").length !== 0) {
    const resizeObserver = new ResizeObserver((entries) => {
      for (let entry of entries) {
        //width of the filter wrapper , 610px - mob view
        controlFiltersView(entry.contentRect.width);

        if (entry.contentRect.width > 610) {
          setFilterWrapperPadding();
        } else {
          removeFilterWrapperPadding();
        }
      }
    });

    // control common controls behavior
    localStorage.clear();
    //initial
    localStorage.pageNumber = 1;
    controlFilterSearch();
    controlFilters();
    resizeObserver.observe(document.querySelector(".app-filters-wrapper"));

    // add action call on filters buttons

    if (document.querySelector(".team-overview")) {
      // TEAM OVERVIEW
      const teamOverviewCount = 18;
      controlFilterOptionsBtns(
        document.querySelector(".app-filter-result[data-filter='location']"),
        `${window.location.origin}/api/getteamdetails?`,
        {
          count: teamOverviewCount,
          language: document.documentElement.lang,
        },
        renderNewTeamMembers,
        true
      );
      controlInput(
        `${window.location.origin}/api/getteamdetails?`,
        {
          count: teamOverviewCount,
          language: document.documentElement.lang,
        },
        renderNewTeamMembers
      );
    }

    if (document.querySelector(".all-jobs")) {
      // JOBS OVERVIEW
      const jobsOverviewCont = 21;

      controlFilterOptionsBtns(
        document.querySelector(".app-filter-result[data-filter='location']"),
        `${window.location.origin}/api/getjobdetails?`,
        {
          count: jobsOverviewCont,
          language: document.documentElement.lang,
        },
        renderNewJobItems,
        false
      );

      controlFilterOptionsBtns(
        document.querySelector(".app-filter-result[data-filter='position']"),
        `${window.location.origin}/api/getjobdetails?`,
        {
          count: jobsOverviewCont,
          language: document.documentElement.lang,
        },
        renderNewJobItems,
        false
      );

      controlInput(
        `${window.location.origin}/api/getjobdetails?`,
        {
          count: jobsOverviewCont,
          language: document.documentElement.lang,
        },
        renderNewJobItems
      );
    }
  }
});
