﻿"use strict";

angular.module("tecnipart").directive('controlEditor', function () {
    return {
        //	'A' - only matches attribute name
        //	'E' - only matches element name
        //	'C' - only matches class name
        restrict: 'A',
        // Replace the element that contains the attribute
        replace: true,
        // scope = false, parent scope
        // scope = true, get new scope
        // scope = {...}, isolated scope>
        //		1. "@"   ( Text binding / one-way )
        //      2. "="   ( Model binding / two-way  )
        //      3. "&"   ( Method binding  )
        scope: {
            column: "=",        // object binding
            item: "=",          // object binding
            keyUpEvent: "&",    // method binding
        },
        // view
        templateUrl: '/Scripts/app/custom/tecnipart/crud.form/control.editor/control.editor.view.html',
        // controller
        controller: "controlEditorController as vm",
        bindToController: true
    };
});