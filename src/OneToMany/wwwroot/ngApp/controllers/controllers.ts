namespace OneToMany.Controllers {

    export class HomeController {
        public movies;

        public deleteMovie(id: number) {
            this.$http.delete(`api/movies/${id}`).then((response) => {
                this.$state.go(`home`);
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/movies`).then((response) => {
                this.movies = response.data;
            })
        }
    }

    export class AboutController {
        public movie;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/movies/` + this.$stateParams[`id`]).then((response) => {
                this.movie = response.data;
            })
        }
    }
    export class AddMovieController {
        public movie;
        public genres;

        public addMovie() {
            this.$http.post(`/api/movies`, this.movie).then((response) => {
                this.$state.go(`home`);
            });
        }
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get(`/api/genres`).then((response) => {
                this.genres = response.data;
            })

        }
    }
    export class EditMovieController {
        public movie;

        public editMovie() {
            this.$http.post(`/api/movies`, this.movie).then((response) => {
                this.$state.go('home');
            });
        }
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.$http.get(`/api/movies/` + this.$stateParams['id']).then((response) => {
                this.movie = response.data;
            })
        }
    }
}
