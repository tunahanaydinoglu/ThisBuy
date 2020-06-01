const editC = document.getElementById("editButton");
const editIs = document.getElementById("IsActive");
const editId = document.getElementById("Id");
const name = document.getElementById("Name");
const message = document.getElementById("Message");
const subject = document.getElementById("Subject");
const email = document.getElementById("Email");


class Request {
    get(url) {//GET Request
        return new Promise((resolve, reject) => {
            fetch(url)
                .then(response => { return response.json() })
                .then(data => { resolve(data); })
                .catch(err => reject(err));
        })
    }

    async put(url, data = {}) {

        const response = await fetch(url, {
            method: 'PUT',
            body: JSON.stringify(data),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        });

        data = await response.json();
        return data;
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
    editC.addEventListener("click", putContact);
}


function putContact() {
    let url = "http://localhost:64382/api/contacts/" + editId.value;
    console.log(url);
    req.put(url, {
        Id: editId.value,
        Message: message.value,
        Email: email.value,
        Name: name.value,
        Subject: subject.value,
        IsActive: editIs.value
    }).then(updateAlbum => console.log(updateAlbum))
        .catch(err => console.log(err));
}
