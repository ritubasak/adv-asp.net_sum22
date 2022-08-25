var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider","$httpProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/", {
        templateUrl : "views/pages/demopage.html"
    })
    .when("/demo", {
        templateUrl : "views/pages/demopage.html",
        controller: 'demo'
    })
   
    .when("/login", {
        templateUrl : "views/pages/login.html",
        controller: 'login'
    })
    .when("/Tbl_Donor", {
        templateUrl : "views/pages/Tbl_Donor.html",
        controller:"Tbl_Donor"
    })  
    .when("/users1", {
        templateUrl : "views/pages/users1.html",
        controller:"users1"
    })
    
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);
  app.factory("interCeptor",function($q,$location){
      return{
         'request':function(config){
              config.headers.Authorization="token";
              console.log("intercepted");
             return config;
          },
          'reponse':function(rejection){
          }
      }
 });
 app.config(function($httpProvider){
  	$httpProvider.interceptors.push("interCeptor");
  });