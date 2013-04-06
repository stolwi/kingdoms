
// Given 2 known points and distances between those two points and each other (x) and
// between those two points and a third point, provide the distance from the third point to the line
// between the first two points.
function bilaterate(v1, v2, x, u, t) {

    var b = (x * x + t * t - u * u) / (2 * x);
    var y = Math.sqrt(t * t - b * b);

    return { x: b, y: y };
}

