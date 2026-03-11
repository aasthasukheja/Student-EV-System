async function loadEmployees() {
    const response = await fetch(`${API_BASE}/Admin/employees`, {
        method: "GET",
        headers: authHeaders()
    });

    const data = await response.json();
    const body = document.getElementById("employeeBody");
    body.innerHTML = "";

    data.forEach(user => {
        body.innerHTML += `
            <tr>
                <td>${user.id}</td>
                <td>${user.username}</td>
                <td>${user.role}</td>
                <td>
                    <button onclick="deleteEmployee(${user.id})">Delete</button>
                </td>
            </tr>
        `;
    });
}

async function deleteEmployee(id) {
    const response = await fetch(`${API_BASE}/Admin/delete/${id}`, {
        method: "DELETE",
        headers: authHeaders()
    });

    const data = await response.json();

    if (response.ok) {
        alert(data.message || "Deleted successfully");
        loadEmployees();
    } else {
        alert(data.title || data.message || "Delete failed");
    }
}