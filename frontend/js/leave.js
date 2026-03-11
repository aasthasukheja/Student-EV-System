async function applyLeave() {
    const leaveType = document.getElementById("leaveType").value;
    const startDate = document.getElementById("startDate").value;
    const endDate = document.getElementById("endDate").value;
    const reason = document.getElementById("reason").value;

    const response = await fetch(`${API_BASE}/Leave/apply`, {
        method: "POST",
        headers: authHeaders(),
        body: JSON.stringify({
            id: 0,
            employeeId: 0,
            leaveType: leaveType,
            startDate: startDate,
            endDate: endDate,
            reason: reason,
            status: ""
        })
    });

    const data = await response.json();

    if (response.ok) {
        alert(data.message || "Leave applied successfully");
        window.location.href = "my-leaves.html";
    } else {
        alert(data.title || data.message || "Failed to apply leave");
    }
}

async function loadMyLeaves() {
    const response = await fetch(`${API_BASE}/Leave/my-leaves`, {
        method: "GET",
        headers: authHeaders()
    });

    const data = await response.json();
    const body = document.getElementById("myLeavesBody");
    body.innerHTML = "";

    data.forEach(item => {
        body.innerHTML += `
            <tr>
                <td>${item.id}</td>
                <td>${item.leaveType}</td>
                <td>${item.startDate.split("T")[0]}</td>
                <td>${item.endDate.split("T")[0]}</td>
                <td>${item.reason}</td>
                <td>${item.status}</td>
            </tr>
        `;
    });
}

async function loadAllLeaves() {
    const response = await fetch(`${API_BASE}/Leave/all`, {
        method: "GET",
        headers: authHeaders()
    });

    const data = await response.json();
    const body = document.getElementById("allLeavesBody");
    body.innerHTML = "";

    data.forEach(item => {
        body.innerHTML += `
            <tr>
                <td>${item.id}</td>
                <td>${item.employeeId}</td>
                <td>${item.leaveType}</td>
                <td>${item.startDate.split("T")[0]}</td>
                <td>${item.endDate.split("T")[0]}</td>
                <td>${item.reason}</td>
                <td>${item.status}</td>
                <td>
                    <button onclick="approveLeave(${item.id})">Approve</button>
                    <button onclick="rejectLeave(${item.id})">Reject</button>
                </td>
            </tr>
        `;
    });
}

async function approveLeave(id) {
    const response = await fetch(`${API_BASE}/Leave/approve/${id}`, {
        method: "PUT",
        headers: authHeaders()
    });

    const data = await response.json();

    if (response.ok) {
        alert(data.message || "Approved");
        loadAllLeaves();
    } else {
        alert(data.title || data.message || "Failed");
    }
}

async function rejectLeave(id) {
    const response = await fetch(`${API_BASE}/Leave/reject/${id}`, {
        method: "PUT",
        headers: authHeaders()
    });

    const data = await response.json();

    if (response.ok) {
        alert(data.message || "Rejected");
        loadAllLeaves();
    } else {
        alert(data.title || data.message || "Failed");
    }
}