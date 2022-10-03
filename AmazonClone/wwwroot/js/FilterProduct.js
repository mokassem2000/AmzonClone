const listCategory = document.getElementById("Searchselect");

listCategory.onchange =async  function (e) {
   
    console.log(`${e.target.value}`)
        
    const result = await fetch(`/Home/ProductFilter/${e.target.value}`)
    const data = await result.json();
    console.log(data);

    const Row = document.getElementById("MyFlexRow");
    Row.innerHTML = "";
    data.forEach((item) => {

        Row.innerHTML += `<a href="https://localhost:44389/Home/ProductDitail/${item.id}" class="card MyFlexRowItem">
                     <div >
                           <img class="card-img-top" src="https://localhost:44389/ProductImages/${item.imageName}" alt="Card image cap">
                          <div class="card-body">
                                 <p class="card-text">${item.name}</p>
                          </div>
                      </div>  
                    </a>`;


        `








    `






    })
         
}
