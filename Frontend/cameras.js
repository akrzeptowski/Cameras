const getHtml = (data) => {
  return data.reduce((acc, curr) => {
    return acc + '<tr><td>' + curr.number + '</td><td>' + curr.name + '</td><td>' + curr.latitude + '</td><td>' + curr.longitude + '</td></tr>';
  }, "");
}

const getCameraData = async () => {
  const response = await fetch("https://localhost:7041/Cameras", {
    headers: {
      "Content-Type": "application/json",
    },
  });

  return await response.json();
}

const setupMap = (data) => {
  const map = L.map('map').setView([52.0914, 5.1115], 15);
  L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
  }).addTo(map);
  for (const item of data) {
    L.marker([item.latitude, item.longitude]).addTo(map);
  }
}

(async () => {
  const data = await getCameraData();

  const column3Items = data.filter(p => p.number % 3 === 0);
  const column5Items = data.filter(p => p.number % 5 === 0);
  const column15Items = data.filter(p => p.number % 3 === 0 && p.number % 5 === 0);
  const columnOtherItems = data.filter(p => p.number % 3 > 0 && p.number % 5 > 0);
  $("#column3 thead").append(getHtml(column3Items));
  $("#column5 thead").append(getHtml(column5Items));
  $("#column15 thead").append(getHtml(column15Items));
  $("#columnOther thead").append(getHtml(columnOtherItems));

  setupMap(data);
})()