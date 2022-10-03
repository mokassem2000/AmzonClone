let ele = document.getElementById("sreachNavBox");
function addbrder(e){
    e.target.parentNode.classList.toggle("brdr");
    

}
ele.addEventListener('click', addbrder);
