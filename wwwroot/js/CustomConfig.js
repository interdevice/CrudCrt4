CKEDITOR.editorConfig = function (config) {
	config.extraPlugins = 'ckeditorfa';
	config.contentsCss = '/ckeditor/plugins/fontawesome/css/fontawesome.min.css';
	config.allowedContent = {
    $1: {
        // Use the ability to specify elements as an object.
        elements: CKEDITOR.dtd,
        attributes: true,
        styles: true,
        classes: true
    }
};
};