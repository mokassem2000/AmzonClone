

function addproduct(e)
{

    /*var id = e.target.dataset.ProductId;*/

    console.log("lolllllss");
    let id = e.target.getAttribute('data-ProductId')
    fetch(`https://localhost:44389/Cart/AddItem/${id}`)

    
}

let Products = document.getElementsByClassName("MainCard");
for (let i = 0; i < Products.length; i++)
{

    Products[i].getElementsByTagName("span")[1].onclick = addproduct;

    
   


}

