// app.controller("createDept",function($scope,$http){
//     $scope.test=function(){
//         var data={'Name':$scope.name,'Id':$scope.id};
//         $http.post("https://localhost:44388/api/department/create",data).then(function(rsp){
//             alert(rsp.data);
//         },function(err){});
//     };
    
// });



 app.controller('createDept',function($scope,$http){    
 $scope.test=function(){      
 $http.post("https://localhost:44388/api/department/create", {
    'Name':$scope.name,
    'Id':$scope.id}) .then(function(response){
        console.log("Data Inserted Successfully");
    },function(error){
        alert("Sorry! Data Couldn't be inserted!");
        console.error(error);

    });
}
});       

 