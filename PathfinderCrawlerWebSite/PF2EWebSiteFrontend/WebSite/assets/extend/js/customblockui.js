var element = document.getElementById("page-mask-image");

if (element) {
    element.style.position = "fixed";
    element.style.top = "0";
    element.style.left = "0";
    element.style.width = "100%";
    element.style.height = "100%";
    element.style.opacity = "0.75";
    element.style.zIndex = "9999";
}

function showBlockUI() {
    var blockUI = document.getElementById('page-mask');
    blockUI.style.display = 'block';
}

function hideBlockUI() {
    var blockUI = document.getElementById('page-mask');
    blockUI.style.display = 'none';
}