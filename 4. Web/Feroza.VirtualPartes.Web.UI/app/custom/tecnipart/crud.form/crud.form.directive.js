angular.module("tecnipart")
    .directive("crudForm", crudForm);

function crudForm() {

    return {
        restrict: "AE",
        replace: false,

        scope: {
            columnButtonClick: "&",    // method binding
            initialized: "&", // method binding
            serverUrl: "@serverUrl",  // one way binding,
            columnsDefinition: "="
        },
        templateUrl: "/Scripts/app/custom/tecnipart/crud.form/crud.form.view.html",
        controller: "crudformController as vm",
        bindToController: true
    }
}