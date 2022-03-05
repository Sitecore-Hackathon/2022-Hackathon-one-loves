export const renderNewTeamMember = (item) => {
  const link = document.createElement("a");
  link.classList.add("team-overview__employee-link");

  const imgWrapper = document.createElement("div");
  imgWrapper.classList.add("img-wrapper-stretch");

  const preview = document.createElement("img");

  const name = document.createElement("span");
  name.classList.add("team-overview__employee-name");

  const job = document.createElement("span");
  job.classList.add("team-overview__employee-job");

  link.setAttribute("href", item.Url);

  preview.setAttribute("src", item.ProfileImageUrl ? item.ProfileImageUrl : "");
  preview.setAttribute("alt", item.ProfileImageAltText);
  imgWrapper.appendChild(preview);

  name.innerHTML = item.Name;
  job.innerHTML = item.Position;

  // append node in a right order
  link.appendChild(imgWrapper);

  link.appendChild(name);
  link.appendChild(job);

  return link;
};

export const isLoadMoreFunction = (ShowLoadMore, wrapper) => {
  if(wrapper) {
    const btn = wrapper.querySelector('.show-more-btn');

    if(!ShowLoadMore) {
      btn.classList.add('hidden')
    } else {
      btn.classList.remove('hidden')
    }
  }
 }

export const renderNewTeamMembers = ({Items, ShowLoadMore}) => {
  const wrapper = document.querySelector(".team-overview__list");  
  if (Items.length !== 0) {
    wrapper.innerHTML = "";
    Items.forEach((item) => {
      wrapper.appendChild(renderNewTeamMember(item));
    });
  } else {
    wrapper.innerHTML = "no results";
  }
};

export const renderNewJobItems = ({Items, ShowLoadMore}) => {
  const wrapper = document.querySelector(".all-jobs__list");
  isLoadMoreFunction(ShowLoadMore,document.querySelector(".all-jobs"))
  if (Items.length !== 0) {
    wrapper.innerHTML = "";
    Items.forEach((item) => {
      // node declarations
      const link = document.createElement("a");
      link.classList.add("all-jobs__list-link", "job-link");

      const block = document.createElement("div");
      block.classList.add("jobs__link-data");
      const title = document.createElement("span");
      title.classList.add("job-link__title");
      const location = document.createElement("p");
      location.classList.add("paragraph-plain", "paragraph-plain--xs");

      const icon = document.createElement("div");
      icon.classList.add("jobs__icon");

      link.setAttribute("href", item.Url);
      title.innerHTML = item.Title;

      item.Locations?.forEach((city) => {
        const span = document.createElement("span");
        span.innerHTML = city;
        location.appendChild(span);
      });
      icon.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="36" height="36">
   <g id="Icon/navigation/chevron-left" fill-rule="evenodd" stroke="none" stroke-width="1">
                <path id="Path" d="M11 9l3.26-3L27 18 14.26 30 11 27l9.6-9z"></path>
              </g>
            </svg>`;

      // append node in a right order
      block.appendChild(title);
      block.appendChild(location);

      link.appendChild(block);
      link.appendChild(icon);

      wrapper.appendChild(link);
    });
  } else {
    wrapper.innerHTML = "no results";
  }
};

export const renderNewBlogTeasers = ({Items, ShowLoadMore}) => {
  const wrapper = document.querySelector(".post-suggestions__list");
  isLoadMoreFunction(ShowLoadMore, document.querySelector(".post-suggestions"))
  if (Items.length !== 0) {
    Items.forEach((item) => {
      // node declarations
      const node = document.createElement("div");
      node.classList.add("blogpost-suggestion-item");
      const imgWrapper = document.createElement("div");
      imgWrapper.classList.add("img-wrapper-stretch");
      const preview = document.createElement("img");
      const nodeData = document.createElement("div");
      nodeData.classList.add("blogpost-suggestion-item__blogpost-item-data");
      const tagsNode = document.createElement("div");
      tagsNode.classList.add("blogpost-suggestion-item__blogpost-tags");
      const headlineLink = document.createElement("a");
      headlineLink.classList.add("blogpost-suggestion-item__blogpost-headline");
      const title = document.createElement("h4");
      title.classList.add("h4");
      const paragraph = document.createElement("p");
      paragraph.classList.add("blogpost-suggestion-item__meta-data");
      const btn = document.createElement("button");
      btn.classList.add("main-btn", "main-btn--black");

      preview.setAttribute(
        "src",
        item.FeaturedImageUrl ? item.FeaturedImageUrl : ""
      );
      preview.setAttribute("alt", item.FeaturedImageAltText);
      imgWrapper.appendChild(preview);

      item.Tags.forEach((tag) => {
        const link = document.createElement("a");
        link.classList.add("blogpost-suggestion-item__blogpost-tag");
        link.setAttribute("href", tag);
        link.innerHTML = `#${tag}`;
        tagsNode.appendChild(link);
      });

      title.innerHTML = item.TeaserTitle;
      headlineLink.setAttribute("href", item.Url);
      headlineLink.appendChild(title);

      paragraph.innerHTML = `${item.ReleaseDate} - ${item.AuthorName} ${item.AuthorSurname}`;
      btn.innerHTML = item?.LearnMoreText || "";

      // append node in a right order
      node.appendChild(imgWrapper);

      nodeData.appendChild(tagsNode);
      nodeData.appendChild(headlineLink);
      nodeData.appendChild(paragraph);
      nodeData.appendChild(btn);

      node.appendChild(nodeData);
      wrapper.appendChild(node);
    });
  } else {
    wrapper.innerHTML = "no results";
  }
};
