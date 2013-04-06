var villages;
var edges;
var dd; // draw data

$(function () {
    initializeViewPortData();
    addUIHooks();

    loadInitialVillages();
    loadTravelTimes();
    //positionFirstThreeVillages(2, 1, 3);

//    drawVillages();
});

function loadInitialVillages() {
/*    villages = [{ id: 1, x: 0, y: 0, name: 'Sirius' }, 
                { id: 2, x: 0, y: 0, name: 'Polaris' },
                { id: 3, x: 0, y: 0, name: 'Betelguese' },
                { id: 4, x: 0, y: 0, name: 'Sx' }];
*/
    addVillage(0, 0, "Sirius");
    addVillage(0, 0, "Polaris");
    addVillage(0, 0, "Betelguese");
}

function updateVillageCount(count) {
    $('#villagecount').InnerText = count;
}

function parseAddVillage(data) {
    var v = { x: data.Y, y: data.Y, name: data.Name }
    if (!villages) {
        villages = [ v ];
    }
    else {
        villages.push(v);
    }
    updateVillageCount(villages.length);
    drawVillages();
}


function addVillage(x, y, name) {
    $.ajax({
        url: 'http://localhost:59971/api/villages',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: { X: x, Y: y, Name: name },
        success: function (data) {
            alert("Received back id " + data.Id);
            parseAddVillage(data);
        },
        error: function (data) {
            alert(data);
        }
    });  
}

function addEdge(from, to, time, timeType) {

}

function loadTravelTimes() {
/*    edges = [{ id: 1, from: 1, to: 2, time: 2 * 60 + 8, timeType: 'm' }, 
             { id: 2, from: 1, to: 3, time: 1 * 60 + 33, timeType: 'm' },
             { id: 3, from: 1, to: 4, time: 2 * 60 + 4, timeType: 'm' },
             { id: 4, from: 2, to: 3, time: 1 * 60 + 20, timeType: 'm' },
             { id: 5, from: 2, to: 4, time: 1 * 60 + 11, timeType: 'm' },
             { id: 6, from: 3, to: 4, time: 2 * 60 + 8, timeType: 'm' }
             ];
*/
}

function findById(list, id) {
    for (var i=0; i < list.length; i++)
    {
        if (list[i].id == id) return list[i];
    }
    return null;
}

function findEdge(v1, v2) {
    for (var i=0; i < edges.length; i++)
    {
        if ((edges[i].from == v1 && edges[i].to == v2) || (edges[i].from == v2 && edges[i].to == v1))
            return edges[i];
    }
    return null;
}



function drawVillages() {
    for (i = 0; i < villages.length; i++) {
        drawOneVillage(villages[i]);
    }
}

function drawOneVillage(village) {
    var c = document.getElementById("mapCanvas");
    var ctx = c.getContext("2d");
    var pos = getViewPoint(village);
    ctx.beginPath();
    ctx.arc(pos.x, pos.y, dd.villageRadius, 0, 2 * Math.PI);
    ctx.stroke();
}

function getViewPoint(target) {
    return { x: target.x * dd.scale + dd.pan.x, y: target.y * dd.scale + dd.pan.y};
}

function initializeViewPortData() {
    var mapSize = { x: 600, y: 800 };
    dd = {
        pan: { x: mapSize.x / 2, y: mapSize.y /2 },
        scale: 1,
        villageColor: '#000000',
        arcColor: '#FF0000',
        villageRadius: 5,
        map: { x: mapSize.x, y: mapSize.y }
           };
}

function clearMap() {
    var c = document.getElementById("mapCanvas");
    var ctx = c.getContext("2d");
    ctx.fillStyle = "#FFFFFF";
    ctx.fillRect(0, 0, dd.map.x, dd.map.y);
}

function pan(x, y) {
    clearMap();
    dd.pan.x += x * dd.scale;
    dd.pan.y += y * dd.scale;
    drawVillages();
}

function scale(x) {
    clearMap();
    dd.scale *= x;
    drawVillages();
}

function addUIHooks() {
    $('#panright').click(function () { pan(5, 0); return false; });
    $('#panleft').click(function () { pan(-5, 0); return false; });
    $('#panup').click(function () { pan(0, -5); return false; });
    $('#pandown').click(function () { pan(0, 5); return false; });

    $('#scaleup').click(function () { scale(1.1); return false; });
    $('#scaledown').click(function () { scale(1 / 1.1); return false; });
}