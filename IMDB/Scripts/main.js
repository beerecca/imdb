(function (window, undefined) {
    'use strict';

    var imdb = {
        
        init: function() {

            var defaultId = $('.movie-item').first().attr('data-movie'),
                defaultImage = $('.movie-item').first().attr('data-image'),
                movieImages = $('.movie-item').map(function () {
                    return $(this).attr('data-image');
                }).get();

            this.preloadImages(movieImages)
                .loadDetails(defaultId)
                .updateUi(defaultId, defaultImage)
                .setUpEvents();
        },

        preloadImages: function(imageArray) {

            var preloadedImages = [];

            $.each(imageArray, function(i, val) {
                preloadedImages[i] = new Image();
                preloadedImages[i].src = val;
            });

            return this;
        },

        setUpEvents: function() {

            var self = this;

            $(".movie-item").click(function (e) {
                
                var movieId = $(this).attr('data-movie');
                var movieImage = $(this).attr('data-image');

                e.preventDefault();
                self.loadDetails(movieId);
                self.updateUi(movieId, movieImage);

                return false;
            });

            return this;
        },

        loadDetails: function(movieId) {
            
            if (movieId !== undefined) {
                $(".actors").load('/Home/DetailsPartial?movieId=' + movieId);
            } else {
                $(".actors").text('Sorry, it appears there has been an error. Please refresh your page.');
            }

            return this;
        },

        updateUi: function(movieId, movieImage) {

            $('.movie-item').parents('tr').removeClass("active");
            $('[data-movie=' + movieId + ']').parents('tr').addClass("active");
            $('.jumbotron').css('background-image', 'url("'+movieImage+'")');

            return this;
        }
    }

    imdb.init();

})(window);