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
    callProd.addEventListener("click", denek);
}


function denek(){
    req.get("http://localhost:64382/api/contacts")
        .then(data => {
            console.log(data);
            return showProduct(data);
        }).catch(err => console.log(err));
}

function showProduct(products) {
    let result = [];
    products.map((product) => {
        result += `
            <tr>
                <td>${product.Id}</td>
                <td>${product.Subject}</td>
                <td>${product.Name}</</td>
                <td><p>${product.Message}</</p></td>
                <td>${product.Email}</td>
                <td>${product.IsActive}</td>
                <td><button class="btn btn-primary" id="">Düzenle</button><button class="btn btn-danger" id="delete-product">Sil</button></td>
            </tr>
        `;
    })
    tbody.innerHTML = result;
        
}
