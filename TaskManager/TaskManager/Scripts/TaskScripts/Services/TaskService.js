angular.module('taskManager', [])
.service('taskService', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('/api/task');
        },
        getById: function (id) {
            return $http.get('/api/task/' + id);
        },
        post: function (data) {
            return $http.post('/api/task/', data);
        },
        remove: function (id) {
            return $http.delete('/api/task/' + id);
        },
        getAllAuthors: function () {
            return $http.get('/api/author');
        }
    }
}]);
