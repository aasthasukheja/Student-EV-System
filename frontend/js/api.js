const API_BASE = "http://localhost:5050/api";
// apna actual backend port yahin rakho

function getToken() {
    return localStorage.getItem("token");
}

function getRole() {
    return localStorage.getItem("role");
}

function getUsername() {
    return localStorage.getItem("username");
}

function authHeaders() {
    return {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + getToken()
    };
}

function logoutUser() {
    localStorage.clear();
    window.location.href = "index.html";
}