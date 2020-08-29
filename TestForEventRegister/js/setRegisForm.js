
var items = document.querySelectorAll(".formitem");
var zones = document.querySelectorAll('.zone');
console.log(items);

for (var i = 0, max = items.length; i < max; i++) {
    items[i].addEventListener("dragstart", dragstartHandler);
}
function dragstartHandler(event) {
    console.log(event.target.id);
    event.dataTransfer.setData("text/plain", event.target.id);

}

for (var j = 0; j < zones.length; j++) {
    zones[j].addEventListener("dragover", dragoverHandler);
    zones[j].addEventListener("drop", creatTextBox);
}
function dragoverHandler(event) {
    event.preventDefault();
}
function creatTextBox(evt) {
    var id = event.dataTransfer.getData('text/plain');
    var item = document.querySelector('#' + id);
    evt.preventDefault();
    evt.stopPropagation();
    evt.target.appendChild(item);
    item.setAttribute("hidden", "true");

    if (id === "email") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "電子郵件：";      
        inputText.setAttribute("type", "email");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "idnumber") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "身分證字號：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
  
    else if (id === "birthday") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "出生年月日：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "gender") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "性別：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "veganornot") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "葷/素食：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "education") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "教育程度：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "marrigement") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "婚姻狀況：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
    else if (id === "other") {
        var formgroup = document.createElement('div');
        formgroup.setAttribute("class", "form-group");
        var inputText = document.createElement('input');
        var labelText = document.createElement('label');
        var changeline = document.createElement('br');
        labelText.innerHTML = "自訂：";
        inputText.setAttribute("type", "text");
        inputText.setAttribute("class", "form-control");
        inputText.setAttribute("name", "inputText1");
        event.target.appendChild(formgroup);
        formgroup.appendChild(labelText);
        formgroup.appendChild(changeline);
        formgroup.appendChild(inputText);
    }
}