const name = document.getElementById("Name");
const message = document.getElementById("Message");
const subject = document.getElementById("Subject");
const email = document.getElementById("Email");
const postButton = document.getElementById("Gonder");

class Request {
    get(url) {//GET Request
        return new Promise((resolve, reject) => {
            fetch(url)
                .then(response => { return response.json() })
                .then(data => { resolve(data); })
                .catch(err => reject(err));
        })
    }

    post(url, data = {}) {
        return new Promise((resolve, reject) => {
            fetch(url, {
                method: 'POST',
                body: JSON.stringify(data),
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
    postButton.addEventListener("click", postContact);
}

function postContact() {
    url = "http://localhost:64382/api/contacts/";
    req.post(url, {
        Message: message.value,
        Name: name.value,
        Email: email.value,
        IsActive: "Aktif",
        Subject: subject.value
    }).then(data => console.log(data))
        .catch(err => console.log(err));
}