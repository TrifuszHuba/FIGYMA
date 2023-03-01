function titleHackAnimation() {
    const letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const title = document.getElementById("title");
    let interval = null;
    let iteration = 0;

    clearInterval(interval);

    interval = setInterval(() => {
    title.innerText = title.innerText
      .split("")
      .map((letter, index) => {
        if(index < iteration) {
          return title.dataset.value[index];
        }
    
        return letters[Math.floor(Math.random() * 26)]
      })
      .join("");
    
        if(iteration >= title.dataset.value.length){ 
        clearInterval(interval);
        }
    iteration += 1 / 3;
    }, 30);
}


titleHackAnimation();