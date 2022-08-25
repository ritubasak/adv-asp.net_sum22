app.controller("users1",function($scope,ajax){
    function success(response){
        $scope.users1 = response.data;
    }
    function failure (error){

    }
    ajax.get("https://localhost:44343/api/raiser",success,failure);
});

