const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    entry: "./wwwroot/js/index.js",
    output: {
        filename: "main.js",
        path: path.resolve(__dirname, "wwwroot/dist/"),
        publicPath: '/wwwroot/dist/'
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
            },
            {
              test: /\.css$/,
              use: [
                  'vue-style-loader',
                  'css-loader'
              ]
            },
        ],
    },
    plugins: [
        new VueLoaderPlugin()
    ]
}
