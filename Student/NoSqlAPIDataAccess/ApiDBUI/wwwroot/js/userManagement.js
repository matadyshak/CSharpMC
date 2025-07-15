const apiUrl = 'https://localhost:44374/api/contacts';

async function loadUsers() {
    const response = await fetch(apiUrl);
    const users = await response.json();
    const tbody = document.querySelector('#userTable tbody');
    tbody.innerHTML = '';

    users.forEach(user => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${user.id}</td>
            <td>${user.firstName}</td>
            <td>${user.lastName}</td>
            <td>${user.emailAddresses.map(e => e.emailAddress).join(', ')}</td>
            <td>${user.phoneNumbers.map(e => e.phoneNumber).join(', ')}</td>
            <td>
                <button onclick='editUser(${JSON.stringify(user)})'>Edit</button>
                <button onclick='deleteUser("${user.id}")'>Delete</button>
            </td>
        `;

        tbody.appendChild(row);
    });
}

async function deleteUser(id) {
    await fetch(`${apiUrl}/${id}`, { method: 'DELETE' });
    loadUsers();
}
function editUser(user) {
    document.getElementById('userId').value = user.id;
    document.getElementById('firstName').value = user.firstName;
    document.getElementById('lastName').value = user.lastName;
    document.getElementById('emailAddresses').value = user.emailAddresses.map(e => e.emailAddress).join(', ');
    document.getElementById('phoneNumbers').value = user.phoneNumbers.map(p => p.phoneNumber).join(', ');
}

function resetForm() {
    document.getElementById('userForm').reset();
    document.getElementById('userId').value = '';
}

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('userForm').addEventListener('submit', async function (e) {
        e.preventDefault();

        const id = document.getElementById('userId').value || crypto.randomUUID();
        const user = {
            id,
            firstName: document.getElementById('firstName').value,
            lastName: document.getElementById('lastName').value,
            emailAddresses: document.getElementById('emailAddresses').value.split(',').map(email => ({ emailAddress: email.trim() })),
            phoneNumbers: document.getElementById('phoneNumbers').value.split(',').map(phone => ({ phoneNumber: phone.trim() }))
        };

        user.id = id;
        await fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });

/*
        await fetch(`${apiUrl}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
*/

        resetForm();
        loadUsers();
    });

    loadUsers();
    console.log("userManagement.js v1.1 loaded");
});
