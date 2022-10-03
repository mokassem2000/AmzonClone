let ele = Array.from(document.getElementsByClassName('page-item'));
ele.foreach((item) => {
    item.onclick = async function (e) {
        console.log(e.target.value);
        const result = await fetch(`/Home/Index/${e.target.value.value}`)
        const data = await result.json();
        const Row = document.getElementById("MyFlexRow");
        Row.innerHTML = "";
        data.forEach((itemCard) => {

            Row.innerHTML += `<a href="https://localhost:44389/Home/ProductDitail/${itemCard.id}" class="card MyFlexRowItem">
                     <div >
                           <img class="card-img-top" src="https://localhost:44389/ProductImages/${itemCard.imageName}" alt="Card image cap">
                          <div class="card-body">
                                 <p class="card-text">${itemCard.name}</p>
                          </div>
                      </div>  
                    </a>`;




         

        })



    }
})