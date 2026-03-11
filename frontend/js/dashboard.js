function loadDashboard() {
    const role = getRole();
    const username = getUsername();

    if (!role || !getToken()) {
        window.location.href = "index.html";
        return;
    }

    document.getElementById("welcomeText").innerText = `Welcome ${username} (${role})`;

    if (role === "Employee") {
        document.getElementById("employeeSection").classList.remove("hidden");
    } else if (role === "Manager") {
        document.getElementById("managerSection").classList.remove("hidden");
    } else if (role === "Admin") {
        document.getElementById("adminSection").classList.remove("hidden");
    }
}