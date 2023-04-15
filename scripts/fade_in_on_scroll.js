let elementsArray = document.querySelectorAll(".block");
console.log(elementsArray);
window.addEventListener('scroll', fadeIn);
function fadeIn() {
    console.clear();
    for (var i = 0; i < elementsArray.length; i++) {
        var elem = elementsArray[i]
        var distInView = elem.getBoundingClientRect().top - window.innerHeight + 40;
        console.log(distInView);
        if (distInView < 0) {
            elem.classList.add("in_view");
        } 
        else {
            elem.classList.remove("in_view");
        }
    }
}
fadeIn();