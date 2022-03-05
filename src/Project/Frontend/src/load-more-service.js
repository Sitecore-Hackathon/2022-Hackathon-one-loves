import { fetchData } from "./api-service";
import { renderNewTeamMember } from "./renderNewNodes";

export const loadMoreOnClick = (url, params, btnSelector, renderFunc) => {
  const loadBtn = document.querySelector(btnSelector);
  let PAGE_NUM = 1;

  if (loadBtn) {
    loadBtn.addEventListener("click", () => {
      params.pageNumber = PAGE_NUM;
      fetchData(url, params, renderFunc);
      PAGE_NUM++;
    });
  }
};

export const loadMoreOnClickWithFilters = (
  url,
  params,
  btnSelector,
  renderFunc
) => {
  const loadBtn = document.querySelector(btnSelector);
  let PAGE_NUM;

  if (loadBtn) {
    loadBtn.addEventListener("click", () => {
      const requestedParams = localStorage.getItem("activeFilter")
        ? JSON.parse(localStorage.getItem("activeFilter"))
        : params;
      delete requestedParams.activeFilter;

      PAGE_NUM =
        params.pageNumber !== 0
          ? Number(localStorage.getItem("pageNumber"))
          : params.pageNumber;
      requestedParams.pageNumber = PAGE_NUM;
      fetchData(url, requestedParams, renderFunc);
      PAGE_NUM++;
      localStorage.setItem("pageNumber", PAGE_NUM);
    });
  }
};

//container
export const loadMoreOnScroll = (url, containerClass, initialParams) => {
  let DB = [];
  let isShowMore = true;

  const container = document.querySelector(containerClass);
  const initDB = (data) => {
    DB = data.Items;
    isShowMore = data.ShowLoadMore;
  };

  if (container) {
    function loadItems() {
      const params = localStorage.getItem("activeFilter")
        ? JSON.parse(localStorage.getItem("activeFilter"))
        : initialParams;
      delete params.activeFilter;
      let PAGE_NUM =
        params.pageNumber === 0 && localStorage.getItem("pageNumber")
          ? localStorage.getItem("pageNumber")
          : params.pageNumber;

      params.pageNumber = PAGE_NUM;

      fetchData(url, params, initDB);
      PAGE_NUM++;
      localStorage.setItem("pageNumber", PAGE_NUM);

      if (DB.length !== 0) {
        for (let i = 0; i < DB.length; i++) {
          container.appendChild(renderNewTeamMember(DB[i]));
        }
      } else {
        return false;
      }
    }

    // loadItems();
    // listen for scroll event and load more items if we reach the bottom of window

    window.addEventListener("scroll", () => {
      // window.scrollY - scrolled from top
      // window.innerHeight - visible part of screen
      if (
        window.scrollY + window.innerHeight >=
        document.documentElement.scrollHeight
      ) {
        if (isShowMore) {
          loadItems();
        }
      }
    });
  }
};
