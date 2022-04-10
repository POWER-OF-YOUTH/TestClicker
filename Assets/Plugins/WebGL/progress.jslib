mergeInto(LibraryManager.library, {
    save: function (data) {
        console.log("Dispatch `saveProgress` event.");

        window.dispatchReactUnityEvent(
            "saveProgress",
            Pointer_stringify(data)
        );
    },
    load: function () {
        console.log("Dispatch `loadProgress` event.");

        const bufferSize = lengthBytesUTF8(window.userProgress.data) + 1;
        const buffer = _malloc(bufferSize);
        stringToUTF8(window.userProgress.data, buffer, bufferSize);

        window.dispatchReactUnityEvent(
            "loadProgress"
        );

        return buffer;
    }
});
