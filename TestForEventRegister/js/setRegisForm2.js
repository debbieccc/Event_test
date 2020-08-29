
var items = document.querySelectorAll(".formitem");
var zones = document.querySelectorAll('.zone');
//console.log(items);

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

    if (id === "emailbtn") {               
        $("#email").css("display", "block");    
        $("#email_v").attr("value", "1"); 
        
    }
    else if (id === "idnumberbtn") {
        $("#idnumber").css("display", "block");
        $("#idnumber_v").attr("value", "1"); 
    }
    else if (id === "birthdaybtn") {
        $("#birthday").css("display", "block");
        $("#birthday_v").attr("value", "1"); 
    }
    else if (id === "genderbtn") {
        $("#gender").css("display", "block");
        $("#gender_v").attr("value", "1");

        
    }
    else if (id === "veganornotbtn") {
        $("#veganornot").css("display", "block");
        //$("#veganornot_v").attr("value", "1");
        var x = document.getElementById("veganornot_v");
        x.value = 1;
                
    }
    else if (id === "occupationbtn") {
        $("#occupation").css("display", "block");
        $("#occupation_v").attr("value", "1"); 
    }   
    else if (id === "otherbtn") {
        $("#other1").css("display", "block");
        $("#other1btn").attr("value", "1");
    }
}