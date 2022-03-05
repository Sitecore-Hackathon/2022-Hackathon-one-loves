document.addEventListener("DOMContentLoaded", function () {
  const container = document.querySelector(".team-overview__list");

  if (container) {
    let DB = [];

    const initDB = (num) => {
      const db = [];
      for (let i = 0; i < num; i++) {
        db.push({
          name: `Name Vorname ${i}`,
          job: "job title",
          imgSrc: "../assets/images/placeholder_1_1.jpg",
        });
      }
      return db;
    };

    DB = initDB(36);
    let initialLoadIndex = 0;

    function loadItems(numBlocks = 18) {
      if (initialLoadIndex !== DB.length) {
        for (let i = initialLoadIndex; i < initialLoadIndex + numBlocks; i++) {
          const link = document.createElement("a");
          link.classList.add("team-overview__employee-link");
          link.setAttribute("id", "employee-link-" + i);
          // TO DO: fix link to person details page
          link.setAttribute("href", "#");
          link.innerHTML = `<div class="img-wrapper-stretch">
      <img src=${DB[i].imgSrc} alt='${DB[i].name} image'>
    </div>
    <span class="team-overview__employee-name">${DB[i].name}</span>
    <span class="team-overview__employee-job">${DB[i].job}</span>`;
          container.appendChild(link);
        }

        initialLoadIndex += numBlocks;
      } else {
        return false;
      }
    }

    loadItems();
    // listen for scroll event and load more items if we reach the bottom of window

    if (window.innerWidth > 640) {
      window.addEventListener("scroll", () => {
        // window.scrollY - scrolled from top
        // window.innerHeight - visible part of screen
        if (
          window.scrollY + window.innerHeight >=
          document.documentElement.scrollHeight
        ) {
          loadItems();
        }
      });
    } else {
      document
        .querySelector(".team-overview__cta")
        .addEventListener("click", () => {
          loadItems();
        });
    }
  }
});
