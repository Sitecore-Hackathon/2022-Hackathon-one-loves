const path = require("path");
const miniCss = require("mini-css-extract-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");

module.exports = {
  mode: "development",
  entry: "./dist/index.js",
  output: {
    path: path.resolve(__dirname, "dist"),
    assetModuleFilename: "assets/images/[name][ext]",
  },
  module: {
    rules: [
      {
        test: /\.(s*)css$/,
        use: [miniCss.loader, "css-loader", "sass-loader"],
      },
      {
        test: /\.(png|jpg|svg|jpeg|gif)$/i,
        type: "asset/resource",
      },
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/i,
        type: "asset/resource",
        generator: {
          filename: "assets/fonts/[name].[ext]",
        },
      },
      {
        test: /\.(json)$/i,
        type: "asset/resource",
      },
    ],
  },
  plugins: [
    new miniCss({
      filename: "styles/style.css",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/blog-start.html",
      template: "./src/pages/blog-start.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/blog-detailed.html",
      template: "./src/pages/blog-detailed.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/blog-keyword.html",
      template: "./src/pages/blog-keyword.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/index.html",
      template: "./src/pages/index.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/home-page.html",
      template: "./src/pages/home-page.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/error-page.html",
      template: "./src/pages/error-page.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/reference-overview.html",
      template: "./src/pages/reference-overview.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/company.html",
      template: "./src/pages/company.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/team-overview.html",
      template: "./src/pages/team-overview.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/team-detail.html",
      template: "./src/pages/team-detail.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/jobs-overview.html",
      template: "./src/pages/jobs-overview.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/all-jobs.html",
      template: "./src/pages/all-jobs.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/job-detail.html",
      template: "./src/pages/job-detail.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/animation.html",
      template: "./src/pages/animation.html",
    }),
    new HtmlWebpackPlugin({
      filename: "./pages/business-segments-detail.html",
      template: "./src/pages/business-segments-detail.html",
    }),
  ],
};
