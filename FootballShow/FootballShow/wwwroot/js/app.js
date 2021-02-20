$(function () {

    /* Fixed Header / Фиксированная Шапка */
    let header = $("#header"); // объявили и инициализировали переменную. (равна блоку с id = header).
    let intro = $("#intro");

    let introHeight; // просто объявили переменную

    let scrollPosition = $(window).scrollTop(); // объявили переменную и инициализировали ее (равно высоте отступа (скролл) сверху в пикселях).

    $(window).on("scroll load resize", function () {  // грубо говоря объявили функцию, которая будет срабатывать при прокрутке, загрузке и обновлении окна.
        introHeight = intro.innerHeight(); // инициализировали introHeight (равна высоте блока intro вместе с отступами, в пикселях).
        scrollPosition = $(this).scrollTop(); // перезаписали в переменную значения отступа сверху в данной точке.

        if (scrollPosition > introHeight) {
            header.addClass("fixed"); // добавили класс fixed к классу header (класс fixed необходимо описать в .css)
        }
        else {
            header.removeClass("fixed"); // убрали класс fixed
        }
    });

    /* Smooth Scroll / Плавный Переход */
    $("[data-scroll]").on("click", function (event) { // грубо говоря объявили функцию, которая будет срабатывать при нажатии на элемент с атрибутом data-scroll.
        event.preventDefault(); // отменили стандартное поведение ссылки

        nav.removeClass("show");

        let elementID = $(this).data('scroll'); // получить айди элемента, к которому нужно перейти (мы его передаем в .html-е).
        let elementOffset;
        if (elementID === "#header") {
            elementOffset = 0;
        }
        else {
            elementOffset = $(elementID).offset().top; // получаем отступ сверху для элемента elementID.
        }

        $("html, body").animate({ // для элементов html и body анимировать
            scrollTop: elementOffset - 70 // перемещение (скролл) сверху на заданное значение elementOffset
        }, 700); //время прокрутки в милисекундах
    });

    /* Nav Toggle / навигационный переключатель */
    let nav = $("#nav");

    $("#navToggle").on("click", function (event) {// грубо говоря объявили функцию, которая будет срабатывать при нажатии на элемент с id = #navToggle.
        event.preventDefault(); // отменили стандартное поведение ссылки

        nav.toggleClass("show"); // тоже самое, что и nav.addClass("show") - если такой класс не добавлен, ИЛИ nav.removeClass("show") - если такой класс уже есть
    });

    /* Для добалвения слайдера на сайт использовалась библиотека: https://kenwheeler.github.io/slick/   урок с канала BrainsCloud №8 */
    let slider = $("#testimonialSlider");

    slider.slick({  // Функция из библиотеки указанной выше
        infinite: true, // скролиться слайдер будет сам бесконечно
        slidesToShow: 1, // кол-во показываемых слайдеров
        slidesToScroll: 1, // кол-во сладйдеров при скролле
        fade: false, // просто эффект затемнения при скролле (если true)
        arrows: false, // скрыть кнопки "вперед" и "назад"
        dots: true // показать точки слайдера (мы их стилизуем в .css в созданном автоматически классе .slick-dots)
    });

});