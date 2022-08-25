app.controller("Tbl_Donor",function($scope,ajax){
      function success(response){
          $scope.Tbl_Donor = response.data;
      }
      function failure (error){

      }
      ajax.get("https://localhost:44343/api/donor",success,failure);
});
