
angular.module('toDoList', ['taskManager'])
.controller('taskCtrl', [
'$scope', '$http', 'taskService',
function ($scope, $http, taskService) {

    $scope.newTask = '';

    $scope.addTask = function () {
        $scope.newTask = {
            name: $scope.name,
            description: $scope.description,
            author: $scope.author
        }
        $scope.tasks.push($scope.newTask);
        taskService.post($scope.newTask);
        $scope.tasks.reverse().show();
        $scope.name = '';
        $scope.description = '';
        $scope.author = '';
    }
    $scope.updateTask = function (index) {
        $scope.newTask = {
            id: $scope.tasks[index].id,
            name: $scope.name,
            description: $scope.description,
            author: $scope.author
        }
        $scope.tasks[index].name = $scope.name;
        $scope.tasks[index].description = $scope.description;
        $scope.tasks[index].authorName = $scope.author;
        taskService.put($scope.newTask);
        $scope.tasks.show();
        $scope.name = '';
        $scope.description = '';
        $scope.author = '';
    }
    $scope.getTaskById = function (index, elem) {
        taskService.getById(elem.id).then(function (response) {
            $scope.tasks = [];

            response.data.forEach(function (element) {
                $scope.tasks.push({
                    id: element.Id,
                    name: element.Name,
                    description: element.Description,
                    authorName: element.Author,
                    createDate: element.CreateDate
                });
            });
        });
    }

    $scope.removeTask = function (index, elem) {
        $scope.tasks.splice(index, 1);

        taskService.remove(elem.id);
    }

    function init() {
        taskService.getAll().then(function (response) {
            $scope.tasks = [];
            var dataFromResponse = JSON.parse(response.data);
            dataFromResponse.forEach(function (element) {
                $scope.tasks.push({
                    id: element.Id,
                    name: element.Name,
                    description: element.Description,
                    authorName: element.Author,
                    createDate: new Date(element.CreateDate).toISOString().slice(0, 16)
                });
            });
            $scope.tasks = $scope.tasks.reverse();
        });

        taskService.getAllAuthors()
            .then(function(response) {
                $scope.authors = [];
                var dataFromResponse = JSON.parse(response.data);
                dataFromResponse.forEach(function (element) {
                    $scope.authors.push({
                        name: element.Name

                    });
                });
            });
    }

    init();
}]);