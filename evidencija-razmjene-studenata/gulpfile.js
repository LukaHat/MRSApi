const gulp = require("gulp");
const sass = require("gulp-sass")(require("sass")); // Specify 'sass' as the Sass compiler
const cleanCSS = require("gulp-clean-css");
const rename = require("gulp-rename");

// Define a task to compile Sass to CSS
gulp.task("sass", function () {
  return gulp
    .src("src/sass/**/*.sass") // Source Sass files with .sass extension
    .pipe(sass().on("error", sass.logError)) // Compile Sass to CSS
    .pipe(gulp.dest("src/dist/css")); // Output directory inside the "src" folder
});

// Define a task to minify CSS
gulp.task("minify-css", function () {
  return gulp
    .src("src/dist/css/*.css") // Source CSS files inside the "src/dist" folder
    .pipe(cleanCSS()) // Minify CSS
    .pipe(rename({ suffix: ".min" })) // Add .min suffix
    .pipe(gulp.dest("src/dist/css")); // Output directory inside the "src" folder
});

// Watch for changes in Sass files and run the tasks
gulp.task("watch", function () {
  gulp.watch("src/sass/**/*.sass", gulp.series("sass", "minify-css"));
});

// Define the default task
gulp.task("default", gulp.series("sass", "minify-css", "watch"));
