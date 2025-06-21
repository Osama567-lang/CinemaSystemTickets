// ✅ تكبير الريزليوشن لتفادي البكسلة
Chart.defaults.devicePixelRatio = 2;

// ✅ Area Chart - Visitors
const areaCtx = document.getElementById("areaChart").getContext("2d");
new Chart(areaCtx, {
    type: "line",
    data: {
        labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
        datasets: [{
            label: "Visitors",
            data: [120, 190, 300, 250, 270, 220, 300],
            fill: true,
            tension: 0.4,
            backgroundColor: "rgba(0, 123, 255, 0.2)",
            borderColor: "rgb(0, 123, 255)",
            pointBackgroundColor: "#ffffff",
            pointRadius: 4
        }]
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: { labels: { color: "#ffffff" } }
        },
        scales: {
            x: { ticks: { color: "#ccc" }, grid: { color: "#444" } },
            y: { ticks: { color: "#ccc" }, grid: { color: "#444" } }
        }
    }
});

// ✅ Bar Chart - Tickets Sold
const barCtx = document.getElementById("barChart").getContext("2d");
new Chart(barCtx, {
    type: "bar",
    data: {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
        datasets: [{
            label: "Tickets Sold",
            data: [3000, 4000, 5000, 7000, 8000, 12000],
            backgroundColor: "rgb(40, 167, 69)"
        }]
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: { labels: { color: "#ffffff" } }
        },
        scales: {
            x: { ticks: { color: "#ccc" }, grid: { color: "#444" } },
            y: { ticks: { color: "#ccc" }, grid: { color: "#444" } }
        }
    }
});

// ✅ Donut Chart - Genres
const donutCtx = document.getElementById("donutChart").getContext("2d");
new Chart(donutCtx, {
    type: "doughnut",
    data: {
        labels: ["Action", "Drama", "Comedy", "Horror"],
        datasets: [{
            data: [300, 150, 100, 80],
            backgroundColor: ["#ffc107", "#0dcaf0", "#198754", "#dc3545"],
            borderWidth: 2,
            borderColor: "#1e1e1e"
        }]
    },
    options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
            legend: {
                position: "bottom",
                labels: {
                    color: "#fff",
                    padding: 20,
                    boxWidth: 20
                }
            }
        }
    }
});

// ✅ Slideshow Data (Static Example — Replace with dynamic if needed)
const movieData = [
    { name: "Moonlight", image: "/images/movies/movie1.png" },
    { name: "Inception", image: "/images/movies/movie2.png" },
    { name: "Interstellar", image: "/images/movies/movie3.png" },
    { name: "The Batman", image: "/images/movies/movie4.png" }
];

let movieIndex = 0;
const movieImg = document.getElementById("movieImage");
const movieTitle = document.getElementById("movieTitle");

function updateMovieCard() {
    const current = movieData[movieIndex];
    movieImg.src = current.image;
    movieTitle.textContent = current.name;
    movieIndex = (movieIndex + 1) % movieData.length;
}

setInterval(updateMovieCard, 2000);
updateMovieCard();


// ✅ بيانات الممثلين
const actorData = [
    { name: "Cillian Murphy", image: "/images/cast/cast1.jpg" },
    { name: "Tom Hardy", image: "/images/cast/cast2.jpg" },
    { name: "Brad Pitt", image: "/images/cast/cast3.jpg" },
    { name: "Ryan Gosling", image: "/images/cast/cast4.jpg" }
];

let actorIndex = 0;
const actorImg = document.getElementById("actorImage");
const actorName = document.getElementById("actorName");

function updateActorCard() {
    const current = actorData[actorIndex];
    actorImg.src = current.image;
    actorName.textContent = current.name;
    actorIndex = (actorIndex + 1) % actorData.length;
}

// ✅ ضيفها في نفس الـ setInterval الخاص بالأفلام
setInterval(() => {
    updateMovieCard();
    updateActorCard();
}, 2000);

// ✅ نفذهم أول ما الصفحة تفتح
updateMovieCard();
updateActorCard();