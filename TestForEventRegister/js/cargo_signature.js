var signature = document.getElementById("canvas_signature");
var context = signature.getContext("2d"); // d 要小寫
var flag = false;

//開始畫圖
signature.addEventListener("mousedown", function (event) {
    flag = true;
    //console.log(event);
    //開始一個新路徑，產生後再使用繪圖指令來設定路徑。
    context.beginPath();

    //移動畫筆到指定的滑鼠點選的位置上
    //使用event.offsetX 取得滑鼠的x軸座標點
    //使用event.offsetY 取得滑鼠的y軸座標點
    context.moveTo(event.offsetX, event.offsetY);

    //設定線條顏色   
    context.strokeStyle = "#000000";

    //設定線條寬度
    context.lineWidth = "4";

}, false);

//畫圖中
signature.addEventListener("mousemove", function (event) {

    if (flag) {
        //從目前繪圖點畫一條直線到滑鼠點選的位置上
        //使用event.offsetX 取得滑鼠的x軸座標點
        //使用event.offsetY 取得滑鼠的y軸座標點
        context.lineTo(event.offsetX, event.offsetY);
        //console.log(event.offsetX + "," + event.offsetY); // 查看座標
        //to do 畫出圖形的線條
        context.stroke();
    }
}, false);

//結束畫圖
signature.addEventListener("mouseup", function (event) {
    flag = false;
 
}, false);

//儲存
document.querySelector("#saveSignature").addEventListener("click", function () {
    var signatureImg = document.querySelector("#signatureImg");
    signatureImg.src = signature.toDataURL("image/png");
    context.clearRect(0, 0, signature.width, signature.height);
    alert("儲存成功");
    $('#btnclose').click();
}, false);


//清除
document.querySelector("#clearSignature").addEventListener("click", function () {
    //location.reload();
    context.clearRect(0, 0, signature.width, signature.height);
}, false);