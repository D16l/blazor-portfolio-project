document.addEventListener("DOMContentLoaded", () => {
    //Get all the images from the gallery
    const images = document.querySelectorAll(".gallery-img");

    //IntersectionObserver API to inject animations class from Animate.css
    const observer = new IntersectionObserver((entries, obs) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const el = entry.target;
                const delay = el.dataset.delay || "0s";

                el.style.animationDelay = delay;
                el.classList.add(
                    "animate__animated",
                    "animate__fadeInUp"
                );

                el.style.opacity = "1";
                obs.unobserve(el);
            }
        });
    }, {
        threshold: 0.2
    });
    //Sets opacity to all the images and sets the IntersectionObserver API observer to observe the images
    images.forEach(img => {
        img.style.opacity = "0";
        observer.observe(img);
    });
});