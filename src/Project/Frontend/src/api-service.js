export const fetchData = (url = "", params = {}, renderFunc) => {
  fetch(url + new URLSearchParams(params), {
    method: "GET",
  })
    .then((data) => {
      return data.json();
    })
    .then((data) => {
      renderFunc(data);
    })
    .catch((e) => {
      console.log(e);
    });
};
