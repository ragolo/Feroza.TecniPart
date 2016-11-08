"use strict";
angular.module("tecnipart")
	.controller("crudformController", crudformController);

crudformController.$inject = ["$scope", "$element", "$attrs", "ajaxServiceFactory", "logger"];

function crudformController($scope, $element, $attrs, ajaxServiceFactory, logger) {

    var self = this;

    self.titleForm = "";

	// Indicates if the view is being loaded
	self.loading = false;

	// Indicates if the view is in add mode
	self.addMode = false;

	self.createItem = createItem;

	// Initialize module
	self.initialize = initialize;

	
	//// ---------------- CODE TO RUN ------------

	self.initialize();

	var itemsService;

	function initialize() {
	    logger.info("Creando servicio para hacer comunicacion con el servidor", self.serverUrl);
		itemsService = ajaxServiceFactory.getService(self.serverUrl);
	    logger.info("Columnas del formulario a crear", self);
	    self.titleForm = $attrs.titleForm;
	}

	function createItem(item) {
		if (_isValid(item)) {
			itemsService.save(item,
                // success response
                function (createdItem) {
                	// Add at the first position
                	self.allItems.unshift(createdItem);
                	self.addMode = false;

                	logger.info("Se guardo exitosamente desde [crudformController] ", createItem);
                },
                // error callback
                function (error) {
                    //_requestError(error.data);
                    logger.error(error.data, createItem, "");

                });
		}
	};

	function _isValid(item) {
		var isValid = true;

		// validate all columns
		self.columnsDefinition.forEach(function (column) {
			if (isValid) {

				// required validation
				if (column.required == 'true') {
					isValid = item[column.binding] != undefined;
				}
			}

		});

		return isValid;
	};
};