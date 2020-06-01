const tbody = document.getElementById("prod");
const callProd = document.getElementById("call-products");
class Request {
    get(url) {//GET Request
        return new Promise((resolve, reject) => {
            fetch(url)
                .then(response => { return response.json() })
                .then(data => { resolve(data); })
                .catch(err => reject(err));
        })
    }

    post(url, data) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'POST',
                body: JSON.stringify({ data }),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
                .then(response => response.json())
                .then(data => resolve(data))
                .catch(err => reject(err));
        })
    }
    put(url, data) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'PUT',
                body: JSON.stringify({ data }),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            }).then(response => {
                return response.json();
            }).then(data => {
                return resolve(data);
            }).catch(err => reject(err));
        })
    }
    delete(url) {
        return new Promise((resolve, reject) => {
            fetch(url, { method: 'DELETE' })
                .then(response => resolve("Veri silme işlemi başarılı..."))
                .catch(err => reject(err));
        })
    }
}

const req = new Request();

eventListeners();

function eventListeners() {
    callProd.addEventListener("click", getContacts);
}


function getContacts() {
    req.get("http://localhost:64382/api/contacts")
        .then(data => {
            console.log(data);
            return showContacts(data);
        }).catch(err => console.log(err));
}

function showContacts(contacts) {
    let result = [];
    contacts.map((contact) => {
        result += `
            <tr>
                <td>${contact.Id}</td>
                <td>${contact.Subject}</td>
                <td>${contact.Name}</</td>
                <td><p>${contact.Message}</</p></td>
                <td>${contact.Email}</td>
                <td><input name="IsActive${contact.Id}" value="${contact.IsActive}"/></td>
                <td><button onclick="window.location='edit/${contact.Id}'" class="btn btn-warning">Düzenle</button> <button onclick="deleteContact(${contact.Id})" class="btn btn-danger">Sil</button></td>
            </tr>
        `;
    })
    tbody.innerHTML = result;
}

function deleteContact(id) {
    url = "http://localhost:64382/api/contacts/" + id;
    console.log(url)
    req.delete(url)
        .then(sonuc => console.log(sonuc))
        .catch(err => console.log(err));
}