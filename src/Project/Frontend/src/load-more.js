import { loadMoreOnClick, loadMoreOnClickWithFilters, loadMoreOnScroll } from "./load-more-service";
import { renderNewBlogTeasers, renderNewJobItems } from "./renderNewNodes";

loadMoreOnClick(
  `${window.location.origin}/api/getblogposts?`,
  {
    tag: "",
    count: 3,
    language: document.documentElement.lang,
  },
  ".post-suggestions__cta",
  renderNewBlogTeasers
);

loadMoreOnClickWithFilters(
  `${window.location.origin}/api/getjobdetails?`,
  {
    location: localStorage.getItem('location'),
    position: localStorage.getItem("position"),
    count: 21,
    pageNumber: 1,
    language: document.documentElement.lang,
  }, 
  ".all-jobs__cta",
  renderNewJobItems
);

loadMoreOnScroll(
  `${window.location.origin}/api/getteamdetails?`, 
  ".team-overview__list",
  {
    location: localStorage.getItem('location'),
    count: 18,
    pageNumber: 1,
    language: document.documentElement.lang,
  }
);
