//function addproductarrow(e) {
//    /*var id = e.target.dataset.ProductId;*/
    
//    let id = e.target.getAttribute('data-UpArrow')
//    console.log(`ftuygh ${id}`)
//    //fetch(`https://localhost:44389/Cart/AddItem/${id}`)


//}


let CartItems = document.getElementById("CartItems").getElementsByClassName("Item");
for (let i = 0; i < CartItems.length; i++) {
    let item = CartItems[i];
    item.getElementsByTagName("i")[0].addEventListener('click', (e) => {
        let id = e.target.getAttribute('data-UpArrow')
        console.log(`ftuygh ${id}`)
        fetch(`https://localhost:44389/Cart/AddItem/${id}`).then((response) => response.json())
            .then((data) => console.log(` haha ${data}`));
    })};


for (let i = 0; i < CartItems.length; i++) {
    let item = CartItems[i];
    item.getElementsByTagName("i")[1].addEventListener('click', (e) => {
        let id = e.target.getAttribute('data-DropArrow')
        console.log(`ftuygh ${id}`)
        fetch(`https://localhost:44389/Cart/removeItem/${id}`).then((response) => response.json())
            .then((data) => console.log(` haha ${data}`));
    })
    
};

