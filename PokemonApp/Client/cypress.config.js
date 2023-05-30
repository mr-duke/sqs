const { defineConfig } = require("cypress");

module.exports = defineConfig({
  testingType: 'component',
  component: {
    devServer: {
      framework: "vue",
      bundler: "vite",
    },
  },
});
