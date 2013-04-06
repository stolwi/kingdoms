
// given 3 known points, and distances from those points to a fourth point,
// solve for the x,y of the fourth point.
function trilaterate(p1, p2, p3, r1, r2, r3) {

    var y = solveY(p1, p2, p3, r1, r2, r3);
    var x = solveX(p1, p2, p3, r1, r2, r3, y);

    return { x: x, y: y };
}

function solveY(p1, p2, p3, r1, r2, r3) {
    var a1 = p1.x;
    var a2 = p2.x;
    var a3 = p3.x;
    var b1 = p1.y;
    var b2 = p2.y;
    var b3 = p3.y;

    var numerator = (a2 - a1) * (a3 * a3 + b3 * b3 - r3 * r3) +
                    (a1 - a3) * (a2 * a2 + b2 * b2 - r2 * r2) +
                    (a3 - a2) * (a1 * a1 + b1 * b1 - r1 * r1);
    var denom = 2 * (b3 * (a2 - a1) + b2 * (a1 - a3) + b1 * (a3 - a2));
    return numerator / denom;
}


function solveX(p1, p2, p3, r1, r2, r3, y) {
    var a1 = p1.x;
    var a2 = p2.x;
    var a3 = p3.x;
    var b1 = p1.y;
    var b2 = p2.y;
    var b3 = p3.y;

    var numerator = r2 * r2 + a1 * a1 + b1 * b1 - r1 * r1 - a2 * a2 - b2 * b2 - 2 * (b1 - b2) * y;
    var denom = 2 * (a1 - a2);
    return numerator / denom;
}
