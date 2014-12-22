(function (window, undefined) {
    'use strict';

    var imdb = {
        
        init : function()
        {
            var defaultId = $('.movie-item').first().attr('data-movie');
            var defaultImage = $('.movie-item').first().attr('data-image');

            this.loadDetails(defaultId)
                .updateUi(defaultId, defaultImage)
                .setUpEvents();
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