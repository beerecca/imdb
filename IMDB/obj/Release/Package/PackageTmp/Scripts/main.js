(function (window, undefined) {
    'use strict';

    var imdb = {
        
        init : function()
        {
            var defaultId = $('.movie-item').first().attr('data-movie');
            var defaultImage = $('.movie-item').first().attr('data-image');
            var movieImages = $('.movie-item').map(function () {
                return $(this).attr('data-image');
            }).get();

            this.preloadImages(movieImages)
                .loadDetails(defaultId)
                .updateUi(defaultId, defaultImage)
                .setUpEvents();
        },

        preloadImages: function (imageArray) {

            var preloadedImages = [];
            for (var i = 0; i < imageArray.length; i++) {
                preloadedImages[i] = new Image();
                preloadedImages[i].src = imageArray[i];
            }

            return this;
        },

        setUpEvents : function() {

            var self = this;
            $(".movie-item").click(function () {
                var movieId = $(this).attr('data-movie');
                var movieImage = $(this).attr('data-image');

                self.loadDetails(movieId);
                self.updateUi(movieId, movieImage);
            });

            return this;
        },

        loadDetails : function (movieId) {
            
            if (movieId != undefined) {
                $(".actors").load('/Home/DetailsPartial?movieId=' + movieId);
            }

            return this;
        },

        updateUi: function (movieId, movieImage) {

            $('.movie-item').parents('tr').removeClass("active");
            $('[data-movie=' + movieId + ']').parents('tr').addClass("active");
            $('.jumbotron').css('background-image', 'url("'+movieImage+'")');

            return this;
        }
    }

    imdb.init();

})(window);