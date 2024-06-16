// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let currentIndex = 0;
const data = [
    {
        image: "https://via.placeholder.com/200/1",
        name: "Иванов Иван Иванович",
        debt: "1000",
        rate: "10",
        date: "01.01.2023"
    },
    {
        image: "https://via.placeholder.com/200/2",
        name: "Петров Петр Петрович",
        debt: "2000",
        rate: "12",
        date: "02.02.2022"
    },
    {
        image: "https://via.placeholder.com/200/3",
        name: "Сидоров Сидор Сидорович",
        debt: "3000",
        rate: "14",
        date: "03.03.2021"
    }
];

function updateForm() {
    const form = document.querySelector(".container");
    const image = form.querySelector(".image");
    const name = form.querySelector(".text div:nth-child(1)");
    const debt = form.querySelector(".text div:nth-child(2)");
    const rate = form.querySelector(".text div:nth-child(3)");
    const date = form.querySelector(".text div:nth-child(4)");

    image.src = data[currentIndex].image;
    name.textContent = data[currentIndex].name;
    debt.textContent = `Должен ${data[currentIndex].debt} рублей`;
    rate.textContent = `Процентная ставка: ${data[currentIndex].rate}%`;
    date.textContent = `Дата взятия: ${data[currentIndex].date}`;
}

document.querySelector("#prev").addEventListener("click", () => {
    currentIndex = (currentIndex - 1 + data.length) % data.length;
    updateForm();
});

document.querySelector("#next").addEventListener("click", () => {
    currentIndex = (currentIndex + 1) % data.length;
    updateForm();
});

updateForm();