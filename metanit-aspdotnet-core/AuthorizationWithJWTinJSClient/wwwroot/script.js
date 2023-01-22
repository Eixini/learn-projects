var tokenKey = "accessToken";

// При нажатии на кнопку отправки формы идет запрос к /login для получения токена
document.getElementById("submitLogin").addEventListener("click", async e => {
    e.preventDefault();
    // Отправление запроса и получение ответа
    const response = await fetch("/login", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            email: document.getElementById("email").value,
            password: document.getElementById("password").value
            })
    });
    // Если запрос прошел успешно
    if (response.ok === true) {
        // Получение данных
        const data = await response.json();
        // Изменение содержимого и видимость блоков на странице
        document.getElementById("userName").innerText = data.username;
        document.getElementById("userInfo").style.display = "block";
        document.getElementById("userForm").style.display = "none";
        // Сохранение в хранилище sessionStorage токен доступа
        sessionStorage.setItem(tokenKey, data.access_token);
    }
    else  // Получение код статуса, если произошла ошибка
        console.log("Status: ", response.status);
});

// Кнопка для обращения по пути "/data" для получения данных
document.getElementById("getData").addEventListener("click", async e => {
    e.preventDefault();
    // Получение токена из sessionStorage
    const token = sessionStorage.getItem(tokenKey);
    // Отправка запроса к "/data"
    const response = await fetch("/data", {
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Authorization": "Bearer" + token  // Передача токена в заголовке
        }
    });

    if (response.ok === true) {
        const data = await response.json();
        alert(data.message);
    }
    else
        console.log("Status: ", response.status);
});

// Условный выход - удаление токена и изменение видимости блоков
document.getElementById("logOut").addEventListener("click", e => {
    e.preventDefault();
    document.getElementById("userName").innerText = "";
    document.getElementById("userInfo").style.display = "none";
    document.getElementById("loginForm").style.display = "block";
    sessionStorage.removeItem(tokenKey);
});