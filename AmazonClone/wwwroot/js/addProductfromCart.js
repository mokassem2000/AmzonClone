//function addproductarrow(e) {
//    /*var id = e.target.dataset.ProductId;*/
    
//    let id = e.target.getAttribute('data-UpArrow')
//    console.log(`ftuygh ${id}`)
//    //fetch(`https://localhost:44389/Cart/AddItem/${id}`)


//}
let CartitemsParent = document.getElementById("CartItems");

let CartItems = document.getElementById("CartItems").getElementsByClassName("Item");
for (let i = 0; i < CartItems.length; i++) {
    let item = CartItems[i];
    item.getElementsByTagName("i")[0].addEventListener('click', (e) => {
        let id = e.target.getAttribute('data-UpArrow')
        console.log(`ftuygh ${id}`)
        fetch(`https://localhost:44389/Cart/AddItem/${id}`).then((response) => response.json())
            .then((data) => {
                document.getElementById(`item+${id}`).innerText = `${data.quantity}`;
                document.getElementById("totalcountId").innerText = `: ${data.totalitem}`
                document.getElementById("totalpriceId").innerText = ` : ${data.totalprice}`
                console.log(data);
            });
    })};


for (let i = 0; i < CartItems.length; i++) {
    let item = CartItems[i];
    item.getElementsByTagName("i")[1].addEventListener('click', (e) => {
        let id = e.target.getAttribute('data-DropArrow')
        fetch(`https://localhost:44389/Cart/removeItem/${id}`).then((response) => response.json())
            .then((data) => {
                if (data.quantity == 0 ) {
                    CartitemsParent.removeChild(document.getElementById(`card+${id}`));   
                    document.getElementById("totalcountId").innerText = `: ${data.totalitem}`
                    document.getElementById("totalpriceId").innerText = ` : ${data.totalprice}`
                } else {
                    document.getElementById(`item+${id}`).innerText = `${data.quantity}`
                    document.getElementById("totalcountId").innerText = `: ${data.totalitem}`
                    document.getElementById("totalpriceId").innerText = ` : ${data.totalprice}`
                }
            });
    })
    
};

