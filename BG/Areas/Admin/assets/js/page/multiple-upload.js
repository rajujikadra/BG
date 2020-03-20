"use strict";
var Base64 = null;
var ImageName = null;
// DropzoneJS
if (window.Dropzone) {
    Dropzone.autoDiscover = false;
}

var dropzone = new Dropzone("#mydropzone", {
    acceptedFiles: ".jpeg,.jpg",
    addRemoveLinks: true,
    url: "#",
    maxFiles: 1,
    maxFilesize: 5,
    init: function () {
        this.on("maxfilesexceeded", function (file) {
            this.removeAllFiles();
            this.addFile(file);
        });
    },
    accept: function (file, done) {
        var reader = new FileReader();
        reader.onload = handleReaderLoad;
        reader.readAsDataURL(file);
        function handleReaderLoad(evt) {
            Base64 = evt.target.result;
            ImageName = file.name;
        }
        done();
    },
});

var minSteps = 6,
    maxSteps = 60,
    timeBetweenSteps = 100,
    bytesPerStep = 100000;

dropzone.uploadFiles = function (files) {
    var self = this;

    for (var i = 0; i < files.length; i++) {
        var totalSteps = null;
        var file = files[i];
        totalSteps = Math.round(Math.min(maxSteps, Math.max(minSteps, file.size / bytesPerStep)));

        for (var step = 0; step < totalSteps; step++) {
            var duration = timeBetweenSteps * (step + 1);
            setTimeout(function (file, totalSteps, step) {
                return function () {
                    file.upload = {
                        progress: 100 * (step + 1) / totalSteps,
                        total: file.size,
                        bytesSent: (step + 1) * file.size / totalSteps
                    };

                    self.emit('uploadprogress', file, file.upload.progress, file.upload.bytesSent);
                    if (file.upload.progress == 100) {
                        file.status = Dropzone.SUCCESS;
                        self.emit("success", file, 'success', null);
                        self.emit("complete", file);
                        self.processQueue();
                    }
                };
            }(file, totalSteps, step), duration);
        }
    }
}