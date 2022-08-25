app.controller("departments",function($scope,ajax){
      function success(response){
          $scope.departments = response.data;
      }
      function failure (error){

      }
      ajax.get("https://localhost:44388/api/department",success,failure);
});
