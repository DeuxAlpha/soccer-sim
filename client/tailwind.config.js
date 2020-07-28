module.exports = {
  purge: {
    content: [
      './src/**/*.vue',
      './src/**/*.ts'
    ],
    defaultExtractor: content => content.match(/[\w-/.:]+(?<!:)/g) || []
  },
  theme: {
    extend: {},
  },
  variants: {
    textColor: ['hover', 'focus', 'active']
  },
  plugins: [],
}
