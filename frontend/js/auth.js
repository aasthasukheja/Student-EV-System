async function registerUser() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    const role = document.getElementById("role").value;

    const response = await fetch(`${API_BASE}/Auth/register`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            id: 0,
            username: username,
            password: password,
            role: role
        })
    });

    const data = await response.json();

    if (response.ok) {
        alert(data.message || "Registered successfully");
        window.location.href = "index.html";
    } else {
        alert(data.title || data.message || "Registration failed");
    }
}

async function loginUser() {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const response = await fetch(`${API_BASE}/Auth/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            id: 0,
            username: username,
            password: password,
            role: ""
        })
    });

    const data = await response.json();

    if (response.ok) {
        localStorage.setItem("token", data.token);
        localStorage.setItem("role", data.role);
        localStorage.setItem("username", data.username);
        localStorage.setItem("userId", data.userId);

        alert("Login successful");
        window.location.href = "dashboard.html";
    } else {
        alert(data.title || data.message || "Login failed");
    }
}