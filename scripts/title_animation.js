window.addEventListener('scroll', () => {
    document.body.style.setProperty('--scroll', window.pageYOffset / (document.body.offsetHeight - window.innerHeight));
}, false);

document.getElementsByTagName('body')[0].onscroll = () => {
    console.clear();
    console.log(window.pageYOffset / (document.body.offsetHeight - window.innerHeight));
};
