const { series, parallel } = require('gulp');

// The `clean` function is not exported so it can be considered a private task.
// It can still be used within the `series()` composition.
function clean(cb: () => void) {
    // body goes here
    console.log('clean');
    cb();
}

// The `build` function is exported so it is public and can be run with the `gulp` command.
// It can also be used within the `series()` composition.
function build(cb: () => void) {
    // body goes here
    console.log('build');
    cb();
}

function transpile(cb: () => void) {
    // body goes here
    console.log('transpile');
    cb();
}

function bundle(cb: () => void) {
    // body goes here
    console.log('bundle');
    cb();
}

function javascript(cb: () => void) {
    // body goes here
    console.log('javascript');
    cb();
}

function css(cb: () => void) {
    // body goes here
    console.log('css');
    cb();
}

function minify(cb: () => void) {
    // body goes here
    console.log('minify');
    cb();
}

function livereload(cb: () => void) {
    // body goes here
    console.log('livereload');
    cb();
}

function cssTranspile(cb: () => void) {
    // body goes here
    console.log('cssTranspile');
    cb();
}

function cssMinify(cb: () => void) {
    // body goes here
    console.log('cssMinify');
    cb();
}

function jsTranspile(cb: () => void) {
    // body goes here
    console.log('jsTranspile');
    cb();
}

function jsBundle(cb: () => void) {
    // body goes here
    console.log('jsBundle');
    cb();
}

function jsMinify(cb: () => void) {
    // body goes here
    console.log('jsMinify');
    cb();
}

function publish(cb: () => void) {
    // body goes here
    console.log('publish');
    cb();
}


exports.build = build;
exports.series = series(transpile, bundle);
exports.parallel = parallel(javascript, css);
if (process.env.NODE_ENV === 'production') {
    exports.conditional = series(transpile, minify);
} else {
    exports.conditional = series(transpile, livereload);
}
exports.buildAndPublish = series(
    clean, 
    parallel(
        cssTranspile, 
        series(jsTranspile, jsBundle)
    ),
    parallel(cssMinify, jsMinify),
    publish
);

exports.default = series(clean, build);