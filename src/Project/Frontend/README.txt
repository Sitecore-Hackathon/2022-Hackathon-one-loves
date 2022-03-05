We should change files only in src directive.

************************
To build the page use 
- npm run build
To watch the project
- npm run start

*************************
To build new page to build modify webpack.config, add
   new HtmlWebpackPlugin({
      filename: "./pages/[PAGE_NAME].html",
      template: "./src/pages/[PAGE_NAME].html",
      minify: true,  
    }),
A new page will be placed in dist/pages directory.