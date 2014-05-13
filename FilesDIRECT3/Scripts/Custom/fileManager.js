// / <reference path="Lib/jquery-1.7.1.js" />

var manageFileModule = (function() {

	var init = function() {
		pulpLoadManager.configUploder();
	}

	var manageFileModule = function() {
		init();
	};

	manageFileModule.prototype = {
		constructor : manageFileModule
	}

	return manageFileModule;
})();

var pulpLoadManager = {
	maxQue : 10,
	configUploder : function() {

		$("#smartFileUploder").plupload({
					// General settings
					runtimes : 'html5,flash,silverlight,browserplus,gears,html4',
					url: $("#uploadUrl").val(),
					max_file_size : '1000000mb',
					chunk_size : '1mb',
					max_file_count : 10, // user can add no more then
					// 20 files at a time

					unique_names : true,
					multiple_queues : true,

					// Resize images on clientside if we can
					resize : {
						width : 320,
						height : 240,
						quality : 90
					},
					multipart: true,

					multipart_params: {
					    Authorization: 'Basic n0ovmBWo0o4d4KPsQdxp0OottMmedK:3QVqLTXR46zJEFho0GibrIxgQiK794'
					},

					// Rename files by clicking on their titles
					rename : true,

					// Sort files
					sortable : true,

					// Specify what files to browse for
					filters : [{
								title : "All files",
								extensions : "*"
							}],
					// Flash settings
					flash_swf_url : $("#pulploadSwf").val(),

					// Silverlight settings
					silverlight_xap_url : $("#pulploadXap").val(),
					
					init : {

		}
				});
	}

}

$(function() {

			var fileModule = new manageFileModule();

		})