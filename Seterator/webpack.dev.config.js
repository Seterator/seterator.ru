const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    mode: 'development',
    devtool: 'eval-source-map',
    entry: {
        Layout: './wwwroot/js/Pages/Layout/Layout.js',
        Home: './wwwroot/js/Pages/Home/Index.js',
        HomePrivacy: './wwwroot/js/Pages/Home/Privacy.js',
        Account: './wwwroot/js/Pages/Account/Index.js',
        CompetitionCreate: './wwwroot/js/Pages/Competition/Create.js',
        CompetitionDetails: './wwwroot/js/Pages/Competition/Details.js',
        CompetitionUpdate: './wwwroot/js/Pages/Competition/Update.js',
        JuryAssessment: './wwwroot/js/Pages/Jury/Assessment.js',
        ParticipantBecome: './wwwroot/js/Pages/Participant/Become.js',
        PoemDetails: './wwwroot/js/Pages/Poem/Details.js',
        Profile: './wwwroot/js/Pages/Profile/Index.js'
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot/dist/')
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
